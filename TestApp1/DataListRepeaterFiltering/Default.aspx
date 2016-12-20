<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DataListRepeaterFiltering_Default" Title="Untitled Page" %>

<%@ Register Src="../UserControls/SectionLevelTutorialListing.ascx" TagName="SectionLevelTutorialListing"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Filtering with the DataList and Repeater Controls</h2>
    <p>
        <uc1:SectionLevelTutorialListing ID="SectionLevelTutorialListing1" runat="server" />
        &nbsp;</p>
</asp:Content>

