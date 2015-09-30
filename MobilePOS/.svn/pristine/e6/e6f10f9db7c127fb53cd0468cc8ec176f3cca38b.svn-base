using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class DiscountDAL : BaseDAL
    {

        internal DataTable GetAllData()
        {
            base.com.CommandText = "spGetAllDiscount";

            return base.GetDataTable();
        }

        internal bool InsertNewDiscount(Discount instance)
        {
            base.com.CommandText = "spInsertDiscount";
            base.com.Parameters.AddWithValue("_Value", instance.Value);
            base.com.Parameters.AddWithValue("_DateFrom", instance.ValidFrom);
            base.com.Parameters.AddWithValue("_DateTo", instance.ValidTo);
            base.com.Parameters.AddWithValue("_KioskAssign", instance.KioskAssign);
            base.com.Parameters.AddWithValue("_ProductAssign", instance.ProductAssign);
            base.com.Parameters.AddWithValue("_CreatedBy", instance.CreatedBy);
            base.com.Parameters.AddWithValue("_Remarks", instance.Remarks);

            int res = 0;

            try
            {
                res = Convert.ToInt32( base.com.ExecuteScalar());
            }catch(Exception ee){

            }

            return res > 0;
        }
    }
}
