/*---------------------------------------------------------------------------*/
/* Copyright(C)  2020  OMRON Corporation                                     */
/*                                                                           */
/* Licensed under the Apache License, Version 2.0 (the "License");           */
/* you may not use this file except in compliance with the License.          */
/* You may obtain a copy of the License at                                   */
/*                                                                           */
/*     http://www.apache.org/licenses/LICENSE-2.0                            */
/*                                                                           */
/* Unless required by applicable law or agreed to in writing, software       */
/* distributed under the License is distributed on an "AS IS" BASIS,         */
/* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  */
/* See the License for the specific language governing permissions and       */
/* limitations under the License.                                            */
/*---------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOFSensorSampleGetTemperature
{
    /// <summary>
    /// Form main class
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Serial communication class
        /// </summary>
        private TOFSerialPort _serialPort = new TOFSerialPort();
        /// <summary>
        /// Command definition list
        /// </summary>
        private List<TOFCommand> _listCommand = new List<TOFCommand>();
        /// <summary>
        /// Sent commandID index
        /// </summary>
        private EnumSenario _indexSendCommandID = EnumSenario.StartMeasurement;
        /// <summary>
        /// Senario enumeration type
        /// </summary>
        private enum EnumSenario
        {
            StartMeasurement = 0,
            GetImagerTemperature,
            GetLEDTemperature,
            StopMeasurement
        }
        /// <summary>
        /// Processing steps
        /// </summary>
        private EnumProcess _enumProcess = 0;
        /// <summary>
        /// Processing steps enumeration type
        /// </summary>
        private enum EnumProcess
        {
            Running,    
            Stopping,
            Stopped
        }
        /// <summary>
        /// Imager abnormal temperature flag
        /// </summary>
        private bool _isAbnormalTemperatureImager = false;
        /// <summary>
        /// LED abnormal temperature flag
        /// </summary>
        private bool _isAbnormalTemperatureLED = false;

        /// <summary>
        /// constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load event.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.lblStatusMessage.Text = string.Empty;
            this.ChangeEnabledButton(true);
            this.btnRefresh.PerformClick();
        }

        /// <summary>
        /// Click the refresh button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Refresh the list of COM ports.
        /// </remarks>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cmbCOMList.Text = "";
            this.cmbCOMList.Items.Clear();
            foreach (string comPort in TOFSerialPort.GetPortNames())
            {
                if (!this.cmbCOMList.Items.Contains(comPort))
                {
                    this.cmbCOMList.Items.Add(comPort);
                }
            }
            this.cmbCOMList.SelectedIndex = this.cmbCOMList.Items.Count - 1;
        }

        /// <summary>
        /// Click the connect button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Serial Port Connect.
        /// </remarks>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // No input check
            if (this.cmbCOMList.Text.Equals(string.Empty))
            {
                MessageBox.Show("Specify a port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Serial communication connection
            string message = this._serialPort.Connect(this.cmbCOMList.Text);
            if (message.Equals(string.Empty))
            {
                this.ChangeEnabledButton(false);
            }
            else
            {
                MessageBox.Show(message, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click the Disconnect button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Serial Port Disconnect.
        /// </remarks>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Serial communication disconnection
            this._serialPort.Disconnect();
            this.ChangeEnabledButton(true);
        }

        /// <summary>
        /// Change button Enabled.
        /// </summary>
        /// <param name="enabled">Enabled property value to set</param>
        /// <remarks>
        /// Set the Enable property of the buttons on the form.
        /// </remarks>
        private void ChangeEnabledButton(bool enabled)
        {
            this.cmbCOMList.Enabled = enabled;
            this.btnRefresh.Enabled = enabled;
            this.btnConnect.Enabled = enabled;
            this.btnDisconnect.Enabled = !enabled;
            this.btnStart.Enabled = !enabled;
            this.btnStop.Enabled = false;
        }

        /// <summary>
        /// Click the Start button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Start scenario.
        /// </remarks>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start scenario
            this._enumProcess = EnumProcess.Running;
            // Button control
            this.btnDisconnect.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            // Scenario creation
            this.SetScenario();
            // Send command
            this._indexSendCommandID = EnumSenario.StartMeasurement;
            TOFCommand command = this._listCommand[(int)this._indexSendCommandID];
            this.AsyncSerialPort(command);
        }

        /// <summary>
        /// Click the Stop button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Scenario stop.
        /// </remarks>
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Scenario stop
            this._enumProcess = EnumProcess.Stopping;
        }

        /// <summary>
        /// Send and receive serial communication asynchronously.
        /// </summary>
        /// <param name="command">Command class object</param>
        /// <remarks>
        /// [Note]
        /// If you let the UI thread process while receiving data, data is likely to be missed.
        /// Data is sent and received in order using the command response method.
        ///    1.Send command from form 
        /// -> 2.Send and receive command in thread 
        /// -> 3.Write received data on form
        /// </remarks>
        async private void AsyncSerialPort(TOFCommand command)
        {
            // Initialize
            this._serialPort.ReceivedDataLength = 0;

            // Write send command information to log area.
            this.txtLog.AppendText(string.Format("{0}  {1}  {2}  {3}\r\n"
                , DateTime.Now.ToString("HH:mm:ss.fff")
                , command.SendDataLength.ToString("D7")
                , "Send   "
                , BitConverter.ToString(command.SendData)));
            this.txtLog.ScrollToCaret();
            this.lblStatusMessage.Text = command.CommandName;
            this.lblStatusMessage.Refresh();

            // Send send command to serial port asynchronously.
            await Task.Run(() => this._serialPort.SendReceive(command));

            // When called back, write the received data.
            this.CallbackSerialPort();
        }

        /// <summary>
        /// Scenario settings
        /// </summary>
        private void SetScenario()
        {
            // Start measurement
            TOFCommand startCommand = new TOFCommand(0x80, new byte[4] { 0xFE, 0x80, 0x00, 0x00 }, 4, 6, 500, 2000, "Start measurement");
            this._listCommand.Add(startCommand);
            // Get imager temperature
            TOFCommand imagerCommand = new TOFCommand(0x9B, new byte[4] { 0xFE, 0x9B, 0x00, 0x00 }, 4, 14, 500, 1000, "Get imager temperature");
            this._listCommand.Add(imagerCommand);
            // Get LED temperature
            TOFCommand ledCommand = new TOFCommand(0x9C, new byte[4] { 0xFE, 0x9C, 0x00, 0x00 }, 4, 8, 500, 1000, "Get LED temperature");
            this._listCommand.Add(ledCommand);
            // Stop measurement
            TOFCommand stopCommand = new TOFCommand(0x81, new byte[4] { 0xFE, 0x81, 0x00, 0x00 }, 4, 6, 500, 5000, "Stop measurement");
            this._listCommand.Add(stopCommand);
        }

        /// <summary>
        /// Callback processing after receiving data.
        /// </summary>
        /// <remarks>
        /// </remarks>
        async private void CallbackSerialPort()
        {
            byte[] data = this._serialPort.ReceiveDataBuffer;
            int length = this._serialPort.ReceivedDataLength;
            bool isError = this._serialPort.IsError;
            byte responseCode = 0x00;

            try
            {
                TOFCommand command = this._listCommand[(int)this._indexSendCommandID];
                if (6 <= length && data[0] == 0xFE)
                {
                    responseCode = data[1];
                    // When the synchronization code is 0xFE and the received data length is 6 or more.
                    int dataLength = (data[2] << 24) + (data[3] << 16) + (data[4] << 8) + data[5];
                    if (length == dataLength + 6)
                    {
                        // When all data can be received,
                        // Write received data information to log area.
                        this.txtLog.AppendText(string.Format("{0}  {1}  {2}  {3}\r\n"
                            , DateTime.Now.ToString("HH:mm:ss.fff")
                            , length.ToString("D7")
                            , "Receive"
                            , BitConverter.ToString(data, 0, 20 <= length ? 20 : length)));
                        this.txtLog.ScrollToCaret();

                        // Command processing
                        switch (command.CommandID)
                        {
                            case 0x80:
                                // Start measurement command
                                // To get imager temperature
                                this._indexSendCommandID = EnumSenario.GetImagerTemperature;
                                break;
                            case 0x9B:
                                // Get imager temperature
                                // Get upper left temperature
                                double curImagerUL = ((data[6] << 8) + data[7]) / 10d;
                                this.txtCurrentImagerUL.Text = string.Format("{0:F1}", curImagerUL);
                                // Get upper right temperature
                                double curImagerUR = ((data[8] << 8) + data[9]) / 10d;
                                this.txtCurrentImagerUR.Text = string.Format("{0:F1}", curImagerUR);
                                // Get lower left temperature
                                double curImagerLL = ((data[10] << 8) + data[11]) / 10d;
                                this.txtCurrentImagerLL.Text = string.Format("{0:F1}", curImagerLL);
                                // Get lower right temperature
                                double curImagerLR = ((data[12] << 8) + data[13]) / 10d;
                                this.txtCurrentImagerLR.Text = string.Format("{0:F1}", curImagerLR);
                                // Get imager start temperature
                                double startImager = (double)this.nudStartImager.Value;
                                // Get imager stop temperature
                                double stopImager = (double)this.nudStopImager.Value;
                                if (stopImager < curImagerUL || stopImager < curImagerUR || stopImager < curImagerLL || stopImager < curImagerLR)
                                {
                                    // When Current temperature is larger than Stop temperature
                                    // To stop measurement
                                    this._indexSendCommandID = EnumSenario.StopMeasurement;
                                    // Detect Abnormal
                                    this._isAbnormalTemperatureImager = true;
                                }
                                else
                                {
                                    if (this._isAbnormalTemperatureImager 
                                        && (startImager < curImagerUL || startImager < curImagerUR || startImager < curImagerLL || startImager < curImagerLR))
                                    {
                                        // When Current temperature is larger than Start temperature
                                        // To stop measurement
                                        this._indexSendCommandID = EnumSenario.StopMeasurement;
                                        // Detect Abnormal
                                        this._isAbnormalTemperatureImager = true;
                                    }
                                    else
                                    {
                                        // When Current temperature is less than Start temperature
                                        // To get LED temperature
                                        this._indexSendCommandID = EnumSenario.GetLEDTemperature;
                                        // Release Abnormal
                                        this._isAbnormalTemperatureImager = false;
                                    }
                                }
                                break;
                            case 0x9C:
                                // Get LED temperature
                                double curLED = ((data[6] << 8) + data[7]) / 10d;
                                this.txtCurrentLED.Text = string.Format("{0:F1}", curLED);
                                // Get LED start temperature
                                double startLED = (double)this.nudStartLED.Value;
                                // Get LED stop temperature
                                double stopLED = (double)this.nudStopLED.Value;
                                if (stopLED < curLED)
                                {
                                    // When Current temperature is larger than Stop temperature
                                    // To stop measurement
                                    this._indexSendCommandID = EnumSenario.StopMeasurement;
                                    // Detect Abnormal
                                    this._isAbnormalTemperatureLED = true;
                                }
                                else
                                {
                                    if (this._isAbnormalTemperatureLED && startLED < curLED)
                                    {
                                        // When Current temperature is larger than Start temperature
                                        // To stop measurement
                                        this._indexSendCommandID = EnumSenario.StopMeasurement;
                                        // Detect Abnormal
                                        this._isAbnormalTemperatureLED = true;
                                    }
                                    else
                                    {
                                        // When Current temperature is less than Start temperature
                                        // To get imager temperature
                                        this._indexSendCommandID = EnumSenario.GetImagerTemperature;
                                        // Release Abnormal
                                        this._isAbnormalTemperatureLED = false;
                                    }
                                }
                                break;
                            case 0x81:
                                // Stop measurement command
                                // Set time interval
                                command.WaitTime = (int)this.nudInterval.Value * 1000;
                                // To start measurement
                                this._indexSendCommandID = EnumSenario.StartMeasurement;
                                break;
                            default:
                                break;
                        }

                    }
                    else
                    {
                        // When some data could not be received,
                        // Write received data information to log area.
                        this.txtLog.AppendText(string.Format("Failed to receive data. The received data length is {0} bytes.\r\n"
                            , length));
                        this.txtLog.ScrollToCaret();
                    }
                }
                else
                {
                    responseCode = 0x99;
                    if (isError)
                    {
                        // When some data could not be received,
                        // Write received data information to log area.
                        this.txtLog.AppendText(string.Format("Failed to send data.\r\n"));
                    }
                    else
                    {
                        // When some data could not be received,
                        // Write received data information to log area.
                        this.txtLog.AppendText(string.Format("Failed to receive data.\r\n"));
                    }
                    this.txtLog.ScrollToCaret();
                }

                // Processing steps
                if (this._enumProcess == EnumProcess.Stopping)
                {
                    // To stop measurement
                    this._indexSendCommandID = EnumSenario.StopMeasurement;
                    this._enumProcess = EnumProcess.Stopped;
                }
                else if (this._enumProcess == EnumProcess.Stopped)
                {
                    // End of scenario.
                    MessageBox.Show("End of scenario.", "End", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ChangeEnabledButton(false);
                    return;
                }

                // Wait processing
                await Task.Run(() => this.Wait(command.WaitTime));

                // Send command
                command = this._listCommand[(int)this._indexSendCommandID];
                this.AsyncSerialPort(command);
            }
            catch (ObjectDisposedException)
            {
                // Do nothing until the object is destroyed.
            }
        }

        /// <summary>
        /// Wait processing
        /// </summary>
        /// <param name="waitTime">Waiting time</param>
        private void Wait(int waitTime)
        {
            Thread.Sleep(waitTime);
        }

        /// <summary>
        /// Event when form is closed.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Serial Port Disconnect.
            this._serialPort.Disconnect();
        }
    }
}
