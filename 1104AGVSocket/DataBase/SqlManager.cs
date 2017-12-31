using AGVSocket.NLog;
using DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AGVSocket.DataBase
{
    class SqlManager
    {
        private static SqlConnection sqlConn;
        private const int MAX_TRY_CONN_COUNT = 100;
        private int connCount = 1;
        private static SqlManager instance;
        public static SqlManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlManager();
                }
                return instance;
            }
        }
        private SqlManager() {
            Task.Factory.StartNew(() => TryConnect2DataBase());//启动线程            
        }
        void TryConnect2DataBase()
        {
            while (sqlConn == null&&connCount<MAX_TRY_CONN_COUNT)
            {
                sqlConn = SqlHelper.GetSqlConnection();
                Thread.Sleep(connCount*100);
                connCount++;
            }
            if (connCount >= MAX_TRY_CONN_COUNT)
            {
                Logs.Warn("未能连上数据库");
            }
        }
        public void GetElecMapInfo()
        {
            if (sqlConn!=null&&sqlConn.State == ConnectionState.Open)
            {
                DataTable data = SqlHelper.GetDataTable(sqlConn, "select * from ElecMap");
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine("数据库未连接");
            }
        }

    }
}
