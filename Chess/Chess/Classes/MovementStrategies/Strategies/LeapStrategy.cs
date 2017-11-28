namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies
{
    using System;
    using System.Collections.Generic;

    using FrontEndEngine.Chess.Classes.Board;
    using FrontEndEngine.Chess.Classes.Figures;
    using FrontEndEngine.Chess.Common;

    using Microsoft.Xna.Framework;

    public abstract class LeapStrategy : Strategy
    {

        public LeapStrategy() : base(0, 0)
        {
        }

        public LeapStrategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove) : base(xDir, yDir, xMovementPoints, yMovementPoints, xMustMove, yMustMove)
        {
        }

        public LeapStrategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove, bool canAttack) : base(xDir, yDir, xMovementPoints, yMovementPoints, xMustMove, yMustMove, canAttack)
        {
        }

        public Point InitialPosition { get; set; }
        public List<Point> PossibleMoves { get; set; }

        public override bool CanMoveTo(Figure figToMove, Board board, Move move)
        {
            throw new NotImplementedException("Still not implemented sorry");
        }
    }
}
