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

public partial class PagingAndSorting_EfficientPaging : System.Web.UI.Page
{

    // The following two event handlers illustrate two different techniques you can use to
    // correctly handle deleting when using custom paging with an ObjectDataSource. Currently,
    // these event handlers aren't wired up to any event, so they have no effect. But if you
    // configure the GridView to support deleing, you'll want to use either one of these two
    // approaches so that when a user deletes the last record from a page, the GridView's PageIndex
    // is updated accordingly.

    protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        // If we get back a Boolean value from the DeleteProduct method and it's true, then
        // we successfully deleted the product. Set AffectedRows to 1
        if (e.ReturnValue is bool && ((bool)e.ReturnValue) == true)
            e.AffectedRows = 1;
    }

    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        // If we just deleted the last row in the GridView, decrement the PageIndex
        if (GridView1.Rows.Count == 1)
            // we just deleted the last row
            GridView1.PageIndex = Math.Max(0, GridView1.PageIndex - 1);
    }
}
