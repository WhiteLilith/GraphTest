using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    /// <summary>
    /// Класс для содержания станций и соответствующие им уровни
    /// </summary>
    class StationsContainer : ITempStationsContainer
    {
        private List<IStation> stations;
        private List<int> levels;

        public StationsContainer()
        {
            stations = new List<IStation>();
            levels = new List<int>();
        }

        public void AddToContainer(IStation station, int level)
        {
            stations.Add(station);
            levels.Add(level);
        }

        public int GetLevelOfStation(IStation station)
        {
            for(int i = stations.Count - 1; i >= 0; i--)
            {
                if(stations[i].GetStationID() == station.GetStationID())
                {
                    return levels[i];
                }
            }
            return -1;
        }

        public List<IStation> GetStationsFromLevel(int level)
        {
            List<IStation> stationsOnLevel = new List<IStation>();
            for(int i = levels.Count - 1; i >= 0; i--)
            {
                if(levels[i] == level)
                {
                    stationsOnLevel.Add(stations[i]);
                }
            }

            return stationsOnLevel;
        }
    }
}
