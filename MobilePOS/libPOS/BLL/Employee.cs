using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Employee
    {
        public string EmpID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int KioskID { get; set; }
        public string Department { get; set; }
        public string UserLevel { get; set; }
        public int UserLevelID { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime? DateHired { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public string KioskName { get; set; }
        public string StaffList_ { get; set; }

        public Employee()
        {
            this.EmpID = "";
            this.Username = "";
            this.Password = "";
            this.Firstname = "";
            this.Lastname = "";
            this.KioskID = 0;
            this.Department = "";
            this.UserLevel = "";
            this.UserLevelID = 0;
            this.MobileNo = "";
            this.Email = "";
            this.DateHired = null;
            this.DateCreated = null;
            this.DateUpdated = null;
            

            this.KioskName = "";
            this.StaffList_ = "";
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.EmpID = Convert.ToString(row["EmpID"]);
                this.Username = Convert.ToString(row["Username"]);
                this.Password = Convert.ToString(row["Password"]);
                this.Firstname = Convert.ToString(row["FirstName"]);
                this.Lastname = Convert.ToString(row["LastName"]);
                this.KioskID = Convert.ToInt32(row["KioskID"]);
                this.Department = Convert.ToString(row["Department"]);
                //this.UserLevel = Convert.ToString(row["Userlevel"]);
                this.UserLevelID = Convert.ToInt32(row["UserLevelID"]);
                this.MobileNo = Convert.ToString(row["MobileNo"]);
                this.Email = Convert.ToString(row["Email"]);
                this.DateHired = Convert.ToDateTime(row["DateHired"]);
                this.DateCreated = Convert.ToDateTime(row["DateCreated"]);

                if (row["DateUpdated"].ToString() != "")
                {
                    this.DateUpdated = Convert.ToDateTime(row["DateUpdated"]);
                }

                this.StaffList_ = Utils.convString("StaffList", row);

                switch (this.UserLevelID)
                {
                    case 1:
                        this.UserLevel = "Admin";
                        break;
                    case 2:
                        this.UserLevel = "RAS";
                        break;
                    case 3:
                        this.UserLevel = "Staff";
                        break;
                    case 4:
                        this.UserLevel = "Cashier";
                        break;
                    case 5:
                        this.UserLevel = "Audit";
                        break;
                }
            }
        }

        public void Bind2(DataRow row)
        {
            if (row != null)
            {
                this.EmpID = Convert.ToString(row["EmpID"]);
                this.Username = Convert.ToString(row["Username"]);
                this.Password = Convert.ToString(row["Password"]);
                this.Firstname = Convert.ToString(row["FirstName"]);
                this.Lastname = Convert.ToString(row["LastName"]);
                this.KioskID = Convert.ToInt32(row["KioskID"]);
                this.Department = Convert.ToString(row["Department"]);
                //this.UserLevel = Convert.ToString(row["Userlevel"]);
                this.UserLevelID = Convert.ToInt32(row["UserLevelID"]);
                this.MobileNo = Convert.ToString(row["MobileNo"]);
                this.Email = Convert.ToString(row["Email"]);
                this.DateHired = Convert.ToDateTime(row["DateHired"]);
                this.DateCreated = Convert.ToDateTime(row["DateCreated"]);
                if (row["DateUpdated"].ToString() != "")
                {
                    this.DateUpdated = Convert.ToDateTime(row["DateUpdated"]);
                }
                //
                this.KioskName = Convert.ToString(row["KioskName"]);

                switch (this.UserLevelID)
                {
                    case 1:
                        this.UserLevel = "Admin";
                        break;
                    case 2:
                        this.UserLevel = "RAS";
                        break;
                    case 3:
                        this.UserLevel = "Staff";
                        break;
                    case 4:
                        this.UserLevel = "Cashier";
                        break;
                    case 5:
                        this.UserLevel = "Audit";
                        break;
                }
            }
        }

        public static Employee GetEmployeeByUsername(string username)
        {
            var dal = new EmployeeDAL();

            DataRow row = dal.GetEmployeeByUsername(username);

            var instance = new Employee();
            instance.Bind(row);

            return instance;
        }

        public static List<Employee> GetAllEmployees()
        {
            var dal = new EmployeeDAL();
            var collection = new List<Employee>();

            foreach (DataRow row in dal.GetAllEmployees().Rows)
            {
                var instance = new Employee();
                instance.Bind2(row);
                collection.Add(instance);
            }

            return collection;
        }

        public static Employee SelectEmployeeByID(string id)
        {
            var dal = new EmployeeDAL();
            DataRow row = dal.SelectEmployeeByID(id);

            var ins = new Employee();
            ins.Bind(row);

            return ins;
        }

        public static void InsertEmployee(Employee ins, string admin)
        {
            var dal = new EmployeeDAL();

            dal.InsertEmployee(ins, admin);
        }

        public static void UpdateEmployee(Employee ins, string admin)
        {
            var dal = new EmployeeDAL();
            dal.UpdateEmployee(ins, admin);
        }

        public static int IsLogged(string empid, string log)
        {
            var dal = new EmployeeDAL();
            return dal.IsLogged(empid, log);
        }

        public static List<Employee> GetLoggedEmployee()
        {
            var dal = new EmployeeDAL();
            var collection = new List<Employee>();

            foreach (DataRow row in dal.GetLoggedEmployee().Rows)
            {
                var ins = new Employee();
                ins.Bind2(row);

                collection.Add(ins);
            }

            return collection;
        }
    }
}
