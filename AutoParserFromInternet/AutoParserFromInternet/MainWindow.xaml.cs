using GemBox.Spreadsheet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoParserFromInternet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnReloadDataClick(object sender, RoutedEventArgs e)  //for reading file from computer
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла для загрузки",
                //Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"
                
            };
            if (dialog.ShowDialog() != true) return;

            var file_name = dialog.FileName;

            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile excelBook = ExcelFile.Load(file_name);
            ExcelWorksheet excelSheet = excelBook.Worksheets[0];
        }

        private void OnDownloadButtonCLick(object sender, RoutedEventArgs e)   //for loading file from internet
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла для загрузки",
                //Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"

            };
            if (dialog.ShowDialog() != true) return;
            
        }

        private void OnOpenDataButtonClick(object sender, RoutedEventArgs e)  //for openong computer file
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла для загрузки",
                //Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"

            };
            if (dialog.ShowDialog() != true) return;

            var file_name = dialog.FileName;

            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile excelBook = ExcelFile.Load(file_name);
            ExcelWorksheet excelSheet = excelBook.Worksheets[0];


        }
    }
}
