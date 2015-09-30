<%@ Page Title="" Language="C#" MasterPageFile="~/Frame.Master" AutoEventWireup="true" CodeBehind="SalesInfoDetails.aspx.cs" Inherits="MobilePOS.SalesInfoDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

     <script type="text/javascript">
         $("[src*=plus]").live("click", function () {
             $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
             $(this).attr("src", "Img/minus.png");
         });
         $("[src*=minus]").live("click", function () {
             $(this).attr("src", "Img/plus.png");
             $(this).closest("tr").next().remove();
         });



     </script>

     <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" type="text/javascript" ></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js" type="text/javascript" ></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 auto;width:950px; border-radius:6px; ">
        <div id="panelBox" class="panel panel-info" runat="server">
            <div class="panel-heading">
                <asp:Label ID="lblTitle" runat="server" Text="Sales Information" Font-Bold="True"></asp:Label>
            </div>
            <div class="panel-body">


            

                <asp:MultiView ID="mvMain" runat="server">
                    <asp:View ID="vMain" runat="server">
                        <table>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvSales" runat="server"
                                        GridLines="None"  
                                        AutoGenerateColumns=false
                                        DataKeyNames="InvNo"
                                        AllowPaging="true" PageSize="20"  
                                        CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr"  
                                        AlternatingRowStyle-CssClass="alt" 
                                        onpageindexchanging="gvSales_PageIndexChanging" onrowdatabound="gvSales_RowDataBound"

                                    >
                                        <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                        <Columns>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <img alt = "" style="cursor: pointer" src="Img/plus.png" />
                                                    <asp:Panel ID="pnl" runat="server" Style="display: none">
                                                        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" CssClass = "">
                                                            <EmptyDataTemplate>No Record(s) found.</EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="InvNo" HeaderStyle-Width="200" HeaderText="Invoice #" />
                                                                <asp:BoundField DataField="ProdName_" HeaderStyle-Width="200" HeaderText="Product Name" />
                                                                <asp:BoundField DataField="Qty" HeaderStyle-Width="200" HeaderText="Quantity" />
                                                                <asp:BoundField DataField="UnitPx" HeaderStyle-Width="200" HeaderText="Unit Price" DataFormatString="{0:#,0}"/>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="CustName" HeaderStyle-Width="200" HeaderText="Customer" />
                                            <asp:BoundField DataField="EmailAdd" HeaderStyle-Width="200" HeaderText="Email Address" />
                                            <asp:BoundField DataField="ContactNo" HeaderStyle-Width="100" HeaderText="Contact" />
                                            <asp:BoundField DataField="CustNo" HeaderStyle-Width="80" HeaderText="CustNo" />
                                            <asp:BoundField DataField="TotalAmount" HeaderStyle-Width="100" HeaderText="Total Amount" DataFormatString="{0:#,0}"/>
                                            <asp:BoundField DataField="InvDate" HeaderStyle-Width="180" HeaderText="Invoice Date" />
                                            <asp:BoundField DataField="Status" HeaderStyle-Width="50" HeaderText="Status" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
