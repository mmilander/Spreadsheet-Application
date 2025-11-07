// <copyright file="ICommand.cs" company="Command Interface">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Interface for Command Design Pattern.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Runs the command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Undoes the command.
        /// </summary>
        void Undo();

        /// <summary>
        /// Redoes the command.
        /// </summary>
        void Redo();
    }
}
