using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParserFromInternet
{
    public class DataController
    {
        public List<Danger> dangersList = new List<Danger>();

        public Task<DataTable> ParseExcel(string filePath)
        {
            return Task.Run(() =>
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile excelBook = ExcelFile.Load(filePath);
                ExcelWorksheet excelSheet = excelBook.Worksheets[0];

                var idColumn = excelSheet.Columns[0];
                var nameColumn = excelSheet.Columns[1];

                string test = (string)excelSheet.Cells[1, 1].Value;

                for(int i = 0; i < 100; i++)
                {
                    Danger danger = new Danger();
                    danger.Id = (string)excelSheet.Cells[i, 0].Value.ToString();
                    danger.Name = (string)excelSheet.Cells[i, 1].Value;
                    danger.Discription = (string)excelSheet.Cells[i, 2].Value;
                    danger.SourceOfThrear = (string)excelSheet.Cells[i, 3].Value;
                    danger.SubjectOfThreat = (string)excelSheet.Cells[i, 4].Value;

                    string ConfidenceProblem = (string)excelSheet.Cells[i, 5].Value.ToString();
                    if(ConfidenceProblem == "1") { danger.ConfidenceProblem = true; } else { danger.ConfidenceProblem = false; }

                    string FullnessProblem = (string)excelSheet.Cells[i, 6].Value.ToString();
                    if (FullnessProblem == "1") { danger.FullnesProblem = true; } else { danger.FullnesProblem = false; }

                    string AccessProblem = (string)excelSheet.Cells[i, 7].Value.ToString();
                    if (AccessProblem == "1") { danger.AccessRroblem = true; } else { danger.AccessRroblem = false; }

                    //dataController.dangersList.Add(danger);
                }
                

                CreateDataTableOptions options = new CreateDataTableOptions();

                return excelSheet.CreateDataTable(options);
            });
        }
    }
}
