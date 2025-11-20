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
        private int row;
        private int col;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> String.</param>
        /// <param name="row">Row Count.</param>
        /// <param name="col">Col Count.</param>
        public ExpressionTree(string expression, int row, int col)
        {
            if (expression == string.Empty)
            {
                throw new ArgumentException("Input is Empty.");
            }

            this.row = row;
            this.col = col;
            this.stackNode = new Stack<Node>();
            this.generateNode = new OperatorNodeFactory();
            expression = Regex.Replace(expression, @"\s+", string.Empty); // Strip whitespace.
            List<string> result = Tokenize(expression);
            result = this.Shunt(result);
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
        /// This method returns the list of Variable keys.
        /// </summary>
        /// <returns>double.</returns>
        public List<string> GetVariableList()
        {
            return this.variables.Select(variable => variable.Key).ToList();
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

        private bool IsValidReference(string val)
        {
            if (val.Length < 2) // Ensures now var is without a row number.
            {
                return false;
            }
            else if (!(val[0] <= 'Z' && val[0] >= 'A')) // Ensures first char is A-Z.
            {
                return false;
            }
            else
            {
                string saveEnd = string.Empty;
                for (int i = 1; i < val.Length; i++)
                {
                    if (!(val[i] >= '0' && val[i] <= '9')) // means char is not a digit
                    {
                        return false;
                    }
                    else
                    {
                        saveEnd += val[i];
                    }
                }

                try
                {
                    int numVal = int.Parse(saveEnd);
                    if (numVal > 0 && numVal <= this.row) // means number is valid row
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (FormatException) // means either string is not all digits, or out of range.
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Parses the operators, operands, and parens from string.
        /// </summary>
        /// <param name="input">The string expression.</param>
        /// <returns>returns a List of strings.</returns>
        private List<string> Tokenize(string input)
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
                    do
                    {
                        tempOperand += input[i];
                        i += 1;
                    }
                    while (i < input.Length);// && IsOperand(input[i]));
                    i--;
                    if (!this.IsValidReference(tempOperand))
                    {
                         throw new ArgumentException("Invalid Operand");
                    }

                    result.Add(tempOperand);
                    tempOperand = string.Empty;
                }
            }

            return result;
        }

        private List<string> Shunt(List<string> input)
        {
            if (input == null)
            {
                throw new ArgumentException("List is null");
            }

            if (input.Count == 0)
            {
                return new List<string>();
            }

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
                    else if (stack.Count != 0)
                    {
                        int precedenceVal = 0;
                        int precedenceStack = 0;
                        try
                        {
                            OperatorNode valOpNode = this.generateNode.CreateOperatorNode(val[0]);
                            precedenceVal = valOpNode.Precedence;
                        }
                        catch (Exception)
                        {
                            precedenceVal = 0;
                        }

                        try
                        {
                            OperatorNode stackOpNode = this.generateNode.CreateOperatorNode(stack.Peek()[0]);
                            precedenceStack = stackOpNode.Precedence;
                        }
                        catch (Exception)
                        {
                            precedenceStack = 0;
                        }

                        if (precedenceVal > precedenceStack)
                        {
                            stack.Push(val);
                        }
                        else
                        {
                            try
                            {
                                OperatorNode stackOpNode = this.generateNode.CreateOperatorNode(stack.Peek()[0]);
                                precedenceStack = stackOpNode.Precedence;
                            }
                            catch (Exception)
                            {
                                precedenceStack = 0;
                            }

                            while (stack.Count != 0 && (precedenceVal <= precedenceStack))
                            {
                                postfix.Add(stack.Pop());
                                if (stack.Count != 0)
                                {
                                    try
                                    {
                                        OperatorNode stackOpNode = this.generateNode.CreateOperatorNode(stack.Peek()[0]);
                                        precedenceStack = stackOpNode.Precedence;
                                    }
                                    catch (Exception)
                                    {
                                        precedenceStack = 0;
                                    }
                                }
                            }

                            stack.Push(val);
                        }
                    }
                }
            }

            while (stack.Count != 0)
            {
                postfix.Add(stack.Pop());
            }

            return postfix;
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