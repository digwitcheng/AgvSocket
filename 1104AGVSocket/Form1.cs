﻿using AGV.Event;
using AGVSocket.Network;
using AGVSocket.Network.EnumType;
using AGVSocket.Network.Packet;
using AGVSocket.NLog;
using client20710711;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVSocket
{
    public partial class Form1 : Form
    {
        static ClientManager cm;
        AgvServerManager asm;
        List<MyPoint> route = new List<MyPoint>();
        public Form1()
        {
            InitializeComponent();
            ConnectToServer();
            ListenAgv();
            CreateRoute();

        }

       

        private void button1Click(object sender, EventArgs e)
        {
           
           
        }
        void ListenAgv()
        {
           

            asm = AgvServerManager.Instance;
            asm.ShowMessage += ShowMsg;
            //  asm.ReLoad += ReInitialSystem;
            //asm.DataMessage += TransmitToTask;
           
            asm.StartServer(Convert.ToInt32(listPort.Text));
            ShowMsg(string.Format( "监听端口{0}中......", listPort.Text));


            //Destination des=new Destination();
            //RunPacket runPacket=new RunPacket(1,1,AgvDirection.Forward,1500,)

        }
       
        void ConnectToServer()
        {
            try
            {
                cm = new ClientManager();
                cm.ShowMessage += ClientMessage;
                cm.DateMessage += HandleData;
                cm.ReLoad += LoadFile;
                cm.ConnectToServer(idAdress.Text, Convert.ToInt32(port.Text));
            }
            catch (Exception ex)
            {
                ShowMsg("连接到控制中心异常，请检查控制中心服务是否开启！");
            }
        }
        protected void ClientMessage(object sender, MessageEventArgs e)
        {
            System.Console.WriteLine(e.Message);
            ShowMsg(e.Message);
        }
        void HandleData(object sender, MessageEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
        void LoadFile()
        {

        }
        void ShowMsg(object sender, PackMessageEventArgs e)
        {
            ShowMsg(e.Message);
        }
        private void ShowMsg(string str)
        {

            if (listViewLog.InvokeRequired)
            {
                // 当一个控件的InvokeRequired属性值为真时，说明有一个创建它以外的线程想访问它
                Action actionDelegate = () => { ShowLog(str); };

                //    IAsyncResult asyncResult =actionDelegate.BeginInvoke()

                // 或者 
                // Action<string> actionDelegate = delegate(string txt) { this.label2.Text = txt; };
                this.listViewLog.Invoke(actionDelegate, null);
            }
            else
            {
                ShowLog(str);
            }
        }
        void ShowLog(string str)
        {
            if (listViewLog.Items.Count > 100)
            {
                listViewLog.Clear();
            }
            listViewLog.View = View.Details;
            listViewLog.GridLines = false;
            listViewLog.Columns.Add("信息",350, HorizontalAlignment.Left);
            listViewLog.Items.Add(new ListViewItem(str));
           // Logs.Info(str);
        }
        private void button2Click(object sender, EventArgs e)
        {

        }

        private void button3Click(object sender, EventArgs e)
        {
            if (cm == null)
            {
                ShowMsg("请先连接");
                return;
            }
            string path="../../AGV.xml";
            if (!File.Exists(path))
            {
                ShowMsg("文件不存在");
                return;
            }
             cm.Send(MessageType.AgvFile, path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {               
                //TrayPacket tp = new TrayPacket(1, 1, TrayMotion.TopLeft);
                //asm.Send(tp);
                for (int i = 0; i < route.Count; i++)
                { 
                    RunPacket rp = new RunPacket(1, 4, MoveDirection.Forward, 1500, new Destination(new MyPoint(route[i].X, route[i].Y), new MyPoint(route[route.Count - 1].X, route[route.Count - 1].Y), new DriftAngle(90), TrayMotion.TopLeft));
                    asm.Send(rp);
                    
                }
                route.Reverse();
             //   MessageBox.Show("发送成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送失败");
            }

        }
        private void CreateRoute()
        {
            route.Add(new MyPoint(0, 6000));
            route.Add(new MyPoint(0, 4500));
            route.Add(new MyPoint(0, 3000));
            route.Add(new MyPoint(0, 1500));
            route.Add(new MyPoint(0, 0));
            //route.Add(new MyPoint(1500, 4500));
            //route.Add(new MyPoint(3000, 4500));
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //SwervePacket sp = new SwervePacket(1, 1, new DriftAngle(90));
            //asm.Send(sp);



            //RunPacket rp = new RunPacket(1, 1, AgvDirection.Forward, 1500, new Destination(new MyPoint(44000, 0), new MyPoint(48000, 0), new DriftAngle(90), TrayMotion.DownLeft));
            //asm.Send(rp);

           
        }

    }
}
