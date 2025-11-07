// <copyright file="UndoRedoCollection.cs" company="Collection of undos and redos">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.VisualBasic;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Stores multiple commands.
    /// </summary>
    public class UndoRedoCollection
    {
        private Stack<ICommand> cmd;
        public string information;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCollection"/> class.
        /// </summary>
        /// <param name="information">Description of related information.</param>
        public UndoRedoCollection(string information)
        {
            this.information = information;
            this.cmd = new Stack<ICommand>();
        }

        /// <summary>
        /// Gets or sets infromation.
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// Allows new command to be added.
        /// </summary>
        /// <param name="cmd">Command.</param>
        public void AddCmd(ICommand cmd)
        {
            this.cmd.Push(cmd);
        }

        /// <summary>
        /// Runs Execute() on all contents of collection.
        /// </summary>
        public void Execute()
        {
            foreach (ICommand val in this.cmd)
            {
                val.Execute();
            }
        }

        /// <summary>
        /// Runs Undo() on all contents of collection.
        /// </summary>
        public void Undo()
        {
            foreach (ICommand val in this.cmd)
            {
                val.Undo();
            }
        }

        /// <summary>
        /// Runs Execute() on all contents of collection.
        /// </summary>
        public void Redo()
        {
            foreach (ICommand val in this.cmd)
            {
                val.Redo();
            }
        }

    }
}
