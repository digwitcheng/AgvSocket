using AGV_V1._0.NLog;
using Cowboy.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGV;
using AGV.Event;

namespace AGV_V1._0.Network
{
     abstract class ServerManager : IDisposable
    {

        protected const int SUCCESS = 6;
        protected const int FAIRED = -1;

        public event EventHandler<PackMessageEventArgs> ErrorMessage;
        public event EventHandler<PackMessageEventArgs> ShowMessage;
        public event EventHandler<PackMessageEventArgs> DataMessage;
        //public event EventHandler ReLoad;
        public delegate void ReLoadDele();
        public ReLoadDele ReLoad;
        protected TcpSocketServer _server;

        /// <summary>
        /// 监听本地ip
        /// </summary>
        /// <param name="port">监听的端口号</param>
        public void StartServer(int port)
        {
           
            _server = new TcpSocketServer(port);
            _server.ClientConnected += server_ClientConnected;
            _server.ClientDisconnected += server_ClientDisconnected;
            _server.ClientDataReceived += server_ClientDataReceived;
            _server.Listen();

        }
       protected abstract void server_ClientConnected(object sender, TcpClientConnectedEventArgs e);
       protected abstract void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e);
       protected abstract void server_ClientDataReceived(object sender, TcpClientDataReceivedEventArgs e);

        //protected int SendTo(string sessionKey, PacketType type, string json, bool isBroadcase)
        //{
        //    //try
        //    //{
        //    //    BaseMessage bm = BaseMessage.Factory(type, json);
        //    //    bm.Send(sessionKey, _server);
        //    //    return SUCCESS;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    OnMessageEvent("发送失败");
        //    //    Logs.Error("发送失败");
        //    //    return FAIRED;
        //    //}


        //}

        protected void ReLoadDel()
        {
            ReLoad();
        }
        void OnMessageEvent(string str)
        {
            OnMessageEvent(this, new PackMessageEventArgs(str));
        }
        protected void OnErrorEvent(object sender, PackMessageEventArgs e)
        {
            try
            {
                if (null != ErrorMessage)
                {
                    ErrorMessage.Invoke(sender, e);
                }
            }
            catch
            {

            }
        }
        protected void OnMessageEvent(object sender, PackMessageEventArgs e)
        {
            try
            {
                if (null != ShowMessage)
                {
                    ShowMessage.Invoke(sender, e);
                }
            }
            catch
            {

            }
        }
        protected void OnDataMessageEvent(object sender, PackMessageEventArgs e)
        {
            try
            {
                if (null != DataMessage)
                {
                    DataMessage.Invoke(sender, e);
                }
            }
            catch
            {

            }
        }
        public void Dispose()
        {
            if (_server != null)
            {
                _server.ClientConnected -= server_ClientConnected;
                _server.ClientDisconnected -= server_ClientDisconnected;
                _server.ClientDataReceived -= server_ClientDataReceived;
                _server.Shutdown();

            }
        }

    }
}
