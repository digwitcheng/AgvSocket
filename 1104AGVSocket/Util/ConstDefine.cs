using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVSocket.Util
{
    class ConstDefine
    {
        public const byte CHECKSUM = 0x7f;

        public const int UPDATA_SQL_TIME = 100;

        public const int minX = 5;
        public const int maxX = 7;
        public const int minY = 6;
        public const int maxY = 10;
        public const int CELL_UNIT = 1000;//格和毫格的转换单位
    }
}
