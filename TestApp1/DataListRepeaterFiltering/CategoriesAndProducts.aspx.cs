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

public partial class DataListRepeaterFiltering_CategoriesAndProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // OPTIONAL: Use the ItemDataBound event handler approach to retrieve information about
    //           how many products there are for the category without having to modify the DAL
    protected void Categories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // Make sure we're working with a data item...
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Reference the CategoriesRow instance bound to this RepeaterItem
            Northwind.CategoriesRow category = (Northwind.CategoriesRow) ((System.Data.DataRowView) e.Item.DataItem).Row;

            // Determine how many products are in this category
            NorthwindTableAdapters.ProductsTableAdapter productsAPI = new NorthwindTableAdapters.ProductsTableAdapter();
            int productCount = productsAPI.GetProductsByCategoryID(category.CategoryID).Count;

            // Reference the ViewCategory LinkButton and set its Text property
            LinkButton ViewCategory = (LinkButton)e.Item.FindControl("ViewCategory");
            ViewCategory.Text = string.Format("{0} ({1:N0})", category.CategoryName, productCount);
        }
    }

    protected void Categories_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // If it's the "ListProducts" command that has been issued...
        if (string.Compare(e.CommandName, "ListProducts", true) == 0)
        {
            // Set the CategoryProductsDataSource ObjectDataSource's CategoryID parameter
            // to the CategoryID of the category that was just clicked (e.CommandArgument)...
            CategoryProductsDataSource.SelectParameters["CategoryID"].DefaultValue = e.CommandArgument.ToString();
        }
    }
}
