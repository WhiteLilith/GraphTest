using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    /// <summary>
    /// Класс ветки метро
    /// </summary>
    class Branch : IBranch
    {
        private List<IStation> stations;
        private string name;
        private string id;
        private string color;

        private static int branch_id = 0;

        public Branch(string name, string color, string[] stations)
        {
            this.name = name;
            this.color = color;
            id = branch_id++.ToString();

            CreateBranch(stations);
        }

        /// <summary>
        /// Соединяет указанные станции разных ветвей
        /// </summary>
        /// <param name="firstStation"></param>
        /// <param name="secondStation"></param>
        static public void ConnectBranches(IStation firstStation, IStation secondStation)
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

        /// <summary>
        /// Создание ветки
        /// </summary>
        /// <param name="stations"></param>
        /// <param name="branchName"></param>
        /// <param name="branchColor"></param>
        /// <param name="branchID"></param>
        /// <param name="stationsID"></param>
        /// <returns></returns>
        private void CreateBranch(string[] stations)
        {
            List<IStation> stationsBranch = new List<IStation>(0);
            for (int i = 0; i < stations.Length; i++)
            {
                if (i == 0 || i == stations.Length)
                {
                    stationsBranch.Add(new Station(stations[i], true));
                }
                else
                {
                    stationsBranch.Add(new Station(stations[i], false));
                }
                if (i > 0)
                {
                    stationsBranch[i - 1].ConnectStation(stationsBranch[i], true);
                }
            }
            this.stations = stationsBranch;
        }
    }
}
