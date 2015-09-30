using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;
using System.Data;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using System.Configuration;

namespace MobilePOS
{
    public partial class AllProducts : System.Web.UI.Page
    {
        // =========================================================================
        // Main Functions
        // =========================================================================
        private void DoAdd()
        {
            hdnID.Value = "0";
            loadProductType();
            LoadColorType();
            LoadUnitType();
            clearFields();
            //
            trURL.Visible = false;
            trBrowse.Visible = true;

            rfvImgUrl.Enabled = false;
        }

        private void PopulateAndSet(int id){

            //
            hdnID.Value = id + "";
            loadProductType();
            LoadColorType();
            LoadUnitType();

            var instance = Products.GetSelectedProduct(id);

            tbName.Text = instance.Name;
            tbPrice.Text = instance.Price.ToString();
            //ddlProductType.SelectedItem.Text = instance.Category;

            ddlProductType.ClearSelection();
            ddlProductType.Items.FindByText(instance.Category).Selected = true;

            //tbUnit.Text = instance.Unit;
            ddlUnitType.ClearSelection();
            ddlUnitType.Items.FindByValue(instance.UnitCode).Selected = true;

            ddlColorType.ClearSelection();
            ddlColorType.Items.FindByValue(instance.ColorCode).Selected = true;

            tbImgURL.Text = instance.ImgUrl;

            imgProduct.ImageUrl = instance.ImgUrl;

            tbWidth.Text = instance.ImgWidth.ToString();
            tbHeight.Text = instance.ImgHeight.ToString();
            tbSpecs.Text = instance.Specs;

            tbProdCode.Text = instance.ProdCode;

            Session["ImageFullPath"] = instance.ImgUrl;
            //tbIMEI.Text = Convert.ToString(instance.IMEI);

            cbActive.Checked = instance.Active == "t"? true: false;
        }

        private void DoEdit(int id)
        {
            hdnIsVariant.Value = "0";
            PopulateAndSet(id);
            // Disable Widget
            tbName.Enabled = false;
            tbProdCode.Enabled = false;
            //

            trURL.Visible = false;
            rfvImgUrl.Enabled = false;

            trBrowse.Visible = true;
            rblUpload.SelectedIndex = 0;
            
        }

        private void DoCreateVariant(int id)
        {
            hdnIsVariant.Value = "1";
            PopulateAndSet(id);
            // Disable Widget
            tbName.Enabled = false;
            tbPrice.Enabled = false;
            ddlUnitType.Enabled = false;
            ddlProductType.Enabled = false; ;
            tbWidth.Enabled = false;
            tbHeight.Enabled = false;
            tbSpecs.Enabled = false;
            // null fields
            tbProdCode.Enabled = true;
            tbProdCode.Text = "";
            //tbIMEI.Text = "";
        }

