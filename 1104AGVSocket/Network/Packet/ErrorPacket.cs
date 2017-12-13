using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network.Packet
{
    class ErrorPacket:ReceiveBasePacket
    {
        public override void Receive()
        {
            throw new NotImplementedException();
        }

        public override byte NeedLen()
        {
            throw new NotImplementedException();
        }
    }
}
