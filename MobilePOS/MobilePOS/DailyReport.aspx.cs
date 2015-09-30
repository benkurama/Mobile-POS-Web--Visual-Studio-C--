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
    public partial class DailyReport : System.Web.UI.Page
    {
        private void CallDatagrid()
        {
            string year = ddlYear.SelectedValue;
            int classid = Convert.ToInt32(ddlClass.SelectedItem.Value);

            gvDialyRep.DataSource = Common.GetDailyReport(year, classid);
            gvDialyRep.DataBind();
        }

        private void LoadYear(){
            //
            ddlYear.DataSource = Common.GetWeekRangeReport();
            ddlYear.DataTextField = "YearRange";
            ddlYear.DataValueField = "YearRange";
            ddlYear.DataBind();
        }

        private void loadSupervisor()
        {
            ddlClass.DataSource = Kiosk_Class.GetAllSupervisor();
            ddlClass.DataTextField = "SuperVisor";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            //
            ListItem item = new ListItem();
            item.Text = "   [<<<Select Here>>>]   ";
            item.Value = "0";
            ddlClass.Items.Insert(0, item);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadYear();
                loadSupervisor();
                CallDatagrid(); 
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelPackage package = new ExcelPackage();
            EppTools tools = new EppTools();
            //
            string fileName = "WeeklyReport";
            string year = ddlYear.SelectedValue;
            int classid = Convert.ToInt32(ddlClass.SelectedItem.Value);

            DataTable table = Common.GetDailyReport(year, classid);
            //
            tools.GenerateDailyReport(table, ref package, fileName);
            //
            var ws = package.Workbook.Worksheets[fileName];
            //
            // HEADER TITLE FORMATING 
            ws.Cells[2, 1].Value = "DAILY REPORT ";
            ws.Cells[3, 1].Value = "Year and Date ";
            ws.Cells[4, 1].Value = "Agent: " + GlobalAccess.Username;

            

            ws.Cells[2, 1, 4, 1].Style.Font.Bold = true;
            ws.Cells[2, 1, 4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // SAVING EXCEL FILE
            Response.Clear();
            Response.BinaryWrite(package.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=\"" + "Daily_Report.xlsx\"");

            Response.Flush();
            Response.End();

            package = null;
            ws = null;
        }

        protected void gvDialyRep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDialyRep.PageIndex = e.NewPageIndex;

            CallDatagrid();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CallDatagrid();
        }
    }
}