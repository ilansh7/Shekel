<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Shekel.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" submitdisabledcontrols="false">
        <div>  
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblGroups" runat="server" Text="Group : " />
            <asp:DropDownList ID="ddlGroups" runat="server" ></asp:DropDownList>  
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCustomersAndGroups" runat="server" Text="Get Customers and Groups" OnClick="btnCustomersAndGroups_Click" style="height: 26px" />
            <br /><br />
            <hr />
            <br />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label><asp:TextBox ID="txtId" runat="server" /> &nbsp;&nbsp;
            <asp:Label ID="LblName" runat="server" Text="Name : "></asp:Label><asp:TextBox ID="txtName" runat="server" /> &nbsp;&nbsp;
            <asp:Label ID="lblAddress" runat="server" Text="Address : "></asp:Label><asp:TextBox ID="txtAddress" runat="server" /> &nbsp;&nbsp;
            <asp:Label ID="lblPhone" runat="server" Text="Phone : "></asp:Label><asp:TextBox ID="TxtPhone" runat="server" /> &nbsp;&nbsp;
            <asp:Label ID="lblGroup" runat="server" Text="Group : "></asp:Label><asp:DropDownList ID="ddlGroups1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroups1_SelectedIndexChanged" ></asp:DropDownList> &nbsp;&nbsp;
            <asp:Label ID="lblFactory" runat="server" Text="Factory : "></asp:Label><asp:DropDownList ID="ddlFactory" runat="server" ></asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAddCustomer" runat="server" Text="Add new Customer" OnClick="btnAddCustomer_Click" style="height: 26px" />

            <br />  
            <br />  
            <asp:GridView ID="gvCustomersAndGroups" runat="server" BackColor="White" BorderColor="#999999"  
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">  
                <AlternatingRowStyle BackColor="#DCDCDC" />  
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />  
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />  
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />  
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />  
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />  
                <SortedAscendingCellStyle BackColor="#F1F1F1" />  
                <SortedAscendingHeaderStyle BackColor="#0000A9" />  
                <SortedDescendingCellStyle BackColor="#CAC9C9" />  
                <SortedDescendingHeaderStyle BackColor="#000065" />  
            </asp:GridView>  
            <asp:Label ID="lblGv" runat="server" Text="" BackColor="LightBlue"></asp:Label>
        </div>  
    </form>
</body>
</html>
