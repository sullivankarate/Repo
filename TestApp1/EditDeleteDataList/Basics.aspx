<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Basics.aspx.cs" Inherits="EditDeleteDataList_Basics" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        The Basics of Editing and Deleting with the DataList</h2>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="ObjectDataSource1" RepeatColumns="2" OnEditCommand="DataList1_EditCommand" OnCancelCommand="DataList1_CancelCommand" OnUpdateCommand="DataList1_UpdateCommand" OnDeleteCommand="DataList1_DeleteCommand">
            <ItemTemplate>
                <h5><asp:Label runat="server" ID="ProductNameLabel" Text='<%# Eval("ProductName") %>'></asp:Label></h5>
                Price: <asp:Label runat="server" ID="Label1" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                <br />
                <asp:Button runat="server" id="EditProduct" CommandName="Edit" Text="Edit" />
                &nbsp;
                <asp:Button runat="server" id="DeleteProduct" CommandName="Delete" Text="Delete" />
                <br />
                <br />
            </ItemTemplate>
            <EditItemTemplate>
                Product name:
                <asp:TextBox ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:TextBox><br />
                Price:
                <asp:TextBox ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:TextBox><br />
                <br />
                <asp:Button ID="UpdateProduct" runat="server" CommandName="Update" Text="Update" />&nbsp;<asp:Button
                    ID="CancelUpdate" runat="server" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
        </asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            SelectMethod="GetProducts" TypeName="ProductsBLL" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
    </p>
</asp:Content>

