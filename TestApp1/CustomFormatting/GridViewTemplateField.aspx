<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GridViewTemplateField.aspx.cs" Inherits="CustomFormatting_GridViewTemplateField" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Custom Formatting with a TemplateField</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:TemplateField HeaderText="HireDate" SortExpression="HireDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("HireDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" SelectedDate='<%# Bind("HireDate") %>'
                            VisibleDate='<%# Eval("HireDate") %>'></asp:Calendar>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Days On The Job">
                    <ItemTemplate>
                        <%# DisplayDaysOnJob((Northwind.EmployeesRow) ((System.Data.DataRowView) Container.DataItem).Row) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetEmployees" TypeName="EmployeesBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>

