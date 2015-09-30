using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class KioskDAL :BaseDAL
    {

        internal DataTable GetAllKiosk()
        {
            base.com.CommandText = "spGetAllKiosk";
            return base.GetDataTable();
        }

        internal void InsertKiosk(string name, string location, string remarks, int classid, string kioskcode, string admin)
        {

                base.com.CommandText = "spInsertKiosk";
                base.com.Parameters.AddWithValue("_KioskName", name);
                base.com.Parameters.AddWithValue("_Location", location);
                base.com.Parameters.AddWithValue("_Remarks", remarks);
                base.com.Parameters.AddWithValue("_ClassID", classid);
                base.com.Parameters.AddWithValue("_KioskCode", kioskcode);
                base.com.Parameters.AddWithValue("_CreatedBy", admin);
                base.com.ExecuteScalar();
        }

        internal DataRow SelectKioskByID(int id)
        {
            base.com.CommandText = "spSelectKioskByID";
            base.com.Parameters.AddWithValue("_KioskID", id);
            return base.GetFirstRow();
        }

        internal void UpdateKiosk(int kioskid, string name, string location, string remarks, int classid, string admin)
        {
            base.com.CommandText = "spUpdateKiosk";
            base.com.Parameters.AddWithValue("_KioskID", kioskid);
            base.com.Parameters.AddWithValue("_KioskName", name);
            base.com.Parameters.AddWithValue("_Location", location);
            base.com.Parameters.AddWithValue("_Remarks", remarks);
            base.com.Parameters.AddWithValue("_ClassID", classid);
            base.com.Parameters.AddWithValue("_CreatedBy", admin);
            base.com.ExecuteScalar();
        }
    }
}
