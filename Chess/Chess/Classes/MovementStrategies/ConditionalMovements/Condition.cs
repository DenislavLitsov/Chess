namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using Common;
    using Figures;
    using System;

    public abstract class Condition
    {
        public abstract bool IsConditionFulfilled(Move move, Board.Board board);
    }
}
