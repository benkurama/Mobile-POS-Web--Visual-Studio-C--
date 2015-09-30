using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace libPOS.BLL
{
    public class GlobalAccess
    {
        private const string EMPID = "EmpID";
        private const string USERNAME = "Username";
        private const string PASSWORD = "Password";
        private const string DEPARTMENT = "Department";
        private const string USERLEVEL = "UserLevel";
        private const string MOBILENO = "MobileNo";
        private const string FULLNAME = "Fullname";

        public static string EmpID
        {
            get
            {
                if (HttpContext.Current.Session[EMPID] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[EMPID].ToString();
                }
            }
            set { HttpContext.Current.Session[EMPID] = value; }
            
        }

        public static string Username
        {
            get
            {
                if (HttpContext.Current.Session[USERNAME] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[USERNAME].ToString();
                }
            }
            set { HttpContext.Current.Session[USERNAME] = value; }

        }

        public static string Password
        {
            get
            {
                if (HttpContext.Current.Session[PASSWORD] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[PASSWORD].ToString();
                }
            }
            set { HttpContext.Current.Session[PASSWORD] = value; }
        }

        public static string Department
        {
            get
            {
                if (HttpContext.Current.Session[DEPARTMENT] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[DEPARTMENT].ToString();
                }
            }
            set { HttpContext.Current.Session[DEPARTMENT] = value; }
        }

        public static string UserLevel
        {
            get
            {
                if (HttpContext.Current.Session[USERLEVEL] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[USERLEVEL].ToString();
                }
            }
            set { HttpContext.Current.Session[USERLEVEL] = value; }
        }

        public static string MobileNo
        {
            get
            {
                if (HttpContext.Current.Session[MOBILENO] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[MOBILENO].ToString();
                }
            }
            set { HttpContext.Current.Session[MOBILENO] = value; }
        }

        public static string Fullname
        {
            get
            {
                if (HttpContext.Current.Session[FULLNAME] == null)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Session[FULLNAME].ToString();
                }
            }
            set
            {
                HttpContext.Current.Session[FULLNAME] = value;
            }
        }
    }
}
