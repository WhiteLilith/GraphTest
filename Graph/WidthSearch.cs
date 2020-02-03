using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class WidthSearch : IPathFinder
    {
        public List<IStation> FindPath(IStation stationFrom, IStation stationTo, IStation pastStation)
        {
            Queue<IStation> searchQueue = new Queue<IStation>();
            List<IStation> searched = new List<IStation>();
            List<IStation> path = new List<IStation>();

            IStation stationFrom_Temp = stationFrom;

            AddToQueue(ref searchQueue, stationFrom_Temp);
            while (searchQueue.Count > 0)
            {
                stationFrom_Temp = searchQueue.Peek();
                searchQueue.Dequeue();

                if(!IsContains(searched, stationFrom_Temp))
                {
                    if (stationFrom_Temp.GetStationID() == stationTo.GetStationID())
                    {
                        return path;
                    }
                    else
                    {
                        AddToQueue(ref searchQueue, stationFrom_Temp);
                        searched.Add(stationFrom_Temp);
                        path.Add(stationFrom_Temp);
                    }
                }
            }
            return null;
        }

        private void AddToQueue(ref Queue<IStation> searchQueue, IStation stationToAdd)
        {
            List<IStation> neighboorStations = stationToAdd.GetConnectedStations();
            foreach(var station in neighboorStations)
            {
                searchQueue.Enqueue(station);
            }
        }

        private List<IStation> TransformFromQueueToList(Queue<IStation> searchQueue)
        {
            List<IStation> path = new List<IStation>();
            IStation temp;
            while(searchQueue.Count > 0)
            {
                temp = searchQueue.Dequeue();
                path.Add(temp);
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
    }
}
