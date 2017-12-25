using AGVSocket.Network.EnumType;
using AGVSocket.Network.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network.Packet
{
    class DoneReplyPacket:ReceiveBasePacket
    {
        private OprationState doneStyle;  //操作完成标识
        public OprationState DoneStyle { get; set; }
        //private const byte NEEDLEN = 9;
        public DoneReplyPacket(byte[] data)
            : base("DoneReplyPacket", data) 
        {
            this.doneStyle = (OprationState)data[7];
           
        }


        public override void Receive()
        {
            
        }

        public override byte NeedLen()
        {
            return 9;
        }
    }
}
