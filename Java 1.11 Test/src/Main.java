import java.io.Console;
import java.util.Random;

public class Main {
    private static final double pi = 3.14159265358979;

    public static void main(String[] args) {
        for (int i = 0; i < 100; i++)
        {


            long start = System.nanoTime();
            double calculation = 0;
            for (int n = 0; n < 10000; n++)
            {
                calculation += Calculate(pi, calculation);
            }
            long end = System.nanoTime();

            long elapsed_time = (end - start);

            System.out.print( (float)elapsed_time / 1000000 + " ");


        }
    }

    static double Calculate(double pi, double x)
    {
        return Math.sqrt(Math.sqrt((Math.pow(new Random().nextDouble() * pi, 2) + Math.pow(new Random().nextDouble() * pi,2)) + x));
    }
}
