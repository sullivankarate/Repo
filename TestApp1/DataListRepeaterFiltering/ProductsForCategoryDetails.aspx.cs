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

public partial class DataListRepeaterFiltering_ProductsForCategoryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ProductsInCategory_DataBinding(object sender, EventArgs e)
    {
        // Show the Label
        NoProductsMessage.Visible = true;
    }
    protected void ProductsInCategory_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        // If we have a data item, hide the Label
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            NoProductsMessage.Visible = false;
    }
}
