using AGV_V1._0.Network.EnumType;
using AGV_V1._0.Network.MyException;
using AGV_V1._0.Queue;
using AGV_V1._0.ThreadCode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.Network.Packet
{
    class AgvResponsePacket:ReceiveBasePacket
    {
        private byte respType; //需要应答报文类型
        private ResponseState respState;//需要应答报文状态

        #region Properties
        public byte RespType { get { return respType; } }
        public ResponseState RespState {
            get { return respState; }
            private set {
              
            } 
        
        }
        #endregion
        public AgvResponsePacket(byte[] data)
            : base("AgvResponsePacket", data)
        {
                this.respType = data[7];
                this.respState = (ResponseState)data[8];
            
        }
      

        public override void Receive()
        {
            Debug.WriteLine("小车{0}应答报文，应答类型{1},是否正确收到：{2},序列号：{3}", this.AgvId,this.respType, this.respState,this.SerialNum);
            if (this.respState == ResponseState.Correct)
            {
                Console.WriteLine("iscanSendNext=true");
                if (SendPacketQueue.Instance.IsHasData())
                {
                    SendBasePacket sp = SendPacketQueue.Instance.Dequeue();
                }
                SendPacketThread.Instance.IsCanSendNext = true;
            }
            else
            {
                if (SendPacketQueue.Instance.IsHasData())
                {
                    SendBasePacket sp = SendPacketQueue.Instance.Peek();
                    AgvServerManager.Instance.Send(sp);
                    Console.WriteLine("reSend");
                }
            }
        }

        public override byte NeedLen()
        {
            return 10;
        }
    }
}
