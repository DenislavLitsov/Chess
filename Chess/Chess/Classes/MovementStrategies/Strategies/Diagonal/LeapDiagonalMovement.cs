namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.Diagonal
{
    using System;
    using Board;
    using Figures;
    using Common;

    public class LeapDiagonalMovement : CustomStrategy
    {
        public LeapDiagonalMovement()
        {
            this._Strategies = new Strategy[4];

            this._Strategies[0] = new LinearLeapStrategy(1, 1, 0, 0, 9999, 9999);
            this._Strategies[1] = new LinearLeapStrategy(1, -1, 0, 0, 9999, 9999);
            this._Strategies[2] = new LinearLeapStrategy(-1, 1, 0, 0, 9999, 9999);
            this._Strategies[3] = new LinearLeapStrategy(-1, -1, 0, 0, 9999, 9999);
        }

        public LeapDiagonalMovement(int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove) : base(xMovementPoints, yMovementPoints)
        {
            this._Strategies = new Strategy[4];

            this._Strategies[0] = new LinearLeapStrategy(1, 1, xMustMove, yMustMove, xMovementPoints, yMovementPoints);
            this._Strategies[1] = new LinearLeapStrategy(1, -1, xMustMove, yMustMove, xMovementPoints, yMovementPoints);
            this._Strategies[2] = new LinearLeapStrategy(-1, 1, xMustMove, yMustMove, xMovementPoints, yMovementPoints);
            this._Strategies[3] = new LinearLeapStrategy(-1, -1, xMustMove, yMustMove, xMovementPoints, yMovementPoints);
        }
    }
}
