﻿using AGVSocket.NLog;
using client20710711;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.Network.ThreadCode
{
    abstract class BaseThread
    {
         public event EventHandler<MessageEventArgs> ShowMessage;
         private bool isRunning = false;
         private bool isStoped = false;
         bool IsRunning { get { return isRunning; } }
         bool IsStoped { get { return isStoped; } }
         
         public  void Start()
         {
             if (!isRunning)
             {
                 Task.Factory.StartNew(() => StartThread());//启动线程
                 isRunning = true;
             }
         }
          void StartThread()
         {
             Logs.Info(ThreadName()+"线程开始");
             HandlerMessage(ThreadName()+"线程开始");
             while (!isStoped)
             {
                 try
                 {
                     Run();
                 }
                 catch (Exception ex)
                 {
                     Logs.Error(ThreadName() + "线程执行出错:" + ex);
                     HandlerMessage(ThreadName() + "线程执行出错:" + ex);
                 }
             }
             isRunning = false;
             isStoped = true;
             Logs.Info(ThreadName()+"线程结束");
             HandlerMessage(ThreadName()+"线程结束");
         }
         protected abstract void Run();

         string unnamed =""+DateTime.Now.Millisecond;
         protected virtual String ThreadName()
         {
             return unnamed;
         }
         public  void End()
         {
             isStoped = true;
         }
         protected void HandlerMessage(string str)
         {
             HandlerMessage(this, new MessageEventArgs(str));
         }
         protected void HandlerMessage(object sender, MessageEventArgs e)
         {
             if (null != ShowMessage)
             {
                 try
                 {
                     this.ShowMessage.Invoke(this, e);
                 }
                 catch
                 {
                 }
             }
         }
    }
}
