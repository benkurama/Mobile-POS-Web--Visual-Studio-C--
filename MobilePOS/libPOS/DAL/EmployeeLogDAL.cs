using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace libPOS.DAL
{
    internal class EmployeeLogDAL :BaseDAL
    {

        internal void InsertLogOutTime(string empid, string empname, string logtype)
        {
            base.com.CommandText = "spInsertLoginTimeByUser";
            base.com.Parameters.AddWithValue("_EmpID", empid);
            base.com.Parameters.AddWithValue("_EmpName", empname);
            base.com.Parameters.AddWithValue("_LogType", logtype);

            try
            {
                base.com.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Insert Data Failed"); ;
            }
            finally
            {
                closeConnection();
            }
        }

        internal DataTable GetAllLogtimeByUser(string empid)
        {
            base.com.CommandText = "spGetLogtimeByUserToday";
            base.com.Parameters.AddWithValue("_EmpId",empid);
            return base.GetDataTable();
        }
    }
}
