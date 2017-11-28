namespace FrontEndEngine.Chess.Classes.Figures.WW2Figures
{
    using FrontEndEngine.Chess.Classes.MovementStrategies;
    using FrontEndEngine.Chess.Classes.MovementStrategies.Strategies;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    class Water : Figure
    {
        public Water(byte color) : base(color, 0, 9999, "Water", "WW2", new Point(0,0))
        {
            List<Strategy> strategies = new List<Strategy>();
            strategies.Add(new Strategy(0, 0, 9999, 9999, 0, 0, true));
            this.MovementStrategy = new FigureMovement(strategies);
        }
    }
}