        private void UploadExcelToDatabase(string filename)
        {
            // set temporary variable  to use where to put into Data Tables {...}
            #region set temporary variable  to use where to put into Data Tables
                string ProdCode = string.Empty;
                string Prodname = string.Empty;
                //int varIMEI = 0;
                string ImgUrl = string.Empty;
                int imgWidth = 0;
                int imgHeight = 0;
                string Specs = string.Empty;
                string Category = string.Empty;
                string UnitCode = string.Empty;
                string ColorCode = string.Empty;
                decimal Price = 0;
                string Active = string.Empty;
            #endregion

            // set initial DataTable Data{...}
            #region set initial DataTable Data
                DataTable dtTable = new DataTable("Product");
                dtTable.Columns.Add("ProdCode", Type.GetType("System.String"));
                dtTable.Columns.Add("ProdName", Type.GetType("System.String"));
                //dtTable.Columns.Add("IMEI", Type.GetType("System.Int32"));
                dtTable.Columns.Add("ImgUrl", Type.GetType("System.String"));
                dtTable.Columns.Add("Width", Type.GetType("System.Int32"));
                dtTable.Columns.Add("Height", Type.GetType("System.Int32"));
                dtTable.Columns.Add("Specs", Type.GetType("System.String"));
                dtTable.Columns.Add("ProdCateg", Type.GetType("System.Int32"));
                dtTable.Columns.Add("UnitCode", Type.GetType("System.String"));
                dtTable.Columns.Add("ColorCode", Type.GetType("System.String"));
                dtTable.Columns.Add("Price", Type.GetType("System.Decimal"));
                dtTable.Columns.Add("Active", Type.GetType("System.String"));
                dtTable.Columns.Add("EmpID", Type.GetType("System.String"));
            #endregion
            //
            int curIndex = 5;
            int TotalColumn = 11;

            bool isValidateFailed = false;
            //
            var existingFile = new FileInfo(filename);
            using (var package = new ExcelPackage(existingFile)){
                ExcelWorkbook workbook = package.Workbook;

                if(workbook != null){
                    if(workbook.Worksheets.Count > 0){
                        ExcelWorksheet currentWorkSheet = workbook.Worksheets.First();

                        for (int rowNumber = curIndex; rowNumber <= currentWorkSheet.Dimension.End.Row; rowNumber++)
                        {
                            DataRow drRows = dtTable.NewRow(); // create new row in DataTable
                            // Clear required fields
                            ProdCode = ""; Prodname = ""; //varIMEI = 0;

                            if(rowNumber >= 5){ // if row starts 5 index

                                for (int column = 1; column <= TotalColumn; column++) // populate columns by looping
                                {

                                    string DataValue = "";
                                    if (currentWorkSheet.Cells[rowNumber, column].Value != null) // assign values ins variable and detect if empty
                                    {
                                        DataValue = currentWorkSheet.Cells[rowNumber, column].Value.ToString().Trim();
                                    }

                                    #region Data Assign
                                    switch (column)
                                    {
                                        case 1:
                                            ProdCode = DataValue;
                                            break;
                                        case 2:
                                            Prodname = DataValue.Trim();
                                            break;
                                        //case 3:
                                        //    varIMEI = Convert.ToInt32(DataValue != "" ? DataValue : "0");
                                        //    break;
                                        case 3:
                                            ImgUrl = DataValue;
                                            break;
                                        case 4:
                                            imgWidth = Convert.ToInt32(DataValue != "" ? DataValue : "0");
                                            break;
                                        case 5:
                                            imgHeight = Convert.ToInt32(DataValue != "" ? DataValue : "0");
                                            break;
                                        case 6:
                                            Specs = DataValue;
                                            break;
                                        case 7:
                                            Category = DataValue;
                                            break;
                                        case 8:
                                            UnitCode = DataValue;
                                            break;
                                        case 9:
                                            ColorCode = DataValue;
                                            if(ColorCode != "DEF" && ColorCode != ""){
                                                Prodname = Prodname + " / " + ColorCode;
                                            }
                                            break;
                                        case 10:
                                            Price = Convert.ToDecimal(DataValue != "" ? DataValue : "0");
                                            break;
                                        case 11:
                                            Active = DataValue;
                                            break;
                                    }
                                    #endregion
                                }
                                //
                                #region Pass To DataTable

                                    if(ProdCode == "" &&  Prodname == ""){ // Skip the code process when null detected from EXCEL File
                                        continue;
                                    }

                                    drRows["ProdCode"] = ProdCode;
                                    drRows["ProdName"] = Prodname;
                                    //drRows["IMEI"] = varIMEI;
                                    drRows["ImgUrl"] = ImgUrl;
                                    drRows["Width"] = imgWidth;
                                    drRows["Height"] = imgHeight;
                                    drRows["Specs"] = Specs;
                                    //
                                    switch(Category){
                                        case "PHONE":
                                            drRows["ProdCateg"] = 1;
                                            break;
                                        case "TABLET":
                                            drRows["ProdCateg"] = 2;
                                            break;
                                        case "ACCESSORY":
                                            drRows["ProdCateg"] = 3;
                                            break;
                                    }
                                    drRows["UnitCode"] = UnitCode;
                                    drRows["ColorCode"] = ColorCode;
                                    drRows["Price"] = Price;
                                    drRows["Active"] = Active == "1" ? "t" : "f";
                                    drRows["EmpID"] = GlobalAccess.EmpID;
                                    //
                                    dtTable.Rows.Add(drRows);
                                #endregion
                                //
                                if(ProdCode == string.Empty){
                                    isValidateFailed = true;
                                }
                            }
                        }
                    }
                }
                //


                // detect if required records is filled
                if (!isValidateFailed)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dtTable);
                    //
                    string res = Common.InsertDataset(ds);

                    string[] result = res.Split(new char[] { '_' }, StringSplitOptions.None);

                    if (result[0] == "Success")
                    {
                        (Master as Frame).PopUp("Process Excel Data Success, Insert Count: " + result[1] + ", Duplicate detect: " + result[2]);

                        int type = Convert.ToInt32(hdnType.Value);
                        callDataGrid(type);
                        mvMain.ActiveViewIndex = 0;
                    }
                    else
                    {
                        (Master as Frame).PopUp(res);
                    }
                }
                else
                {
                    (Master as Frame).PopUp("Required Field is Missing, ex: (Product Code) Check your excel file");
                }
            };
        }
        // =========================================================================
        // Sub Functions
        // =========================================================================
        private void loadProductType()
        {
            //
            ddlProductType.DataSource = Common.GetAllProductTypes();
            ddlProductType.DataValueField = "ProdCategID";
            ddlProductType.DataTextField = "Description";
            ddlProductType.DataBind();

            ListItem item = new ListItem();
            item.Text = "   [<<<Select Here>>>]   ";
            item.Value = "0";
            ddlProductType.Items.Insert(0,item);
        }

        private void LoadColorType()
        {
            ddlColorType.DataSource = Common.GetColorTypes();
            ddlColorType.DataValueField = "ColorCode";
            ddlColorType.DataTextField = "ColorName";
            ddlColorType.DataBind();
        }

        private void LoadUnitType()
        {
            ddlUnitType.DataSource = Common.GetUnitTypes();
            ddlUnitType.DataValueField = "UnitCode";
            ddlUnitType.DataTextField = "UnitName";
            ddlUnitType.DataBind();
            //
            ListItem li = new ListItem();
            li.Text = "   [<<<Select Here>>>]   ";
            li.Value = "0";
            ddlUnitType.Items.Insert(0, li);
        }

        private void clearFields()
        {
            tbName.Text = "";
            tbPrice.Text = "";
            ddlProductType.SelectedItem.Value = "0";
            //tbUnit.Text = "";
            ddlUnitType.SelectedItem.Value = "0";
            tbImgURL.Text = "";
            tbWidth.Text = "";
            tbHeight.Text = "";
            tbSpecs.Text = "";
            imgProduct.ImageUrl = "";

            tbProdCode.Text = "";
            //tbIMEI.Text = "";
            ddlColorType.SelectedValue = "DEF";
            // clear settings
            tbName.Enabled = true;
            tbProdCode.Enabled = true;
            tbPrice.Enabled = true;
            tbImgURL.Enabled = true;
            ddlUnitType.Enabled = true;
            ddlProductType.Enabled = true;
            tbWidth.Enabled = true;
            tbHeight.Enabled = true;
            tbSpecs.Enabled = true;
            //
            Session.Clear();
        }

        private void MessageBox(string msg)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);

            string scrp = "$('#myModal').modal('show')";
            lblPopMessage.Text = msg;
            ClientScript.RegisterStartupScript(this.GetType(), "none",
            scrp, true
            );

        }

        private void callDataGrid(int type)
        {
            //gvProducts.DataSource = Products.GetAllProducts();
            string filter = tbSearchBox.Text.Trim();

            filter = filter == "" ? "all" : filter;

            gvProducts.DataSource = Products.GetAllProductsFilterByType(type, filter);
            gvProducts.DataBind();
            
            switch(type){
                case 1:
                    lblTitle.Text = "Phone Items";
                    break;
                case 2:
                    lblTitle.Text = "Tablet Items";
                    break;
                case 3:
                    lblTitle.Text = "Accessory Items";
                    break;
                default:
                    lblTitle.Text = "All Items";
                    break;
            }
            
        }

        private string ChangeProdName(string colorCode, string prodName)
        {
            // concatinate colorcode to prodname
            if (colorCode != "DEF")
            {
                string[] prodname = prodName.Split(new char[] { '/' }, StringSplitOptions.None);
                if (prodname.Length == 2)
                {
                    prodName = prodname[0].Trim() + " / " + colorCode;
                }
                else
                {
                    prodName = prodName + " / " + colorCode;
                }
            }
            else
            {
                if (prodName.Contains("/"))
                {
                    string[] prodname = prodName.Split(new char[] { '/' }, StringSplitOptions.None);
                    prodName = prodname[0].Trim();
                }
            }

            return prodName;
        }

        private void InsertProdMethod(Products ins, int Type)
        {
            bool isInserted = Products.InsertNewItem(ins, Type, GlobalAccess.EmpID);

            if (isInserted)
            {
                //MessageBox("Products has successfuly inserted");
                (Master as Frame).PopUp("Products has successfuly inserted");
                int type = Convert.ToInt32(hdnType.Value);
                callDataGrid(type);
                mvMain.ActiveViewIndex = 0;
                // back to normal
                clearFields();
            }
            else
            {
                //MessageBox("Data is not inserted, check your fields");
                (Master as Frame).PopUp("Data is not inserted, check your fields");
            }
        }

        private void UpdateProMethod(Products ins, int Type)
        {
            bool isUpdated = Products.UpdatedSelItem(ins, Type, GlobalAccess.EmpID);
            if (isUpdated)
            {
                //MessageBox("Products has successfuly updated");
                (Master as Frame).PopUp("Products has successfuly updated");
                int type = Convert.ToInt32(hdnType.Value);
                callDataGrid(type);
                mvMain.ActiveViewIndex = 0;
                // back to normal
                clearFields();
            }
            else
            {
                //MessageBox("Data is not updated, check your fields");
                (Master as Frame).PopUp("Data is not updated, check your fields");
            }
        }

        private void InactiveActiveProd()
        {

        }
        // =========================================================================
        // Overrides
        // =========================================================================
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                mvMain.ActiveViewIndex = 0;
                //
                int type = Convert.ToInt32(Request.QueryString["type"]);
                hdnType.Value = type + "";
                callDataGrid(type);//

               
            }
            //(Master as Frame).MessageBox("Twinkle");
            //(Master as Frame).AlertBox("Twinkle");
            //(Master as Frame).PopUp("testing");

            // Call post back for loading image after set to ImgURL TextBox
            var ctrlName = Request.Params[Page.postEventSourceID];
            var args = Request.Params[Page.postEventArgumentID];

            HandleCustomPostbackEvent(ctrlName, args);
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;

            int type = Convert.ToInt32(Request.QueryString["type"]);
            hdnType.Value = type + "";
            callDataGrid(type);
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    panelBox.Attributes.Add("class", "panel panel-default");
        //}

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            switch(e.CommandName){
                case "DoEdit":
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    mvMain.ActiveViewIndex = 1;
                    DoEdit(id);
                    break;
                case "DoAddCol":
                    int id2 = Convert.ToInt32(e.CommandArgument.ToString());
                    mvMain.ActiveViewIndex = 1;
                    DoCreateVariant(id2);
                    break;
                case "DoActive":
                    string[] active = Convert.ToString(e.CommandArgument.ToString()).Split(new char[] { ',' }, StringSplitOptions.None);
                    int id3 = Convert.ToInt32(active[1]);

                    if (active[0] == "t")
                    {
                        try
                        {
                            Products.UpdateActiveStatus("f", id3, GlobalAccess.EmpID);
                            int type = Convert.ToInt32(hdnType.Value);
                            callDataGrid(type);
                            //
                            (Master as Frame).PopUp("Selected Item is Inactive");
                        }
                        catch (Exception eee)
                        {
                            (Master as Frame).PopUp(eee.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            Products.UpdateActiveStatus("t", id3, GlobalAccess.EmpID);
                            int type = Convert.ToInt32(hdnType.Value);
                            callDataGrid(type);
                            //
                            (Master as Frame).PopUp("Selected Item is Active");
                        }
                        catch (Exception ee)
                        {
                            (Master as Frame).PopUp(ee.Message);
                        }
                    }
                    
                    break;
            }
        }

        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int prodid = Convert.ToInt32(gvProducts.DataKeys[e.Row.RowIndex].Value);
                var ins = Products.GetSelectedProduct(prodid);

                Button btnActive = e.Row.FindControl("btnActive") as Button;

                if (ins.Active == "t")
                {
                    btnActive.Text = "Inactive";
                    btnActive.BorderColor = Color.Red;
                }
                else
                {
                    btnActive.Text = "Activate";
                    btnActive.BorderColor = Color.Green;
                }   
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hdnID.Value);

            if (rblUpload.SelectedValue == "1" && id == 0)
            {
                string val = Session["ImageFullPath"] as string;
                if(val == null || val == string.Empty){
                    (Master as Frame).PopUp("No Selected Images");
                    return;
                }
            }

            
            try
            {
                Products ins = new Products();
                ins.ID = id;
                ins.Name = tbName.Text.ToUpper().Trim();
                ins.Price = Convert.ToDecimal(tbPrice.Text.Trim());
                int Type = Convert.ToInt32(ddlProductType.SelectedValue);
                ins.UnitCode = ddlUnitType.SelectedValue;

                if (rblUpload.SelectedValue == "1")
                {
                    ins.ImgUrl = Session["ImageFullPath"] as string;
                }
                else
                {
                    ins.ImgUrl = tbImgURL.Text.Trim();
                }

                ins.ImgWidth = Convert.ToInt32(tbWidth.Text.Trim());
                ins.ImgHeight = Convert.ToInt32(tbHeight.Text.Trim());
                ins.Specs = tbSpecs.Text.ToUpper();
                ins.DateCreated = DateTime.Now;
                ins.DateUpdated = DateTime.Now;
                ins.EmpID = GlobalAccess.EmpID;
                ins.ColorCode = ddlColorType.SelectedValue;
                //ins.IMEI = tbIMEI.Text.Trim();
                ins.ProdCode = tbProdCode.Text.ToUpper();

                ins.Active = cbActive.Checked ? "t":"f" ;

                ins.Name = ins.Name.Trim();

                // concatinate colorcode to prodname
                ins.Name = ChangeProdName(ins.ColorCode, ins.Name);
                //
                if (id == 0)// for Adding
                {
                    InsertProdMethod(ins, Type);
                }
                else // for Updating
                {
                    int isVariantCreation = Convert.ToInt32(hdnIsVariant.Value);

                    if (isVariantCreation == 0) // if edit mode
                    {
                        UpdateProMethod(ins, Type);
                    }
                    else
                    {// if create variant mode

                        InsertProdMethod(ins, Type);
                    }

                }
            }
            catch (Exception ee)
            {
               (Master as Frame).PopUp(ee.Message);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            mvMain.ActiveViewIndex = 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mvMain.ActiveViewIndex = 1;
            DoAdd();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(Request.QueryString["type"]);
            hdnType.Value = type + "";
            callDataGrid(type);
            // null all fields
            //clearFields();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            mvMain.ActiveViewIndex = 2;
        }

        protected void btnCancelUpload_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(hdnType.Value);
            callDataGrid(type);
            mvMain.ActiveViewIndex = 0;
        }

        protected void btnUploadNow_Click(object sender, EventArgs e)
        {
            //bool hasFile = true;
            if (afuFileUpload.HasFile)
            {
                //
                string filename = Server.MapPath("./ExcelFiles/" + afuFileUpload.FileName);
                afuFileUpload.SaveAs(filename);
                UploadExcelToDatabase(filename);
   
            }
            else
            {
                (Master as Frame).PopUp("Browse your Excel file first.");
            }

            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            var onBlurScript = Page.ClientScript.GetPostBackEventReference(tbImgURL, "OnBlur");
            tbImgURL.Attributes.Add("onblur", onBlurScript);
        }

        private void HandleCustomPostbackEvent(string ctrlName, string args)
        {
            //Since this will get called for every postback, we only
            // want to handle a specific combination of control
            // and argument.
            if (ctrlName == tbImgURL.UniqueID && args == "OnBlur")
            {
                
                if(rblUpload.SelectedValue == "2"){
                    imgProduct.ImageUrl = tbImgURL.Text;
                }
            }
        }

        protected void BtnSaveColor_Click(object sender, EventArgs e)
        {

            string colorname = ColorNameTxt.Text;
            string colorcode = ColorCodeTxt.Text;

            if (colorcode == "" || colorname == "")
            {
                (Master as Frame).PopUp("Please fill-up all the data");
                
                return;
            }

            colorcode = colorcode.ToUpper();

            bool IsInsert = Colors.InsertNewColor(colorcode, colorname);

            if (IsInsert)
            {
                (Master as Frame).PopUp("Color Added Successfully!");

                

                ColorCodeTxt.Text = " ";
                ColorNameTxt.Text = " ";

                LoadColorType();
            }
            else
            {
                (Master as Frame).PopUp("Insert failed");
            }
        }

        protected void btnImageSave_Click(object sender, EventArgs e)
        {
            if (afuImageSave.HasFile)
            {
                string filename = afuImageSave.FileName;
                string filepath = string.Format("~/{0}/{1}", "ImagesProduct", filename);
                string filepathtodb = string.Format("{0}/{1}", "ImagesProduct", filename);
                string filefullpath = Server.MapPath(filepath);

                afuImageSave.SaveAs(filefullpath);

                imgProduct.ImageUrl = filepath;

                string webtool = ConfigurationManager.ConnectionStrings["WebTool"].ConnectionString;

                Session["ImageFullPath"] = string.Format("http://{0}/{1}/{2}", webtool, "MobilePOS", filepathtodb);
            }
            else
            {
                (Master as Frame).PopUp("Browse your picture first.");
            }

            
        }

        protected void rblUpload_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = rblUpload.SelectedValue;

            switch(val){
                case "1":
                    trURL.Visible = false;
                    trBrowse.Visible = true;

                    rfvImgUrl.Enabled = false;
                    break;
                case "2":
                    trURL.Visible = true;
                    trBrowse.Visible = false;

                    rfvImgUrl.Enabled = true;
                    break;
            }
        }
    }
}