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
namespace TOFSensorSampleGetTemperature
{
    /// <summary>
    /// Data class for sending and receiving commands
    /// </summary>
    public class TOFCommand
    {
        /// <summary>
        /// Command No.
        /// </summary>
        public byte CommandID { get; set; }
        /// <summary>
        /// Data of send command
        /// </summary>
        public byte[] SendData { get; set; }
        /// <summary>
        /// Length of send command data
        /// </summary>
        public int SendDataLength { get; set; }
        /// <summary>
        /// Length of receive command data
        /// </summary>
        public int ReceiveDataLength { get; set; }
        /// <summary>
        /// First reception timeout
        /// </summary>
        public int InitialReceiveTimeout { get; set; }
        /// <summary>
        /// Wait time after execution
        /// </summary>
        public int WaitTime { get; set; }
        /// <summary>
        /// Command name
        /// </summary>
        public string CommandName { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="commandID">Command No.</param>
        /// <param name="sendData">Data of send command</param>
        /// <param name="sendDataLength">Length of send command data</param>
        /// <param name="receiveDataLength">Length of receive command data</param>
        /// <param name="initialReceiveTimeout">First reception timeout</param>
        /// <param name="waitTime">Wait time after execution</param>
        /// <param name="commandName">Command name</param>        
        public TOFCommand(byte commandID, byte[] sendData, int sendDataLength, int receiveDataLength, int initialReceiveTimeout, int waitTime, string commandName)
        {
            this.CommandID = commandID;
            this.SendData = sendData;
            this.SendDataLength = sendDataLength;
            this.ReceiveDataLength = receiveDataLength;
            this.InitialReceiveTimeout = initialReceiveTimeout;
            this.WaitTime = waitTime;
            this.CommandName = commandName;
        }
    }
}
