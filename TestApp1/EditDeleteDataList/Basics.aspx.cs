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

public partial class EditDeleteDataList_Basics : System.Web.UI.Page
{
    #region Editing-Related Event Handlers
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        // Set the DataList's EditItemIndex property to the
        // index of the DataListItem that was clicked
        DataList1.EditItemIndex = e.Item.ItemIndex;

        // Rebind the data to the DataList
        DataList1.DataBind();
    }

    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        // Set the DataList's EditItemIndex property to -1
        DataList1.EditItemIndex = -1;

        // Rebind the data to the DataList
        DataList1.DataBind();
    }

    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        // Read in the ProductID from the DataKeys collection
        int productID = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex]);

        // Read in the product name and price values
        TextBox productName = (TextBox)e.Item.FindControl("ProductName");
        TextBox unitPrice = (TextBox)e.Item.FindControl("UnitPrice");

        string productNameValue = null;
        if (productName.Text.Trim().Length > 0)
            productNameValue = productName.Text.Trim();
        
        decimal? unitPriceValue = null;
        if (unitPrice.Text.Trim().Length > 0)
            unitPriceValue = Decimal.Parse(unitPrice.Text.Trim(), System.Globalization.NumberStyles.Currency);

        // Call the ProductsBLL's UpdateProduct method...
        ProductsBLL productsAPI = new ProductsBLL();
        productsAPI.UpdateProduct(productNameValue, unitPriceValue, productID);
        

        // Revert the DataList back to its pre-editing state
        DataList1.EditItemIndex = -1;
        DataList1.DataBind();
    }
    #endregion


    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        // Read in the ProductID from the DataKeys collection
        int productID = Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex]);

        // Delete the data
        ProductsBLL productsAPI = new ProductsBLL();
        productsAPI.DeleteProduct(productID);

        // Rebind the data to the DataList
        DataList1.DataBind();
    }
}
