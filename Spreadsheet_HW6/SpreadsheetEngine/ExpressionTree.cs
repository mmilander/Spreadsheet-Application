// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This program creates an expression tree.
    /// </summary>
    public class ExpressionTree
    {
        private OperatorNode root;
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">string to parse.</param>
        public ExpressionTree(string expression)
        {
            if (expression == string.Empty)
            {
                throw new ArgumentException("Input is Empty.");
            }

            char op = this.GetOp(expression);
            string[] array = Regex.Split(expression, $@"\{op}");
            this.root = this.GetOperationNode(op);
            this.root = this.BuildTree(this.root, array, op);
        }

        /// <summary>
        /// Determines which operator is present in String.
        /// </summary>
        /// <param name="expression">Input string.</param>
        /// <returns>char.</returns>
        public char GetOp(string expression)
        {
            if (expression.Contains('+'))
            {
                return '+';
            }

            if (expression.Contains('-'))
            {
                return '-';
            }

            if (expression.Contains('*'))
            {
                return '*';
            }

            if (expression.Contains('/'))
            {
                return '/';
            }

            throw new ArgumentException("Invalid Operator.");
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName">string value.</param>
        /// <param name="variableValue">double value.</param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
        }

        /// <summary>
        /// This method evaluates the entire expression tree.
        /// </summary>
        /// <returns>double.</returns>
        public double Evaluate()
        {
            if (this.root == null)
            {
                return 0;
            }

            return this.root.Evaluate();
        }

        private OperatorNode BuildTree(OperatorNode rootPtr, string[] elements, char op)
        {
            int length = elements.Length;
            int count = 0;
            foreach (var element in elements)
            {
                Node insertLeaf;
                if (element[0] >= '0' && element[0] <= '9') // number constant.
                {
                    insertLeaf = new ConstantNode(double.Parse(element));
                }
                else
                {
                    insertLeaf = new VariableNode(element, ref this.variables); // variable.
                }

                if (count == 0) // First element should be added to left.
                {
                    rootPtr.Left = insertLeaf;
                    count++;
                }
                else if (count == 1) // First element should be addedd to right.
                {
                    rootPtr.Right = insertLeaf;
                    count++;
                }
                else
                {
                    OperatorNode insertOp = this.GetOperationNode(op);
                    insertOp.Left = rootPtr;
                    rootPtr = insertOp;
                    rootPtr.Right = insertLeaf;
                    count++;
                }
            }

            return rootPtr;
        }

        private OperatorNode GetOperationNode(char op)
        {
            switch (op)
            {
                case '+':
                    return new AdditionOperatorNode();
                case '-':
                    return new SubtractionOperatorNode();
                case '*':
                    return new MultiplicationOperatorNode();
                default:
                    return new DivisionOperatorNode();
            }
        }
    }
}
