<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="BookletAssign.aspx.cs" Inherits="MobilePOS.InvoiceAssign" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 auto; width: 950px; border-radius: 6px;">
        <div id="panelBox" class="panel panel-info" runat="server">
            <div class="panel-heading">
                <asp:Label ID="lblTitle" runat="server" Text="Booklet Assignment" Font-Bold="True"></asp:Label>
            </div>
            <div class="panel-body">

            <asp:HiddenField ID="hdnBookletID" Value="0" runat="server"/>

                <asp:MultiView ID="mvMain" runat="server" ActiveViewIndex="0">
                    <asp:View ID="vwMain" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add Booklet Series" 
                                                CssClass="btn btn-default" onclick="btnAdd_Click"   />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvInvoice" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns="false"
                                        DataKeyNames="BookletID"
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" onrowcommand="gvInvoice_RowCommand" 
                                        >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="Prefix" HeaderStyle-Width="50" HeaderText="Prefix" />
                                            <asp:BoundField DataField="DigitFrom" HeaderStyle-Width="100" HeaderText="Range From" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField DataField="DigitTo" HeaderStyle-Width="100" HeaderText="Range To" ItemStyle-HorizontalAlign="Right"/>
                                            <asp:BoundField DataField="Pages" HeaderStyle-Width="50" HeaderText="Pages" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="_KioskName" HeaderStyle-Width="200" HeaderText="Kiosk Name" />
                                            <asp:BoundField DataField="CreatedBy" HeaderStyle-Width="100" HeaderText="Created By" />
                                            <asp:BoundField DataField="CreatedDate" HeaderStyle-Width="170" HeaderText="Created Date" />
                                            <asp:TemplateField HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEditRow" runat="server" Text="Edit" CssClass="btn btn-warning btn-xs" CommandName="DoEdit" CommandArgument='<%# Bind("BookletID") %>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vwAddBooklet" runat="server">

                        <div style="width: 700px; margin: 0 auto;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4>
                                        Add New Booklet Series
                                    </h4>
                                </div>
                                <div class="panel-body">

                                    <asp:Panel runat="server" DefaultButton="btnBookletSave">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            Prefix <span style="color: Red;">*</span>
                                                        </td>
                                                        <td colspan="2">
                                                            Range From <span style="color: Red;">*</span>
                                                        </td>
                                                        <td colspan="2">
                                                            Range To <span style="color: Red;">*</span>
                                                        </td>
                                                        <td colspan="2">
                                                            Pages
                                                        </td>
                                                    </tr>
                                                        <tr>
                                                            <td>
                                                                
                                                                <asp:TextBox ID="tbPrefix" runat="server" CssClass="form-control hasclear" 
                                                                    style="text-transform:uppercase;" Width="60px" MaxLength="3"></asp:TextBox>

                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Prefix is required" 
                                                                     ControlToValidate="tbPrefix" ValidationGroup="booklet" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                                     </asp:RequiredFieldValidator>
                                                                
                                                            </td>
                                                            <td>
                                                                &nbsp;#&nbsp;
                                                            </td>
                                                            <td>
                                                                
                                                                <asp:TextBox ID="tbRangeFrom" runat="server" CssClass="form-control hasclear" 
                                                                    style="text-transform:uppercase;" Width="130px" MaxLength="12"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Range From is required" 
                                                                     ControlToValidate="tbRangeFrom" ValidationGroup="booklet" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                                     </asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                
                                                                <asp:TextBox ID="tbRangeTo" runat="server" CssClass="form-control hasclear" 
                                                                    style="text-transform:uppercase;" Width="130px" MaxLength="12" 
                                                                    ClientIDMode="Static" onblur="__doPostBack('tbRangeTo','OnBlur');"
                                                                    ></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Range To is required" 
                                                                     ControlToValidate="tbRangeTo" ValidationGroup="booklet" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                                     </asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbPages" runat="server" CssClass="form-control hasclear" 
                                                                    style="text-transform:uppercase;" Width="50px" MaxLength="12" 
                                                                    Enabled="False"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Pages is null" 
                                                                    ControlToValidate="tbPages" ValidationGroup="booklet" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                                    </asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                                <td style="width: 150px;">
                                                    Select Kiosk: <span style="color: Red;">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlKiosk" runat="server" CssClass="dropdown-header" Width="200px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Kiosk is required" 
                                                            ControlToValidate="ddlKiosk" ValidationGroup="booklet" Display="Dynamic" Font-Italic="True" Font-Size="Smaller" InitialValue="0">
                                                            </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                                <div class="panel-footer">
                                    <table style="width: 400px; margin: 0 auto;">
                                        <tr>
                                            <td style="padding-right: 15px;">
                                                <asp:Button ID="btnBookletSave" runat="server" Text="SAVE " 
                                                    CssClass="btn btn-success btn-block" ValidationGroup="booklet" 
                                                    style="width:200px;" onclick="btnBookletSave_Click"/>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnBookletCancel" runat="server" Text="CANCEL" 
                                                    CssClass="btn btn-warning btn-block"  style="width:200px;" 
                                                    onclick="btnBookletCancel_Click" />
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
