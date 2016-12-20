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
/// Summary description for Employees
/// </summary>
[System.ComponentModel.DataObject]
public class EmployeesBLL
{
    private EmployeesTableAdapter _employeesAdapter = null;
    protected EmployeesTableAdapter Adapter
    {
        get
        {
            if (_employeesAdapter == null)
                _employeesAdapter = new EmployeesTableAdapter();

            return _employeesAdapter;
        }
    }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public Northwind.EmployeesDataTable GetEmployees()
    {
        return Adapter.GetEmployees();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.EmployeesDataTable GetEmployeeByEmployeeID(int employeeID)
    {
        return Adapter.GetEmployeeByEmployeeID(employeeID);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.EmployeesDataTable GetEmployeesByManager(int managerID)
    {
        return Adapter.GetEmployeesByManager(managerID);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Northwind.EmployeesDataTable GetEmployeesByHiredDateMonth(int month)
    {
        return Adapter.GetEmployeesByHiredDateMonth(month);
    }
}
