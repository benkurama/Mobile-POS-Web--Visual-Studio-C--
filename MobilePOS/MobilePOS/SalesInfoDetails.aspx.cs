using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;

namespace MobilePOS
{
    public partial class SalesInfoDetails : System.Web.UI.Page
    {

        private void callDataGrid()
        {
            gvSales.DataSource = SalesInfo.GetAllSalesInfo();
            gvSales.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                mvMain.ActiveViewIndex = 0;
                //
                callDataGrid();
            }


            //var master = Master as Frame;
            //if (master != null)
            //{
            //    master.MessageBox("I can fly");
            //}
            //
            //(Master as Frame).MessageBox("Twinkle");
            //(Master as Frame).AlertBox("Twinkle");
            //(Master as Frame).PopUp("testing");
        }

        protected void gvSales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSales.PageIndex = e.NewPageIndex;
            callDataGrid();
        }

        protected void gvSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //
                string datakey = gvSales.DataKeys[e.Row.RowIndex].Values[0].ToString();

                GridView gvDetails = e.Row.FindControl("gvDetails") as GridView;
                gvDetails.DataSource = SalesDetails.GetSalesDetailsByInvno(datakey);
                gvDetails.DataBind();
            }
        }
    }
}