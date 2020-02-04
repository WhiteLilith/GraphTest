using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    /// <summary>
    /// Класс станции метро
    /// </summary>
    class Station : IStation
    {
        private List<IStation> ConnectedStations;
        private string name;
        private string id;
        private bool isEnd;

        private static int global_id = 0;

        public Station(string name, bool isEnd)
        {
            this.name = name;
            this.id = global_id++.ToString();
            this.isEnd = isEnd;
            ConnectedStations = new List<IStation>(0);
        }

        public void ConnectStation(IStation station, bool isViceVersa)
        {
            ConnectedStations.Add(station);
            if(isViceVersa == true)
            {
                station.ConnectStation(this, false);
            }
        }

        public string GetStationID()
        {
            return id;
        }

        public string GetStationName()
        {
            return name;
        }

        public List<IStation> GetConnectedStations()
        {
            return ConnectedStations;
        }

        public bool IsEndStation()
        {
            return isEnd;
        }
    }
}
