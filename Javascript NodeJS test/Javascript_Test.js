'use strict';


class Test {

	pi = 3.14159265358979;

	Calculate(pi, x) {
		return  Math.sqrt(Math.sqrt((Math.pow(Math.random() * pi, 2) + Math.pow(Math.random() * pi, 2)) + x));
	}

	StartTest() {
		var args = process.argv.slice(2);

		var numOfTests = Number(args[0]);
		var iterationsPerTest = Number(args[1]);


		for (var i = 0; i < numOfTests; i++)
		{

			let start = performance.now();
			var calculation = 0.0;
			for (var n = 0; n < iterationsPerTest; n++)
			{
				calculation += this.Calculate(this.pi, calculation)/10;
			}

			let end = performance.now();
		
			var elapsed_seconds = end - start;

			process.stdout.write(elapsed_seconds + " ");
		}
	}
}



let test = new Test();

test.StartTest();