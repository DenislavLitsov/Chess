namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using Common;
    using Figures;
    using System;

    public class IfEnemyIsThere : Condition
    {
        private readonly Figure _Figure;
            
        public IfEnemyIsThere(Figure fig)
        {
            this._Figure = fig;
        }

        public override bool IsConditionFulfilled(Move move, Board.Board board)
        {
            Figure fig = board.GetFigure(move.To);
            if (fig != null)
            {
                if (fig.Color != this._Figure.Color)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
