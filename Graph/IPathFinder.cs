using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IPathFinder
    {
        List<IStation> FindPath(IStation stationFrom, IStation stationTo, IStation pastStation);
    }
}
