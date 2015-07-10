<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustList.aspx.cs" Inherits="D3_ASP_NET.CustList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <style type="text/css">
        #frm_CustList {
            height: 640px;
        }
        .auto-style1 {
            width: 308px;
            height: 178px;
        }
    </style>
    <link href="acme.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#e4e4e4">
    <form id="frm_CustList" runat="server">
    <div style="height: 683px; font-weight: 700; margin-top: 0px">
    
        <img alt="" class="auto-style1" src="acme.png" /><br />
        <div>Customer Search Results&nbsp;
            <asp:Label ID="lbl_STATUS" runat="server" Font-Size="Medium" ForeColor="Red" Width="400px"></asp:Label>
        </div>
        <asp:Button ID="btn_NewSearch" runat="server" style="margin-left: 1125px" Text="New Search" Width="117px" OnClick="Get_CustomerSearch" />
    

        <asp:GridView ID="Grid_CustList" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="99px" style="margin-top: 0px; margin-right: 22px;" Width="1200px" ShowFooter="True" OnRowCommand="Grid_CustList_RowCommand">
           
            <AlternatingRowStyle BorderStyle="Inset" />
            <Columns>
                <asp:TemplateField HeaderText="Account#">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("[Account#]", "Invoices.aspx?param={0}") %>' Text='<%# Eval("[Account#]") %>'></asp:HyperLink>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAcct" runat="server" Text='<%# Bind("Account") %>' BackColor="#33CC33"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAcct" width="60px" runat="server"/>
                    </FooterTemplate>
                    <HeaderStyle BackColor="Blue" ForeColor="White" />
                    <ItemStyle BackColor="#FFFFCC" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name" ValidateRequestMode="Enabled">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' BackColor="#33CC33" ForeColor="#009933"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="White" ForeColor="Black" Height="10px" HorizontalAlign="Center" Width="350px" />
                    <ItemStyle BackColor="#FFFFCC" Font-Size="Small" ForeColor="#333333" Height="9px" HorizontalAlign="Left" Width="350px" />
                    <FooterTemplate>
                        <asp:TextBox ID="txtName" width="340px" runat="server"/>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAddr" runat="server" Text='<%# Bind("Address") %>' BackColor="#33CC33"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddr" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BackColor="White" Font-Size="Medium" ForeColor="Black" Height="10px" HorizontalAlign="Center" Width="325px" />
                    <ItemStyle BackColor="#FFFFCC" Font-Size="Small" ForeColor="#333333" Height="9px" HorizontalAlign="Left" Width="325px" />
                    <FooterTemplate>
                        <asp:TextBox ID="txtAddr" width="330px" runat="server"/>
                    </FooterTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtCity" width="125px" runat="server"/>
                    </FooterTemplate>
                    <HeaderStyle BackColor="White" ForeColor="Black" Width="125px" />
                    <ItemStyle BackColor="#FFFFCC" ForeColor="#333333" Width="125px" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="State">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtState" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtState" width="50px" runat="server"/>
                    </FooterTemplate>
                    <HeaderStyle BackColor="White" ForeColor="Black" Width="50px" />
                    <ItemStyle BackColor="#FFFFCC" ForeColor="#333333" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Zip">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtZip" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblZip" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtZip" width="100px" runat="server"/>
                    </FooterTemplate>
                    <HeaderStyle BackColor="White" ForeColor="Black" Width="100px" />
                    <ItemStyle BackColor="#FFFFCC" ForeColor="#333333" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPhone" width="100px" runat="server"/>
                    </FooterTemplate>
                    <HeaderStyle BackColor="White" ForeColor="Black" Width="100px" />
                    <ItemStyle BackColor="#FFFFCC" ForeColor="#333333" />
                </asp:TemplateField>
          
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Delete" runat="server" CausesValidation="False" Text="Delete" Height ="20px" Width="50px" Font-Size ="8pt" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="DeleteItem" BackColor="#FF3300" ForeColor="White" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btn_New" runat="server" CausesValidation="False" Text="New" Height ="20px" Width="50px" Font-Size ="8pt" OnClick="Insert_Item_Click" BackColor="#33CC33" ForeColor="Black" />
                    </FooterTemplate>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#333333" />
                    <HeaderStyle BackColor="White" ForeColor="#333333" />
                    <ItemStyle BackColor="#FFFFCC" />
                </asp:TemplateField>
          
         </Columns>
            <EditRowStyle BorderStyle="Inset" />
            <FooterStyle BackColor="#FFFFCC" ForeColor="#333333" BorderStyle="Inset" />
            <HeaderStyle BackColor="#A55129" BorderColor="#000099" BorderStyle="Inset" Font-Bold="True" ForeColor="White" Height="10px" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" BorderStyle="Inset" ForeColor="#8C4510" Height="9px" Font-Size="Small" />
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
