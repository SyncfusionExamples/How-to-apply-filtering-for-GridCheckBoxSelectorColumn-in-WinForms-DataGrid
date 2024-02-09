# How to apply filtering for GridCheckBoxSelectorColumn in WinForms DataGrid

In [WinForms DataGrid](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html) (SfDataGrid), As of now, we cannot apply filters directly to the [GridCheckBoxSelectorColumn](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.GridCheckBoxSelectorColumn.html). However, we made a customization to apply filters using [ViewFilter](https://help.syncfusion.com/cr/windowsforms/Syncfusion.Data.CollectionViewAdv.html#Syncfusion_Data_CollectionViewAdv_Filter). You can click the GridCheckBoxSelectorColumn header cell to apply filter. Again, click the header to remove filter.



Kindly refer the below code snippet.
 
 ```C#
 ObservableCollection<object> selectedItems = new ObservableCollection<object>();
sfDataGrid1.CellClick += SfDataGrid1_CellClick;

sfDataGrid1.SelectionChanged += SfDataGrid1_SelectionChanged;


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
              recordsfiltered = true;
          }
          else
          {
              sfDataGrid1.View.Filter = null;
              recordsfiltered = false;
          }
          sfDataGrid1.View.RefreshFilter();
          selectedItems.ForEach(x => this.sfDataGrid1.SelectedItems.Add(x));
      }
  }

  public bool FilterRecords(object o)
  {
      var item = o as OrderInfo;
      if (item != null)
      {
          if (selectedItems.Contains(item))
          {
              return true;
          }
      }
      return false;
  }
 ```

 
 ![SfDataGrid_SelectorColumnFiltering.gif](https://support.syncfusion.com/kb/agent/attachment/article/14532/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE4MzEwIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.d7MxUW6XYmit3UFsWZZqvWtd1ADppPW_XblgJvfnueI) 

Take a moment to peruse the [WinForms DataGrid - ViewFilter](https://help.syncfusion.com/windowsforms/datagrid/filtering#view-filtering) documentation, where you can find about the clipboard operations with code examples.
