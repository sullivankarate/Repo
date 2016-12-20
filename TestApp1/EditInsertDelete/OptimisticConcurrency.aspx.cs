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

public partial class EditInsertDelete_OptimisticConcurrency : System.Web.UI.Page
{
    protected void ProductsOptimisticConcurrencyDataSource_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.ReturnValue != null && e.ReturnValue is bool)
        {
            bool deleteReturnValue = (bool)e.ReturnValue;

            if (deleteReturnValue == false)
            {
                // No row was deleted, display the warning message
                DeleteConflictMessage.Visible = true;
            }
        }
    }

    protected void ProductsGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null && e.Exception.InnerException != null)
        {
            if (e.Exception.InnerException is System.Data.DBConcurrencyException)
            {
                // Display the warning message and note that the exception has
                // been handled...
                UpdateConflictMessage.Visible = true;
                e.ExceptionHandled = true;

                // OPTIONAL: Rebind the data to the GridView and keep it in edit mode
                //ProductsGrid.DataBind();
                //e.KeepInEditMode = true;
            }
        }
    }

    // OPTIONAL: Display a warning message if the user attempts to update a record that has since been deleted
    //              To use this logic, uncomment the Label control in the markup portion.
    protected void ProductsOptimisticConcurrencyDataSource_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //if (e.ReturnValue != null && e.ReturnValue is bool)
        //{
        //    bool updateReturnValue = (bool)e.ReturnValue;

        //    if (updateReturnValue == false)
        //    {
        //        // No row was updated, display the warning message
        //        UpdateLostMessage.Visible = true;
        //    }
        //}
    }
}