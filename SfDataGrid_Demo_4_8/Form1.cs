using SfDataGrid_Demo_4_8.Model;
using SfDataGrid_Demo_4_8.ViewModel;
using Syncfusion.Data;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.DataPager;
using Syncfusion.WinForms.Input.Enums;
using Syncfusion.WinForms.ListView.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGrid_Demo_4_8
{
    public partial class Form1 : Form
    {
        OrderInfoCollection orderInfo;
        public Dictionary<int, ObservableCollection<object>> selectedItemCollection = new Dictionary<int, ObservableCollection<object>>();
        ObservableCollection<object> selectedItems;
        public Form1()
        {
            InitializeComponent();
            selectedItems = new ObservableCollection<object>();
            orderInfo = new OrderInfoCollection(250000);
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };

            this.sfDataGrid1.Columns.Add(new GridCheckBoxSelectorColumn() { MappingName = "Select", HeaderText = "Select"});
            this.sfDataGrid1.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;
            this.sfDataGrid1.DataSource = orderInfo.OrdersListDetails;
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ContactNumber", HeaderText = "Contact Number" });
            this.sfDataGrid1.Columns["ContactNumber"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;
            NumberFormatInfo numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.CurrencyDecimalDigits = 0;
            numberFormat.CurrencyGroupSizes = new int[] { };

            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                MappingName = "UnitPrice",
                HeaderText = "Unit Price",
                FormatMode = FormatMode.Currency,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                HeaderText = "Quantity",
                MappingName = "Quantity",
                FormatMode = FormatMode.Numeric,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.PercentDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "Discount", HeaderText = "Discount", FormatMode = FormatMode.Percent, NumberFormatInfo = numberFormat });
            this.sfDataGrid1.Columns.Add(new GridDateTimeColumn() { MappingName = "OrderDate", HeaderText = "Order Date", FilterMode = ColumnFilter.DisplayText });
            this.sfDataGrid1.Columns.Add(new GridHyperlinkColumn() { MappingName = "Hyperlink", HeaderText = "Order URI" });

            sfDataGrid1.CellClick += SfDataGrid1_CellClick;
            sfDataGrid1.SelectionChanged += SfDataGrid1_SelectionChanged;
        }

        private void SfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0 && !selectedItems.Contains(e.AddedItems[0]))
                selectedItems.Add(e.AddedItems[0]);
            if (e.RemovedItems.Count > 0 && selectedItems.Contains(e.RemovedItems[0]))
                selectedItems.Remove(e.RemovedItems[0]);

        }
        bool recordsfiltered = false;
        private void SfDataGrid1_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.HeaderRow
                && e.DataColumn.GridColumn is GridCheckBoxSelectorColumn)
            {
                if (!recordsfiltered)
                {
                    sfDataGrid1.View.Filter = FilterRecords;
                    sfDataGrid1.View.RefreshFilter();
                    recordsfiltered = true;
                }
                else
                {
                    sfDataGrid1.View.Filter = null;
                    sfDataGrid1.View.RefreshFilter();
                    recordsfiltered = false;
                }
                selectedItems.ForEach(x => this.sfDataGrid1.SelectedItems.Add(x));
            }
        }

        public bool FilterRecords(object o)
        {
            var item = o as OrderInfo;
            if (item != null)
            {
                foreach(var selectedItem in selectedItems)
                {
                    if (item.Equals(selectedItem))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
