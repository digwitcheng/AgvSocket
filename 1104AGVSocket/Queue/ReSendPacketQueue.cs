using AGV_V1._0;
using AGVSocket.Network.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Queue
{
    class ReSendPacketQueue:BaseQueue<SendBasePacket>
    {
        private static ReSendPacketQueue instance;
        public static ReSendPacketQueue Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReSendPacketQueue();
                }
                return instance;
            }
        }
        private ReSendPacketQueue() { }
    }
}
