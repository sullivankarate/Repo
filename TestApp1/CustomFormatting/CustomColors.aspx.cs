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

public partial class CustomFormatting_CustomColors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ExpensiveProductsPriceInBoldItalic_DataBound(object sender, EventArgs e)
    {
        // Get the ProductsRow object from the DataItem property...
        Northwind.ProductsRow product = (Northwind.ProductsRow)((System.Data.DataRowView) ExpensiveProductsPriceInBoldItalic.DataItem).Row;
        if (!product.IsUnitPriceNull() && product.UnitPrice > 75m)
        {
            ExpensiveProductsPriceInBoldItalic.Rows[4].Cells[1].CssClass = "ExpensivePriceEmphasis";
        }
    }

    protected void LowStockedProductsInRed_DataBound(object sender, EventArgs e)
    {
        // Get the ProductsRow object from the DataItem property...
        Northwind.ProductsRow product = (Northwind.ProductsRow)((System.Data.DataRowView)LowStockedProductsInRed.DataItem).Row;
        if (!product.IsUnitsInStockNull() && product.UnitsInStock <= 10)
        {
            Label unitsInStock = (Label)LowStockedProductsInRed.FindControl("UnitsInStockLabel");

            if (unitsInStock != null)
            {
                unitsInStock.CssClass = "LowUnitsInStockEmphasis";
            }
        }
    }

    protected void HighlightCheapProducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Make sure we are working with a DataRow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the ProductsRow object from the DataItem property...
            Northwind.ProductsRow product = (Northwind.ProductsRow)((System.Data.DataRowView)e.Row.DataItem).Row;
            if (!product.IsUnitPriceNull() && product.UnitPrice < 10m)
            {
                e.Row.CssClass = "AffordablePriceEmphasis";
            }
        }
    }
}
