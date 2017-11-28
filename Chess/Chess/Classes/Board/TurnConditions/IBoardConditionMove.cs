namespace FrontEndEngine.Chess.Classes.Board.TurnConditions
{
    using FrontEndEngine.Chess.Common;

    public interface IBoardConditionMove
    {
        bool IsFulFilled(Move move);
    }
}
