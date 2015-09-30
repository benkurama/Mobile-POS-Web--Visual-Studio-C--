<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="ProductDiscount.aspx.cs" Inherits="MobilePOS.ProductDiscount" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 auto; width: 950px; border-radius: 6px;">
        <div id="panelBox" class="panel panel-info" runat="server">
            <div class="panel-heading">
                <asp:Label ID="lblTitle" runat="server" Text="Product Discount Manager" Font-Bold="True"></asp:Label>
            </div>
            <div class="panel-body">
                <asp:MultiView ID="mvMain" runat="server" ActiveViewIndex="0">
                    <asp:View ID="vwMain" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add Discount" 
                                                CssClass="btn btn-default" onclick="btnAdd_Click"   />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvDiscount" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns="false"
                                        
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" 
                                        >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="DiscountID" HeaderStyle-Width="50" HeaderText="ID" />
                                            <asp:BoundField DataField="Value" HeaderStyle-Width="80" HeaderText="Discount" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="ValidFrom" HeaderStyle-Width="100" HeaderText="Valid From"  DataFormatString="{0:yyyy-MM-dd}"/>
                                            <asp:BoundField DataField="ValidTo" HeaderStyle-Width="100" HeaderText="Valid To"  DataFormatString="{0:yyyy-MM-dd}"/>
                                            <asp:BoundField DataField="KioskAssign" HeaderStyle-Width="150" HeaderText="Selected Kiosk ID" />
                                            <asp:BoundField DataField="ProductAssign" HeaderStyle-Width="150" HeaderText="Selected Product ID" />
                                            <asp:BoundField DataField="CreatedBy" HeaderStyle-Width="100" HeaderText="Created By" />
                                            <asp:BoundField DataField="CreatedDate" HeaderStyle-Width="150" HeaderText="Created Date" DataFormatString="{0:yyyy-MM-dd}"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            
                        </table>
                    </asp:View>
                    <asp:View runat="server" ID="vwAdd">
                        <div style="width: 600px; margin: 0 auto;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3>
                                        Add New Discount
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <asp:Panel runat="server" DefaultButton="btnDiscountSave">
                                        <table>
                                            <tr>
                                                <td style="width: 200px;">
                                                    Discount Value <span style="color: Red;">*</span>
                                                </td>
                                                <td style="width: 400px;">
                                                    <asp:TextBox ID="tbValue" runat="server" CssClass="form-control hasclear" 
                                                        Style="text-transform: uppercase;" Width="150px" 
                                                        ></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbValue" runat="server" 
                                                    ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" Font-Italic="True" Font-Size="Smaller" ValidationGroup="discount">
                                                    </asp:RegularExpressionValidator>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Discount is required"
                                                        ControlToValidate="tbValue" ValidationGroup="discount" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                               <td>
                                                    Valid From:<span style="color: Red;">*</span>
                                               </td>
                                               <td>
                                                    <asp:TextBox ID="tbValidFrom" runat="server" Width="150px" CssClass="date" MaxLength="10" placeholder="yyyy-mm-dd">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Valid From is required"
                                                        ControlToValidate="tbValidFrom" ValidationGroup="discount" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                    </asp:RequiredFieldValidator>
                                               </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                               <td>
                                                    Valid To:
                                               </td>
                                               <td>
                                                    <asp:TextBox ID="tbValidTo" runat="server" Width="150px" CssClass="date" MaxLength="10" placeholder="yyyy-mm-dd">
                                                    </asp:TextBox>
                                               </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                          
                                            <tr>
                                                <td colspan="2">
                                                    <strong>Kiosk Selection</strong> <span style="color: Red;">*</span>
                                                    <asp:UpdatePanel runat="server" ID="up1">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>Kiosk List</td>
                                                                    <td></td>
                                                                    <td>Selected Kiosk</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 250px;">
                                                                        <asp:ListBox ID="lbxKiosk" runat="server" Height="250px" Width="100%" 
                                                                            SelectionMode="Multiple" >
                                                                        </asp:ListBox>
                                                                    </td>
                                                                    <td style="width: 50px;" valign="middle" align="center">
                                                                        <asp:Button ID="btnAssign" runat="server" Text=">>" Style="margin-bottom: 10px;"
                                                                            OnClick="btnAssign_Click" />
                                                                        <asp:Button ID="btnRevoke" runat="server" Text="<<" OnClick="btnRevoke_Click" />
                                                                    </td>
                                                                    <td style="width: 250px;">
                                                                        <asp:ListBox ID="lbxKioskSel" runat="server" Height="250px" Width="100%" 
                                                                            SelectionMode="Multiple">
                                                                        </asp:ListBox>
                                                                        
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <strong>Product Selection</strong>
                                                    <asp:Panel runat="server" ID="pnlProducts">
                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>Product List</td>
                                                                    <td></td>
                                                                    <td>Selected Product</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 250px;">
                                                                        <asp:ListBox ID="lbxProduct" runat="server" Height="250px" Width="100%" 
                                                                            SelectionMode="Multiple" >
                                                                        </asp:ListBox>
                                                                    </td>
                                                                    <td style="width: 50px;" valign="middle" align="center">
                                                                        <asp:Button ID="btnProdAssign" runat="server" Text=">>" 
                                                                            Style="margin-bottom: 10px;" onclick="btnProdAssign_Click"
                                                                             />
                                                                        <asp:Button ID="btnProdRevoke" runat="server" Text="<<" 
                                                                            onclick="btnProdRevoke_Click"  />
                                                                    </td>
                                                                    <td style="width: 250px;">
                                                                        <asp:ListBox ID="lbxProductSel" runat="server" Height="250px" Width="100%" SelectionMode="Multiple">
                                                                        </asp:ListBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                                <td>
                                                    Remarks:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbRemarks" runat="server" CssClass="form-control hasclear" Style="text-transform: uppercase;" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <div class="panel-footer">
                                    <table style="width: 400px; margin: 0 auto;">
                                        <tr>
                                            <td style="padding-right: 15px;">
                                                <asp:Button ID="btnDiscountSave" runat="server" Text="SAVE " 
                                                    CssClass="btn btn-success btn-block" ValidationGroup="discount" 
                                                     style="width:200px;" onclick="btnDiscountSave_Click"/>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnDiscountCancel" runat="server" Text="CANCEL" 
                                                    CssClass="btn btn-warning btn-block" 
                                                    style="width:200px;" onclick="btnDiscountCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>

        </div>
     </div>
</asp:Content>
