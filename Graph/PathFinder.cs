using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graph
{
    class PathFinder : IPathFinder
    {  
        public PathFinder()
        {
            
        }

        public List<IStation> FindPath(IStation stationFrom, IStation stationTo, IStation pastStation)
        {
            List<IStation> path = new List<IStation>();
            List<IStation> searchHistory = new List<IStation>();
            IStation stationFrom_, pastStation_;
            stationFrom_ = stationFrom;

            path.Add(stationFrom_);

            while(true)
            {
                if(IsStationIsNeighboor(stationFrom_, stationTo) != null)
                {
                    path.Add(stationTo);
                    return path;
                }

                if (!IsHistoryContains(searchHistory, stationFrom_))
                {
                    searchHistory.Add(stationFrom_);
                }

                for (int i = 0; i < stationFrom_.GetConnectedStations().Count; i++)
                {
                    if (!IsHistoryContains(searchHistory, stationFrom_.GetConnectedStations()[i]))
                    {
                        stationFrom_ = stationFrom_.GetConnectedStations()[i];
                        path.Add(stationFrom_);
                        break;
                    }
                }

                if(stationFrom_.IsEndStation() && searchHistory.Contains(stationFrom_.GetConnectedStations()[0]))
                {
                    path.Clear();
                    stationFrom_ = stationFrom;
                    path.Add(stationFrom_);
                }
            }
        }

        private IStation IsStationIsNeighboor(IStation currentStation, IStation needStation)
        {
            foreach (IStation station in currentStation.GetConnectedStations())
            {
                if (station.GetStationName() == needStation.GetStationName())
                {
                    return station;
                }
            }
            return null;
        }

        private bool IsHistoryContains(List<IStation> stations, IStation station)
        {
            foreach(IStation stat in stations)
            {
                if(stat.GetStationID() == station.GetStationID())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
