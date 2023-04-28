namespace Calculator
{
    public class CalculatorHelper : ICalculatorHelper
    {
        /// <summary>
        /// Evaluate the given stacks data
        /// </summary>
        /// <param name="numbersStack"></param>
        /// <param name="operatorsStack"></param>
        public void Evaluate(Stack<double> numbersStack, Stack<char> operatorsStack)
        {
            char @operator = operatorsStack.Pop();
            double number2 = numbersStack.Pop();
            double number1 = numbersStack.Pop();
            double result = 0;

            switch (@operator)
            {
                case '+':
                    result = number1 + number2;
                    break;
                case '-':
                    result = number1 - number2;
                    break;
                case '*':
                    result = number1 * number2;
                    break;
                case '/':
                    result = number1 / number2;
                    break;
            }

            numbersStack.Push(result);
        }

        /// <summary>
        /// Checks if the given parameter is an operator
        /// </summary>
        /// <param name="operator"></param>
        /// <returns>boolean</returns>
        public bool IsOperator(char @operator)
        {
            if (@operator == '+' ||
                @operator == '-' ||
                @operator == '*' ||
                @operator == '/')
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the operator's order
        /// </summary>
        /// <param name="operator"></param>
        /// <returns>operator's order</returns>
        public int OperationOrder(char @operator)
        {
            int result = 0;

            switch (@operator)
            {
                case '+':
                case '-':
                    result = 1;
                    break;
                case '*':
                case '/':
                    result = 2;
                    break;

            }

            return result;
        }

        /// <summary>
        /// Evaluating the given expression
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Evaluated expression as a double</returns>
        public double SolveExpression(string input)
        {
            Stack<double> numbersStack = new Stack<double>();
            Stack<char> operatorsStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char chunk = input[i];

                if (char.IsDigit(chunk))
                {
                    var startPosition = i;

                    while (i < input.Length &&
                           char.IsDigit(input[i]))
                    {
                        i++;
                    }

                    var number = double.Parse(input.Substring(startPosition, i - startPosition));
                    numbersStack.Push(number);

                    i--;
                }
                else if (chunk == '(')
                {
                    operatorsStack.Push(chunk);
                }
                else if (chunk == ')')
                {
                    while (operatorsStack.Peek() != '(')
                    {
                        this.Evaluate(numbersStack, operatorsStack);
                    }

                    operatorsStack.Pop();
                }
                else if (IsOperator(chunk))
                {
                    while (operatorsStack.Count > 0 &&
                           OperationOrder(chunk) <= OperationOrder(operatorsStack.Peek()))
                    {
                        this.Evaluate(numbersStack, operatorsStack);
                    }

                    operatorsStack.Push(chunk);
                }
            }

            while (operatorsStack.Count > 0)
            {
                this.Evaluate(numbersStack, operatorsStack);
            }

            return numbersStack.Pop();
        }
    }
}
