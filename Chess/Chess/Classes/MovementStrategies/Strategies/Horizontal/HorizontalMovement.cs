namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.Horizontal
{
    using System;
    using Board;
    using Figures;
    using Common;
    using System.Collections.Generic;

    public class HorizontalMovement : CustomStrategy
    {
        public HorizontalMovement()
        {
            this._Strategies = new Strategy[2];
            this._Strategies[0] = new Strategy(1,0);
            this._Strategies[1] = new Strategy(-1,0);
        }

        public HorizontalMovement(int xMovementPoints, int xMustMove):
            base(xMovementPoints, 0)
        {
            this._Strategies = new Strategy[2];
            this._Strategies[0] = new Strategy(1, 0, xMovementPoints, 0, xMustMove, 0);
            this._Strategies[1] = new Strategy(-1, 0, xMovementPoints, 0, xMustMove, 0);
        }
    }
}
