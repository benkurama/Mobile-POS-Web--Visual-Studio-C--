using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;

namespace MobilePOS
{
    public partial class InvoiceAssign : System.Web.UI.Page
    {
        private void loadKioskList()
        {
            ddlKiosk.DataSource = Kiosk.GetAllKiosk();
            ddlKiosk.DataTextField = "Name";
            ddlKiosk.DataValueField = "KioskID";
            ddlKiosk.DataBind();
            //
            ListItem item = new ListItem();
            item.Text = "   [<<<Select Here>>>]   ";
            item.Value = "0";
            ddlKiosk.Items.Insert(0, item);
        }

        private void CallDataGrid()
        {
            gvInvoice.DataSource = Booklet.GetAllData();
            gvInvoice.DataBind();
        }

        private void DoAdd()
        {
            mvMain.SetActiveView(vwAddBooklet);
            

            ClearFields();
        }

        private void ClearFields()
        {
            tbPrefix.Text = "";
            tbRangeFrom.Text = "";
            tbRangeTo.Text = "";
            ddlKiosk.SelectedIndex = 0;
            //
            tbPrefix.Enabled = true;
            ddlKiosk.Enabled = true;
        }

        private void DoEdit(int id)
        {
            mvMain.SetActiveView(vwAddBooklet);

            var instance = Booklet.SelectByID(id);

            tbPrefix.Text = instance.Prefix;
            tbRangeFrom.Text = instance.DigitFrom;
            tbRangeTo.Text = instance.DigitTo;
            tbPages.Text = instance.Pages+"";

            ddlKiosk.ClearSelection();
            ddlKiosk.Items.FindByValue(instance.KioskID+"").Selected = true;
            //
            tbPrefix.Enabled = false;
            ddlKiosk.Enabled = false;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            var onBlurScript = Page.ClientScript.GetPostBackEventReference(tbRangeTo, "OnBlur");
            tbRangeTo.Attributes.Add("onblur", onBlurScript);
        }

        private void HandleCustomPostbackEvent(string ctrlName, string args)
        {
            //Since this will get called for every postback, we only
            // want to handle a specific combination of control
            // and argument.
            if (ctrlName == tbRangeTo.UniqueID && args == "OnBlur")
            {
                if (tbRangeFrom.Text != "" && tbRangeTo.Text != "")
                {
                    int from = Convert.ToInt32(tbRangeFrom.Text);
                    int to = Convert.ToInt32(tbRangeTo.Text);

                    int pages = to - from;

                    bool positive = pages > 0;

                    pages = pages + 1;

                    if (positive)
                    {
                        tbPages.Text = pages + "";
                    }
                    else
                    {
                        (Master as Frame).PopUp("Invalid Range of Series");
                        tbPages.Text = "";
                    }
                }
                else
                {
                    tbPages.Text = "0";
                }
                
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                CallDataGrid();
                loadKioskList();
            }

            // Call post back for loading image after set to ImgURL TextBox
            var ctrlName = Request.Params[Page.postEventSourceID];
            var args = Request.Params[Page.postEventArgumentID];
            HandleCustomPostbackEvent(ctrlName, args);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DoAdd();
        }

        protected void btnBookletSave_Click(object sender, EventArgs e)
        {

            string prefix = tbPrefix.Text.ToUpper();
            string rangefrom = tbRangeFrom.Text.ToUpper();
            string rangeto = tbRangeTo.Text.ToUpper();
            int kioskid = Convert.ToInt32(ddlKiosk.SelectedValue);
            int hdnID = Convert.ToInt32(hdnBookletID.Value);
            int pages = Convert.ToInt32(tbPages.Text);

            var instance = new Booklet();

            instance.Prefix = prefix;
            instance.DigitFrom = rangefrom;
            instance.DigitTo = rangeto;
            instance.KioskID = kioskid;
            instance.CreatedBy = GlobalAccess.EmpID;
            instance.Pages = pages;


            bool isInsert = true;
            try
            {
                if (hdnID == 0)
                {
                    Booklet.InsertNewSeries(instance);
                }
                else
                {
                    instance.BookletID = hdnID;
                    Booklet.UpdateSelectedSeries(instance);
                }
                
            }
            catch (Exception ee)
            {
                isInsert = false;
                (Master as Frame).PopUp(ee.Message);
            }

            if (isInsert)
            {
                (Master as Frame).PopUp("Apply Success!");

                mvMain.SetActiveView(vwMain);
                CallDataGrid();
            }
        }

        protected void btnBookletCancel_Click(object sender, EventArgs e)
        {
            hdnBookletID.Value = "0";
            mvMain.SetActiveView(vwMain);
        }

        protected void gvInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch(e.CommandName){
                case "DoEdit":
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    hdnBookletID.Value = id+"";
                    DoEdit(id);
                    break;
            }
        }
    }
}