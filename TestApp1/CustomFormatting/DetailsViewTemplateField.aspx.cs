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

public partial class CustomFormatting_DetailsViewTemplateField : System.Web.UI.Page
{
    protected string DisplayDiscontinuedAsYESorNO(bool discontinued)
    {
        if (discontinued)
            return "YES";
        else
            return "NO";
    }
}
