﻿using AGVSocket.Network.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network
{
    class CurrentLocation
    {
        private MyPoint curNode;
        private MyPoint desNode;
        private MoveDirection moveDir;
        private DriftAngle agvAngle;
        #region Properties
        public MyPoint CurNode { get { return curNode; } }
        public MyPoint DesNode { get { return desNode; } }
        public MoveDirection Speed { get { return moveDir; } }
        public DriftAngle AgvAngle { get { return agvAngle; } }
       

        #endregion

        public CurrentLocation(byte[] data,ref int offset)
        {
            UInt32 curX = MyBitConverter.ToUInt32(data,ref offset);
            UInt32 curY = MyBitConverter.ToUInt32(data,ref offset);
            this.curNode = new MyPoint(curX, curY);
            UInt32 desX = MyBitConverter.ToUInt32(data, ref offset);
            UInt32 desY = MyBitConverter.ToUInt32(data,ref offset);
            this.desNode = new MyPoint(desX, desY);
            this.moveDir = (MoveDirection)data[offset++];
            this.agvAngle =new DriftAngle( MyBitConverter.ToUInt16(data,ref offset));
        }
    }
}
