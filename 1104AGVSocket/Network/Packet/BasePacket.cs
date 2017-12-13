using AGV;
using Cowboy.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Network.Packet
{
    abstract class BasePacket
    {
        private ushort header = 0xAA55;  //报文头
        private byte len;                //报文长度(字节?)
        private byte serialNum;          //报文序号 0-255 循环指令序号 
        private byte type;               //报文类型
        private ushort agvId;            //AGV 编号
        private byte checkSum;           //校验和 前面所有内容按字节累加，再与上 0x7F

        protected ushort Header
        {
            get { return header; }
            set { header = value; }
        }
        protected byte Len
        {
            get { return len; }
            set { len = value; }
        }
        protected byte SerialNum
        {
            get { return serialNum; }
            set { serialNum = value; }
        }
        protected byte Type
        {
            get { return type; }
            set { type = value; }
        }
        protected ushort AgvId
        {
            get { return agvId; }
            set { agvId = value; }
        }
        protected byte CheckSum
        {
            get { return checkSum; }
            set { checkSum = value; }
        }

        //public abstract BasePacket Create(string msg);
        //public abstract void Send(string sessionKey, TcpSocketServer server);

        //public abstract void Receive();
        //protected abstract byte GetCheckSum();
        // protected abstract byte[] SetBytes();
        //public event EventHandler<PackMessageEventArgs> ShowMessage;
        //public event EventHandler<PackMessageEventArgs> DataMessage;
        //public event EventHandler<PackMessageEventArgs> ErrorMessage;
        //public delegate void ReLoadDele();
        //public ReLoadDele ReLoad;

    }
}
