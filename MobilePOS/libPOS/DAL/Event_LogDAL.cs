using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class Event_LogDAL:BaseDAL
    {

        internal DataTable GetCurrentEvents()
        {
            base.com.CommandText = "spGetCurrentEventLog";

            return base.GetDataTable();
        }
    }
}
