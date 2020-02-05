using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    interface IDataWriterReader
    {
        void DataWrite(string filename, IUnderground underground);

        IUnderground DataRead(string filename);
    }
}
