namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.Vertical
{
    using System;
    using Board;
    using Figures;
    using Common;

    public class VerticalMovement : CustomStrategy
    {
        public VerticalMovement()
        {
            this._Strategies = new Strategy[2];

            this._Strategies[0] = new Strategy(0, 1, 0, 9999, 0, 0);
            this._Strategies[1] = new Strategy(0, -1, 0, 9999, 0, 0);
        }

        public VerticalMovement(int yMovementPoints, int yMustMove) : base(0, yMovementPoints)
        {
            this._Strategies = new Strategy[2];

            this._Strategies[0] = new Strategy(0, 1, 0, yMovementPoints, 0, yMustMove);
            this._Strategies[1] = new Strategy(0, -1, 0, yMovementPoints, 0, yMustMove);
        }
    }
}
