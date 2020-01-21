using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Station : IStation
    {
        private List<IStation> ConnectedStations;
        private string name;
        private string id;

        public Station(string name, string id)
        {
            this.name = name;
            this.id = id;
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
    }
}
