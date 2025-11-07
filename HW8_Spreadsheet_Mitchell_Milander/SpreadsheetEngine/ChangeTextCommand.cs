// <copyright file="ChangeTextCommand.cs" company="Text Command">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    internal class ChangeTextCommand : ICommand
    {
        private Spreadsheet receiver;


        public ChangeTextCommand(Spreadsheet receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            textReceiver.t
        }
        public void Undo()
        {

        }
        public void Redo()
        {

        }
    }
}
