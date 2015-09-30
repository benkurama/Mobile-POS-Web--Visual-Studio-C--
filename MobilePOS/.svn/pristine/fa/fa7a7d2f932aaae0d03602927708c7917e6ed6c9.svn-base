using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
using OfficeOpenXml;
using MobilePOS.Class;
using System.Data;
using OfficeOpenXml.Style;

namespace MobilePOS
{
    public partial class SalesReport : System.Web.UI.Page
    {

        private void CallDatagrid()
        {
            string dateFrom = tbStart.Text.Trim();
            string dateTo = tbEnd.Text.Trim();


            dateFrom = dateFrom != string.Empty ? dateFrom : "all";
            dateTo = dateTo != string.Empty ? dateTo : "all";

            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            gvSalesRep.DataSource = Common.GetSalesReport(dateFrom, dateTo, kioskid);
            gvSalesRep.DataBind();
        }

        private void loadKioskList()
        {
            ddlKiosk.DataSource = Kiosk.GetAllKiosk();
            ddlKiosk.DataTextField = "Name";
            ddlKiosk.DataValueField = "KioskID";
            ddlKiosk.DataBind();
            //
            ListItem item = new ListItem();
            item.Text = "   [<<<Select All>>>]   ";
            item.Value = "0";
            ddlKiosk.Items.Insert(0, item);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                loadKioskList();
                CallDatagrid();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage package = new ExcelPackage();
            EppTools tools = new EppTools();
            //
            string fileName = "SalesReport";
            //string year = ddlYear.SelectedValue;

            string dateFrom = tbStart.Text.Trim();
            string dateTo = tbEnd.Text.Trim();

            dateFrom = dateFrom != string.Empty ? dateFrom : "all";
            dateTo = dateTo != string.Empty ? dateTo : "all";
            int kiosk = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            DataTable table = Common.GetSalesReport(dateFrom, dateTo, kiosk);
            //
            tools.GenerateSalesReport(table, ref package, fileName);
            //
            var ws = package.Workbook.Worksheets[fileName];
            //
            // HEADER TITLE FORMATING 
            ws.Cells[2, 1].Value = "SALES REPORT ";
            ws.Cells[3, 1].Value = "Date From: " + dateFrom + " To: "+ dateTo;
            ws.Cells[4, 1].Value = "Agent: " + GlobalAccess.Username;

            ws.Cells[2, 1, 4, 1].Style.Font.Bold = true;
            ws.Cells[2, 1, 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            ws.Cells[6, 9].Value = "PRICE #";
            ws.Cells[6, 8].Style.Font.Bold = true;

            // SAVING EXCEL FILE
            Response.Clear();
            Response.BinaryWrite(package.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=\"" + "Sales_Report_"+dateFrom+"_"+dateTo+".xlsx\"");

            Response.Flush();
            Response.End();

            package = null;
            ws = null;
            //
        }

        protected void gvSalesRep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesRep.PageIndex = e.NewPageIndex;

            CallDatagrid();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CallDatagrid();
        }

        
    }
}