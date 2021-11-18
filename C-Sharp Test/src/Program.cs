using System;


class Program
{
	const double pi = 3.14159265358979;

	static void Main(string[] args)
	{
		DateTime totalStart = DateTime.Now;
		for (int i = 0; i < 100; i++)
		{


			DateTime start = DateTime.Now;

			double calculation = 0;

			for (int n = 0; n < 10000; n++)
			{
				calculation += Calculate(pi, calculation);
			}

			DateTime end = DateTime.Now;

			TimeSpan elapsed_seconds = end - start;


			Console.Write(elapsed_seconds.TotalMilliseconds + " ");
		}

		DateTime totalEnd = DateTime.Now;

		TimeSpan total_elapsed_seconds = totalEnd - totalStart;
	}	

	static double Calculate(double pi, double x)
	{
		return Math.Sqrt(Math.Sqrt((Math.Pow(new Random().NextDouble() * pi, 2) + Math.Pow(new Random().NextDouble() * pi, 2)) + x));
	}
}
