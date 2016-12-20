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

public partial class CustomFormatting_GridViewTemplateField : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string DisplayDaysOnJob(Northwind.EmployeesRow employee)
    {
        // Make sure HiredDate is not null... if so, return "Unknown"
        if (employee.IsHireDateNull())
            return "Unknown";
        else
        {
            // Returns the number of days between the current 
            // date/time and hiredDate
            TimeSpan ts = DateTime.Now.Subtract(employee.HireDate);
            return ts.Days.ToString("#,##0");
        }
    }
}
