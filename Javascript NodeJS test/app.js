'use strict';

const pi = 3.14159265358979;

function Calculate(pi) {
	return  Math.Sqrt(Math.Sqrt((Math.Pow(Math.random() * pi, 2) + Math.Pow(Math.random() * pi, 2)) + 1));
}

function StartTest() {
	var totalStart = Date.now();
	for (var i = 0; i < 100; i++)
	{

		let start = performance.now();

		for (int n = 0; n < 10; n++)
		{
			let calculation = Calculate(pi);
		}

		let end = performance.now();
		
		var elapsed_seconds = end.valueOf() - start.valueOf();

		process.stdout.write(elapsed_seconds + " ");
	}

	var totalEnd = Date.now();

	var total_elapsed_seconds = totalEnd - totalStart;
}

StartTest();