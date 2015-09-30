using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class RemittanceDAL : BaseDAL
    {

        internal int InsertRemittanceData(Remittance instance)
        {
            base.com.CommandText = "spInsertRemittance";
            base.com.Parameters.AddWithValue("InvNo_", instance.InvNo);
            base.com.Parameters.AddWithValue("InvAmount_", instance.InvAmt);
            base.com.Parameters.AddWithValue("TakenBy_", instance.TakenBy);
            base.com.Parameters.AddWithValue("KioskID_", instance.KioskID);

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
