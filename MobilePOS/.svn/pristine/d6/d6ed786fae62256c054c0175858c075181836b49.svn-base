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
    public partial class WeekLyReport : System.Web.UI.Page
    {
        private void CallDataGrid()
        {
            string year = ddlYear.SelectedValue;
            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            gvWeeklyRep.DataSource = Common.GetWeeklyReport(year, kioskid);
            gvWeeklyRep.DataBind();
        }

        private void LoadYear()
        {
            ddlYear.DataSource = Common.GetWeekRangeReport();
            ddlYear.DataTextField = "YearRange";
            ddlYear.DataValueField = "YearRange";
            ddlYear.DataBind();
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
                LoadYear();
                loadKioskList();
                CallDataGrid();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage package = new ExcelPackage();
            EppTools tools = new EppTools();
            //
            string fileName = "WeeklyReport";
            string year = ddlYear.SelectedValue;

            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);
            DataTable table = Common.GetWeeklyReport(year, kioskid);
            //
            tools.GenerateWeeklyReport(table,ref package, fileName);
            //
            var ws = package.Workbook.Worksheets[fileName];
            //
            // HEADER TITLE FORMATING 
            ws.Cells[2, 1].Value = "WEEKLY REPORT ";
            ws.Cells[3, 1].Value = "Year and Date " ;
            ws.Cells[4, 1].Value = "Agent: " + GlobalAccess.Username;

            ws.Cells[2, 1, 4, 1].Style.Font.Bold = true;
            ws.Cells[2, 1, 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // SAVING EXCEL FILE
            Response.Clear();
            Response.BinaryWrite(package.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=\"" + "Weekly_Report.xlsx\"");

            Response.Flush();
            Response.End();

            package = null;
            ws = null;

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CallDataGrid();
        }

        protected void gvWeeklyRep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvWeeklyRep.PageIndex = e.NewPageIndex;

            CallDataGrid();
        }
    }
}