namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.Horizontal
{
    using System;
    using Board;
    using Figures;
    using Common;

    public class HorizontalLeapMovement : CustomStrategy
    {
        public HorizontalLeapMovement()
        {
            this._Strategies = new Strategy[2];
            this._Strategies[0] = new LinearLeapStrategy(1, 0, 0, 0, 9999, 0);
            this._Strategies[1] = new LinearLeapStrategy(-1, 0, 0, 0, 9999, 0);
        }

        public HorizontalLeapMovement(int xMovementPoint, int xMustMove) : base(xMovementPoint, 0)
        {
            this._Strategies = new Strategy[2];
            this._Strategies[0] = new LinearLeapStrategy(1, 0, xMustMove, 0, xMovementPoint, 0);
            this._Strategies[1] = new LinearLeapStrategy(-1, 0, xMustMove, 0, xMovementPoint, 0);
        }
    }
}
