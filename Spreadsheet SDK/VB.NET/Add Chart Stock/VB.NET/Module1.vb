﻿'*******************************************************************
'       ByteScout Spreadsheet SDK
'                                                                   
'       Copyright © 2016 Bytescout, http://www.bytescout.com        
'       ALL RIGHTS RESERVED                                         
'                                                                   
'*******************************************************************

Imports Bytescout.Spreadsheet
Imports Bytescout.Spreadsheet.Charts
Imports System.IO


Module Module1

    Sub Main()


			Try
				' create new Spreadsheet object
				Dim spreadsheet As New Spreadsheet()

				' add new worksheet
				Dim sheet As Worksheet = spreadsheet.Workbook.Worksheets.Add("Sample")

				' add a data for stock chart
				For i As Integer = 1 To 5
					sheet(i, 0).Value = 39082 + i
					sheet(i, 0).ValueDataTypeByNumberFormatString = Bytescout.Spreadsheet.Constants.NumberFormatType.DateTime
				Next
				sheet(1, 1).Value = 41301
				sheet(1, 2).Value = 24.3
				sheet(1, 3).Value = 27.2
				sheet(1, 4).Value = 23.49
				sheet(1, 5).Value = 25.45
				sheet(2, 1).Value = 35203
				sheet(2, 2).Value = 25.4
				sheet(2, 3).Value = 25.03
				sheet(2, 4).Value = 19.55
				sheet(2, 5).Value = 23.05
				sheet(3, 1).Value = 27908
				sheet(3, 2).Value = 23
				sheet(3, 3).Value = 19.05
				sheet(3, 4).Value = 15.12
				sheet(3, 5).Value = 17.32
				sheet(4, 1).Value = 29567
				sheet(4, 2).Value = 17.3
				sheet(4, 3).Value = 20.33
				sheet(4, 4).Value = 17.84
				sheet(4, 5).Value = 20.45
				sheet(5, 1).Value = 25895
				sheet(5, 2).Value = 20.4
				sheet(5, 3).Value = 18.56
				sheet(5, 4).Value = 16.33
				sheet(5, 5).Value = 17.35

				' add charts to worksheet
				Dim stockChart As Chart = sheet.Charts.AddChartAndFitInto(7, 1, 26, 9, ChartType.StockHLC)
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 3, 5, 3)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 4, 5, 4)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 5, 5, 5)))

				stockChart = sheet.Charts.AddChartAndFitInto(7, 10, 26, 18, ChartType.StockOHLC)
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 2, 5, 2)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 3, 5, 3)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 4, 5, 4)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 5, 5, 5)))

				stockChart = sheet.Charts.AddChartAndFitInto(28, 1, 46, 9, ChartType.StockVHLC)
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 1, 5, 1)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 3, 5, 3)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 4, 5, 4)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 5, 5, 5)))

				stockChart = sheet.Charts.AddChartAndFitInto(28, 10, 46, 18, ChartType.StockVOHLC)
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 1, 5, 1)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 2, 5, 2)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 3, 5, 3)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 4, 5, 4)))
				stockChart.SeriesCollection.Add(New Series(sheet.Range(1, 5, 5, 5)))

				If File.Exists("Output.xls") Then
					File.Delete("Output.xls")
				End If

				' Save it as XLS
				spreadsheet.SaveAs("Output.xls")

				' close the document
				spreadsheet.Close()

				' open output XLS


				Process.Start("Output.xls")
			Catch e As Exception
				Console.WriteLine("CAN NOT EXECUTE: " & e.ToString())
				Console.WriteLine("" & Chr(10) & "Press any key to exit")
				Console.ReadKey()
			End Try


    End Sub

End Module