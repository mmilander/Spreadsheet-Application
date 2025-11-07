// <copyright file="ICommand.cs" company="Command Interface">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }
}
