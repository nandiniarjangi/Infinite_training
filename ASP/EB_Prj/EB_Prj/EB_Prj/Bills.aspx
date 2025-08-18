<%@ Page Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Bills.aspx.cs"
    Inherits="EB_Prj.Bills" %>
 
<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
 
    <h2>Electricity Bills</h2>
 
    <!-- Step 1: how many to add -->
    <asp:Panel ID="pnlHowMany" runat="server">
        <asp:Label runat="server" Text="Enter Number of Bills To Be Added: " />
        <asp:TextBox ID="txtCount" runat="server" />
        <asp:Button ID="btnSetCount" runat="server" CssClass="btn"
            Text="Start" OnClick="btnSetCount_Click" />
        <asp:Label ID="lblCountMsg" runat="server" ForeColor="Red"></asp:Label>
    </asp:Panel>
 
    <!-- Step 2: per-customer entry -->
    <asp:Panel ID="pnlEntry" runat="server" Visible="false">
        <h4>Bill <asp:Label ID="lblIndex" runat="server" /> </h4>
 
        <asp:Label runat="server" Text="Enter Consumer Number:" /><br />
        <asp:TextBox ID="txtCNo" runat="server" /><br />
 
        <asp:Label runat="server" Text="Enter Consumer Name:" /><br />
        <asp:TextBox ID="txtCName" runat="server" /><br />
 
        <asp:Label runat="server" Text="Enter Units Consumed:" /><br />
        <asp:TextBox ID="txtUnits" runat="server" /><br />
 
        <asp:Button ID="btnAddOne" runat="server" CssClass="btn"
            Text="Add This Bill" OnClick="btnAddOne_OnClick" />
        <asp:Label ID="lblAddMsg" runat="server" ForeColor="Red"></asp:Label>
        <hr />
    </asp:Panel>
 
    <!-- Step 3: retrieve last N -->
    <asp:Panel ID="pnlRetrieve" runat="server" Visible="false">
        <asp:Label runat="server" Text="Enter Last 'N' Number of Bills To Generate:" />
        <asp:TextBox ID="txtLastN" runat="server" />
        <asp:Button ID="btnFetch" runat="server" CssClass="btn"
            Text="Retrieve" OnClick="BtnFetch_Click" />
    </asp:Panel>
 
    <!-- GridView for displaying bills -->
    <asp:GridView ID="gvBills" runat="server"
        AutoGenerateColumns="false" Visible="false">
        <Columns>
            <asp:BoundField HeaderText="Consumer No" DataField="ConsumerNumber" />
            <asp:BoundField HeaderText="Name" DataField="ConsumerName" />
            <asp:BoundField HeaderText="Units" DataField="UnitsConsumed" />
            <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount"
                DataFormatString="{0:N2}" />
        </Columns>
    </asp:GridView>
 
    <!-- Textual summary like sample output -->
    <asp:Repeater ID="rptText" runat="server" Visible="false">
        <ItemTemplate>
            EB Bill for <%# Eval("ConsumerName") %> is <%# Eval("BillAmount") %><br />
        </ItemTemplate>
    </asp:Repeater>
 
</asp:Content>