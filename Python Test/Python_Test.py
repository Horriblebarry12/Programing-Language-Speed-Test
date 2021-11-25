import math
import random
import time
import sys

piNum = 3.14159265358979



class Test:

    pi : float

    def __init__(self, Pi : float):
        self.pi = Pi
        return
        

    def RunTest(self):
        numOfTests = int(sys.argv[1], base=10)
        iterationsPerTest = int(sys.argv[2], base=10)


        for i in range(numOfTests):

            StartTime = time.time()
            calculation = 0;
            for n in range(iterationsPerTest):
                calculation += self.Calculate(self.pi, calculation)/10
            EndTime = time.time()

            ElapsedTime = ((EndTime)  - (StartTime)) * 1000

            print(str(ElapsedTime), end= " ")

        return

    def Calculate(self ,pi : float, x : float):
        return math.sqrt( math.sqrt( (math.pow((random.random() * pi), 2) + math.pow(( random.random() * pi), 2)) + x));
    
    pass

test = Test(piNum)

test.RunTest();