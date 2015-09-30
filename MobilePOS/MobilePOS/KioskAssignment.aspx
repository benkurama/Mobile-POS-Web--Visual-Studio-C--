﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="KioskAssignment.aspx.cs" Inherits="MobilePOS.KioskAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="margin: 0 auto;width:950px; border-radius:6px; ">
        <div id="panelBox" class="panel panel-info" runat="server">
            <div class="panel-heading">
                <asp:Label ID="lblTitle" runat="server" Text="Kiosk Assignment" Font-Bold="True"></asp:Label>
            </div>
            <div class="panel-body">

            <asp:HiddenField ID="hdnKioskID" Value="0" runat="server"/>

                <asp:MultiView ID="mvMain" runat="server">
                    <asp:View ID="vMain" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add Kiosk" 
                                                CssClass="btn btn-default" onclick="btnAdd_Click"  />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvKiosk" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns=false
                                        DataKeyNames="KioskID"
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" onrowcommand="gvKiosk_RowCommand" onpageindexchanging="gvKiosk_PageIndexChanging" 
                                    >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="KioskCode" HeaderStyle-Width="60" HeaderText="Kiosk ID" />
                                            <asp:BoundField DataField="Name" HeaderStyle-Width="200" HeaderText="Kiosk Name" />
                                            <asp:BoundField DataField="Location" HeaderStyle-Width="200" HeaderText="Location" />
                                            <asp:BoundField DataField="_Supervisor" HeaderStyle-Width="120" HeaderText="Supervisors" />

                                            <asp:TemplateField HeaderStyle-Width="300" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnAssignRow" runat="server" Text="Add Items" CssClass="btn btn-warning btn-xs" CommandName="DoAssign" CommandArgument='<%# Bind("KioskID") %>' />
                                                    <asp:Button ID="btnEditRow" runat="server" Text="Edit" CssClass="btn btn-warning btn-xs" CommandName="DoEdit" CommandArgument='<%# Bind("KioskID") %>'/>
                                                    <asp:Button ID="btnViewRow" runat="server" Text="View Items" CssClass="btn btn-warning btn-xs" CommandName="DoView" CommandArgument='<%# Bind("KioskID") %>'/>
                                                    <asp:Button ID="btnIMEI" runat="server" Text="View IMEI" CssClass="btn btn-warning btn-xs" CommandName="DoIMEI" CommandArgument='<%# Bind("KioskID") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vAssign" runat="server">

                        <div style="width: 900px;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4>
                                        <asp:Label ID="LblKioskName" runat="server" Text="Name"></asp:Label>
                                        <br />
                                    </h4>
                                    <h5>
                                    <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                                    </h5>
                                </div>
                                <div class="panel-body">
                                    <asp:UpdatePanel ID="updPanel" runat="server" >
                                        <ContentTemplate >
                                       
                                        <table>

                                            <tr>
                                                <td>

                                                    <table width="500">
                                                        <tr>
                                                            <td style="padding:5px;">
                                                                <b>Distributor Reciept: </b><span style="color:Red;">*</span>
                                                                <asp:TextBox ID="tbDistReciept" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Distributor Reciept is required" 
                                                                 ControlToValidate="tbDistReciept" ValidationGroup="ProdSel" Display="Dynamic" Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </td>
                                                            <td style="padding:5px;">
                                                                
                                                                <b>Reference Number : </b><span style="color:Red;">*</span>
                                                                <asp:TextBox ID="tbReference" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Reference Number is required" 
                                                                 ControlToValidate="tbReference" ValidationGroup="ProdSel" Display="Dynamic" Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="padding-bottom:10px;">
                                                    <table>
                                                        <tr >
                                                            <td colspan=3>
                                                                Phone Stocks  <--->  Kiosk Stocks
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td style="width:300px;">
                                                                <asp:ListBox ID="lbxPhone" runat="server" Height="250px" Width="100%" 
                                                                    SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                            <td style="width:50px;" valign="middle" align="center">
                                                                <asp:Button ID="btnAssign" runat="server" Text=">>" style="margin-bottom:10px;" 
                                                                    onclick="btnAssign_Click"/>
                                                                
                                                                <asp:Button ID="btnRevoke" runat="server" Text="<<" onclick="btnRevoke_Click" />
                                                            </td>
                                                            <td style="width:300px;">
                                                                <asp:ListBox ID="lbxPhoneSel" runat="server" Height="250px" Width="100%" 
                                                                    SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="padding-left:40px;">

                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td style="padding-bottom:10px;">
                                                    <table>
                                                        <tr>
                                                            <td colspan=3>
                                                                Tablet Stocks  <--->  Kiosk Stocks
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:300px;">
                                                                <asp:ListBox ID="lbxTablet" runat="server" Height="250px" Width="100%" 
                                                                    SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                            <td style="width:50px;" valign="middle" align="center">
                                                                <asp:Button ID="btnAssignTab" runat="server" Text=">>" 
                                                                    style="margin-bottom:10px;" onclick="btnAssignTab_Click" 
                                                                    />
                                                                
                                                                <asp:Button ID="btnRevokeTab" runat="server" Text="<<" 
                                                                    onclick="btnRevokeTab_Click"  />
                                                            </td>
                                                            <td style="width:300px;">
                                                                <asp:ListBox ID="lbxTabletSel" runat="server" Height="250px" Width="100%" 
                                                                    SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td colspan=3>
                                                                Accessory Stocks  <--->  Kiosk Stocks
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:300px;">
                                                                <asp:ListBox ID="lbxAccessory" runat="server" Height="250px" Width="100%" 
                                                                    SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                            <td style="width:50px;" valign="middle" align="center">
                                                                <asp:Button ID="btnAsssignAcc" runat="server" Text=">>" 
                                                                    style="margin-bottom:10px;" onclick="btnAsssignAcc_Click" 
                                                                    />
                                                                
                                                                <asp:Button ID="btnRevokeAcc" runat="server" Text="<<" 
                                                                    onclick="btnRevokeAcc_Click" />
                                                            </td>
                                                            <td style="width:300px;">
                                                                <asp:ListBox ID="lbxAccessorySel" runat="server" Height="250px" Width="100%" 
                                                                    SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            <br />
                                                                <b> Remarks:</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="tbRemarks" runat="server" Height="80px" TextMode="MultiLine" 
                                                                    Width="300px" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                </div>
                                <div class="panel-footer">
                                    <table style="width:400px;margin:0 auto;">
                                        <tr>
                                            <td style="padding-right:15px;">
                                                <asp:Button ID="btnNext" runat="server" Text="NEXT " 
                                                 CssClass="btn btn-success btn-block" onclick="btnNext_Click"   ValidationGroup="ProdSel"/>
                                            </td>
                                            <td style="padding-left:15px;">
                                                <asp:Button ID="btnClose" runat="server" Text="CANCEL" 
                                                CssClass="btn btn-warning btn-block" onclick="btnClose_Click"   />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>

                    </asp:View>
                    <asp:View ID="vSetStocks" runat="server">
                        <div style="width: 900px;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4>
                                        <asp:Label ID="lblNameKiosk" runat="server" Text="Name"></asp:Label>
                                        <br />
                                    </h4>
                                    <h5>
                                        <asp:Label ID="lblLoc" runat="server" Text="Location"></asp:Label>
                                    </h5>
                                </div>
                                <div class="panel-body">

                                
                                    <table>

                                        
                                        <tr>
                                            <td valign="top" style="padding-right:5px;">
                                                <div style="border: 1px solid #ccc; padding: 5px; width: 280px;">
                                                    Set Phone Stocks here:
                                                    <asp:Panel ID="pnlHolder" runat="server">
                                                    </asp:Panel>
                                                    <asp:GridView ID="gvStockPhone" runat="server" GridLines="None" DataKeyNames="Value"
                                                        AutoGenerateColumns="false" OnRowDataBound="gvStockSet_RowDataBound">
                                                        <Columns>
                                                            
                                                            <asp:BoundField DataField="Text" HeaderStyle-Width="200" HeaderText="Product Name" />
                                                            <asp:TemplateField HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Center" HeaderText="Stocks"><ItemTemplate><asp:TextBox ID="tbStocks" runat="server" Width="50"></asp:TextBox></ItemTemplate></asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>

                                            <td valign="top" style="padding-right:5px;">
                                                <div style="border: 1px solid #ccc; padding: 5px; width: 280px;">
                                                    Set Tablet Stocks here:
                                                    <asp:Panel ID="Panel1" runat="server">
                                                    </asp:Panel>
                                                    <asp:GridView ID="gvStockTablet" runat="server" GridLines="None" DataKeyNames="Value"
                                                        AutoGenerateColumns="false" onrowdatabound="gvStockTablet_RowDataBound" >
                                                        <Columns>
                                                            
                                                            <asp:BoundField DataField="Text" HeaderStyle-Width="200" HeaderText="Product Name" />
                                                            <asp:TemplateField HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Center" HeaderText="Stocks"><ItemTemplate><asp:TextBox ID="tbStocks" runat="server" Width="50"></asp:TextBox></ItemTemplate></asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>

                                            <td valign="top">
                                                <div style="border: 1px solid #ccc; padding: 5px; width: 280px;">
                                                    Set Accessory Stocks here:
                                                    <asp:Panel ID="Panel2" runat="server">
                                                    </asp:Panel>
                                                    <asp:GridView ID="gvStockAccessory" runat="server" GridLines="None" DataKeyNames="Value"
                                                        AutoGenerateColumns="false" 
                                                        onrowdatabound="gvStockAccessory_RowDataBound" >
                                                        <Columns>
                                                            
                                                            <asp:BoundField DataField="Text" HeaderStyle-Width="200" HeaderText="Product Name" />
                                                            <asp:TemplateField HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Center" HeaderText="Stocks"><ItemTemplate><asp:TextBox ID="tbStocks" runat="server" Width="50"></asp:TextBox></ItemTemplate></asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </td>

                                        </tr>
                                    </table>
                                    
                                </div>
                                <div class="panel-footer">
                                    <table style="width: 400px; margin: 0 auto;">
                                        <tr>
                                            <td style="padding-right: 15px;">
                                                <asp:Button ID="btnPostSave" runat="server" Text="SAVE " 
                                                    CssClass="btn btn-success btn-block" onclick="btnPostSave_Click"
                                                     />
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnCloseFinal" runat="server" Text="BACK" 
                                                    CssClass="btn btn-warning btn-block" onclick="btnCloseFinal_Click"
                                                    
                                                     />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="vwAddKiosk" runat="server">
                        <div style="width: 500px;margin: 0 auto;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3>
                                        Add New Kiosk
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    
                                    <asp:Panel runat="server" DefaultButton="btnKioskSave">
                                    
                                    <table >
                                        <tr>
                                            <td style="width:150px;">
                                                Kiosk Code:
                                                <span style="color:Red;">*</span>
                                            </td>

                                            <td style="width:400px;">
                                                <asp:TextBox ID="tbKioskCode" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Kiosk Code is required" ControlToValidate="tbKioskCode" 
                                                ValidationGroup="kiosk" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </asp:RequiredFieldValidator>
                                                
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td style="width:150px;">
                                                Kiosk Name:
                                                <span style="color:Red;">*</span>
                                            </td>

                                            <td style="width:400px;">
                                                <asp:TextBox ID="tbKioskName" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Name is required" ControlToValidate="tbKioskName" 
                                                ValidationGroup="kiosk" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </asp:RequiredFieldValidator>
                                                
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td >
                                                Location:
                                                <span style="color:Red;">*</span>
                                            </td>

                                            <td >
                                                <asp:TextBox ID="tbKioskLocation" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Location is required" ControlToValidate="tbKioskLocation" 
                                                ValidationGroup="kiosk" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </asp:RequiredFieldValidator>
                                                
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td >
                                                Select Supervisor:
                                            </td>

                                            <td >
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdown-header" Width="150px">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlClass"
                                                                Display="Dynamic" ErrorMessage="Supervisor is required" Font-Italic="True" Font-Size="Smaller"
                                                                InitialValue="0" ValidationGroup="kiosk"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <!-- Trigger the modal with a button -->
                                                            <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">
                                                                +</button>
                                                            &nbsp;<span class="style1"> <em>add supervisor</em></span>
                                                        </td>
                                                    </tr>
                                                    <!-- Modal -->
                                                    <div id="myModal" align="center" class="modal fade" role="dialog">
                                                        <div class="modal-dialog">
                                                            <!-- Modal content-->
                                                            <div class="modal-content" style="width: 400px;">
                                                                <div class="modal-header">
                                                                    <button type="button" class="close" data-dismiss="modal">
                                                                        &times;</button>
                                                                    <h4 class="modal-title">
                                                                        Add New Supervisor</h4>
                                                                </div>
                                                                <div class="modal-body">
                                                                    <div class="modal-body">
                                                                        <div class="container-fluid">
                                                                            <div class="row">
                                                                                <div class="col-md-2">
                                                                                    Name:
                                                                                </div>
                                                                                <div class="col-md-8 ">
                                                                                    <asp:TextBox ID="SupervisorNameTxt" runat="server" Width="250px" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox></div>
                                                                            </div>
                                                                            <br></br>
                                                                            <div class="row">
                                                                                <div class="col-md-2">
                                                                                    Class:
                                                                                </div>
                                                                                <div class="col-md-8 ">
                                                                                    <asp:TextBox ID="ClassTypeTxt" runat="server" Width="250px" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox></div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="modal-footer">
                                                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                                                            Close</button>
                                                                        <asp:Button ID="BtnSaveSupervisor" runat="server" Text="Save" CssClass="btn btn-info"
                                                                            OnClick="BtnSaveSupervisor_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <caption>
                                                    </div>
                                                    </caption>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td >
                                                Remarks:
                                            </td>
                                            
                                            <td >
                                                <asp:TextBox ID="tbKioskRemarks" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                </div>
                                <div class="panel-footer">
                                    <table style="width: 400px; margin: 0 auto;">
                                        <tr>
                                            <td style="padding-right: 15px;">
                                                <asp:Button ID="btnKioskSave" runat="server" Text="SAVE " 
                                                    CssClass="btn btn-success btn-block" ValidationGroup="kiosk" onclick="btnKioskSave_Click"
                                                     style="width:200px;"/>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnKioskCancel" runat="server" Text="CANCEL" 
                                                    CssClass="btn btn-warning btn-block" onclick="btnKioskCancel_Click" 
                                                    style="width:200px;"
                                                     />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="vInventory">
                        <table>
                            <tr>
                                <td>
                                    
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblKioskLabel" runat="server" Text="Kiosk Name" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td  >
                                                 <asp:Button ID="btnBackMain" runat="server" Text="Return" 
                                                    CssClass="btn btn-default btn-block" 
                                                    style="width:200px;float:right;" onclick="btnBackMain_Click"
                                                     />
                                </td>
                                        </tr>
                                    </table>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvInventory" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns="false"
                                        DataKeyNames="InventoryID"
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" onrowcommand="gvInventory_RowCommand" onrowdatabound="gvInventory_RowDataBound" 
                                          >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="InventoryID" HeaderStyle-Width="50" HeaderText="ID" />
                                            <asp:BoundField DataField="ProdName_" HeaderStyle-Width="200" HeaderText="Product Name" />
                                            <asp:BoundField DataField="StockIn" HeaderStyle-Width="80" HeaderText="Stock In" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="InsertDate" HeaderStyle-Width="180" HeaderText="Date Inserted" />
                                            <asp:BoundField DataField="StockOut" HeaderStyle-Width="80" HeaderText="Stock Out" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="StockDiff_" HeaderStyle-Width="80" HeaderText="Balance" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="Price_" HeaderStyle-Width="80" HeaderText="Orig Price" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0}"/>
                                            <asp:BoundField DataField="PriceDiscount_" HeaderStyle-Width="80" HeaderText="Discount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0}"/>
                                            <asp:TemplateField HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Center"><ItemTemplate><asp:Button ID="btnActive" runat="server" Text="Inactive" CssClass="btn btn-warning btn-xs" 
                                                        CommandName="DoActive" CommandArgument='<%# Eval("Active") + "," + Eval("InventoryID") %>'/></ItemTemplate></asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>

                         </table>
                    </asp:View>
                    <asp:View runat="server" ID="vSetIMEIold">
                        <div style="width: 900px;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4>
                                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                                        <br />
                                    </h4>
                                    <h5>
                                        <asp:Label ID="Label2" runat="server" Text="Location"></asp:Label>
                                    </h5>
                                </div>
                                <div class="panel-body">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Panel runat="server" ID="PnlIMEI">
                                                    <asp:PlaceHolder runat="server" ID="phHold">
                                                    
                                                    </asp:PlaceHolder>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        
                                    </table>
                                </div>
                                <div class="panel-footer">
                                    <table style="width: 400px; margin: 0 auto;">
                                        <tr>
                                            <td style="padding-right: 15px;">
                                            <asp:UpdatePanel runat="server" ID="up">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnSaveAll" runat="server" Text="SAVE "  
                                                    CssClass="btn btn-success btn-block" onclick="btnSaveAll_Click"  
                                                     />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                                
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnBackPrev" runat="server" Text="BACK" 
                                                    CssClass="btn btn-warning btn-block" 
                                                    
                                                     />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                         </div>
                    </asp:View>
                    <asp:View runat="server" ID="vwNewItems">
                        <table>
                            <tr>
                                <td>
                                    
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblKioskNameList" runat="server" Text="Kiosk Name" Font-Bold="True"></asp:Label>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvNewItems" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns="false"
                                        DataKeyNames="InventoryID"
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" onrowcommand="gvNewItems_RowCommand" onrowdatabound="gvNewItems_RowDataBound" 
                                          >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="InventoryID" HeaderStyle-Width="50" HeaderText="ID" />
                                            <asp:BoundField DataField="ProdName_" HeaderStyle-Width="150" HeaderText="Product Name" />
                                            <asp:BoundField DataField="StockIn" HeaderStyle-Width="70" HeaderText="Stock In" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField DataField="StockOut" HeaderStyle-Width="70" HeaderText="Stock Out" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField DataField="InsertDate" HeaderStyle-Width="180" HeaderText="Date Inserted" />
                                            <asp:BoundField DataField="StockDiff_" HeaderStyle-Width="80" HeaderText="Balance" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="InsuficienIMEI_" HeaderStyle-Width="100 " HeaderText="IMEI Not Set" ItemStyle-HorizontalAlign="Right" />
                                            <asp:TemplateField HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Center"><ItemTemplate><asp:Button ID="btnSetIMEI" runat="server" Text="Set IMEI" CssClass="btn btn-warning btn-xs" 
                                                       CommandName="DoSetIMEI"  CommandArgument='<%# Eval("InventoryID") %>'/></ItemTemplate></asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnMainBack" runat="server" Text="Back To Main"  
                                                     CssClass="btn btn-default btn-block" style="width:200px;" onclick="btnMainBack_Click"  
                                                  />
                                </td>
                            </tr>
                         </table>
                    </asp:View>
                    <asp:View runat="server" ID="vwSetIMEI">

                        <table>
                            <tr>
                                <td>
                                    
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblProdNameIMEI" runat="server" Text="Kiosk Name" Font-Bold="True"></asp:Label>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvSetIMEI" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns="false"
                                        DataKeyNames="InventoryID,isAdd"
                                        
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" onrowcommand="gvNewItems_RowCommand" onrowdatabound="gvSetIMEI_RowDataBound" 
                                          >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderStyle-Width="50" HeaderText="No." />
                                            <asp:TemplateField HeaderText = "Input IMEI Here" ><ItemTemplate><asp:TextBox runat="server" ID="tbIMEIset" Width="400">
                                                    </asp:TextBox></ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText = "Out" HeaderStyle-Width="50"><ItemTemplate><asp:Label runat="server" ID="lblIMEIout">
                                                    </asp:Label></ItemTemplate></asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    
                                    <table width=100%>
                                        <tr>
                                            <td>
                                              
                                                 <asp:Button ID="btnIMEISave" runat="server" Text="Save"  CssClass="btn btn-success btn-block" style="width:200px;" 
                                                 onclick="btnIMEISave_Click" />
                                            </td>
                                            <td>
                                                 <asp:Button ID="btnIMEICancel" runat="server" Text="Cancel"  
                                                     CssClass="btn btn-default btn-block" style="width:200px;" onclick="btnIMEICancel_Click"  
                                                  />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                
                            </tr>

                         </table>
                    </asp:View>

                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
