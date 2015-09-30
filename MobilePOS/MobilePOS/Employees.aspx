<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="MobilePOS.Employees" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 auto;width:950px; border-radius:6px; ">
        <div id="panelBox" class="panel panel-info" runat="server">
            <div class="panel-heading">
                <asp:Label ID="lblTitle" runat="server" Text="Employee List" Font-Bold="True"></asp:Label>
            </div>
            <div class="panel-body">
            <asp:HiddenField ID="hdnEmpID" Value="0" runat="server"/>
            <asp:HiddenField ID="hdnMethod" Value="" runat="server"/>

                <asp:MultiView ID="mvMain" runat="server">
                    <asp:View ID="vwMain" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="btnAdd" runat="server" Text="Add Employee" 
                                                CssClass="btn btn-default" onclick="btnAdd_Click"  />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvEmployee" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns=false
                                        DataKeyNames="EmpID"
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" onrowcommand="gvEmployee_RowCommand" >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="Firstname" HeaderStyle-Width="100" HeaderText="First Name" />
                                            <asp:BoundField DataField="Lastname" HeaderStyle-Width="100" HeaderText="Last Name" />
                                            <asp:BoundField DataField="Username" HeaderStyle-Width="100" HeaderText="Username" />
                                            <asp:BoundField DataField="Department" HeaderStyle-Width="100" HeaderText="Department" />
                                            <asp:BoundField DataField="KioskName" HeaderStyle-Width="150" HeaderText="Kiosk" />
                                            <asp:BoundField DataField="UserLevel" HeaderStyle-Width="100" HeaderText="User Level" />
                                            <asp:BoundField DataField="DateHired" HeaderStyle-Width="100" HeaderText="Date Hired"  DataFormatString="{0:yyyy-MM-dd}"/>
                                            <asp:TemplateField HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEditRow" runat="server" Text="Edit" CssClass="btn btn-warning btn-xs" 
                                                    CommandName="DoEdit" CommandArgument='<%# Bind("EmpID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vwManage" runat="server">
                        <div style="width:600px;margin: 0 auto;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4>
                                        Manage Employee Data
                                    </h4>
                                </div>
                                <div class="panel-body">
                                <asp:Panel ID="pnlEmp" runat="server" DefaultButton="btnSave">
                                    <table>
                                        
                                       <tr>
                                            <td  >
                                                User Level :
                                                <span style="color:Red;">*</span>
                                                
                                            </td>
                                            <td  >
                                                <asp:DropDownList ID="ddlUserLevel" runat="server" CssClass="dropdown-header" 
                                                Width="200px" AutoPostBack="True" 
                                                    onselectedindexchanged="ddlUserLevel_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Userlevel is required" 
                                                ControlToValidate="ddlUserLevel" ValidationGroup="emp" Display="Dynamic" InitialValue="0"
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td  >
                                                Employee ID:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td  >
                                                <asp:TextBox ID="tbEmpID" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmpID" runat="server" ErrorMessage="Employee ID is required"
                                                ControlToValidate="tbEmpID" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>

                                        <tr>
                                            <td colspan="2">
                                            <asp:Panel runat="server" ID="pnlUserPass">
                                                <table>
                                                    <tr>
                                                        <td style="width: 200px;">
                                                            Username : <span style="color: Red;">*</span>
                                                        </td>
                                                        <td style="width: 300px;">
                                                            <asp:TextBox ID="tbEmpUsername" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Username is required"
                                                                ControlToValidate="tbEmpUsername" ValidationGroup="emp" Display="Dynamic" Font-Italic="True"
                                                                Font-Size="Smaller">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Password : <span style="color: Red;">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbEmpPassword" runat="server" CssClass="form-control hasclear" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password is required"
                                                                ControlToValidate="tbEmpPassword" ValidationGroup="emp" Display="Dynamic" Font-Italic="True"
                                                                Font-Size="Smaller">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Confirm Password : <span style="color: Red;">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbEmpConfirmPass" runat="server" CssClass="form-control hasclear"
                                                                TextMode="Password"></asp:TextBox>
                                                            <asp:CompareValidator ID="cvConPass" runat="server" ControlToValidate="tbEmpConfirmPass"
                                                                ControlToCompare="tbEmpPassword" ErrorMessage="No Match" Font-Italic="True" Font-Size="Smaller"
                                                                ToolTip="Password must be the same" />
                                                            <br />
                                                            <asp:RequiredFieldValidator ID="rfvConPass" runat="server" ErrorMessage="Confirm Password is Required"
                                                                ControlToValidate="tbEmpConfirmPass" ToolTip="Compare Password is a REQUIRED field"
                                                                Font-Italic="True" Font-Size="Smaller" ValidationGroup="emp">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>

                                        <tr><td colspan=2 align="center"><br />
                                            <div style="width:550px;border-top:1px solid #ccc;"></div>
                                            <br />
                                        </td></tr>
                                        <tr>
                                            <td  >
                                                First Name :
                                                <span style="color:Red;">*</span>
                                                
                                            </td>
                                            <td  >
                                                <asp:TextBox ID="tbEmpFirstname" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="First Name is required"
                                                ControlToValidate="tbEmpFirstname" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                Last Name:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbEmpLastname" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Last Name is required"
                                                ControlToValidate="tbEmpLastname" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                Department:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbEmpDepartment" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Department is required"
                                                ControlToValidate="tbEmpDepartment" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                Kiosk:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlKioskList" runat="server" CssClass="dropdown-header" 
                                                Width="200px"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Kiosk is required" 
                                                ControlToValidate="ddlKioskList" ValidationGroup="emp" Display="Dynamic" InitialValue="0"
                                                Font-Italic="True" Font-Size="Smaller"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                Date Hired:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbEmpDateHired" runat="server" CssClass="form-control hasclear" 
                                                    Width="150px" ></asp:TextBox>
                                                
                                                <cc1:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                                                    Enabled="True" TargetControlID="tbEmpDateHired" Format="yyyy-MM-dd">
                                                </cc1:CalendarExtender>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Date Hired is required"
                                                ControlToValidate="tbEmpDateHired" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                </asp:RequiredFieldValidator>
                                                
                                                <asp:CompareValidator
                                                id="dateValidator" runat="server" Type="Date" Operator="DataTypeCheck"
                                                ControlToValidate="tbEmpDateHired" Font-Size="Smaller" Font-Italic="True"
                                                ErrorMessage="Please enter a valid date.">
                                            </asp:CompareValidator>
                                                
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                Mobile Number:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbEmpMobile" runat="server" CssClass="form-control hasclear" 
                                                    Width="200px" ></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Mobile Number is required"
                                                    ControlToValidate="tbEmpMobile" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                    </asp:RequiredFieldValidator>
                                                    
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                                    runat="server" ErrorMessage="Enter valid Phone number" ValidationGroup="emp"
                                                    ControlToValidate="tbEmpMobile" Font-Size="Smaller" Font-Italic="True"
                                                    ValidationExpression= "^([0-9\(\)\/\+ \-]*)$"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                Email Add:
                                                <span style="color:Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbEmpEmail" runat="server" CssClass="form-control hasclear" style="text-transform:uppercase;"
                                                     ></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Email Add is required"
                                                ControlToValidate="tbEmpEmail" ValidationGroup="emp" Display="Dynamic" Font-Italic="True" Font-Size="Smaller">
                                                </asp:RequiredFieldValidator>

                                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" Font-Size="Smaller" Font-Italic="True"
                                                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tbEmpEmail" ValidationGroup="emp"
                                                ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        
                                    </table>
                                    </asp:Panel>
                                </div>
                                <div class="panel-footer">
                                    <table style="width: 400px; margin: 0 auto;">
                                        <tr>
                                            <td style="padding-right: 15px;">
                                                <asp:Button ID="btnSave" runat="server" Text="SAVE " 
                                                    CssClass="btn btn-success btn-block" ValidationGroup="emp"
                                                     style="width:200px;" onclick="btnSave_Click"/>
                                            </td>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnCancel" runat="server" Text="CANCEL" 
                                                    CssClass="btn btn-warning btn-block" 
                                                    style="width:200px;" onclick="btnCancel_Click"
                                                     />
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
