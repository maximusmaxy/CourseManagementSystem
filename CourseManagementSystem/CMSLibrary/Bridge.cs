using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Bridge
    {
        public string BridgingTable { get; }
        public string ForeignTable { get; }
        public string IdColumn { get; }
        public string ForeignColumn { get; }
        public string ForeignDisplay { get; }

        public Bridge(string bridgingTable, string foreignTable, string idColumn, string foreignColumn, string foreignDisplay)
        {
            BridgingTable = bridgingTable;
            ForeignTable = foreignTable;
            IdColumn = idColumn;
            ForeignColumn = foreignColumn;
            ForeignDisplay = foreignDisplay;
        }
    }
}
