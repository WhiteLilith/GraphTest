using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class BreadthFirstSearch : IPathFinder
    {
        public List<IStation> FindPath(IStation stationFrom, IStation stationTo, IStation pastStation)
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

        private List<IStation> TransformFromQueueToList(Queue<IStation> searchQueue)
        {
            IStation[] tempQueue = new Station[searchQueue.Count];
            searchQueue.CopyTo(tempQueue, 0);

            List<IStation> path = new List<IStation>();
            IStation temp;

            for(int i = tempQueue.Length - 1; i >= 0; i--)
            {
                path.Add(tempQueue[i]);
            }
            return path;
        }

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

        private List<IStation> FormPath(ITempStationsContainer container, IStation stationFrom, IStation stationTo, int currentLevel)
        {
            int level = currentLevel;
            List<IStation> path = new List<IStation>();
            List<IStation> tempStationsList = new List<IStation>();
            IStation stationTemp = stationTo;
            bool IsStationFound = false;

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

            return path;
        }

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
