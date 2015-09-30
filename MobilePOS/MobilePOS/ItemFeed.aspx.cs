using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
//using Newtonsoft.Json;
using MobilePOS.LocalClass;

namespace MobilePOS
{
    public partial class ItemFeed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if(!IsPostBack){
                
            //    if (GlobalAccess.EmpID != null)
            //    {
            //        var collection = Products.GetAllProducts();

            //        JsonBridge<Products> datafeed = new JsonBridge<Products>();
            //        datafeed.Valid = 1;
            //        datafeed.collection = collection;

            //        string output = JsonConvert.SerializeObject(datafeed);
            //        Response.Write(output);
            //    }
            //    else
            //    {
            //        Response.Redirect("Default.aspx");
            //    }
            //}

        }
    }
}