#include <math.h>
#include <cmath>
#include <iostream>
#include <sstream>
#include <ctime>
#include <chrono>
#include <random>

class Test
{
public:
	Test(double Pi) : pi(Pi)
	{

	};
	void RunTest();
private:
	double Calculate(double, double);
	double pi;

};

void Test::RunTest()
{
	// Yes I do know auto isn't slower

	std::chrono::system_clock::time_point totalStart = std::chrono::system_clock::now();
	for (int i = 0; i < 100; i++)
	{


		std::chrono::system_clock::time_point start = std::chrono::system_clock::now();

		auto calculation = 0.0;

		for (int n = 0; n < 10000; n++)
		{
			calculation += Calculate(pi, calculation);
		}

		std::chrono::system_clock::time_point end = std::chrono::system_clock::now();

		std::chrono::duration<double> elapsed_seconds = end - start;

		std::cout << elapsed_seconds.count() * 1000 << " ";
		//std::cout << "Interation: " << i << "\n";
	}

	std::chrono::system_clock::time_point totalEnd = std::chrono::system_clock::now();

	std::chrono::duration<double, std::ratio<1, 1000>> elapsed_seconds = totalEnd - totalStart;

	//std::cout << "Total Time: " << elapsed_seconds.count() << "\n";
}

double Test::Calculate(double pi, double x)
{
	return std::sqrt( std::sqrt((std::pow(std::rand() * pi, 2) + std::pow(std::rand() * pi, 2)) + x));
}

const double pi = 3.14159265358979;
//const double e = 2.718281828459045;

int main(int argc, char* argv[])
{
	Test test(pi);

	test.RunTest();

	return 0;
}