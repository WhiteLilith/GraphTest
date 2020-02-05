using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IBranch
    {
        IStation GetStationByID(string id);

        IStation GetStationByName(string name);

        static void ConnectBranches(IStation firstStation, IStation secondStation)
        {

        }

        List<IStation> GetAllStations();

        string GetBranchID();

        string GetBranchName();
    }
}
