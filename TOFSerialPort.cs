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
using System.IO.Ports;
using System.Threading;

namespace TOFSensorSampleGetTemperature
{
    /// <summary>
    /// Serial Port Control
    /// </summary>
    public class TOFSerialPort : SerialPort
    {
        /// <summary>
        /// Thread for sending and receiving.
        /// </summary>
        private Thread _threadSendReceive;
        /// <summary>
        /// Receive buffer
        /// </summary>
        public byte[] ReceiveDataBuffer { get; set; }
        /// <summary>
        /// Receive buffer length
        /// </summary>
        private int _receiveDataBufferLength = 2 * 1024 * 1024;
        /// <summary>
        /// Length of received data
        /// </summary>
        public int ReceivedDataLength { get; set; }
        /// <summary>
        /// Flag of sending and receiving
        /// </summary>
        private bool _isSendingReceiving { get; set; }
        /// <summary>
        /// Command definition
        /// </summary>
        private TOFCommand _command;
        /// <summary>
        /// Error flag
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// Serial Port Connect
        /// </summary>
        /// <param name="portName">Communication port name</param>
        /// <remarks>
        /// [Note]
        /// If a load is applied, the data may be missed in the receiving process of serial communication.
        /// Run threads at high priority.
        /// If that doesn't work,
        /// Change the setting value of "97h: Response speed setting command" of the TOF sensor.
        /// </remarks>
        public string Connect(string portName)
        {
            try
            {
                // Initialize
                this.ReceiveDataBuffer = new byte[this._receiveDataBufferLength];

                // Open serial communication.
                this.BaudRate = 115200;
                this.Parity = Parity.None;
                this.DataBits = 8;
                this.StopBits = StopBits.One;
                this.PortName = portName;
                this.ReadBufferSize = (1024 * 64);
                this.WriteBufferSize = (1024 * 4);
                this.WriteTimeout = 2000;
                this.ReadTimeout = 2000;
                this.ReceivedBytesThreshold = 1;
                this.Open();

                // Threads start at higher priority due to data loss.
                this._isSendingReceiving = false;
                this._threadSendReceive = new Thread(ThreadSendReceive);
                this._threadSendReceive.Priority = ThreadPriority.Highest;
                this._threadSendReceive.Name = "RecieveThread";
                this._threadSendReceive.IsBackground = true;
                this._threadSendReceive.Start();

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Serial Port Disconnect
        /// </summary>
        public void Disconnect()
        {
            if (this.IsOpen)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Send Command And Wait for Receive Response
        /// </summary>
        /// <param name="command">Command class object</param>
        public void SendReceive(TOFCommand command)
        {
            // Set command from parameter.
            this._command = command;
            // Set the flag to True to start sending and receiving.
            this._isSendingReceiving = true;
            // Wait until sending and receiving stops.
            while (this._isSendingReceiving)
            {
                Thread.Yield();
            }
        }

        /// <summary>
        /// Send Command And Receive Response in Other Thread 
        /// </summary>
        /// <remarks>
        /// [Note]
        /// Focus on data reception and do not perform high-load processing as much as possible.
        /// Example) new (Object creation) / String combination processing / Heavy operation
        /// </remarks>
        private void ThreadSendReceive()
        {
            DateTime dt = DateTime.Now;
            // Loop while serial port is open because thread is starting.
            while (this.IsOpen)
            {
                try
                {
                    if (this._isSendingReceiving)
                    {
                        this.IsError = false;
                        // Send command when flag is True.
                        this.Write(this._command.SendData, 0, this._command.SendDataLength);
                        // Initialize timer.
                        dt = DateTime.Now;

                        // Loop while flag is true for receive.
                        while (this._isSendingReceiving)
                        {
                            try
                            {
                                // Get the data length that can be received.
                                int size = this.BytesToRead;
                                if (size == 0)
                                {
                                    // When there is no receivable data and the received data is 6 bytes or more.
                                    if (6 <= this.ReceivedDataLength)
                                    {
                                        // When the synchronization code is 0xFE and the response code is not 0x00,
                                        if (this.ReceiveDataBuffer[0] == 0xFE && this.ReceiveDataBuffer[1] != 0x00)
                                        {
                                            // Set the flag to False to stop sending and receiving.
                                            this._isSendingReceiving = false;
                                            break;
                                        }
                                        // When all data can be received,
                                        if (this.ReceiveDataBuffer[0] == 0xFE && this.ReceivedDataLength == this._command.ReceiveDataLength)
                                        {
                                            // Set the flag to False to stop sending and receiving.
                                            this._isSendingReceiving = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // Receive data from serial port.
                                    int length = this.Read(this.ReceiveDataBuffer, this.ReceivedDataLength, this._receiveDataBufferLength - this.ReceivedDataLength);
                                    // Add the received data length.
                                    this.ReceivedDataLength = this.ReceivedDataLength + length;
                                    // If data can be received, initialize the timer.
                                    if (0 < length)
                                    {
                                        dt = DateTime.Now;
                                    }
                                }

                                TimeSpan ts = DateTime.Now.Subtract(dt);
                                if (this.ReceivedDataLength == 0)
                                {
                                    // First receive timeout.
                                    if (this._command.InitialReceiveTimeout < ts.TotalMilliseconds)
                                    {
                                        // Set the flag to False to stop sending and receiving.
                                        this._isSendingReceiving = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    // Timeout after 1000 milliseconds.
                                    if (1000 < ts.TotalMilliseconds)
                                    {
                                        // Set the flag to False to stop sending and receiving.
                                        this._isSendingReceiving = false;
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                    this.IsError = true;
                    this._isSendingReceiving = false;
                }
            }
        }
    }
}
