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

public partial class CustomFormatting_SummaryDataInFooter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Class-scope, running total variables...
    decimal _totalUnitPrice = 0m;
    int _totalNonNullUnitPriceCount = 0;
    int _totalUnitsInStock = 0;
    int _totalUnitsOnOrder = 0;

    protected void ProductsInCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Reference the ProductsRow via the e.Row.DataItem property
            Northwind.ProductsRow product = (Northwind.ProductsRow)((System.Data.DataRowView)e.Row.DataItem).Row;

            // Increment the running totals (if they're not NULL!)
            if (!product.IsUnitPriceNull())
            {
                _totalUnitPrice += product.UnitPrice;
                _totalNonNullUnitPriceCount++;
            }

            if (!product.IsUnitsInStockNull())
                _totalUnitsInStock += product.UnitsInStock;

            if (!product.IsUnitsOnOrderNull())
                _totalUnitsOnOrder += product.UnitsOnOrder;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            // Determine the average UnitPrice
            decimal avgUnitPrice = _totalUnitPrice / (decimal)_totalNonNullUnitPriceCount;

            // Display the summary data in the appropriate cells
            e.Row.Cells[1].Text = "Avg.: " + avgUnitPrice.ToString("c");
            e.Row.Cells[2].Text = "Total: " + _totalUnitsInStock.ToString();
            e.Row.Cells[3].Text = "Total: " + _totalUnitsOnOrder.ToString();
        }
    }
}
