using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class Top10ProductDAL : BaseDAL
    {

        internal DataTable GetTop10Products(string from, string to)
        {
            base.com.CommandText = "spGetTop10Products";
            base.com.Parameters.AddWithValue("_From", from);
            base.com.Parameters.AddWithValue("_To", to);
            return base.GetDataTable();
        }
    }
}
