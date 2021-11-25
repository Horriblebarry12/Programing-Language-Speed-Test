using System;


class Program
{
	const double pi = 3.14159265358979;

	static void Main(string[] args)
	{

		int numOfTests = int.Parse(args[0]);
		int iterationsPerTest = int.Parse(args[1]);
		for (int i = 0; i < numOfTests; i++)
		{


			DateTime start = DateTime.Now;

			double calculation = 0;

			for (int n = 0; n < iterationsPerTest; n++)
			{
				calculation += Calculate(pi, calculation)/10;
			}

			DateTime end = DateTime.Now;

			TimeSpan elapsed_seconds = end - start;


			Console.Write(elapsed_seconds.TotalMilliseconds + " ");
		}

	}

	static double Calculate(double pi, double x)
	{
		return Math.Sqrt(Math.Sqrt((Math.Pow(new Random().NextDouble() * pi, 2) + Math.Pow(new Random().NextDouble() * pi, 2)) + x));
	}
}
