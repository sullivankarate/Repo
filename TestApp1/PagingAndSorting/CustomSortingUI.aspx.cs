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

public partial class PagingAndSorting_CustomSortingUI : System.Web.UI.Page
{
    protected override void Render(HtmlTextWriter writer)
    {
        // Only add the sorting UI if the GridView is sorted
        if (!string.IsNullOrEmpty(ProductList.SortExpression))
        {
            // Determine the index and HeaderText of the column that 
            //the data is sorted by
            int sortColumnIndex = -1;
            string sortColumnHeaderText = string.Empty;
            for (int i = 0; i < ProductList.Columns.Count; i++)
            {
                if (ProductList.Columns[i].SortExpression.CompareTo(ProductList.SortExpression) == 0)
                {
                    sortColumnIndex = i;
                    sortColumnHeaderText = ProductList.Columns[i].HeaderText;
                    break;
                }
            }


            // Reference the Table the GridView has been rendered into
            Table gridTable = (Table)ProductList.Controls[0];

            // Enumerate each TableRow, adding a sorting UI header if
            // the sorted value has changed
            string lastValue = string.Empty;
            foreach (GridViewRow gvr in ProductList.Rows)
            {
                string currentValue = string.Empty;
                if (gvr.Cells[sortColumnIndex].Controls.Count > 0)
                {
                    if (gvr.Cells[sortColumnIndex].Controls[0] is CheckBox)
                    {
                        if (((CheckBox)gvr.Cells[sortColumnIndex].Controls[0]).Checked)
                            currentValue = "Yes";
                        else
                            currentValue = "No";
                    }

                    // ... Add other checks here if using columns with other
                    //      Web controls in them (Calendars, DropDownLists, etc.) ...
                }
                else
                    currentValue = gvr.Cells[sortColumnIndex].Text;

                if (lastValue.CompareTo(currentValue) != 0)
                {
                    // there's been a change in value in the sorted column
                    int rowIndex = gridTable.Rows.GetRowIndex(gvr);

                    // Add a new sort header row
                    GridViewRow sortRow = new GridViewRow(rowIndex, rowIndex, DataControlRowType.DataRow, DataControlRowState.Normal);
                    TableCell sortCell = new TableCell();
                    sortCell.ColumnSpan = ProductList.Columns.Count;
                    sortCell.Text = string.Format("{0}: {1}", sortColumnHeaderText, currentValue);
                    sortCell.CssClass = "SortHeaderRowStyle";

                    // Add sortCell to sortRow, and sortRow to gridTable
                    sortRow.Cells.Add(sortCell);
                    gridTable.Controls.AddAt(rowIndex, sortRow);
                    
                    // Update lastValue
                    lastValue = currentValue;
                }
            }
        }

        base.Render(writer);
    }

}
