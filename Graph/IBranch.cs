﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IBranch
    {
        IStation GetStationByID(string id);

        IStation GetStationByName(string name);

        void ConnectBranches(IStation firstStation, IStation secondStation);
    }
}