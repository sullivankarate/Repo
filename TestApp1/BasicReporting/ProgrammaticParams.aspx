<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProgrammaticParams.aspx.cs" Inherits="BasicReporting_ProgrammaticParams" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        Employee Anniversaries This Month</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID"
            DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last" SortExpression="LastName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="HireDate" HeaderText="Hired" SortExpression="HireDate" DataFormatString="{0:d}" HtmlEncode="False" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetEmployeesByHiredDateMonth" TypeName="EmployeesBLL" OnSelecting="ObjectDataSource1_Selecting">
            <SelectParameters>
                <asp:Parameter Name="month" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

