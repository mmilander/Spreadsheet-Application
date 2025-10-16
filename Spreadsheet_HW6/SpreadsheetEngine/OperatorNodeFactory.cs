namespace SpreadsheetEngine
{
    //Factory
    internal class OperatorNodeFactory
    {
        public OperatorNode CreateOperatorNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new AdditionOperatorNode();
                case '-':
                    return new SubtractionOperatorNode();
                case '*':
                    return new MultiplicationOperatorNode();
                case '/':
                    return new DivisionOperatorNode();
                default:
                    throw new ArgumentException("Invalid Operator");
            }
        }
    }
}
