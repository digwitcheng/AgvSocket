using AGVSocket.Network.EnumType;
using AGVSocket.Network.MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network.Packet
{
    class AgvInfoPacket:ReceiveBasePacket
    {
        private AgvInfo info;//小车详情
        //private const byte NEEDLEN = 24;
        public AgvInfo Info { get; set; }
        
        public AgvInfoPacket(byte[] data)
            : base("AgvInfoPacket", data)
        {
            this.info=new AgvInfo(data,7);
            this.CheckSum = data[NeedLen() - 1];
           
        }

        public override void Receive()
        {
           
        }

        public override byte NeedLen()
        {
            return 35;
        }
    }
}
