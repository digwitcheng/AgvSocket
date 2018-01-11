using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.Util
{
    class ConstDefine
    {
       

        public const byte CHECKSUM = 0x7f;

        public const int minX = 5;
        public const int maxX = 7;
        public const int minY = 6;
        public const int maxY = 10;
        public const int CELL_UNIT = 1000;//格和毫格的转换单位

        public const int REMOTE_PORT = 8081;//远程过程调用端口
        public const string REMOTE_NAME = "RouteSearch";//远程过程调用名称

        public const int VEHICLE_SUM = 10;


        public const float DEVIATION = 0.02f;//坐标相差在DEVIATION以内就看作在一个点
        public const int UPDATA_SQL_TIME = 50;



        public static int g_WidthNum = 100;        //地图格子的个数，默认150*150
        public static int g_HeightNum = 100;       //
        public static int g_NodeLength = 12;       //默认边长
        public static int g_VehicleCount = 10;     //小车数量
        public const int FORWORD_STEP = 2; //锁定多少格(包括自己所在的位置)


        public const string IP_ADRESS = "127.0.0.1";
        public const string GUI_PORT_ADRESS = "5555";
        public const string TASK_PORT_ADRESS = "5556";
        public const string AGV_PORT_ADRESS = "12321";
        public const string AGV_PATH = "..\\..\\Agv\\AGV.xml";
        public const string MAP_PATH = "..\\..\\Map\\ElcMap.xml";
        public const string CONFIG_PATH = "..\\..\\NLog\\NLog.config";
    }
}
