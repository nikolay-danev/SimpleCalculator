namespace Calculator
{
    public static class Core
    {
        public static void Main()
        {
            // Get the input
            string input = Console.ReadLine().Replace(" ", string.Empty);

            // Instantiate the calculator helper
            CalculatorHelper calculatorHelper = new CalculatorHelper();

            // Evaluate the expression
            double result = calculatorHelper.SolveExpression(input);

            // Output the result
            Console.WriteLine(result);
        }
    }
}