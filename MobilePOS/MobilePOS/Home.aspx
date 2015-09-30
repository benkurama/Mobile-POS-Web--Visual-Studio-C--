<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MobilePOS.Home" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        
        .panel-body .btn:not(.btn-block) { width:120px;margin-bottom:10px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 0 auto;width:900px;border: 1px #e1e1e1 solid;padding:10px; background-color:#fff;border-radius:6px; ">


        


        <div class="alert alert-success" role="alert">
            <b>Welcome <asp:Label ID="lblUser" runat="server" Text="User"></asp:Label>...</b> You can now manage in this dashboard...
            
        </div>
        
        <div class="container">
            <div class="row">
                <div class="col-md-9">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <span class="glyphicon glyphicon-bookmark"></span> &nbsp; Quick Shortcuts / Today's Count
                             </h3>
                        </div>
                        <div class="panel-body">
                            
                         <div class="row">
                            <div class="col-xs-6 col-md-6">
                                <a href="Employees.aspx" class="btn btn-danger btn-lg" role="button" >
                                    <span class="glyphicon glyphicon-user"></span><br />                                   
                                    <asp:Label ID="lblEmployee" runat="server" Text="Employee:(0)" style="font-size:14px;font-weight:bold"></asp:Label>
                                </a>
                                <a href="KioskAssignment.aspx" class="btn btn-warning btn-lg" role="button" >
                                    <span class="glyphicon glyphicon-list-alt"></span><br />                                   
                                    <asp:Label ID="lblKiosk" runat="server" Text="Kiosk:(0)" style="font-size:14px;font-weight:bold"></asp:Label>
                                </a>
                                <a href="AllProducts.aspx?type=0" class="btn btn-primary btn-lg" role="button" >
                                    <span class="glyphicon glyphicon-phone"></span><br />                                   
                                    <asp:Label ID="lblItems" runat="server" Text="Products:(0)" style="font-size:14px;font-weight:bold"></asp:Label>
                                </a>
                                
                                <a href="#" class="btn btn-success btn-lg" role="button" >
                                    <span class="glyphicon glyphicon-barcode"></span><br />                                   
                                    <asp:Label ID="lblSales" runat="server" Text="Sales:(0)" style="font-size:14px;font-weight:bold"></asp:Label>
                                </a>
                                <a href="ProductDiscount.aspx" class="btn btn-info btn-lg" role="button" >
                                    <span class="glyphicon glyphicon-scissors"></span><br />                                   
                                    <asp:Label ID="Label2" runat="server" Text="Discount:(0)" style="font-size:14px;font-weight:bold"></asp:Label>
                                </a>
                                <a href="BookletAssign.aspx" class="btn btn-primary btn-lg" role="button" >
                                    <span class="glyphicon glyphicon-book"></span><br />                                   
                                    <asp:Label ID="Label3" runat="server" Text="Booklet:(0)" style="font-size:14px;font-weight:bold"></asp:Label>
                                </a>

                            </div>

                            <div class="col-xs-6 col-md-6">
                                
                                <asp:GridView ID="gvEmployeeLog" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns=false
                                        DataKeyNames="EmpID"
                                        AllowPaging="false" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:BoundField DataField="Username" HeaderStyle-Width="80" HeaderText="User Online" />
                                            <asp:BoundField DataField="KioskName" HeaderStyle-Width="120" HeaderText="Kiosk" />
                                            <asp:BoundField DataField="UserLevel" HeaderStyle-Width="50" HeaderText="Type" />
                                        </Columns>
                                    </asp:GridView>
                            </div>
                            
                         </div>
                        

                        </div>
                    </div>
                </div>
            </div>
        </div>


        
    </div>
    
</asp:Content>
