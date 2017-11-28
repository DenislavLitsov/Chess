namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies.Vertical
{
    using System;

    public class VerticalLeapMovement : CustomStrategy
    {
        public VerticalLeapMovement()
        {
            this._Strategies = new Strategy[2];

            this._Strategies[0] = new LinearLeapStrategy(0, 1, 0, 0, 0, 9999);
            this._Strategies[1] = new LinearLeapStrategy(0, -1, 0, 0, 0, 9999);
        }

        public VerticalLeapMovement(int yMovementPoints, int yMustMove) : base(0, yMovementPoints)
        {
            this._Strategies = new Strategy[2];

            this._Strategies[0] = new LinearLeapStrategy(0, 1, 0, yMustMove, 0, yMovementPoints);
            this._Strategies[1] = new LinearLeapStrategy(0, -1, 0, yMustMove, 0, yMovementPoints);
        }
    }
}
