using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Branch : IBranch
    {
        private List<IStation> stations;
        private string name;
        private string id;
        private string color;

        public Branch(string name, string id, string color, List<IStation> stations)
        {
            this.name = name;
            this.id = id;
            this.color = color;
            this.stations = stations;
        }

        public void ConnectBranches(IStation firstStation, IStation secondStation)
        {
            firstStation.ConnectStation(secondStation, true);
        }

        public IStation GetStationByID(string id)
        {
            foreach(IStation station in stations)
            {
                if (station.GetStationID() == id)
                {
                    return station;
                }
            }
            throw new IndexOutOfRangeException();
        }

        public IStation GetStationByName(string name)
        {
            foreach (IStation station in stations)
            {
                if (station.GetStationName() == name)
                {
                    return station;
                }
            }
            throw new IndexOutOfRangeException();
        }

        public string GetBranchName()
        {
            return name;
        }

        public string GetBranchID()
        {
            return id;
        }

        public string GetBranchColor()
        {
            return color;
        }
    }
}
