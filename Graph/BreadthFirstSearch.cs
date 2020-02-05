using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class BreadthFirstSearch : IPathFinder
    {
        /// <summary>
        /// Ищет путь от станции А к станции Б
        /// </summary>
        /// <param name="stationFrom"></param>
        /// <param name="stationTo"></param>
        /// <param name="pastStation"></param>
        /// <returns></returns>
        public List<IStation> FindPath(IStation stationFrom, IStation stationTo)
        {
            Queue<IStation> searchQueue = new Queue<IStation>();
            List<IStation> searched = new List<IStation>();

            ITempStationsContainer pathContainer = new StationsContainer();
            int currentLevel = 0;

            IStation stationFrom_Temp = stationFrom;

            searchQueue.Enqueue(stationFrom_Temp);
            searched.Add(stationFrom_Temp);
            pathContainer.AddToContainer(stationFrom_Temp, currentLevel);

            bool IsPathFound = false;

            while (searchQueue.Count > 0)
            {
                stationFrom_Temp = searchQueue.Dequeue();
                

                foreach(IStation station in stationFrom_Temp.GetConnectedStations())
                {
                    if (!IsContains(searched, station))
                    {
                        if (station.GetStationID() == stationTo.GetStationID())
                        {
                            IsPathFound = true;
                        }
                        else
                        {
                            searchQueue.Enqueue(station);
                            searched.Add(station);
                            currentLevel = SetStationLevel(pathContainer, station, currentLevel);
                            pathContainer.AddToContainer(station, currentLevel);
                        }
                    }
                }

                if (IsPathFound) break;
            }


            return FormPath(pathContainer, stationFrom, stationTo, currentLevel);
        }

        /// <summary>
        /// Проверяет, содержит ли список станция указанную станцию
        /// </summary>
        /// <param name="stationsList"></param>
        /// <param name="stationToCheck"></param>
        /// <returns></returns>
        private bool IsContains(List<IStation> stationsList, IStation stationToCheck)
        {
            foreach(IStation station in stationsList)
            {
                if(station.GetStationID() == stationToCheck.GetStationID())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает кратчайший путь
        /// </summary>
        /// <param name="container"></param>
        /// <param name="stationFrom"></param>
        /// <param name="stationTo"></param>
        /// <param name="currentLevel"></param>
        /// <returns></returns>
        private List<IStation> FormPath(ITempStationsContainer container, IStation stationFrom, IStation stationTo, int currentLevel)
        {
            int level = currentLevel;
            List<IStation> path = new List<IStation>();
            List<IStation> tempStationsList = new List<IStation>();
            IStation stationTemp = stationTo;
            bool IsStationFound = false;

            path.Add(stationTo);

            while (level > 0)
            {
                IsStationFound = false;
                tempStationsList = container.GetStationsFromLevel(level);

                foreach(IStation station in tempStationsList)
                {
                    if (IsStationFound)
                    {
                        break;
                    }

                    foreach (IStation stat in stationTemp.GetConnectedStations())
                    {
                        if(station.GetStationID() == stat.GetStationID())
                        {
                            stationTemp = stat;
                            IsStationFound = true;
                        }
                    }
                }
                path.Add(stationTemp);

                level--;
            }
            path.Add(stationFrom);

            path.Reverse();

            return path;
        }

        /// <summary>
        /// Задает уровень станции в графе
        /// </summary>
        /// <param name="container"></param>
        /// <param name="currentStation"></param>
        /// <param name="currentLevel"></param>
        /// <returns></returns>
        private int SetStationLevel(ITempStationsContainer container, IStation currentStation, int currentLevel)
        {
            foreach(IStation station in currentStation.GetConnectedStations())
            {
                if(container.GetLevelOfStation(station) != -1)
                {
                    return container.GetLevelOfStation(station) + 1;
                }
            }
            return currentLevel++;
        }
    }
}
