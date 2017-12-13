using AGVSocket.Network.Packet;
using AGV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGV.Event;
using AGVSocket.NLog;
using AGVSocket.Network.MyException;
using System.Diagnostics;

namespace AGVSocket.Network
{
    class AgvServerManager:ServerManager
    {
         private static AgvServerManager instance;
        public static AgvServerManager Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new AgvServerManager();
                }
                return instance;
            }
        }
        private AgvServerManager() { }
        protected override void server_ClientConnected(object sender, Cowboy.Sockets.TcpClientConnectedEventArgs e)
        {
            string str = string.Format("TCP client {0} has connected.", e.Session.RemoteEndPoint);
            Console.WriteLine(str);
            OnMessageEvent(this, new PackMessageEventArgs(str));
        }

        protected override void server_ClientDisconnected(object sender, Cowboy.Sockets.TcpClientDisconnectedEventArgs e)
        {
            string str = string.Format("TCP client {0} has disconnected.", e.Session.RemoteEndPoint);
            Console.WriteLine(str);
            OnMessageEvent(this, new PackMessageEventArgs(str));
        }

        protected override void server_ClientDataReceived(object sender, Cowboy.Sockets.TcpClientDataReceivedEventArgs e)
        {
           //  var text= Encoding.ASCII.GetChars(e.Data, e.DataOffset, e.DataLength);
           //// var text = Encoding.UTF8.GetString(e.Data, e.DataOffset, e.DataLength);
           //// OnMessageEvent(this, new PackMessageEventArgs(text));
           // Console.WriteLine(text);


            if (e==null||e.DataLength < 8)//
            {
                Debug.WriteLine("data error!,len<8");
                Logs.Error("data error!,len<8");
                return;
            }
            PacketType type = (PacketType)e.Data[e.DataOffset + 4];
            byte[] buffers = new byte[e.DataLength];
            Buffer.BlockCopy(e.Data, e.DataOffset, buffers, 0, e.DataLength);
            // var text = Encoding.UTF8.SetBytes(e.Data, e.DataOffset, e.DataLength);


            try
            {
                ReceiveBasePacket bp = ReceiveBasePacket.Factory(type, buffers);
                //bp.ShowMessage += OnMessageEvent;
                //bp.ErrorMessage += OnErrorEvent;
                //bp.DataMessage += OnDataMessageEvent;
                //bp.ReLoad += ReLoadDel;
                bp.Receive();
                bp.ReceiveResponse();
            }
            catch (PacketException pe)
            {
                Logs.Error("接收异常：" + pe.Code);
                //Send(new SysResponsePacket(1,buffers[));
            }
            catch (Exception ex)
            {
                Logs.Error("未知错误:"+ex);
            }
             
           
        }
        public void Send(SendBasePacket pack)
        {
            try
            {
                pack.Send(_server);
            }
            catch { }
        }
        //public void Send(RunPacket rp)
        //{
        //    try
        //    {
        //        _server.Broadcast(rp.GetBytes());
        //    }
        //    catch
        //    {
               
        //    }
        //}
        //public void Send(SwervePacket swerve)
        //{
        //    _server.Broadcast(swerve.GetBytes());
        //}
        //public void Send(TrayPacket tray)
        //{
        //    _server.Broadcast(tray.GetBytes());
        //}
    }
}
