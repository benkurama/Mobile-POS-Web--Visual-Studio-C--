using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
using OfficeOpenXml;
using libPOS;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using MobilePOS.Class;

namespace MobilePOS
{
    public partial class MonthlyReport : System.Web.UI.Page
    {
        // =========================================================================
        // Main Functions
        // =========================================================================
        private void CallDatagrid()
        {
            string from = ddlFrom.SelectedItem.Text;
            string to = ddlTo.SelectedItem.Text;
            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            DataTable table = Common.GetMonthlyReport(from, to, kioskid);

            gvMonthlyRep.DataSource = table;
            gvMonthlyRep.DataBind();
        }

        private void LoadFromToList()
        {
            DataTable table = Common.GetMonthRangeReport();
            

            ddlFrom.DataSource = table;
            ddlFrom.DataTextField = "DateRange";
            ddlFrom.DataValueField = "DateRange";
            ddlFrom.DataBind();

            DataView dv = table.DefaultView;
            dv.Sort = "DateRange DESC";

            ddlTo.DataSource = table;
            ddlTo.DataTextField = "DateRange";
            ddlTo.DataValueField = "DateRange";
            ddlTo.DataBind();
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
        // =========================================================================
        // Sub Functions
        // =========================================================================

        // =========================================================================
        // Overrides
        // =========================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                LoadFromToList();
                loadKioskList();
                CallDatagrid();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage package = new ExcelPackage();
            EppTools tools = new EppTools();
            //
            string fileName = "MonthlyReport";

            string from = ddlFrom.SelectedItem.Text;
            string to = ddlTo.SelectedItem.Text;
            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            DataTable table = Common.GetMonthlyReport(from, to, kioskid);

            tools.GenerateMonthlyReport(table, ref package, fileName);

            var ws = package.Workbook.Worksheets[fileName];
            //
            // HEADER TITLE FORMATING 
            ws.Cells[2, 1].Value = "MONTHLY REPORT " ;
            ws.Cells[3, 1].Value = "Year and Date: from "+from+" to "+to;
            ws.Cells[4, 1].Value = "Agent: " + GlobalAccess.Username;

            ws.Cells[2, 1, 4, 1].Style.Font.Bold = true;
            ws.Cells[2, 1, 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // SAVING EXCEL FILE
            Response.Clear();
            Response.BinaryWrite(package.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=\"" + "Monthly_Report.xlsx\"");

            Response.Flush();
            Response.End();

            package = null;
            ws = null;


        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CallDatagrid();
        }

        protected void gvMonthlyRep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMonthlyRep.PageIndex = e.NewPageIndex;

            CallDatagrid();
        }

     

 
    }
}