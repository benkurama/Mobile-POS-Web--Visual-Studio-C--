using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class InventoryDAL : BaseDAL
    {

        internal DataTable GetAllByKiosk(int id)
        {
            base.com.CommandText = "spGetAllInventoryByKiosk";
            base.com.Parameters.AddWithValue("_KioskID", id);

            return base.GetDataTable();
        }

        internal bool UpdateActiveStatus(string active, int InvID)
        {
            base.com.CommandText = "spUpdateInventoryActive";
            base.com.Parameters.AddWithValue("_Active", active);
            base.com.Parameters.AddWithValue("_InvID", InvID);

            int res = 0;
            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());

                if(res<=0){
                    throw new ArgumentException("Update Failed");
                }
            }catch(Exception ee){
                throw;
            }

            return res > 0;
        }

        internal DataTable GetSelectedInventory(int invid)
        {
            base.com.CommandText = "spSelectInventoryByID";
            base.com.Parameters.AddWithValue("_InvID", invid);
            return base.GetDataTable();
        }
    }
}
