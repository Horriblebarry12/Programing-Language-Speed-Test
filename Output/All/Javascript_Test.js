'use strict';



class Test {

	pi = 3.14159265358979;

	Calculate(pi, x) {
		return  Math.sqrt(Math.sqrt((Math.pow(Math.random() * pi, 2) + Math.pow(Math.random() * pi, 2)) + x));
	}

	StartTest() {
		for (var i = 0; i < 100; i++)
		{

			let start = performance.now();
			var calculation = 0.0;
			for (var n = 0; n < 10000; n++)
			{
				calculation += this.Calculate(this.pi, calculation);
			}

			let end = performance.now();
		
			var elapsed_seconds = end - start;

			process.stdout.write(elapsed_seconds + " ");
		}
	}
}



let test = new Test();

test.StartTest();