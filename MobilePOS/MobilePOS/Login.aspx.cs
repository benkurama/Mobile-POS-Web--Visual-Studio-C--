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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alertError.Visible = false;
            // temporary code
            /*tbUserID.Text = "adminmin";
            tbPassword.Text = "redfoot";*/
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUserID.Text.Trim();

            if (username != "")
            {
                var instance = Employee.GetEmployeeByUsername(username);

                if (tbPassword.Text.Trim() == instance.Password && instance.EmpID != "")
                {
                    //
                    
                    //
                    GlobalAccess.EmpID = instance.EmpID;
                    GlobalAccess.Username = instance.Username;
                    GlobalAccess.Password = instance.Password;
                    GlobalAccess.Department = instance.Department;
                    GlobalAccess.UserLevel = instance.UserLevel;
                    GlobalAccess.MobileNo = instance.MobileNo;
                    GlobalAccess.Fullname = instance.Firstname + " " + instance.Lastname;

                    // Form Authentication
                    if (Application[GlobalAccess.EmpID] != null)
                    {
                        //
                        if (Application[GlobalAccess.EmpID].ToString() == GlobalAccess.EmpID.ToString())
                        {
                            //
                            alertError.Visible = true;

                            tbErroMessage.Text = "System not allow concurrent user sessions.";

                            //
                            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            HttpContext.Current.Response.Cache.SetNoServerCaching();
                            HttpContext.Current.Response.Cache.SetNoStore();

                            this.Session.Abandon();
                            this.Session.RemoveAll();
                            this.Session.Clear();

                            return;
                        }
                        else
                        {
                            Application[GlobalAccess.EmpID] = GlobalAccess.EmpID;
                        }
                    }
                    else
                    {
                        Application[GlobalAccess.EmpID] = GlobalAccess.EmpID;
                    }
                    //
                    DateTime timeout = DateTime.Now.AddMinutes(30);
                    // Assigning Ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, instance.EmpID, DateTime.Now, timeout, false, "", FormsAuthentication.FormsCookiePath);
                    
                    string hashCookies = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies);

                    this.Response.Cookies.Add(cookie);
                    //
                    Employee.IsLogged(instance.EmpID,"t");
                    //
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    alertError.Visible = true;
                    tbErroMessage.Text = "Username/Password is Invalid... ";
                }
            }
            else
            {
                alertError.Visible = true;
                tbErroMessage.Text = "Username/Password is Invalid... ";
            }

        }
    }
}