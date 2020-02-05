using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IUnderground
    {
        void AddBranch(IBranch branch);

        IBranch GetBranchByName(string branchName);

        IBranch GetBranchByID(string id);

        IStation GetStationByName(string stationName);

        IStation GetStationByID(string id);

        List<IStation> GetAllStationsByName(string branchName);

        List<IStation> GetAllStationsByID(string id);
    }
}
