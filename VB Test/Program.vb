Imports System

Module Program
	Const pi = 3.14159265358979

	Sub Main(args As String())
		Dim totalStart = DateTime.Now
		For index = 1 To 100
			Dim starttime = DateTime.Now

			Dim calculation = 0.0
			For n = 1 To 10000
				calculation += Calculate(pi, calculation)
			Next


			Dim endtime = DateTime.Now

			Dim elapsed_seconds = endtime - starttime


			Console.Write(elapsed_seconds.TotalMilliseconds.ToString() + " ")
		Next


		Dim totalEnd = DateTime.Now

		Dim total_elapsed_seconds = totalEnd - totalStart
	End Sub

	Public Function Calculate(pi As Double, x As Double) As Double

		Return Math.Sqrt(Math.Sqrt((Math.Pow(New Random().NextDouble() * pi, 2) + Math.Pow(New Random().NextDouble() * pi, 2)) + x))
	End Function

End Module
