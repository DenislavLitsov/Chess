namespace FrontEndEngine.Chess.EngineFolder.Utility
{
    using System;
    using System.Collections.Generic;

    using Classes.Players;
    using Classes.Board;

    public class TurnHandler
    {
        private List<Player> _Players;

        private int _CurrPlayer;

        public TurnHandler(List<Player> players)
        {
            this._Players = players;
            this._CurrPlayer = 0;
        }

        public List<Player> Players
        {
            get
            {
                return _Players;
            }

            private set
            {
                this._Players = value;
            }
        }

        public void ChangeTurn(Board board)
        {
            this._CurrPlayer++;

            if (this._CurrPlayer >= this.Players.Count)
            {
                this._CurrPlayer = 0;
            }

            board.TurnEnded();
        }

        public Player GetCurrPlayer()
        {
            Player result = this._Players[this._CurrPlayer];
            return result;
        }
    }
}
