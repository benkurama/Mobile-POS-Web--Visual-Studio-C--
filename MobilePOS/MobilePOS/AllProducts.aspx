﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="MobilePOS.AllProducts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" type="text/javascript" ></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js" type="text/javascript" ></script>

    <script type="text/javascript">

        function showUploadConfirmation() {
            alert("Attachment complete!");
            
        }

        function uploadStarted(sender, args) {
            if (sender !== null && args !== null) {
                var filename = args.get_fileName();
                var filext = filename.substring(filename.lastIndexOf(".") + 1);
                if (filext == "xls" || filext == "XLS" || filext == "xlsx" || filext == "XLSX") {
                    return true;
                } else {
                    var err = new Error();
                    err.name = 'My API Input Error';
                    err.message = 'Invalid file format. File should be in excel format (e.g. .xls or .xlsx).';
                    throw (err);

                    return false;
                }
            }
        }

        function uploadImgStarted(sender, args) {
            if (sender !== null && args !== null) {
                var filename = args.get_fileName();

                var filext = filename.substring(filename.lastIndexOf(".") + 1);

                if (filext == "jpg" || filext == "png" || filext == "gif" || filext == "jpeg") {
                    return true;
                } else {
                    var err = new Error();
                    err.name = 'My API Input Error';
                    err.message = 'Invalid file format. File should be in picture (e.g. jpg/png/gif/jpeg).';
                    throw (err);

                    return false;
                }
            }
        }

        function ShowLoading() {
            $(".redirectClass").show();
        }
        
    </script>

    <style type="text/css">
        .style1
        {
            width: 150px;
            height: 55px;
        }
        .style2
        {
            height: 55px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="margin: 0 auto;width:950px; border-radius:6px; ">
        <div id="panelBox" class="panel panel-info" runat="server">

            <div class="panel-heading">
                <asp:Label ID="lblTitle" runat="server" Text="Products" Font-Bold="True"></asp:Label>
            </div>
            <div class="panel-body">
                
                <asp:HiddenField ID="hdnID" Value="0" runat="server"/>
                <asp:HiddenField ID="hdnIsVariant" Value="0" runat="server"/>
                <asp:HiddenField ID="hdnType" Value="0" runat="server"/>

                <!-- set up the modal to start hidden and fade in and out -->
                <div id="myModal" class="modal fade">
                    <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- dialog body -->
                        <div class="modal-body">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>

                            <asp:Label ID="lblPopMessage" runat="server" Text="Label"></asp:Label>

                        </div>
                        <!-- dialog buttons -->
                    <div class="modal-footer"><button type="button" class="btn btn-primary" data-dismiss="modal">OK</button></div>
                    </div>
                    </div>
                </div>

                <asp:MultiView ID="mvMain" runat="server">
                    <asp:View ID="vMain" runat="server">
                    
                        <table>
                            <tr>
                                <td>
                                
                                <table width=100%>
                                    <tr>
                                        <td align="left">
                                            <asp:Panel runat="server" DefaultButton="btnFilter">
                                                Search By Name: 
                                                <asp:TextBox ID="tbSearchBox" runat="server" Width="200px" 
                                                    CssClass="text-primary" ></asp:TextBox>
                                                <asp:Button ID="btnFilter" runat="server" Text="Filter" 
                                                    onclick="btnFilter_Click" />
                                             </asp:Panel>
                                        </td>

                                        <td align="left">
                                            <asp:Button ID="btnImport" runat="server" Text="Import Products From Excel" 
                                                CssClass="btn btn-primary" onclick="btnImport_Click"   />
                                        </td>
                                        
                                        <td align="right">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add Item" 
                                                CssClass="btn btn-default" onclick="btnAdd_Click"  />
                                        </td>
                                    </tr>
                                </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvProducts" runat="server" 
                                    GridLines="None"  
                                    AutoGenerateColumns="false"
                                    DataKeyNames="ID"
                                    AllowPaging="true" PageSize="20"  
                                    CssClass="mGrid"  
                                    PagerStyle-CssClass="pgr"  
                                    AlternatingRowStyle-CssClass="alt" 
                                        onpageindexchanging="gvProducts_PageIndexChanging" 
                                        onrowcommand="gvProducts_RowCommand" onrowdatabound="gvProducts_RowDataBound"
                                    >
                                    <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                            
                                    <Columns>
                                        <asp:BoundField DataField="ProdCode" HeaderStyle-Width="100" HeaderText="Item Code" />
                                        <asp:BoundField DataField="Name" HeaderStyle-Width="200" HeaderText="Item Name" />
                                        
                                        <asp:BoundField DataField="Category" HeaderStyle-Width="100" HeaderText="Type" />
                                        <asp:BoundField DataField="UnitCode" HeaderStyle-Width="100" HeaderText="Unit Code" />
                                        
                                        <asp:BoundField DataField="ColorCode" HeaderStyle-Width="100" HeaderText="Color Code" />
                                        <asp:BoundField DataField="Price" HeaderStyle-Width="100" HeaderText="Price" DataFormatString="{0:#,0}"/>
                                        <asp:TemplateField HeaderStyle-Width="300" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditRow" runat="server" Text="  Edit  " CssClass="btn btn-warning btn-xs" 
                                                CommandName="DoEdit" CommandArgument='<%# Bind("ID") %>' />

                                                <asp:Button ID="btnProdColor" runat="server" Text="New Color" CssClass="btn btn-warning btn-xs" 
                                                CommandName="DoAddCol" CommandArgument='<%# Bind("ID") %>' />

                                                <asp:Button ID="btnActive" runat="server" Text="Inactive" CssClass="btn btn-warning btn-xs" 
                                                CommandName="DoActive" CommandArgument='<%# Eval("Active") +","+Eval("ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            
                        </table>

                    </asp:View>

                    <asp:View ID="subView" runat="server">

                    <table>
                        <tr>
                            <td>
                                <div style="width:500px;">

                              <div class="panel panel-default">
                              <div class="panel-heading">
                                <h4>Edit Mode: </h4>
                     
                              </div>
                              <div class="panel-body">
                                <asp:Panel runat="server" DefaultButton="btnSave">
                                    <table width="450">
                                   
                                    <tr>
                                        <td class="style1">
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Product Code: </span>
                                            <span style="color: Red;">*</span>
                                        </td>
                                        <td class="style2">
                                             <asp:TextBox ID="tbProdCode" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Product Code is required" 
                                                         ControlToValidate="tbProdCode" ValidationGroup="Unit" Display="Dynamic" 
                                                            Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><br /></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Name: </span>
                                            <span style="color: Red;">*</span>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="tbName" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                             
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is required" 
                                            ControlToValidate="tbName" ValidationGroup="Unit" Display="Dynamic" 
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><br /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                       
                                            <asp:RadioButtonList ID="rblUpload" runat="server" RepeatDirection="Horizontal" 
                                                onselectedindexchanged="rblUpload_SelectedIndexChanged" AutoPostBack="True" >
                                                <asp:ListItem style="padding:10px;" Value="1" Selected="true">Browse from File</asp:ListItem>
                                                <asp:ListItem Value="2">Image Url</asp:ListItem>
                                            </asp:RadioButtonList>
                                           
                                            
                                        </td>
                                    </tr>

                                    

                                    <tr id="trURL" runat="server">
                                        <td >
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Image URL: </span>
                                            <span style="color: Red;">*</span>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="tbImgURL" runat="server" CssClass="form-control hasclear" 
                                             ClientIDMode="Static" onblur="__doPostBack('tbImgURL','OnBlur');"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="rfvImgUrl" runat="server" ErrorMessage="URL is required" 
                                             ControlToValidate="tbImgURL" ValidationGroup="Unit" Display="Dynamic" 
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr id="trBrowse" runat="server">
                                        <td colspan="2">
                                            <table>
                                                <tr>
                                                    <td>
                                                    <asp:Panel runat="server" DefaultButton="btnImageSave">
                                                    
                                                        Upload From File...
                                                        <ajaxToolkit:AsyncFileUpload ID="afuImageSave" runat="server" OnClientUploadStarted="uploadImgStarted" 
                                                            OnClientUploadComplete="showUploadConfirmation" 
                                                                UploadingBackColor="Yellow" ThrobberID="spanUploading"/>
                                                                <br />
                                                        <asp:Button ID="btnImageSave" runat="server" Text="Upload Images" CssClass="btn btn-primary"
                                                            onclick="btnImageSave_Click" />
                                                    </asp:Panel>   
                                                    
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><br /></td>
                                    </tr>
                                    <tr>
                                        <td  colspan="2">
                                            <table style="width:400px;margin:0 auto;">
                                                <tr>

                                                    <td style="padding-right:15px;" valign="top">
                                                        <span style="font-family:Arial,Verdana;font-size:14px;">Image Width: </span>
                                                        <span style="color: Red;">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbWidth" runat="server" CssClass="form-control"  Width="80"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Width is required" 
                                                         ControlToValidate="tbWidth" ValidationGroup="Unit" Display="Dynamic" 
                                                            Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                                            <br />
                                                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="tbWidth" Type="Integer" Display="Dynamic"
                                                         Operator="DataTypeCheck" ErrorMessage="Not a valid number" runat="server" Font-Italic="True" Font-Size="Smaller"
                                                         ValidationGroup="Unit">
                                                         </asp:CompareValidator>
                                                    </td>

                                                    <td style="padding-right:15px;" valign="top">
                                                        <span style="font-family:Arial,Verdana;font-size:14px;">Image Height: </span>
                                                        <span style="color: Red;">*</span>
                                                    </td>
                                                    <td style="padding-right:15px;">
                                                        <asp:TextBox ID="tbHeight" runat="server" CssClass="form-control"  Width="80"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Height is required" 
                                                         ControlToValidate="tbHeight" ValidationGroup="Unit" Display="Dynamic" 
                                                            Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                                            <br />
                                                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="tbHeight" Type="Integer" Display="Dynamic"
                                                         Operator="DataTypeCheck" ErrorMessage="Not a valid number" runat="server" Font-Italic="True" Font-Size="Smaller"
                                                         ValidationGroup="Unit" >
                                                         </asp:CompareValidator>
                                                    </td>
                                                    
                                                </tr>
                                                
                                            </table>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td >
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Specs: </span>
                                            <span style="color: Red;">*</span>
                                        </td>
                                        <td>
                                            
                                             <asp:TextBox ID="tbSpecs" runat="server" CssClass="form-control hasclear" 
                                                 style="text-transform:uppercase;overflow:auto;" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Specs is required" 
                                                         ControlToValidate="tbSpecs" ValidationGroup="Unit" Display="Dynamic" 
                                                            Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><br /></td>
                                    </tr>
                                    
                                    <tr>
                                        <td >
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Product Type: </span>
                                            <span style="color: Red;">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlProductType" runat="server" CssClass="dropdown-header" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Type is required" 
                                            ControlToValidate="ddlProductType" ValidationGroup="Unit" Display="Dynamic" InitialValue="0"
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><br /></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Unit: </span>
                                            <span style="color: Red;">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnitType" runat="server" CssClass="dropdown-header" 
                                                Width="200px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Unit is Required" 
                                            ControlToValidate="ddlUnitType" ValidationGroup="Unit" Display="Dynamic" InitialValue="0"
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><br /></td>
                                    </tr>

                                    <tr>
                                        <td >
                                            <span style="font-family:Arial,Verdana;font-size:14px;">Color: </span>
                                            <span style="color: Red;">*</span>
                                        </td>

                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlColorType" runat="server" CssClass="dropdown-header" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp&nbsp&nbsp
                                                        <!-- Trigger the modal with a button -->
                                                        <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal1">
                                                            +</button>
                                                        <!-- Modal -->
                                                        <div id="myModal1" align="center" class="modal fade" role="dialog">
                                                            <div class="modal-dialog">
                                                                <!-- Modal content-->
                                                                <div class="modal-content" style="width: 500px;">
                                                                    <div class="modal-header">
                                                                        <button type="button" class="close" data-dismiss="modal">
                                                                            &times;</button>
                                                                        <h4 class="modal-title">
                                                                            Add New Color</h4>
                                                                    </div>
                                                                    <div class="modal-body">
                                                                        <div class="container-fluid">
                                                                            <div class="row">
                                                                                <div class="col-md-3">
                                                                                    Color Code:
                                                                                </div>
                                                                                <div class="col-md-8 ">
                                                                                    <asp:TextBox ID="ColorCodeTxt" runat="server" MaxLength="3" Width="250px"></asp:TextBox></div>
                                                                            </div>
                                                                        </div>
                                                                        <br>
                                                                        <div class="row">
                                                                            &nbsp;&nbsp;
                                                                            <div class="col-md-3">
                                                                                &nbsp;&nbsp; Color Name:
                                                                            </div>
                                                                            <div class="col-md-8 ">
                                                                                <asp:TextBox ID="ColorNameTxt" runat="server" Width="250px"></asp:TextBox></div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="modal-footer">
                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                                                            Close</button>
                                                                        <asp:Button ID="BtnSaveColor" runat="server" Text="Save" CssClass="btn btn-info"
                                                                            OnClick="BtnSaveColor_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- End Modal -->
                                                    </td>
                                                    </tr>
                                                       
                                                    </table>
                                        </td>

                                       
                                    </tr>
                                    <tr>
                                        <td ><br /></td>
                                    </tr>
                                    <tr>
                                        <td >
                                            
                                               <span style="font-family:Arial,Verdana;font-size:14px;">Price: </span>
                                               <span style="color: Red;">*</span>
                                        </td>
                                        <td>
                                             <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control hasclear" 
                                                 style="text-transform:uppercase;" ></asp:TextBox>

                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price is required" 
                                                ControlToValidate="tbPrice" ValidationGroup="Unit" Display="Dynamic" 
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                                <br />
                                             <asp:CompareValidator ID="cmprValidatorDoubleType" ControlToValidate="tbPrice" Type="Currency" Display="Dynamic"
                                                 Operator="DataTypeCheck" ErrorMessage="Not a valid amount." runat="server" Font-Italic="True" Font-Size="Smaller"
                                                 ValidationGroup="Unit">
                                                 </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="cbActive" runat="server" Text=" Product is still active" 
                                                Checked="True" />
                                        </td>
                                    </tr>
                                    

                                </table>
                                    

                                </asp:Panel>
                              </div>
                              <div class="panel-footer">

                                    <table style="width:400px;margin:0 auto;">
                                        <tr>
                                            <td style="padding-right:15px;">
                                                <asp:Button ID="btnSave" runat="server" Text="SAVE " 
                                                 CssClass="btn btn-success btn-block" onclick="btnSave_Click"  ValidationGroup="Unit"/>
                                            </td>
                                            <td style="padding-left:15px;">
                                                <asp:Button ID="btnClose" runat="server" Text="CLOSE" 
                                                CssClass="btn btn-warning btn-block" onclick="btnClose_Click"  />
                                            </td>
                                        </tr>
                                    </table>
                                    
                              </div>
                            </div>

                        </div>
                            </td>
                            <td valign="top">
                                <div style="width:400px;padding-left:50px;">
                                    <div class="panel panel-default">
                                      <div class="panel-heading">
                                        <h4>Image Preview: </h4>
                                      </div>
                                      <div class="panel-body" align="center">
                                      <asp:Image ID="imgProduct" runat="server" style="max-width:320px;" />
                                            
                                      </div>
 
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    </asp:View>
                    <asp:View ID="vImportExcel" runat="server">
                        <h3><b>Import Products</b></h3>
                        <p>
                            You can supply your product list in a csv format for quick importing and 
                            updating. You can download a CSV template to get you started. Download  <asp:HyperLink ID="hlProductList" runat="server" NavigateUrl="ExcelFiles/MobilePOS Product List.xlsx">here</asp:HyperLink>.</p>
                        
                        
                        <b>Product file</b>
                        <ajaxToolkit:AsyncFileUpload ID="afuFileUpload" runat="server" OnClientUploadStarted="uploadStarted" OnClientUploadComplete="showUploadConfirmation"
                        UploadingBackColor="Yellow" ThrobberID="spanUploading"/>
                        <span id="spanUploading" runat="server">Uploading...</span>
                        <table width=100%>
                            <tr>
                                <td align="center" style="font-size:11px;color:Gray;">
                                
                                    .........................................................................................................................................................................................................................................................................
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                     <asp:Button ID="btnUploadNow" runat="server" CssClass="btn btn-success" 
                                         Text="Import from Excel" Width="200px" onclick="btnUploadNow_Click"/>
                                         &nbsp;&nbsp;&nbsp;
                                     <asp:Button ID="btnCancelUpload" runat="server" CssClass="btn btn-warning" 
                                         Text="Close" Width="200px" onclick="btnCancelUpload_Click"/>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>

                </div>

            </div>
        </div>


</asp:Content>
