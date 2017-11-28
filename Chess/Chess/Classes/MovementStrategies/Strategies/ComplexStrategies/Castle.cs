namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.ComplexStrategies
{
    using System;
    using ConditionalMovements;
    using Figures;
    using Board;
    using Common;
    using EngineFolder;
    using Microsoft.Xna.Framework;

    public class Castle : Strategy
    {
        private string CastlingWith;

        public Castle(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove, bool canAttack, Condition condition, string castlingWith) : base(xDir, yDir, xMovementPoints, yMovementPoints, xMustMove, yMustMove, canAttack, condition)
        {
            this.CastlingWith = castlingWith;
        }

        public override void Move(Figure figToMove, Board board, Move move, Engine engine)
        {
            this.MoveFigure(move, board);

            Figure secondFig = this.GetCastleFig(board, move);
            Point secondToMovePos = new Point(move.To.X + (- move.GetXDir()), move.To.Y + (-move.GetYDir()));
            Move secondMove = new Common.Move(secondFig.GetPosition(), secondToMovePos);

            this.MoveFigure(secondMove, board);
            board.UnTagBlocks();
        }

        private Figure GetCastleFig(Board board, Move move)
        {
            if (this._Condition.GetType() == typeof(CastleCondition))
            {
                return ((CastleCondition)this._Condition).GetSecondFigure(board, move);
            }
            else if (this._Condition.GetType() == typeof(Conditions))
            {
                Figure fig = ((CastleCondition)(((Conditions)this._Condition).GetCondition(typeof(CastleCondition)))).GetSecondFigure(board, move);
                return fig;
            }

            throw new Exception("No Castle Fig Found");
        }
    }
}
