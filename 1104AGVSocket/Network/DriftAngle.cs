using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network
{
    
    class DriftAngle
    {
        private ushort angle;
        public ushort Angle { get; set; }

        public DriftAngle(ushort angle)
        {
            this.Angle = angle;
        }
    }
}
