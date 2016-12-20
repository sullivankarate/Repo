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

public partial class EditInsertDelete_ErrorHandling : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ExceptionDetails.Visible = false;
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (e.NewValues["UnitPrice"] != null)
            e.NewValues["UnitPrice"] = decimal.Parse(e.NewValues["UnitPrice"].ToString(), System.Globalization.NumberStyles.Currency);
    }

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            // Display a user-friendly message
            ExceptionDetails.Visible = true;
            ExceptionDetails.Text = "There was a problem updating the product. ";

            if (e.Exception.InnerException != null)
            {
                Exception inner = e.Exception.InnerException;

                if (inner is System.Data.Common.DbException)
                    ExceptionDetails.Text += "Our database is currently experiencing problems. Please try again later.";
                else if (inner is NoNullAllowedException)
                    ExceptionDetails.Text += "There are one or more required fields that are missing.";
                else if (inner is ArgumentException)
                {
                    string paramName = ((ArgumentException)inner).ParamName;
                    ExceptionDetails.Text += string.Concat("The ", paramName, " value is illegal.");
                }
                else if (inner is ApplicationException)
                    ExceptionDetails.Text += inner.Message;
            }

            // Indicate that the exception has been handled
            e.ExceptionHandled = true;

            // Keep the row in edit mode
            e.KeepInEditMode = true;
        }
    }
}
