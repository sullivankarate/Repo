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

[System.ComponentModel.DataObject]
public class ProductsBLL
{
    private ProductsTableAdapter _productsAdapter = null;
    protected ProductsTableAdapter Adapter
    {
        get {
            if (_productsAdapter == null)
                _productsAdapter = new ProductsTableAdapter();

            return _productsAdapter; 
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Northwind.ProductsDataTable GetProducts()
    {
        return Adapter.GetProducts();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.ProductsDataTable GetProductByProductID(int productID)
    {
        return Adapter.GetProductByProductID(productID);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.ProductsDataTable GetProductsByCategoryID(int categoryID)
    {
        if (categoryID < 0)
            return GetProducts();
        else
            return Adapter.GetProductsByCategoryID(categoryID);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.ProductsDataTable GetProductsBySupplierID(int supplierID)
    {
        return Adapter.GetProductsBySupplierID(supplierID);
    }

    #region Custom Paging-Related Methods
    public int TotalNumberOfProducts()
    {
        return Adapter.TotalNumberOfProducts().GetValueOrDefault();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.ProductsDataTable GetProductsPaged(int startRowIndex, int maximumRows)
    {
        return Adapter.GetProductsPaged(startRowIndex, maximumRows);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.ProductsDataTable GetProductsPagedAndSorted(string sortExpression, int startRowIndex, int maximumRows)
    {
        return Adapter.GetProductsPagedAndSorted(sortExpression, startRowIndex, maximumRows);
    }
    #endregion

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddProduct(string productName, int? supplierID, int? categoryID, string quantityPerUnit, 
                          decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, 
                          bool discontinued)
    {
        // Create a new ProductRow instance
        Northwind.ProductsDataTable products = new Northwind.ProductsDataTable();
        Northwind.ProductsRow product = products.NewProductsRow();

        product.ProductName = productName;
        if (supplierID == null) product.SetSupplierIDNull(); else product.SupplierID = supplierID.Value;
        if (categoryID == null) product.SetCategoryIDNull(); else product.CategoryID = categoryID.Value;
        if (quantityPerUnit == null) product.SetQuantityPerUnitNull(); else product.QuantityPerUnit = quantityPerUnit;
        if (unitPrice == null) product.SetUnitPriceNull(); else product.UnitPrice = unitPrice.Value;
        if (unitsInStock == null) product.SetUnitsInStockNull(); else product.UnitsInStock = unitsInStock.Value;
        if (unitsOnOrder == null) product.SetUnitsOnOrderNull(); else product.UnitsOnOrder = unitsOnOrder.Value;
        if (reorderLevel == null) product.SetReorderLevelNull(); else product.ReorderLevel = reorderLevel.Value;
        product.Discontinued = discontinued;

        // Add the new product
        products.AddProductsRow(product);
        int rowsAffected = Adapter.Update(products);

        // Return true if precisely one row was inserted, otherwise false
        return rowsAffected == 1;
    }

    #region UpdateProduct Overloads
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
    public bool UpdateProduct(string productName, int? supplierID, int? categoryID, string quantityPerUnit,
                              decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel,
                              bool discontinued, int productID)
    {
        Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
        if (products.Count == 0)
            // no matching record found, return false
            return false;

        Northwind.ProductsRow product = products[0];

        // Business rule check - cannot discontinue a product that's supplied by only
        // one supplier
        if (discontinued)
        {
            // Get the products we buy from this supplier
            Northwind.ProductsDataTable productsBySupplier = Adapter.GetProductsBySupplierID(product.SupplierID);

            if (productsBySupplier.Count == 1)
                // this is the only product we buy from this supplier
                throw new ApplicationException("You cannot mark a product as discontinued if its the only product purchased from a supplier");
        }

        product.ProductName = productName;
        if (supplierID == null) product.SetSupplierIDNull(); else product.SupplierID = supplierID.Value;
        if (categoryID == null) product.SetCategoryIDNull(); else product.CategoryID = categoryID.Value;
        if (quantityPerUnit == null) product.SetQuantityPerUnitNull(); else product.QuantityPerUnit = quantityPerUnit;
        if (unitPrice == null) product.SetUnitPriceNull(); else product.UnitPrice = unitPrice.Value;
        if (unitsInStock == null) product.SetUnitsInStockNull(); else product.UnitsInStock = unitsInStock.Value;
        if (unitsOnOrder == null) product.SetUnitsOnOrderNull(); else product.UnitsOnOrder = unitsOnOrder.Value;
        if (reorderLevel == null) product.SetReorderLevelNull(); else product.ReorderLevel = reorderLevel.Value;
        product.Discontinued = discontinued;

        // Update the product record
        int rowsAffected = Adapter.Update(product);

        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
    public bool UpdateProduct(string productName, decimal? unitPrice, int productID)
    {
        Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
        if (products.Count == 0)
            // no matching record found, return false
            return false;

        Northwind.ProductsRow product = products[0];

        product.ProductName = productName;
        if (unitPrice == null) product.SetUnitPriceNull(); else product.UnitPrice = unitPrice.Value;

        // Update the product record
        int rowsAffected = Adapter.Update(product);

        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
    public bool UpdateProduct(string productName, decimal? unitPrice, short? unitsInStock, int productID)
    {
        Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
        if (products.Count == 0)
            // no matching record found, return false
            return false;

        Northwind.ProductsRow product = products[0];

        // Make sure the price hasn't more than doubled
        if (unitPrice != null && !product.IsUnitPriceNull())
            if (unitPrice > product.UnitPrice * 2)
                throw new ApplicationException("When updating a product's price, the new price cannot exceed twice the original price.");


        product.ProductName = productName;
        if (unitPrice == null) product.SetUnitPriceNull(); else product.UnitPrice = unitPrice.Value;
        if (unitsInStock == null) product.SetUnitsInStockNull(); else product.UnitsInStock = unitsInStock.Value;

        // Update the product record
        int rowsAffected = Adapter.Update(product);

        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
    public bool UpdateProduct(string productName, int? categoryID, int? supplierID, bool discontinued, int productID)
    {
        Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
        if (products.Count == 0)
            // no matching record found, return false
            return false;

        Northwind.ProductsRow product = products[0];

        product.ProductName = productName;
        if (supplierID == null) product.SetSupplierIDNull(); else product.SupplierID = supplierID.Value;
        if (categoryID == null) product.SetCategoryIDNull(); else product.CategoryID = categoryID.Value;
        product.Discontinued = discontinued;

        // Update the product record
        int rowsAffected = Adapter.Update(product);

        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
    public bool UpdateProduct(string productName, string quantityPerUnit, int productID)
    {
        Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
        if (products.Count == 0)
            // no matching record found, return false
            return false;

        Northwind.ProductsRow product = products[0];

        product.ProductName = productName;
        if (quantityPerUnit == null) product.SetQuantityPerUnitNull(); else product.QuantityPerUnit = quantityPerUnit;

        // Update the product record
        int rowsAffected = Adapter.Update(product);

        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }

    public bool UpdateProduct(decimal unitPriceAdjustmentPercentage, int productID)
    {
        Northwind.ProductsDataTable products = Adapter.GetProductByProductID(productID);
        if (products.Count == 0)
            // no matching record found, return false
            return false;

        Northwind.ProductsRow product = products[0];

        // Adjust the UnitPrice by the specified percentage (if it's not NULL)
        if (!product.IsUnitPriceNull())
            product.UnitPrice *= unitPriceAdjustmentPercentage;

        // Update the product record
        int rowsAffected = Adapter.Update(product);

        // Return true if precisely one row was updated, otherwise false
        return rowsAffected == 1;
    }
    #endregion

    public int DiscontinueAllProductsForSupplier(int supplierID)
    {
        return Adapter.DiscontinueAllProductsForSupplier(supplierID);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteProduct(int productID)
    {
        int rowsAffected = Adapter.Delete(productID);

        // Return true if precisely one row was deleted, otherwise false
        return rowsAffected == 1;
    }
}
