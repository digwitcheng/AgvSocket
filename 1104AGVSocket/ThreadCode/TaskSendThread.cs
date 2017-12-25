using AGV_V1._0.Queue;
using AGVSocket.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGV_V1._0.Network.ThreadCode
{
    class TaskSendThread:BaseThread
    {
         private static TaskSendThread instance;
        public static TaskSendThread Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskSendThread();
                }
                return instance;
            }
        }
        private TaskSendThread()
        {            
        }
        protected override string ThreadName()
        {
            return "TaskSend";
        }
        protected override void Run()
        {
            try
            {                
                
                Thread.Sleep(ConstDefine.TASK_TIME);
            }
            catch { }
        }
    }
}
