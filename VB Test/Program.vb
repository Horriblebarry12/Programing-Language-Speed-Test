Imports System

Module Program
	Const pi = 3.14159265358979

	Sub Main(args As String())



		Dim numOfTests = Integer.Parse(args(0))
		Dim iterationsPerTest = Integer.Parse(args(1))


		For index = 1 To numOfTests
			Dim starttime = DateTime.Now

			Dim calculation = 0.0
			For n = 1 To iterationsPerTest
				calculation += Calculate(pi, calculation) / 2
			Next

			Dim endtime = DateTime.Now

			Dim elapsed_seconds = endtime - starttime


			Console.Write(elapsed_seconds.TotalMilliseconds.ToString() + " ")
		Next

	End Sub

	Public Function Calculate(pi As Double, x As Double) As Double

		Return Math.Sqrt(Math.Sqrt((Math.Pow(New Random().NextDouble() * pi, 2) + Math.Pow(New Random().NextDouble() * pi, 2)) + x))
	End Function

End Module
