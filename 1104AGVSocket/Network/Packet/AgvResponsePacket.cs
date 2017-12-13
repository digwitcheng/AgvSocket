using AGVSocket.Network.EnumType;
using AGVSocket.Network.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network.Packet
{
    class AgvResponsePacket:ReceiveBasePacket
    {
        private byte responseType; //需要应答报文类型
        private ResponseState responseState;//需要应答报文状态

        #region Properties
        public byte ResponseType { get { return responseType; } }
        public ResponseState ResponseState {
            get { return responseState; }
            private set {
              
            } 
        
        }
        #endregion
        public AgvResponsePacket(byte[] data)
            : base("AgvResponsePacket", data)
        {
            try
            {
                this.responseType = data[7];
                this.responseState = (ResponseState)data[8];
            }
            catch
            {
                IsCheckSumCorrect = ResponseState.Error;
                throw;
            }
        }
      

        public override void Receive()
        {
            
        }

        public override byte NeedLen()
        {
            return 10;
        }
    }
}
