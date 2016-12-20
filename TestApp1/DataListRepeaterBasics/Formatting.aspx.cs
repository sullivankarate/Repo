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

public partial class DataListRepeaterBasics_Formatting : System.Web.UI.Page
{
    protected void ItemDataBoundFormattingExample_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Programmatically reference the ProductsRow instance bound to this DataListItem
            Northwind.ProductsRow product = (Northwind.ProductsRow)((System.Data.DataRowView)e.Item.DataItem).Row;

            // See if the UnitPrice is not NULL and less than $20.00
            if (!product.IsUnitPriceNull() && product.UnitPrice < 20)
            {
                // Highlight the product name and unit price Labels
                // First, get a reference to the two Label Web controls
                Label ProductNameLabel = (Label)e.Item.FindControl("ProductNameLabel");
                Label UnitPriceLabel = (Label)e.Item.FindControl("UnitPriceLabel");

                // Next, set their CssClass properties
                if (ProductNameLabel != null)
                    ProductNameLabel.CssClass = "AffordablePriceEmphasis";

                if (UnitPriceLabel != null)
                    UnitPriceLabel.CssClass = "AffordablePriceEmphasis";

                
                
                // Alternatively, you can opt to adjust the style for the *entire* item:
                // e.Item.CssClass = "AffordablePriceEmphasis";
            }
        }
    }

    protected string DisplayProductNameAndDiscontinuedStatus(string productName, bool discontinued)
    {
        // Return just the productName if discontinued is false
        if (!discontinued)
            return productName;
        else
            // otherwise, return the productName appended with the text "[DISCONTINUED]"
            return string.Concat(productName, " [DISCONTINUED]");
    }

    protected string DisplayPrice(Northwind.ProductsRow product)
    {
        // If price is less than $20.00, return the price, highlighted
        if (!product.IsUnitPriceNull() && product.UnitPrice < 20)
            return string.Concat("<span class=\"AffordablePriceEmphasis\">", product.UnitPrice.ToString("C"), "</span>");
        else
            // Otherwise return the text, "Please call for a price quote"
            return "<span>Please call for a price quote</span>";
    }


    // ALTERATIVE OPTION: You can also allow the UnitPrice to be passed in as a scalar value...
    //protected string DisplayPrice(object unitPrice)
    //{
    //    // If price is less than $20.00, return the price, highlighted
    //    if (!Convert.IsDBNull(unitPrice) && ((decimal)unitPrice) < 20)
    //        return string.Concat("<span class=\"AffordablePriceEmphasis\">", ((decimal)unitPrice).ToString("C"), "</span>");
    //    else
    //        // Otherwise return the text, "Please call for a price quote"
    //        return "<span>Please call for a price quote</span>";
    //}

}
