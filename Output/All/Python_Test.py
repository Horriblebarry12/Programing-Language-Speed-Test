import math
import random
import time

piNum = 3.14159265358979



class Test:

    pi : float

    def __init__(self, Pi : float):
        self.pi = Pi
        return
        

    def RunTest(self):
    
        for i in range(100):

            StartTime = time.time()
            calculation = 0;
            for n in range(10000):
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