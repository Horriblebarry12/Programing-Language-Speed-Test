import java.util.Random;

public class Main {
    private static final double pi = 3.14159265358979;

    public static void main(String[] args) {
        int numOfTests = Integer.parseInt(args[0]);
        int iterationsPerTest = Integer.parseInt(args[1]);

        for (int i = 0; i < numOfTests; i++)
        {
            long start = System.nanoTime();
            double calculation = 0;
            for (int n = 0; n < iterationsPerTest; n++)
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
