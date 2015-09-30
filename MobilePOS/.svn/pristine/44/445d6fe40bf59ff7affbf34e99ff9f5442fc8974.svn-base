using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libPOS.DAL;

namespace libPOS.BLL
{
    public class Users
    {
        // =========================================================================
        // Variables
        // =========================================================================
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string UserLevel { get; set; }
        public string Contact { get; set; }
        public DateTime? DateHired { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Users()
        {
            this.ID = 0;
            this.UserName = "";
            this.Password = "";
            this.Department = "";
            this.UserLevel = "";
            this.Contact = "";
            this.DateHired = null;
            this.DateCreated = null;
            this.DateUpdated = null;
        }

        public void Bind(DataRow row)
        {
            if(row != null){
                this.ID = Convert.ToInt32(row["UserID"]);
                this.UserName = Convert.ToString(row["Username"]);
                this.Password = Convert.ToString(row["Password"]);
                this.Department = Convert.ToString(row["Department"]);
                this.UserLevel = Convert.ToString(row["UserLevel"]);
                this.Contact = Convert.ToString(row["Contact"]);
                this.DateHired = Convert.ToDateTime(row["DateHired"]);
                this.DateCreated = Convert.ToDateTime(row["DateCreated"]);

                if(row["DateUpdated"].ToString() != ""){
                    this.DateUpdated = Convert.ToDateTime(row["DateUpdated"]);
                }
            }
        }

        public static List<Users> GetAllUserData()
        {
            var dal = new UserDAL();
            var collection = new List<Users>();

            foreach(DataRow row in dal.GetAllUserData().Rows){
                var instance = new Users();
                instance.Bind(row);
                collection.Add(instance);
            }

            return collection;
        }

        public static Users GetUserByUserID(string username)
        {
            var dal = new UserDAL();

            DataRow row = dal.GetUserByUserID(username);

            var instance = new Users();
            instance.Bind(row);

            return instance;
        }
    }
}
