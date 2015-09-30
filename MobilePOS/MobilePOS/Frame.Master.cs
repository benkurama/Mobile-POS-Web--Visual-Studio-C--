using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
using System.Web.Security;

namespace MobilePOS
{
    public partial class Frame : System.Web.UI.MasterPage
    {

        public void MessageBox(string msg)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert( '" + msg + "');", true);

            //string scrp = "$('#myModal').modal('show')";
            //lblPopMessage.Text = msg;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "none",
            //scrp, true
            //);
        }

        public void AlertBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert( '" + msg + "');", true);

        }

        public void PopUp(string msg)
        {
            lblMessage.Text = msg;
            mpe.Show();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    if (GlobalAccess.EmpID != null)
                    {
                        //string name = HttpContext.Current.User.Identity.Name;

                        string name = GlobalAccess.Username;

                        lblUserGlobal.Text = name;
                        lblUserTypeGlobal.Text = GlobalAccess.UserLevel;
                    }
                    else
                    {

                        //FormsAuthentication.SignOut();
                        //FormsAuthentication.RedirectToLoginPage();

                        //Application[GlobalAccess.EmpID] = "";
                        ClearServerApplication();
                    }
                }
                else
                {
                    

                    //FormsAuthentication.SignOut();
                    //FormsAuthentication.RedirectToLoginPage();

                   // Application[GlobalAccess.EmpID] = "";
                    ClearServerApplication();
                }
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            EmployeeLog.InsertLogOutTime(GlobalAccess.EmpID, GlobalAccess.Fullname);

            ClearServerApplication();
        }

        private void ClearServerApplication()
        {
            //if (GlobalAccess.EmpID != null)
            //{
            //    if (Application[GlobalAccess.EmpID].ToString() == GlobalAccess.EmpID.ToString())
            //    {
            //        Application.Contents.Remove(GlobalAccess.EmpID);
            //    }

            //    Employee.IsLogged(GlobalAccess.EmpID, "f");
            //}

            //
            string empid = HttpContext.Current.User.Identity.Name;
            Application.Contents.Remove(empid);
            Employee.IsLogged(empid, "f");
            //
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();

            this.Session.Abandon();
            this.Session.RemoveAll();
            this.Session.Clear();


            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        //////////
    }
}