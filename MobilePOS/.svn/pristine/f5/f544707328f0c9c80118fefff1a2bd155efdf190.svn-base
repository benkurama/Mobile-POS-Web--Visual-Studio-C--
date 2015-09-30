using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
using OfficeOpenXml;
using MobilePOS.Class;
using OfficeOpenXml.Style;
using System.Data;

namespace MobilePOS
{
    public partial class VolumeWeekReport : System.Web.UI.Page
    {
        private void CallDataGrid()
        {
            string dateFrom = tbStart.Text.Trim();
            string dateTo = tbEnd.Text.Trim();

            dateFrom = dateFrom != string.Empty ? dateFrom : "all";
            dateTo = dateTo != string.Empty ? dateTo : "all";

            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            gvVolumeWeek.DataSource = Common.GetVolumeWeekReport(dateFrom, dateTo, kioskid);
            gvVolumeWeek.DataBind();
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
                CallDataGrid();
            }
        }

        protected void gvVolumeWeek_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVolumeWeek.PageIndex = e.NewPageIndex;
            //
            CallDataGrid();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage package = new ExcelPackage();
            EppTools tools = new EppTools();
            //
            string fileName = "VolumeWeekReport";
            //string year = ddlYear.SelectedValue;]

            string dateFrom = tbStart.Text.Trim();
            string dateTo = tbEnd.Text.Trim();

            dateFrom = dateFrom != string.Empty ? dateFrom : "all";
            dateTo = dateTo != string.Empty ? dateTo : "all";

            int kioskid = Convert.ToInt32(ddlKiosk.SelectedItem.Value);

            DataTable table = Common.GetVolumeWeekReport(dateFrom, dateTo, kioskid);
            //
            tools.GenerateVolumeWeekReport(table, ref package, fileName);
            //
            var ws = package.Workbook.Worksheets[fileName];
            //
            // HEADER TITLE FORMATING 
            ws.Cells[2, 1].Value = "VOLUME (WEEK) REPORT ";
            ws.Cells[3, 1].Value = "Date From: " ;
            ws.Cells[4, 1].Value = "Agent: " + GlobalAccess.Username;

            ws.Cells[2, 1, 4, 1].Style.Font.Bold = true;
            ws.Cells[2, 1, 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // SAVING EXCEL FILE
            Response.Clear();
            Response.BinaryWrite(package.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=\"" + "VolumeWeek_Report.xlsx\"");

            Response.Flush();
            Response.End();

            package = null;
            ws = null;
            //
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CallDataGrid();
        }
    }
}