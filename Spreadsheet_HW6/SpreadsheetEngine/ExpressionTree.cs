// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    /// <summary>
    /// This program creates an expression tree.
    /// </summary>
    public class ExpressionTree
    {
        private OperatorNodeFactory generateNode;
        private Stack<Node> stackNode;
        private Node root;
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

            this.stackNode = new Stack<Node>();
            this.generateNode = new OperatorNodeFactory();
            expression = Regex.Replace(expression, @"\s+", string.Empty); // Strip whitespace.
            List<string> result = Tokenize(expression);
            result = Shunt(result);
            this.root = this.BuildTree(this.stackNode, result);
        }

        /// <summary>
        /// Determines if character represents an operator.
        /// </summary>
        /// <param name="c">First character of a string token.</param>
        /// <returns>bool.</returns>
        public static bool IsOperator(char c)
        {
            string check = "/-+*";
            return check.Contains(c);
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

        /// <summary>
        /// Parses the operators, operands, and parens from string.
        /// </summary>
        /// <param name="input">The string expression.</param>
        /// <returns>returns a List of strings.</returns>
        private static List<string> Tokenize(string input)
        {
            List<string> result = new List<string>();
            string tempOperand = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == ')' || IsOperator(input[i]))
                {
                    result.Add(input[i].ToString());
                }
                else if (input[i] >= '0' && input[i] <= '9') // Numerical operand logic.
                {
                    do
                    {
                        tempOperand += input[i];
                        i += 1;
                    }
                    while (i < input.Length && (input[i] >= '0' && input[i] <= '9'));
                    i--;
                    result.Add(tempOperand);
                    tempOperand = string.Empty;
                }
                else // Variable logic.
                {
                    if (!IsOperand(input[i]))
                    {
                        throw new ArgumentException("Invalid Operand");
                    }

                    do
                    {
                        tempOperand += input[i];
                        i += 1;
                    }
                    while (i < input.Length && IsOperand(input[i]));
                    i--;
                    result.Add(tempOperand);
                    tempOperand = string.Empty;
                }
            }

            return result;
        }

        private static List<string> Shunt(List<string> input)
        {
            List<string> postfix = new List<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string val in input)
            {
                string tempStackContents = "\0";
                if (IsOperand(val[0]))
                {
                    postfix.Add(val);
                }
                else if (val[0] == '(') // save on stack.
                {
                    stack.Push(val);
                }
                else if (val[0] == ')') // discard right paren.
                {
                    while (stack.Count != 0 && tempStackContents[0] != '(')
                    {
                        tempStackContents = stack.Pop();
                        if (tempStackContents[0] != '(')
                        {
                            postfix.Add(tempStackContents);
                        }
                    }

                    tempStackContents = "\0";
                }

                if (IsOperator(val[0]))
                {
                    if (stack.Count == 0 || stack.Peek()[0] == '(')
                    {
                        stack.Push(val);
                    }
                    else if (stack.Count != 0 && (Precedence(val[0], stack.Peek()[0]) == 2))
                    {
                        stack.Push(val);
                    }
                    else
                    {
                        while (stack.Count != 0 && (Precedence(val[0], stack.Peek()[0]) < 2))
                        {
                            postfix.Add(stack.Pop());
                        }

                        stack.Push(val);
                    }
                }
            }

            while (stack.Count != 0)
            {
                postfix.Add(stack.Pop());
            }

            return postfix;
        }

        private static bool IsOperand(char c)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
                || (c >= 'a' && c <= 'z'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int Precedence(char lhs, char rhs) // Determines the precedence of the left compared to right, giving both sides an integer value.
        {
            int lhsValue = 0;
            int rhsValue = 0;
            switch (lhs)
            {
                case '/':
                    lhsValue = 3;
                    break;
                case '*':
                    lhsValue = 3;
                    break;
                case '+':
                    lhsValue = 1;
                    break;
                case '-':
                    lhsValue = 1;
                    break;
                default:
                    lhsValue = 0;
                    break;
            }

            switch (rhs)
            {
                case '/':
                    rhsValue = 3;
                    break;
                case '*':
                    rhsValue = 3;
                    break;
                case '+':
                    rhsValue = 1;
                    break;
                case '-':
                    rhsValue = 1;
                    break;
                default:
                    rhsValue = 0;
                    break;
            }

            if (lhsValue < rhsValue)
            {
                return 0; // lhs has lower precedence.
            }
            else if (lhsValue == rhsValue)
            {
                return 1; // lhs & rhs have same precedence.
            }
            else
            {
                return 2; // lhs has greater precedence.
            }
        }

        private Node BuildTree(Stack<Node> stackNode, List<string> elements)
        {
            foreach (var token in elements)
            {
                if (IsOperator(token[0]))
                {
                    OperatorNode parent = this.generateNode.CreateOperatorNode(token[0]);
                    parent.Right = stackNode.Pop();
                    parent.Left = stackNode.Pop();
                    stackNode.Push(parent);
                }
                else // operator node.
                {
                    Node insertLeaf;
                    if (token[0] >= '0' && token[0] <= '9') // number constant.
                    {
                        insertLeaf = new ConstantNode(double.Parse(token));
                    }
                    else
                    {
                        insertLeaf = new VariableNode(token, ref this.variables); // variable.
                    }

                    stackNode.Push(insertLeaf);
                }
            }

            return stackNode.Pop();
        }
    }
}