using AGV_V1._0.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_V1._0.Remoting
{
    class RouteRemoteObject:MarshalByRefObject
    {
        public RouteRemoteObject() { }

        public List<string> Search(List<string> scannerNode, List<string> lockNode, int v_num, int width, int height, int firstX, int firstY, int endX, int endY)
        {
            return null;
        }
    }
}
