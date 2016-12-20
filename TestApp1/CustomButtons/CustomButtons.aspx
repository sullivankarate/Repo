<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomButtons.aspx.cs" Inherits="CustomButtons_CustomButtons" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Using ButtonFields and Buttons in Templates</h2>
    <p>
        <asp:FormView ID="Suppliers" runat="server" DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" EnableViewState="False" AllowPaging="True" OnItemCommand="Suppliers_ItemCommand">
            <ItemTemplate>
                <h3><asp:Label ID="CompanyName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label></h3>
                <b>Phone:</b>
                <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                <br />
                <asp:Button ID="DiscontinueAllProductsForSupplier" runat="server" CommandName="DiscontinueProducts"
                    Text="Discontinue All Products" OnClientClick="return confirm('This will mark _all_ of this supplier\'s products as discontinued. Are you certain you want to do this?');" />
            </ItemTemplate>
        </asp:FormView>
        
        <asp:ObjectDataSource ID="SuppliersDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSuppliers" TypeName="SuppliersBLL"></asp:ObjectDataSource>
    </p>
    <p>
        <asp:GridView ID="SuppliersProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SuppliersProductsDataSource" EnableViewState="False" OnRowCommand="SuppliersProducts_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="IncreasePrice" Text="Price +10%" />
                <asp:ButtonField ButtonType="Button" CommandName="DecreasePrice" Text="Price -10%" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" SortExpression="UnitPrice" DataFormatString="{0:C}" HtmlEncode="False" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        
        <asp:ObjectDataSource ID="SuppliersProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsBySupplierID" TypeName="ProductsBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="Suppliers" Name="supplierID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

