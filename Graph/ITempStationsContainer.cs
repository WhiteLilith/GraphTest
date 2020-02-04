using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface ITempStationsContainer
    {
        void AddToContainer(IStation station, int level);

        List<IStation> GetStationsFromLevel(int level);

        int GetLevelOfStation(IStation station);
    }
}
