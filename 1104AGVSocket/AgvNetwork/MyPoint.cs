using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.Network
{
    [Serializable]
    class MyPoint
    {
        private uint x;
        private uint y;

        public uint Y
        {
            get { return y; }
            set { y = value; }
        }

        public uint X
        {
            get { return x; }
            set { x = value; }
        }

        public MyPoint(MyPoint poUInt32)
        {
            if (poUInt32 == null)
            {
                return;
            }
            this.x = poUInt32.x;
            this.y = poUInt32.y;

        }
        public MyPoint(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }
        public MyPoint(int x, int y)
        {
            this.x = (uint)x;
            this.y = (uint)y;
        }
    }
}
