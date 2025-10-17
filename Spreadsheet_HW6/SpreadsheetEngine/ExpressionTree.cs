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
            expression = Regex.Replace(expression, @"\s+", ""); // Strip whitespace.
            List<string> result = Tokenize(expression);
            result = Shunt(result);
            this.root = this.BuildTree(this.stackNode, result);
          //  this.root = this.generateNode.CreateOperatorNode(op);
           // this.root = this.BuildTree(this.root, array, op);
        }

        /// <summary>
        /// Parses the operators, operands, and parens from string.
        /// </summary>
        /// <param name="input">The string expression.</param>
        /// <returns>returns a List of strings.</returns>
        public static List<string> Tokenize(string input)
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
                    } while (i < input.Length && (input[i] >= '0' && input[i] <= '9'));
                    i--;
                    result.Add(tempOperand);
                    tempOperand = string.Empty;
                }
                else // Variable logic.
                {
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

        /// <summary>
        /// Implements Shunting Yard Algorithm.
        /// </summary>
        /// <param name="input">List of string tokens.</param>
        /// <returns>returns a list of tokens in postfix notation.</returns>
        public static List<string> Shunt(List<string> input)
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

        /// <summary>
        /// Determines if character represents an operand.
        /// </summary>
        /// <param name="c">First character of a string token.</param>
        /// <returns>bool.</returns>
        public static bool IsOperand(char c)
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
        /// Determines the precedence of the left compared to right, giving both sides an integer value.
        /// </summary>
        /// <param name="lhs">char from input string.</param>
        /// <param name="rhs">char from stack contents.</param>
        /// <returns>Integere value.</returns>
        public static int Precedence(char lhs, char rhs)
        {
            int lhsValue = 0;
            int rhsValue = 0;
            switch (lhs)
            {
                case '/':
                    lhsValue = 3;
                    break;
                case '*':
                    lhsValue = 2;
                    break;
                case '+':
                    lhsValue = 1;
                    break;
                case '-':
                    rhsValue = 1;
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
                    rhsValue = 2;
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
                else
                {

                }
            }
            return stackNode.Pop();
        }
    }
}


/*
 * 
 * int length = elements.Length;
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
                    OperatorNode insertOp = this.generateNode.CreateOperatorNode(op);
                    insertOp.Left = rootPtr;
                    rootPtr = insertOp;
                    rootPtr.Right = insertLeaf;
                    count++;
                }
 * */