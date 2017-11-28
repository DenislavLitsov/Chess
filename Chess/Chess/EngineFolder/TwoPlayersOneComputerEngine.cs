namespace FrontEndEngine.Chess.EngineFolder
{
    using System;
    using System.Collections.Generic;
    using Classes.Players;
    using Initializers;

    public class TwoPlayersOneComputerEngine : Engine
    {
        public TwoPlayersOneComputerEngine(List<Player> players, List<int> playersThisEngineControlls) : 
            base(players, playersThisEngineControlls)
        {
            InitBoard();
        }

        private void InitBoard()
        {
            // swap "ClassicalChessBoardInitializer("Medieval")" with "WW2FromFileInitializer()" to run the WW2 version of the game also swap one line in the figure class line: 153;
            IBoardIniter boardIniter = new ClassicalChessBoardInitializer("Medieval"); //WW2FromFileInitializer();

            this.Board = boardIniter.GetBoard();
        }
    }
}
