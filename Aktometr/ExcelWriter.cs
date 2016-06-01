using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

internal class ExcelWriter : IDisposable
{
    // Fields
    private Application excelApp = new Application();
    private Worksheet tmpWorksheet;
    private List<Range> usedRanges = new List<Range>();

    // Methods
    public ExcelWriter(bool show)
    {
        this.excelApp.Visible = show;
        this.excelApp.DisplayAlerts = false;
    }

    public void ShowOrHide(bool show)
    {
        if(this.excelApp.Visible != show)
           this.excelApp.Visible = show;
    }

    public void Close()
    {
        this.performGC();
        if (this.excelApp != null)
        {
            foreach (Range r in this.usedRanges)
            {
                this.CloseRange(r);
            }

            this.CloseWorksheet(this.tmpWorksheet);
            this.excelApp.Quit();

            Marshal.FinalReleaseComObject(this.excelApp);
        }
        this.performGC();
    }

    public void CloseRange(Range range)
    {
        if (range != null)
        {
            Marshal.FinalReleaseComObject(range);
        }
    }

    public void CloseSheets(Sheets sheets)
    {
        if (sheets != null)
        {
            Marshal.FinalReleaseComObject(sheets);
        }
    }

    public void CloseWorkbook(Workbook workbook)
    {
        if (workbook != null)
        {
            workbook.Close(false, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(workbook);
        }
    }

    public void CloseWorkbooks(Workbooks workbooks)
    {
        if (workbooks != null)
        {
            Marshal.FinalReleaseComObject(workbooks);
        }
    }

    public void CloseWorksheet(Worksheet worksheet)
    {
        if (worksheet != null)
        {
            Marshal.FinalReleaseComObject(worksheet);
        }
    }

    public Workbook CreateExcelWorkbook()
    {
        Workbook workbook;
        Workbooks workbooks = this.excelApp.Workbooks;
        try
        {
            workbook = workbooks.Add(1);
        }
        finally
        {
            this.CloseWorkbooks(workbooks);
        }
        return workbook;
    }

    public Worksheet CreateWorksheet(Workbook workbook, string name)
    {
        Worksheet worksheet = null;
        Sheets worksheets = workbook.Worksheets;
        try
        {
            worksheet = (Worksheet) worksheets.Add(Type.Missing, Type.Missing, Type.Missing, XlWBATemplate.xlWBATWorksheet);
            worksheet.Name = name;
        }
        finally
        {
            this.CloseSheets(worksheets);
        }
        return worksheet;
    }

    private void DeleteRange(Range range)
    {
        if (range != null)
        {
            range.Delete(XlDirection.xlUp);
        }
    }

    public void Dispose()
    {
        this.Close();
    }

    public string FindWorksheet(string filename, string[] patterns)
    {
        Workbook workbook = this.OpenExcelWorkbook(filename);
        Sheets sheets = workbook.Worksheets;
        foreach (string pattern in patterns)
        {
            Worksheet worksheet = null;
            for (int i = 1; i <= sheets.Count; i++)
            {
                worksheet = this.SelectWorksheet(workbook, i);
                if (worksheet != null)
                {
                    string worksheetName = worksheet.Name;
                    if (Regex.IsMatch(worksheetName, pattern))
                    {
                        this.CloseSheets(sheets);
                        this.CloseWorksheet(worksheet);
                        this.CloseWorkbook(workbook);
                        return worksheetName;
                    }
                }
                this.CloseWorksheet(worksheet);
            }
        }
        if (sheets.Count == 1)
        {
            Worksheet worksheet = this.SelectWorksheet(workbook, 1);
            string wName = worksheet.Name;
            this.CloseSheets(sheets);
            this.CloseWorksheet(worksheet);
            this.CloseWorkbook(workbook);
            return wName;
        }

        this.CloseSheets(sheets);
        this.CloseWorkbook(workbook);

        return "";
    }

    public object[] Get1DRangeData(Range range)
    {
        int i = 0;
        object[] v = new object[range.Count];
        foreach (Range r in range)
        {
            object value = r.get_Value(Type.Missing);
            if (value == null)
            {
                value = "";
            }
            v[i++] = value;
        }
        return v;
    }

    public Range getCell(Worksheet worksheet, int row, int col)
    {
        Range r = worksheet.Range[worksheet.Cells[row, col], worksheet.Cells[row, col]];
        this.usedRanges.Add(r);
        return r;
    }

    public Range GetRange(Worksheet worksheet, string leftTop, string bottomRight)
    {
        string range = string.Format("{0}:{1}", leftTop, bottomRight);
        return worksheet.get_Range(range, Type.Missing);
    }

    private Range GetRow(Worksheet worksheet, int? index)
    {
        if (index.HasValue && (index.Value > 0))
        {
            string range = string.Format("A{0}", index);
            return worksheet.get_Range(range, Type.Missing).EntireRow;
        }
        return null;
    }

    private Range GetRows(Worksheet worksheet, int[] indexes)
    {
        string[] rows = new string[indexes.Length];
        for (int i = 0; i < indexes.Length; i++)
        {
            rows[i] = string.Format("A{0}", indexes[i]);
        }
        Range range = null;
        Range entireRowRange = null;
        try
        {
            if (indexes.Length > 0)
            {
                range = worksheet.get_Range(string.Join(";", rows), Type.Missing);
                entireRowRange = range.EntireRow;
            }
        }
        finally
        {
            this.CloseRange(range);
        }
        return entireRowRange;
    }

    public double Sum(Range range)
    {
        double sum = 0;
        for (int i = 0; i < range.Count; ++i)
        {
            Range r = (Range)range.Cells[i, 1];
            sum += Convert.ToDouble(r.Value2);
        }
        return sum;
    }

    public void Filter(Range range, Func<double, bool> pred, double ValueIfFail)
    {
        for (int i = 0; i < range.Count; ++i)
        {
            Range r = (Range)range.Cells[i, 1];
            double value = Convert.ToDouble(r.Value2);

            if (!pred(value))
                r.Value2 = ValueIfFail;
        }
    }

    public Worksheet GetTmpWorksheet(Workbook workbook)
    {
        if (this.tmpWorksheet == null)
        {
            this.tmpWorksheet = this.CreateWorksheet(workbook, "tmp");
            //this.tmpWorksheet.Visible = XlSheetVisibility.xlSheetHidden;
        }
        return this.tmpWorksheet;
    }

    public Workbook OpenExcelWorkbook(string filename)
    {
        Workbook workbook;
        Workbooks workbooks = this.excelApp.Workbooks;
        try
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            workbook = workbooks.Open(filename, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        }
        finally
        {
            this.CloseWorkbooks(workbooks);
        }
        return workbook;
    }

    private void performGC()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    private void SaveWorkbookAs(Workbook workbook, string filename)
    {
        try
        {
            workbook.SaveAs(filename, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing);
        }
        catch (Exception)
        {
            workbook.SaveAs(filename, XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, false, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, false, Type.Missing, Type.Missing, Type.Missing);
        }
    }

    private Worksheet SelectWorksheet(Workbook workbook, int index)
    {
        Worksheet worksheet;
        Sheets worksheets = workbook.Worksheets;
        try
        {
            if ((index > 0) && (index <= worksheets.Count))
            {
                return (Worksheet) worksheets.get_Item(index);
            }
            worksheet = null;
        }
        finally
        {
            this.CloseSheets(worksheets);
        }
        return worksheet;
    }

    public Worksheet SelectWorksheet(Workbook workbook, string pattern)
    {
        Worksheet worksheet = null;
        Sheets worksheets = workbook.Worksheets;
        try
        {
            for (int i = 1; i <= worksheets.Count; i++)
            {
                worksheet = this.SelectWorksheet(workbook, i);
                if (Regex.IsMatch(worksheet.Name, pattern))
                {
                    return worksheet;
                }
            }
            worksheet = null;
        }
        finally
        {
            this.CloseSheets(worksheets);
        }
        return worksheet;
    }

    public Range Union(Range r1, Range r2)
    {
        return this.excelApp.Union(r1, r2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    }

}