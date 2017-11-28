namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using System;
    using Figures;
    using Board;
    using Common;
    using System.Collections.Generic;

    public class FriendlyFigureIsNotInCheck : Condition
    {
        private readonly Figure _Figure;
        private readonly string _FriendlyName;

        public FriendlyFigureIsNotInCheck(Figure fig, string friendlyName)
        {
            this._FriendlyName = friendlyName;
            this._Figure = fig;
        }

        public override bool IsConditionFulfilled(Move move, Board board)
        {
            // gleda za predniq board a ne za noviq
            List<Figure> allFriendlyFigs = this.GetFigsWithName(board);
            foreach (var fig in allFriendlyFigs)
            {
                if (board.IsSomethingAttackingThisPositionByEnemy(fig.Color, fig.GetPosition()) == true)
                {
                    return false;
                }
            }

            return true;
        }

        private List<Figure> GetFigsWithName(Board board)
        {
            List<Figure> allFriendlyFigs = board.GetAllFigure(this._Figure.Color);
            List<Figure> result = new List<Figure>();

            foreach (var fig in allFriendlyFigs)
            {
                if (fig.Name == this._FriendlyName)
                {
                    result.Add(fig);
                }
            }

            return result;
        }
    }
}
