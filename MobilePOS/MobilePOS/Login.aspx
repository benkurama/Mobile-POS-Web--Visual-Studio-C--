<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MobilePOS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Home Page</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" type="text/javascript" ></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js" type="text/javascript" ></script>

    <style type="text/css">
        .effect2
        {
          position: relative;
        }
        .effect2:before, .effect2:after
        {
          z-index: -1;
          position: absolute;
          content: "";
          bottom: 15px;
          left: 10px;
          width: 50%;
          top: 80%;
          max-width:300px;
          background: #777;
          -webkit-box-shadow: 0 15px 10px #777;
          -moz-box-shadow: 0 15px 10px #777;
          box-shadow: 0 15px 10px #777;
          -webkit-transform: rotate(-3deg);
          -moz-transform: rotate(-3deg);
          -o-transform: rotate(-3deg);
          -ms-transform: rotate(-3deg);
          transform: rotate(-3deg);
        }
        .effect2:after
        {
          -webkit-transform: rotate(3deg);
          -moz-transform: rotate(3deg);
          -o-transform: rotate(3deg);
          -ms-transform: rotate(3deg);
          transform: rotate(3deg);
          right: 10px;
          left: auto;
        }
    </style>

  </head>
  <body style="background:#f1f1f1">
    <form id="form1" runat="server">

    <table style="width:300px;margin:0 auto;position:relative;top:150px;">
        <tr>
            <td>
                <div class="effect2">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="panel-title">
                                MOBILE POS LOGIN
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:Label ID="Label1" runat="server" Text="USER NAME :" CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="tbUserID" runat="server" CssClass="form-control hasclear" 
                                ></asp:TextBox>

                            <br />
                            <asp:Label ID="Label2" runat="server" Text="PASSWORD :" CssClass="control-label"></asp:Label>
                            <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control hasclear" 
                                TextMode="Password"></asp:TextBox>

                            <br />

                            <asp:Button ID="btnLogin" runat="server" Text="LOGIN" 
                                CssClass="btn btn-success btn-block" onclick="btnLogin_Click" />
                            <br />
                            <div class="alert alert-danger" role="alert" id="alertError" runat="server">
                                
                                <asp:Label ID="tbErroMessage" runat="server" 
                                    Text="Username/Password is Invalid... " Font-Bold="True"></asp:Label>

                            </div>
                        </div>
                        <div class="panel-footer"> 
                            powered by redfoottech.
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
        
    </form>

  </body>
</html>