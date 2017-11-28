namespace FrontEndEngine.Chess.EngineFolder
{
    using System;
    using System.Collections.Generic;
    using FrontEndEngine.Chess.Classes.Players;

    class EditorEngine : Engine
    {
        public EditorEngine() : base()
        {
            this.InitBoard();
        }

        private void InitBoard()
        {
            this.Board = new Classes.Board.Board(1, 1, 1, "Medieval");
        }
    }
}
