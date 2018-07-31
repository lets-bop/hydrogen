namespace LC_FB_Medium
{
    class PowModM
    {
        public static double Calculate(float x, int n, int m)
        {
            if (n < 0)
                return CalculateRecursively(1/x, -n, m);
            return CalculateRecursively(x, n, m);
        }
        private static double CalculateRecursively(float x, int n, int m)
        {
            if (n == 0)
                return (double) 1.0;
            
            double half = CalculateRecursively(x, n/2, m);
            if (n % 2 == 0)
                return (half % m * half % m) % m;
            else
                return (half % m * half % m * x) % m;
        }
    }
}