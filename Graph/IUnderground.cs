using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IUnderground
    {
        void AddBranch(IBranch branch);

        IBranch GetBranchByName(string branchName);

        IBranch GetBranchID(string id);

        IStation GetStationByName(string stationName);

        IStation GetStationByID(string id);

        List<IStation> GetAllStations(string branchName);

        List<IStation> GetAllStationsByID(string id);
    }
}
