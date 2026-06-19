namespace ConsoleApp
{
    public static class MathOperations
    {
        // Sum two integers
        public static int Sum(int a, int b) => a + b;

        // Subtract two float numbers and return integer result
        public static int Subtract(float a, float b)
        {
            return (int)(a - b);
        }

        // Multiply two numbers
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        // Divide two numbers
        public static float Divide(float a, float b)
        {
            if (b == 0)
            {
                throw new System.DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
    }
}
