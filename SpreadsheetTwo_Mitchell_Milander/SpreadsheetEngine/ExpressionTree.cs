// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// This program creates an expression tree.
    /// </summary>
    public class ExpressionTree
    {
        private Dictionary<string, double> variables = new Dictionary<string, double>();

        public ExpressionTree(string expression)
        {

            //Implement this constructor to construct the tree from the specific expression
        }

        public void SetVariable(string variableName, double variableValue)
        {
            //Sets the specified variable within the ExpressionTree variables dictionary
        }

        public double Evaluate()
        {
            //Implement this method with no parameters that evaluates the expression to a double value
        }
    }
}
