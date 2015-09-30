using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.BLL;

namespace libPOS.DAL
{
    internal class EmployeeDAL : BaseDAL
    {
        public DataRow GetEmployeeByUsername(string username)
        {
            base.com.CommandText = "spSelectEmployeeByUsername";
            base.com.Parameters.AddWithValue("_username", username);

            return base.GetFirstRow();
        }

        internal DataTable GetAllEmployees()
        {
            base.com.CommandText = "spGetAllEmployee";
            return base.GetDataTable();
        }

        internal DataRow SelectEmployeeByID(string id)
        {
            base.com.CommandText = "spSelectEmployeeByID";
            base.com.Parameters.AddWithValue("_EmpID", id);
            return base.GetFirstRow();
        }

        internal void InsertEmployee(Employee ins, string admin)
        {
            base.com.CommandText = "spInsertEmployee";
            base.com.Parameters.AddWithValue("_EmpID", ins.EmpID);
            base.com.Parameters.AddWithValue("_Username", ins.Username);
            base.com.Parameters.AddWithValue("_Password", ins.Password);
            base.com.Parameters.AddWithValue("_FirstName", ins.Firstname);
            base.com.Parameters.AddWithValue("_LastName", ins.Lastname);
            base.com.Parameters.AddWithValue("_KioskID", ins.KioskID);
            base.com.Parameters.AddWithValue("_Department", ins.Department);
            base.com.Parameters.AddWithValue("_UserLevelID", ins.UserLevelID);
            base.com.Parameters.AddWithValue("_MobileNo", ins.MobileNo);
            base.com.Parameters.AddWithValue("_Email", ins.Email);
            base.com.Parameters.AddWithValue("_DateHired", ins.DateHired);
            base.com.Parameters.AddWithValue("_CreatedBy", admin);
            base.com.ExecuteScalar();
            
            
            closeConnection();
            
        }

        internal void UpdateEmployee(Employee ins, string admin)
        {
            base.com.CommandText = "spUpdateEmployee";
            base.com.Parameters.AddWithValue("_EmpID", ins.EmpID);
            base.com.Parameters.AddWithValue("_Username", ins.Username);
            base.com.Parameters.AddWithValue("_FirstName", ins.Firstname);
            base.com.Parameters.AddWithValue("_LastName", ins.Lastname);
            base.com.Parameters.AddWithValue("_KioskID", ins.KioskID);
            base.com.Parameters.AddWithValue("_Department", ins.Department);
            base.com.Parameters.AddWithValue("_UserLevelID", ins.UserLevelID);
            base.com.Parameters.AddWithValue("_MobileNo", ins.MobileNo);
            base.com.Parameters.AddWithValue("_Email", ins.Email);
            base.com.Parameters.AddWithValue("_CreatedBy", admin);
            base.com.ExecuteScalar();

            closeConnection();
        }

        internal int IsLogged(string empid, string log)
        {
            base.com.CommandText = "spUpdateEmpStatusLog";
            base.com.Parameters.AddWithValue("EmpID_", empid);
            base.com.Parameters.AddWithValue("LogStatus_", log);

            int res = 0;
            try
            {
                res = Convert.ToInt32(base.com.ExecuteScalar());
            }
            catch (Exception e)
            {

            }
            finally
            {
                base.closeConnection();
            }

            return res;
        }

        internal DataTable GetLoggedEmployee()
        {
            base.com.CommandText = "spSelectEmployeeLogged";

            return base.GetDataTable();
        }
    }
}
