using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class EmployeeLog
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string LogTime { get; set; }
        public string LogType { get; set; }

        public EmployeeLog()
        {
            this.EmpID = "";
            this.EmpName = "";
            this.LogTime = "";
            this.LogType = "";
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.EmpID = Convert.ToString(row["EmpID"]);
                this.EmpName = Convert.ToString(row["EmpName"]);
                DateTime date = Convert.ToDateTime(row["LogTime"]);
                this.LogTime = String.Format("{0:G}", date);
                this.LogType = Convert.ToString(row["LogType"]);
            }
        }

        public static void InsertLogOutTime(string empid, string empname)
        {
            var dal = new EmployeeLogDAL();
            dal.InsertLogOutTime(empid, empname, "O");
        }

        public static List<EmployeeLog> GetAllLogtimeByUser(string empid)
        {
            var dal = new EmployeeLogDAL();
            var collection = new List<EmployeeLog>();

            foreach(DataRow row in dal.GetAllLogtimeByUser(empid).Rows){

                var instance = new EmployeeLog();
                instance.Bind(row);
                collection.Add(instance);
            }
            //
            return collection;
        }
    }
}
