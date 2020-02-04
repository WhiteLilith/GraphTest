using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Undeground : IUnderground
    {
        List<IBranch> branches;


        public Undeground()
        {

        }

        public Undeground(List<IBranch> branches)
        {
            this.branches = branches;
        }

        void AddBranch(IBranch branch)
        {
            branches.Add(branch);
        }

        IBranch GetBranchByName(string branchName)
        {
            foreach(IBranch branch in branches)
            {
                if(branch.GetBranchName() == branchName)
                {
                    return branch;
                }
            }
            throw new IndexOutOfRangeException();
        }

        IBranch GetBranchByID(string id)
        {
            foreach (IBranch branch in branches)
            {
                if (branch.GetBranchID() == id)
                {
                    return branch;
                }
            }
            throw new IndexOutOfRangeException();
        }

        IStation GetStationByName(string stationName)
        {
            IStation station;
            foreach(IBranch branch in branches)
            {
                station = branch.GetStationByName(stationName);
                if(station != null)
                {
                    return station;
                }
            }
            return null;
        }

        IStation GetStationByID(string id)
        {
            IStation station;
            foreach (IBranch branch in branches)
            {
                station = branch.GetStationByID(id);
                if (station != null)
                {
                    return station;
                }
            }
            return null;
        }

        List<IStation> GetAllStationsByName(string branchName)
        {
            IBranch branch = Undeground.GetBranchByName(branchName);
            return branch != null ? branch.GetAllStations() : null;
        }

        List<IStation> GetAllStationsByID(string id)
        {
            IBranch branch = Undeground.GetBranchByID(id);
            return branch != null ? branch.GetAllStations() : null;
        }
    }
}
