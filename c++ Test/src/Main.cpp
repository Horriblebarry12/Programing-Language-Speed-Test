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
	void RunTest(char* args[]);
private:
	double Calculate(double, double);
	double pi;

};

void Test::RunTest(char* args[])
{

	int numOfTests;
	int iterationsPerTest;
	{
		std::stringstream ssN;
		ssN << args[1];
		ssN >> numOfTests;

		std::stringstream ssI;
		ssI << args[2];
		ssI >> iterationsPerTest;
	}

	for (int i = 0; i < numOfTests; i++)
	{


		std::chrono::system_clock::time_point start = std::chrono::system_clock::now();

		auto calculation = 0.0;

		for (int n = 0; n < iterationsPerTest; n++)
		{
			calculation += Calculate(pi, calculation)/10;
		}

		std::chrono::system_clock::time_point end = std::chrono::system_clock::now();

		std::chrono::duration<double> elapsed_seconds = end - start;

		std::cout << elapsed_seconds.count() * 1000 << " ";
	}
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

	test.RunTest(argv);

	return 0;
}