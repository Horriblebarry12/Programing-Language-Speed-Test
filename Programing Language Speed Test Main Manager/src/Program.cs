using Microsoft.Office.Interop.Excel;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		//try
		{
			Program program = new Program();
		}
		/*
        catch (Exception e)
        {
            Console.WriteLine("Oh No!");
            Console.WriteLine("There has been a error!");
            Console.WriteLine("You may close the app or press enter to see error information.");
            Console.ReadLine();
            Console.WriteLine("Error information: \n");
            Console.WriteLine(e.GetType());
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            Console.ReadLine();

        }
        */
	}

	Dictionary<string, string> Languages;

	string? CurrentLanguage;

	const string Iterations = "100";

	Application? ExcelApplication;

	Workbook? ExcelWorkbook;
	Worksheet? ExcelWorkSheet;

	private Program()
	{
		Languages = new Dictionary<string, string>();

		//Todo: Add config
		FillLanguagesDictionary();

		InitializeExcelSpreadsheet();

		int i = 1;
		SaveExcelItem(1, 3, "ALL NUMBERS ARE IN MILISECONDS");
		SaveExcelItem(2, 1, "Language");
		SaveExcelItem(3, 1, "Average");
		SaveExcelItem(4, 1, "Median");
		SaveExcelItem(5, 1, "Max");
		SaveExcelItem(6, 1, "Min");
		SaveExcelItem(7, 1, "Data");
		foreach (var item in Languages.Keys)
		{
			i++;
			CurrentLanguage = item;
			Console.WriteLine($"Starting {item} Test");
			RunTest(item, i);
		}
		CleanUpExcel();

	}

	private void RunTest(string item, int i, string cmd = "", string args = Iterations)
	{
		Process process = new Process();
		Languages.TryGetValue(item, out string? Filepath);
		process.StartInfo.FileName = Filepath;
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.WorkingDirectory = Filepath.Remove(Filepath.LastIndexOf('\\'));
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.ArgumentList.Add(Iterations.ToString());


		process.Start();

		string output = process.StandardOutput.ReadToEnd();

		process.WaitForExit();

		Console.WriteLine($"Finished testing {item}. Logging data");

		string[] splitOutput = output.Split(' ');

		{
			SaveExcelItem(2, i, item);
			float time = 0;
			int row = 7;

			foreach (var data in splitOutput)
			{
				if (string.IsNullOrWhiteSpace(data))
					continue;
				SaveExcelItem(row, i, data);
				row++;
			}


			string columnName = GetExcelColumnName(i);

			SaveExcelItem(3, i, $"= AVERAGE({columnName}7:{columnName}{row - 1})");
			SaveExcelItem(4, i, $"= MEDIAN({columnName}7:{columnName}{row - 1})");
			SaveExcelItem(5, i, $"= MAX({columnName}7:{columnName}{row - 1})");
			SaveExcelItem(6, i, $"= MIN({columnName}7:{columnName}{row - 1})");
		}

	}

	// From https://stackoverflow.com/questions/181596/how-to-convert-a-column-number-e-g-127-into-an-excel-column-e-g-aa
	private string GetExcelColumnName(int columnNumber)
	{
		string columnName = "";

		while (columnNumber > 0)
		{
			int modulo = (columnNumber - 1) % 26;
			columnName = Convert.ToChar('A' + modulo) + columnName;
			columnNumber = (columnNumber - modulo) / 26;
		}

		return columnName;
	}

	private int InitializeExcelSpreadsheet()
	{
		ExcelApplication = new Application();

		if (ExcelApplication == null)
		{
			Console.WriteLine("Excel is not properly installed!");
			return -1;
		}
		ExcelWorkbook = ExcelApplication.Workbooks.Add(System.Reflection.Missing.Value);

		ExcelWorkbook.Title = "Programing langugage charts";

		ExcelWorkSheet = (Worksheet)ExcelWorkbook.Worksheets.get_Item(1);


		return 0;
	}

	private void SaveExcelItem(int row, int column, object value)
	{
		if (ExcelWorkSheet != null)
			ExcelWorkSheet.Cells[row, column] = value;
	}

	private void CleanUpExcel()
	{
		if (ExcelApplication == null || ExcelWorkbook == null || ExcelWorkSheet == null)
		{
			return;
		}

		ExcelWorkbook.SaveAs(@$"{Directory.GetCurrentDirectory()}\OutputExcel.xls", XlFileFormat.xlWorkbookNormal);
		//ExcelWorkbook.Close();
		ExcelApplication.Quit();

		Marshal.ReleaseComObject(ExcelWorkSheet);
		Marshal.ReleaseComObject(ExcelWorkbook);
		Marshal.ReleaseComObject(ExcelApplication);
	}

	private void FillLanguagesDictionary()
	{
		Languages.Add("C#", @$"{Directory.GetCurrentDirectory()}\C-Sharp Test.exe");
		Languages.Add("Visual Basic", @$"{Directory.GetCurrentDirectory()}\VB Test.exe");
		Languages.Add("C++", @$"{Directory.GetParent(Directory.GetCurrentDirectory())}\c++ Test.exe");
		Languages.Add("Javascript", @$"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent}\Javascript_Test.bat");
		Languages.Add("Java 1.11", @$"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent}\Python_Test.bat");
		Languages.Add("Python", @$"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent}\Python_Test.bat");

	}
}