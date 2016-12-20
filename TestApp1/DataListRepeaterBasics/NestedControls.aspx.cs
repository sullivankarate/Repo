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

public partial class DataListRepeaterBasics_NestedControls : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    // OPTIONAL: Use this ItemDataBound event handler if you want to use the ObjectDataSource approach
    //           to bind the data to the inner Repeater... this event handler references that ObjectDataSource
    //           and sets its CategoryID parameter accordingly...
    //protected void CategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
    //    {
    //        // Reference the CategoriesRow object being bound to this RepeaterItem
    //        Northwind.CategoriesRow category = (Northwind.CategoriesRow)((System.Data.DataRowView)e.Item.DataItem).Row;

    //        // Reference the ProductsByCategoryDataSource ObjectDataSource
    //        ObjectDataSource ProductsByCategoryDataSource = (ObjectDataSource)e.Item.FindControl("ProductsByCategoryDataSource");

    //        // Set the CategoryID Parameter value
    //        ProductsByCategoryDataSource.SelectParameters["CategoryID"].DefaultValue = category.CategoryID.ToString();
    //    }
    //}

    // OPTIONAL: You can use this implementation of the GetProductsInCategory method if you want; it simply returns
    //           the exact subset of products for the specified categoryID using the ProductsBLL class's
    //           GetProductsByCategoryID method...
    //protected Northwind.ProductsDataTable GetProductsInCategory(int categoryID)
    //{
    //    // Create an instance of the ProductsBLL class
    //    ProductsBLL productAPI = new ProductsBLL();

    //    // Return the products in the category
    //    return productAPI.GetProductsByCategoryID(categoryID);
    //}

    // This implementation of the GetProductsInCategory method intelligently accesses ALL of the
    // products from the database first, and then returns the filtered view of those results based
    // on the passed-in categoryID parameter...
    private Northwind.ProductsDataTable allProducts = null;

    protected Northwind.ProductsDataTable GetProductsInCategory(int categoryID)
    {
        // First, see if we've yet to have accessed all of the product information
        if (allProducts == null)
        {
            ProductsBLL productAPI = new ProductsBLL();
            allProducts = productAPI.GetProducts();
        }

        // Return the filtered view
        allProducts.DefaultView.RowFilter = "CategoryID = " + categoryID;
        return allProducts;
    }
}
