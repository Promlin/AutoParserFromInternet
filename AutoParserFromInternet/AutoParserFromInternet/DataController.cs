using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParserFromInternet
{
    internal class DataController
    {
        public Task<DataTable> ParseExcel(string filePath)
        {
            return Task.Run(() =>
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile excelBook = ExcelFile.Load(filePath);
                ExcelWorksheet excelSheet = excelBook.Worksheets[0];

                CreateDataTableOptions options = new CreateDataTableOptions();

                

                return excelSheet.CreateDataTable(options);
            });
        }
    }
}
