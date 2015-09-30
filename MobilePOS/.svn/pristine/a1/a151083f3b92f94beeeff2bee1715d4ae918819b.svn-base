using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
using System.Text.RegularExpressions;

namespace MobilePOS
{
    public partial class ProductDiscount : System.Web.UI.Page
    {
        private void CallDatagrid()
        {
            gvDiscount.DataSource = Discount.GetAllData();
            gvDiscount.DataBind();
        }

        private void LoadKioskList()
        {
            lbxKiosk.DataSource = Kiosk.GetAllKiosk();
            lbxKiosk.DataTextField = "Name";
            lbxKiosk.DataValueField = "KioskID";
            lbxKiosk.DataBind();
        }

        private void LoadProductList()
        {
            lbxProduct.DataSource = Products.GetAllProducts();
            lbxProduct.DataTextField = "Name";
            lbxProduct.DataValueField = "ID";
            lbxProduct.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CallDatagrid();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LoadKioskList();
            LoadProductList();
            mvMain.SetActiveView(vwAdd);

            pnlProducts.Enabled = false;
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            foreach(ListItem li in lbxKiosk.Items){

                if(li.Selected == true){
                    lbxKioskSel.Items.Add(li);
                }
            }
            //
            foreach(ListItem li in lbxKioskSel.Items){

                lbxKiosk.Items.Remove(li);
            }

            lbxKioskSel.ClearSelection();

            if(lbxKioskSel.Items.Count != 0){
                pnlProducts.Enabled = true;
            }
        }

        protected void btnRevoke_Click(object sender, EventArgs e)
        {
            foreach(ListItem li in lbxKioskSel.Items){

                if(li.Selected == true){
                    lbxKiosk.Items.Add(li);
                }
            }

            foreach(ListItem li in lbxKiosk.Items){
                lbxKioskSel.Items.Remove(li);
            }

            lbxKiosk.ClearSelection();

            if (lbxKioskSel.Items.Count == 0)
            {
                pnlProducts.Enabled = false;
            }
        }

        protected void btnProdAssign_Click(object sender, EventArgs e)
        {
            foreach(ListItem li in lbxProduct.Items){
                //
                if(li.Selected == true){
                    lbxProductSel.Items.Add(li);
                }
            }
            //
            foreach (ListItem li in lbxProductSel.Items)
            {
                lbxProduct.Items.Remove(li);
            }

            lbxProductSel.ClearSelection();
        }

        protected void btnProdRevoke_Click(object sender, EventArgs e)
        {
            foreach(ListItem li in lbxProductSel.Items){
                //
                if(li.Selected == true){
                    lbxProduct.Items.Add(li);
                }
            }
            //
            foreach(ListItem li in lbxProduct.Items){
                //
                lbxProductSel.Items.Remove(li);
            }
            //
            lbxProduct.ClearSelection();
        }

        protected void btnDiscountCancel_Click(object sender, EventArgs e)
        {
            mvMain.SetActiveView(vwMain);
        }

        protected void btnDiscountSave_Click(object sender, EventArgs e)
        {
            // kiosk validation
            if(lbxKioskSel.Items.Count == 0){
                (Master as Frame).PopUp("Kiosk is Required");
                return;
            }

            decimal value = Convert.ToDecimal(tbValue.Text);
            DateTime fromDate = DateTime.Parse(tbValidFrom.Text);
            DateTime? toDate = null;
            if (tbValidTo.Text != string.Empty)
            {
                toDate = DateTime.Parse(tbValidTo.Text);
            }
            string kioskAssign = null;

            foreach(ListItem li in lbxKioskSel.Items){
                kioskAssign += li.Value + ",";
            }

            kioskAssign = kioskAssign.Substring(0, kioskAssign.Length - 1);

            string productAssign = null;

            if(lbxProductSel.Items.Count != 0){
                foreach(ListItem li in lbxProductSel.Items){
                    productAssign += li.Value + ",";
                }
                productAssign = productAssign.Substring(0, productAssign.Length - 1);
            }

            string createdby = GlobalAccess.EmpID;
            string remarks = tbRemarks.Text;
            //
            var instance = new Discount();
            instance.Value = value;
            instance.ValidFrom = fromDate;
            instance.ValidTo = toDate;
            instance.KioskAssign = kioskAssign;
            instance.ProductAssign = productAssign;
            instance.CreatedBy = createdby;
            instance.Remarks = remarks;

            bool isInsert = Discount.InsertNewDiscount(instance);
            //
            if (isInsert)
            {
                (Master as Frame).PopUp("Insert Discount Success");
                CallDatagrid();
                mvMain.SetActiveView(vwMain);
            }
            else
            {
                (Master as Frame).PopUp("Insert Discount Failed");
            }
        }

    }
}