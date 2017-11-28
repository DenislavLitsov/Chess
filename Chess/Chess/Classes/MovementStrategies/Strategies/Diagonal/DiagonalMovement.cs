namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.Diagonal
{
    using System;
    using Board;
    using Figures;
    using Common;

    public class DiagonalMovement : CustomStrategy
    {
        public DiagonalMovement()
        {
            this._Strategies = new Strategy[4];

            this._Strategies[0] = new Strategy(1, 1, 9999, 9999, 0, 0);
            this._Strategies[1] = new Strategy(1, -1, 9999, 9999, 0, 0);
            this._Strategies[2] = new Strategy(-1, 1, 9999, 9999, 0, 0);
            this._Strategies[3] = new Strategy(-1, -1, 9999, 9999, 0, 0);
        }

        public DiagonalMovement(int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove) : base(xMovementPoints, yMovementPoints)
        {
            this._Strategies = new Strategy[4];

            this._Strategies[0] = new Strategy(1, 1, xMovementPoints, yMovementPoints, xMustMove, yMustMove);
            this._Strategies[1] = new Strategy(1, -1, xMovementPoints, yMovementPoints, xMustMove, yMustMove);
            this._Strategies[2] = new Strategy(-1, 1, xMovementPoints, yMovementPoints, xMustMove, yMustMove);
            this._Strategies[3] = new Strategy(-1, -1, xMovementPoints, yMovementPoints, xMustMove, yMustMove);
        }
    }
}
