<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="D3_ASP_NET.Invoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 308px;
            height: 178px;
        }
    </style>
</head>
<body bgcolor="#e5e5e5" style="height: 590px">
    <form id="frm_Invoices" runat="server" name="Customer Invoices" title="Customer Invoices">
    <div style="height: 585px; font-weight: 700; width: 1106px">
    
        <img alt="" class="auto-style1" src="acme.png" /><br />
        List of Invoices for:&nbsp;
        &nbsp;&nbsp;<asp:Label ID="lbl_CustomeName" runat="server" Width="474px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_NewSearch" runat="server" style="margin-left: 98px" Text="New Search" Width="101px" Height="20px" OnClick="Get_CustomerSearch" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView ID="Grid_Invoices" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="16px" style="margin-top: 3px" Width="863px" EmptyDataText="No data" EnableViewState="False" ShowHeaderWhenEmpty="True" ViewStateMode="Enabled">
            <AlternatingRowStyle BorderStyle="Inset" />
            <Columns>
                <asp:HyperLinkField HeaderText="Invoice#" DataNavigateUrlFields="Invoice#" DataNavigateUrlFormatString="Invoice.aspx?param={0}" DataTextField="Invoice#">
                <HeaderStyle BackColor="White" ForeColor="Black" Height="10px" Width="100px" Font-Size="Medium" />
                <ItemStyle BackColor="#FFFFCC" BorderStyle="Outset" Height="9px" HorizontalAlign="Center" Width="100px" Font-Size="Small" />
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="Invoice date" ReadOnly="True" DataField="InvoiceDate">
                <HeaderStyle BackColor="White" ForeColor="Black" Height="10px" Width="100px" Font-Size="Medium" />
                <ItemStyle BackColor="#FFFFCC" Height="9px" HorizontalAlign="Center" Width="75px" Font-Size="Small" ForeColor="#333333" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Order Date" DataField="OrderDate">
                <HeaderStyle BackColor="White" ForeColor="Black" Height="10px" Width="100px" Font-Size="Medium" />
                <ItemStyle BackColor="#FFFFCC" Height="9px" HorizontalAlign="Center" Width="75px" Font-Size="Small" ForeColor="#333333" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Terms" DataField="Terms">
                <HeaderStyle BackColor="White" ForeColor="Black" Font-Size="Medium" Height="10px" Width="75px" />
                <ItemStyle BackColor="#FFFFCC" Height="9px" HorizontalAlign="Center" Width="100px" Font-Size="Small" ForeColor="#333333" />
                </asp:BoundField>
                <asp:BoundField DataField="Gross" DataFormatString="{0:c}" HeaderText="Gross" HtmlEncode="False">
                <HeaderStyle BackColor="White" Font-Size="Medium" ForeColor="Black" Height="10px" Width="100px" />
                <ItemStyle BackColor="#FFFFCC" Font-Size="Small" ForeColor="#333333" Height="9px" HorizontalAlign="Right" Width="100px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Discount" DataField="Discount" DataFormatString="{0:c}" HtmlEncode="False">
                <HeaderStyle BackColor="White" ForeColor="Black" Font-Size="Medium" Height="10px" />
                <ItemStyle BackColor="#FFFFCC" HorizontalAlign="Right" Width="100px" Font-Size="Small" ForeColor="#333333" Height="9px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Net Invoice" DataField="NetInvoice" DataFormatString="{0:c}" HtmlEncode="False">
                <HeaderStyle BackColor="White" ForeColor="Black" Font-Size="Medium" Height="10px" />
                <ItemStyle BackColor="#FFFFCC" HorizontalAlign="Right" Width="100px" Font-Size="Small" ForeColor="#333333" Height="9px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" BorderColor="#000099" BorderStyle="Inset" Font-Bold="True" ForeColor="White" Height="10px" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" BorderStyle="Inset" ForeColor="#8C4510" Height="9px" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
