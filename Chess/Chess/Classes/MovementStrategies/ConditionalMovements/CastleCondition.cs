namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using System;

    using Board;
    using Figures;
    using Common;
    using Microsoft.Xna.Framework;

    public class CastleCondition : Condition
    {
        private Figure _Figure;
        private readonly string NameToCastleWith;

        public CastleCondition(Figure fig, string nameToCastleWith)
        {
            this._Figure = fig;
            this.NameToCastleWith = nameToCastleWith;
        }


        public override bool IsConditionFulfilled(Move move, Board board)
        {
            if (board.IsPositionOutOfRange(move.To))
            {
                return false;
            }

            Figure castlingFig = this.GetSecondFigure(board, move);
            if (castlingFig != null)
            {
                bool inBetween = this.IsSomethingInBetween(move, board);
                bool moves = this._Figure.MovesMade == 0;
                bool secondMoves = castlingFig.MovesMade == 0;
                bool name = castlingFig.Name == this.NameToCastleWith;

                if (inBetween == false && moves && secondMoves && name && this.IsSomethingAttackingABlocksOnTheWay(move, board) == false && this.IsFigInCheck(board) == false)
                {
                    return true;
                }
            }

            return false;
        }

        public Figure GetSecondFigure(Board board, Move move)
        {
            int xDir = move.GetXDir();
            int yDir = move.GetYDir();

            int x = move.From.X + xDir;
            int y = move.From.Y + yDir;

            Figure currFig = board.GetFigure(new Point(x, y));

            while (currFig == null || currFig.Name != NameToCastleWith)
            {
                x += xDir;
                y += yDir;

                Point pos = new Point(x, y);
                if (board.IsPositionOutOfRange(pos))
                {
                    return null;
                }

                currFig = board.GetFigure(pos);
            }

            return currFig;
        }

        private bool IsFigInCheck(Board board)
        {
            if (board.IsSomethingAttackingThisPositionByEnemy(this._Figure.Color, this._Figure.GetPosition()))
            {
                return true;
            }

            return false;
        }

        private bool IsSomethingAttackingABlocksOnTheWay(Move move, Board board)
        {
            int xDir = move.GetXDir();
            int yDir = move.GetYDir();

            int x = move.From.X + xDir;
            int y = move.From.Y + yDir;

            for (int i = 0; i < board.GetNumberOfFigureColors(); i++)
            {
                if (i ==  this._Figure.Color)
                {
                    continue;
                }

                while (x != move.To.X || y != move.To.Y)
                {
                    // tuk mai ne trqbwa da e I ami neshto dr
                    if (board.IsSomethingAttackingThisPositionByEnemy(this._Figure.Color, new Point(x, y)))
                    {
                        return true;
                    }

                    x += xDir;
                    y += yDir;
                }
            }

            return false;
        }

        private bool IsSomethingInBetween(Move move, Board board)
        {
            int xDir = move.GetXDir();
            int yDir = move.GetYDir();

            int x = move.From.X + xDir;
            int y = move.From.Y + yDir;

            Point to = this.GetSecondFigure(board, move).GetPosition();

            while (x != to.X || y != to.Y)
            {
                Point pos = new Point(x, y);

                if (board.GetFigure(pos) != null)
                {
                    return true;
                }

                x += xDir;
                y += yDir;
            }

            return false;
        }
    }
}
