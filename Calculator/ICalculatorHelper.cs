namespace Calculator
{
    public interface ICalculatorHelper
    {
        double SolveExpression(string input);

        int OperationOrder(char @operator);

        bool IsOperator(char chunk);

        void Evaluate(Stack<double> numbersStack, Stack<char> operatorsStack);
    }
}
