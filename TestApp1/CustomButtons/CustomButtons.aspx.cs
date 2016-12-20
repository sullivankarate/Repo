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

public partial class CustomButtons_CustomButtons : System.Web.UI.Page
{
    protected void Suppliers_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName.CompareTo("DiscontinueProducts") == 0)
        {
            // The "Discontinue All Products" Button was clicked.
            // Invoke the ProductsBLL.DiscontinueAllProductsForSupplier(supplierID) method

            // First, get the SupplierID selected in the FormView
            int supplierID = (int)Suppliers.SelectedValue;

            // Next, create an instance of the ProductsBLL class
            ProductsBLL productInfo = new ProductsBLL();

            // Finally, invoke the DiscontinueAllProductsForSupplier(supplierID) method
            productInfo.DiscontinueAllProductsForSupplier(supplierID);
        }
    }

    protected void SuppliersProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.CompareTo("IncreasePrice") == 0 ||
            e.CommandName.CompareTo("DecreasePrice") == 0)
        {
            // The Increase Price or Decrease Price Button has been clicked

            // Determine the ID of the product whose price was adjusted
            int productID = (int)SuppliersProducts.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;

            // Determine how much to adjust the price
            decimal percentageAdjust;
            if (e.CommandName.CompareTo("IncreasePrice") == 0)
                percentageAdjust = 1.1M;
            else
                percentageAdjust = 0.9M;


            // Adjust the price
            ProductsBLL productInfo = new ProductsBLL();
            productInfo.UpdateProduct(percentageAdjust, productID);
        }
    }
}
