namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using System;
    using Figures;
    using Common;

    public class MovementBeforeNumberOfMoves : Condition
    {
        private Figure _Figure;
        private int _BeforeMoves;

        public MovementBeforeNumberOfMoves(Figure figure, int beforeMoves)
        {
            this._Figure = figure;
            this._BeforeMoves = beforeMoves;
        }
        
        public override bool IsConditionFulfilled(Move move, Board.Board board)
        {
            if (this._Figure.MovesMade < this._BeforeMoves)
            {
                return true;
            }

            return false;
        }
    }
}