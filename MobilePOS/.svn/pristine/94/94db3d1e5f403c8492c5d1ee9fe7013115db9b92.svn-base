using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class ReturnDetailsDAL : BaseDAL
    {
        internal int InsertReturnDetails(ReturnDetails rd)
        {
            base.com.CommandText = "spInsertReturnDetails";
            base.com.Parameters.AddWithValue("RetNo_", rd.RetNo);
            base.com.Parameters.AddWithValue("InvNo_", rd.InvNo);
            base.com.Parameters.AddWithValue("ProdID_", rd.ProdID);
            base.com.Parameters.AddWithValue("RetQty_", rd.RetQty);
            base.com.Parameters.AddWithValue("Unit_", rd.Unit);
            base.com.Parameters.AddWithValue("UnitPx_", rd.UnitPx);
            base.com.Parameters.AddWithValue("Reason_", rd.Reason);
            //
            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception e)
            {
                res = 0;
            }

            return res;
        }
    }
}
