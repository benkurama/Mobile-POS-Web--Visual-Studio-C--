using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libPOS.BLL;
using System.Data;

namespace libPOS.DAL
{
    internal class ProdIMEIDAL : BaseDAL
    {

        internal void InsertNewIMEI(List<ProdIMEI> prodIMEIList)
        {
            
            foreach(ProdIMEI ins in prodIMEIList){
                //
                InsertIMEI(ins);
            }

            closeConnection();
        }

        internal bool InsertIMEI(ProdIMEI instance)
        {
            base.com.CommandText = "spInsertProdIMEI";
            base.com.Parameters.Clear();
            base.com.Parameters.AddWithValue("InventoryID_", instance.InventoryID);
            base.com.Parameters.AddWithValue("IMEI_", instance.IMEI);

            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception ee)
            {
                res = 0;
            }

            return res > 0;
        }

        internal DataTable GetIMEIByKioskIDProdID(int kioskid, int prodid)
        {
            base.com.CommandText = "spGetAllIMEIByKioskProd";
            base.com.Parameters.AddWithValue("KioskID_", kioskid);
            base.com.Parameters.AddWithValue("ProdID_", prodid);

            return base.GetDataTable();
        }

        internal DataTable GetIMEIByInventoryID(int inventID)
        {
            base.com.CommandText = "spGetAllIMEIByInventoryID";
            base.com.Parameters.AddWithValue("InventoryID_", inventID);

            return base.GetDataTable();
        }
    }
}
