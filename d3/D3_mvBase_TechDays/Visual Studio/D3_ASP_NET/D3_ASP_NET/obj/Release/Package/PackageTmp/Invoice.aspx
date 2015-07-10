<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="D3_ASP_NET.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

            .rightCol
  {
    width: 60%;
    float: right;
    height: 30px;
  }

        .leftCol
  {
    width: 40%;
    float: left;
    height: 30px;
    text-indent: 10px;
  }
   
        #frm_Invoice {
            height: 809px;
        }
        .auto-style1 {
            width: 308px;
            height: 178px;
            margin-left: 0px;
        }
    </style>
</head>
<body bgcolor="#e5e5e5" style="height: 590px; margin-left: 7px;">
    <form id="frm_Invoice" runat="server" name="Customer Invoice" title="Customer Invoice" clientidmode="Static">
   <div style="height: 180px; font-weight: 700; width: 854px"> &nbsp;<img alt="" class="auto-style1" src="acme.png" />&nbsp;&nbsp;&nbsp;&nbsp;
       <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       </div>
        <asp:Button ID="Button2" runat="server" Height="23px" style="margin-left: 770px; margin-bottom: 0px;" Text="New Search" Width="100px" OnClick="Get_CustomerSearch" />
        <br />
&nbsp;<asp:Table ID="Tbl_InvoiceInfo" runat="server" Height="29px" Width="873px" BorderStyle="Inset" GridLines="Vertical">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black" Width="50px">Bill To:</asp:TableCell>
                <asp:TableCell ID="tbl_BillTo" runat="server" BackColor="#FFFFCC" ForeColor="#333333" Width="250px"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" BorderStyle="None" Font-Bold="True" Width="75px">Invoice#</asp:TableCell>
                <asp:TableCell ID="tbl_InvoiceID" runat="server" BackColor="#FFFFCC" ForeColor="#333333" Width="150px"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC" Width="50px"></asp:TableCell>
                <asp:TableCell ID="tbl_BillToAddr" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black" Width="75px">Account#</asp:TableCell>
                <asp:TableCell ID="tbl_AccountID" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell ID="tbl_BillToCSZ" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Ordered:</asp:TableCell>
                <asp:TableCell ID="tbl_Ordered" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BackColor="#FFFFCC" ForeColor="#333333">
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Invoiced#</asp:TableCell>
                <asp:TableCell ID="tbl_Invoiced" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BackColor="#FFFFCC" ForeColor="Black">
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Ship To:</asp:TableCell>
                <asp:TableCell ID="tbl_ShipTo" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Terms:</asp:TableCell>
                <asp:TableCell ID="tbl_Terms" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell ID="tbl_ShipToAddr" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True">Note:</asp:TableCell>
                <asp:TableCell ID="tbl_Note" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell ID="tbl_ShipToCSZ" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Gross:</asp:TableCell>
                <asp:TableCell ID="tbl_Gross" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True">Discount:</asp:TableCell>
                <asp:TableCell ID="tbl_Discount" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Contact:</asp:TableCell>
                <asp:TableCell ID="tbl_Contact" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True" ForeColor="Black">Net:</asp:TableCell>
                <asp:TableCell ID="tbl_Net" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True">Sales Rep:</asp:TableCell>
                <asp:TableCell ID="tbl_SalesRep" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#FFFFCC" Font-Bold="True">Rep Phone:</asp:TableCell>
                <asp:TableCell ID="tbl_RepPhone" runat="server" BackColor="#FFFFCC" ForeColor="#333333"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
                <asp:TableCell runat="server" BackColor="#FFFFCC"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView ID="Grid_InvoiceList" runat="server" AutoGenerateColumns="False" RowHeaderColumn="Disc" style="margin-top: 0px" Width="872px" BorderStyle="Outset">
            <Columns>
                <asp:BoundField DataField="Ln" HeaderText="Ln">
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="Qty" HeaderText="Qty">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="ItemId" HeaderText="ItemId">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description">
                <ItemStyle HorizontalAlign="Left" Width="300px" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Unit Price" HtmlEncode="False">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="ExtPrice" DataFormatString="{0:c}" HeaderText="Ext Price" HtmlEncode="False">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Disc" HeaderText="Disc" HtmlEncode="False">
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Ext" DataFormatString="{0:c}" HeaderText="Ext" HtmlEncode="False">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="White" BorderColor="#333333" BorderStyle="Outset" Font-Size="Medium" ForeColor="Black" Height="10px" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFFCC" BorderColor="#333333" BorderStyle="Inset" BorderWidth="2px" Font-Size="Small" ForeColor="#333333" Height="9px" />
        </asp:GridView>
        <br />
        <br />
    </form>
    
    </body>
    
</html>
