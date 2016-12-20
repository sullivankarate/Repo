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

public partial class UserControls_SectionLevelTutorialListing : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // If SiteMap.CurrentNode is not null,
        // bind CurrentNode's ChildNodes to the GridView
        if (SiteMap.CurrentNode != null)
        {
            TutorialList.DataSource = SiteMap.CurrentNode.ChildNodes;
            TutorialList.DataBind();
        }
    }
}
