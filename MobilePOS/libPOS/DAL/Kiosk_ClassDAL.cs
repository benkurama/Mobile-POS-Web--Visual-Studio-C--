using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class Kiosk_ClassDAL : BaseDAL
    {

        internal DataTable GetAllSupervisor()
        {
            base.com.CommandText = "spGetAllClass";
            return base.GetDataTable();
        }

        internal bool InsertSupervisor(string classtype, string supervisor, string admin)
        {
            base.com.CommandText = "spInsertKiosk_Class";
            base.com.Parameters.AddWithValue("ClassName_", classtype);
            base.com.Parameters.AddWithValue("Supervisor_", supervisor);
            base.com.Parameters.AddWithValue("CreatedBy_", admin);

            int res = 0;

            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception)
            {
     
            }

            finally
            {
                closeConnection();
            }

            return res > 0;
        }
    }
}
