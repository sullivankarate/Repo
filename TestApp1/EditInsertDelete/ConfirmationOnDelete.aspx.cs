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

public partial class EditInsertDelete_ConfirmationOnDelete : System.Web.UI.Page
{
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // reference the Delete LinkButton
            LinkButton db = (LinkButton)e.Row.Cells[0].Controls[0];

            // Get information about the product bound to the row
            Northwind.ProductsRow product = (Northwind.ProductsRow) ((System.Data.DataRowView) e.Row.DataItem).Row;

            db.OnClientClick = string.Format("return confirm('Are you certain you want to delete the {0} product?');", product.ProductName.Replace("'", @"\'"));
        }
    }
}
