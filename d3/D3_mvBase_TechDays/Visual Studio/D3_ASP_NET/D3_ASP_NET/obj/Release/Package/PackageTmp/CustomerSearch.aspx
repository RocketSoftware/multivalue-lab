<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSearch.aspx.cs" Inherits="D3_ASP_NET.CustomerSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 302px;
            height: 167px;
            margin-top: 0px;
        }
    </style>
</head>
<body bgcolor="#e8e8ff" style="height: 753px">
    <form id="frm_CustomerSearch" runat="server">
        <img alt="" class="auto-style1" src="acme.png" /><div style="height: 459px">
    
        Customer Search:<br />
        <br />
        Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_CustName" runat="server" style="margin-left: 4px" Width="329px" BorderStyle="Inset"></asp:TextBox>
        <br />
        <br />
        Address:<asp:TextBox ID="txt_CustAddr" runat="server" style="margin-left: 23px" Width="329px" BorderStyle="Inset"></asp:TextBox>
        <br />
        <br />
        Phone:<asp:TextBox ID="txt_CustPhone" runat="server" style="margin-left: 36px" Width="80px" BorderStyle="Inset"></asp:TextBox>
&nbsp;&nbsp;&nbsp; (Last 4 Digits)<br />
        <br />
        Terr#:<asp:TextBox ID="txt_CustTerr" runat="server" style="margin-left: 40px" Width="78px" BorderStyle="Inset"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btn_Search" runat="server" Height="26px" style="margin-left: 78px" Text="Search" Width="78px" OnCommand="Get_CustList" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Clear" runat="server" Height="26px" Text="Clear" Width="78px" OnClick="ClearSearch" />
    
    </div>
    </form>
</body>
</html>
