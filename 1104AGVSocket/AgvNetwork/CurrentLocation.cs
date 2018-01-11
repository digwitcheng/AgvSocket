using AGV_V1._0.Network.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.Network
{
    class CurrentLocation
    {
        private MyPoint curNode;
        private MyPoint desNode;
        private UInt16 speed;
        private MoveDirection moveDir;
        private AgvDriftAngle agvAngle;
        #region Properties
        public MyPoint CurNode { get { return curNode; } }
        public MyPoint DesNode { get { return desNode; } }
        public UInt16 Speed { get { return speed; } }
        public MoveDirection MoveDir { get { return moveDir; } }
        public AgvDriftAngle AgvAngle { get { return agvAngle; } }
       

        #endregion

        public CurrentLocation(byte[] data,ref int offset)
        {
            UInt32 curX = MyBitConverter.ToUInt32(data,ref offset);
            UInt32 curY = MyBitConverter.ToUInt32(data,ref offset);
            this.curNode = new MyPoint(curX, curY);
            UInt32 desX = MyBitConverter.ToUInt32(data, ref offset);
            UInt32 desY = MyBitConverter.ToUInt32(data,ref offset);
            this.desNode = new MyPoint(desX, desY);
            this.speed = MyBitConverter.ToUInt16(data, ref offset);
            this.moveDir = (MoveDirection)data[offset++];
            this.agvAngle =new AgvDriftAngle( MyBitConverter.ToUInt16(data,ref offset));
        }
    }
}
