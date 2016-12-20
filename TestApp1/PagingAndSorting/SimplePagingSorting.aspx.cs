using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class PagingAndSorting_SimplePagingSorting : System.Web.UI.Page
{
    protected void Products_DataBound(object sender, EventArgs e)
    {
        PagingInformation.Text = string.Format("You are viewing page {0} of {1}...", Products.PageIndex + 1, Products.PageCount);

        // Clear out all of the items in the DropDownList
        PageList.Items.Clear();

        // Add a ListItem for each page
        for (int i = 0; i < Products.PageCount; i++)
        {
            // Add the new ListItem
            ListItem pageListItem = new ListItem(string.Concat("Page ", i + 1), i.ToString());
            PageList.Items.Add(pageListItem);

            // select the current item, if needed
            if (i == Products.PageIndex)
                pageListItem.Selected = true;
        }
    }

    protected void PageList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Jump to the specified page
        Products.PageIndex = Convert.ToInt32(PageList.SelectedValue);
    }

    protected void SortPriceDescending_Click(object sender, EventArgs e)
    {
        // Sort by UnitPrice in descending order
        Products.Sort("UnitPrice", SortDirection.Descending);
    }
}
