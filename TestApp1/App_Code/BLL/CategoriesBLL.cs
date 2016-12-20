using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NorthwindTableAdapters;

/// <summary>
/// Summary description for Categories
/// </summary>
[System.ComponentModel.DataObject]
public class CategoriesBLL
{
    private CategoriesTableAdapter _categoriesAdapter = null;
    protected CategoriesTableAdapter Adapter
    {
        get
        {
            if (_categoriesAdapter == null)
                _categoriesAdapter = new CategoriesTableAdapter();

            return _categoriesAdapter;
        }
    }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Northwind.CategoriesDataTable GetCategories()
    {
        return Adapter.GetCategories();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.CategoriesDataTable GetCategoriesAndNumberOfProducts()
    {
        return Adapter.GetCategoriesAndNumberOfProducts();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.CategoriesDataTable GetCategoryByCategoryID(int categoryID)
    {
        return Adapter.GetCategoryByCategoryID(categoryID);
    }
}
