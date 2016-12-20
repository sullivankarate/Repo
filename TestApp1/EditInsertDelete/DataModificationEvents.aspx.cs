using System;
using System.Globalization;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class EditInsertDelete_DataModificationEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MustProvideUnitPriceMessage.Visible = false;
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (e.NewValues["UnitPrice"] != null)
            e.NewValues["UnitPrice"] = decimal.Parse(e.NewValues["UnitPrice"].ToString(), System.Globalization.NumberStyles.Currency);
        else
        {
            // Show the Label
            MustProvideUnitPriceMessage.Visible = true;

            // Cancel the update
            e.Cancel = true;
        }
    }

    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["CategoryID"] = 1;
        e.InputParameters["SupplierID"] = 1;
    }
}
