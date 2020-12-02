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
        public static List<Danger> dangersList = new List<Danger>();
        public static Task<DataTable> ParseExcel(string filePath)
        {
            return Task.Run(() =>
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile excelBook = ExcelFile.Load(filePath);
                ExcelWorksheet excelSheet = excelBook.Worksheets[0];

                var idColumn = excelSheet.Columns[0];
                var nameColumn = excelSheet.Columns[1];

                string test = (string)excelSheet.Cells[1, 1].Value;

                for(int i = 0; i < 150; i++)
                {
                    Danger danger = new Danger();
                    danger.Id = (int)excelSheet.Cells[i, 0].Value;
                    danger.Name = (string)excelSheet.Cells[i, 1].Value;
                    danger.Discription = (string)excelSheet.Cells[i, 2].Value;
                    danger.SourceOfThrear = (string)excelSheet.Cells[i, 3].Value;
                    danger.SubjectOfThreat = (string)excelSheet.Cells[i, 4].Value;

                    int ConfidenceProblem = (int)excelSheet.Cells[i, 5].Value;
                    if(ConfidenceProblem == 1) { danger.ConfidenceProblem = true; } else { danger.ConfidenceProblem = false; }

                    int FullnessProblem = (int)excelSheet.Cells[i, 6].Value;
                    if (FullnessProblem == 1) { danger.FullnesProblem = true; } else { danger.FullnesProblem = false; }

                    int AccessProblem = (int)excelSheet.Cells[i, 7].Value;
                    if (AccessProblem == 1) { danger.AccessRroblem = true; } else { danger.AccessRroblem = false; }

                    dangersList.Add(danger);
                }
                

                CreateDataTableOptions options = new CreateDataTableOptions();

                return excelSheet.CreateDataTable(options);
            });
        }
    }
}
