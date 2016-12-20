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

public partial class EditInsertDelete_UserLevelAccess : System.Web.UI.Page
{
    protected void Suppliers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Suppliers.SelectedValue == "-1")
        {
            // The "Show/Edit ALL" option has been selected
            SupplierDetails.DataSourceID = "AllSuppliersDataSource";

            // Reset the page index to show the first record
            SupplierDetails.PageIndex = 0;
        }
        else
            // The user picked a particular supplier
            SupplierDetails.DataSourceID = "SingleSupplierDataSource";

        // Ensure that the DetailsView and GridView are in read-only mode
        SupplierDetails.ChangeMode(DetailsViewMode.ReadOnly);
        ProductsBySupplier.EditIndex = -1;

        // Need to "refresh" the DetailsView
        SupplierDetails.DataBind();
    }

    protected void ProductsBySupplier_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Is this a supplier-specific user?
            if (Suppliers.SelectedValue != "-1")
            {
                // Get a reference to the ProductRow
                Northwind.ProductsRow product = (Northwind.ProductsRow)((System.Data.DataRowView)e.Row.DataItem).Row;

                // Is this product discontinued?
                if (product.Discontinued)
                {
                    // Get a reference to the Edit LinkButton
                    LinkButton editButton = (LinkButton)e.Row.Cells[0].Controls[0];

                    // Hide the Edit button
                    editButton.Visible = false;
                }
            }
        }
    }
}
