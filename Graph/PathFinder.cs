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

                foreach(var station in stationFrom_.GetConnectedStations())
                {
                    if (IsStationIsNeighboor(station, stationTo) != null)
                    {
                        path.Add(station);
                        path.Add(stationTo);
                        return path;
                    }
                }
                for(int i = 0; i < stationFrom_.GetConnectedStations().Count; i++)
                {
                    searchHistory.Add(stationFrom_);
                    if (stationFrom_.GetConnectedStations()[i].IsEndStation() != false && 
                        !searchHistory.Contains(stationFrom_.GetConnectedStations()[i]))
                    {
                        stationFrom_ = stationFrom_.GetConnectedStations()[i];
                    }
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
    }
}
