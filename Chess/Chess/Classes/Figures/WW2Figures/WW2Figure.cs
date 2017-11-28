namespace FrontEndEngine.Chess.Classes.Figures.WW2Figures
{
    using System.Collections.Generic;

    using FrontEndEngine.Chess.Classes.MovementStrategies;
    using FrontEndEngine.Chess.Classes.MovementStrategies.Strategies;
    class WW2Figure : Figure
    {
        public WW2Figure(byte color, int damage, int maxHealth, string name) : base(color, 5, 7, name, "WW2", new Microsoft.Xna.Framework.Point(0, 0))
        {
            List<Strategy> strategies = new List<Strategy>();
            strategies.Add(new Strategy(1, 1, 1, 1, 0, 0, true));
            strategies.Add(new Strategy(-1, 1, 1, 1, 0, 0, true));
            strategies.Add(new Strategy(1, -1, 1, 1, 0, 0, true));
            strategies.Add(new Strategy(-1, -1, 1, 1, 0, 0, true));

            strategies.Add(new Strategy(0, 1, 0, 1, 0, 0, true));
            strategies.Add(new Strategy(1, 0, 1, 0, 0, 0, true));
            strategies.Add(new Strategy(-1, 0, 1, 0, 0, 0, true));
            strategies.Add(new Strategy(0, -1, 0, 1, 0, 0, true));

            strategies.Add(new Strategy(1, 0, 5, 0, 0, 0, true, false, null));
            strategies.Add(new Strategy(-1, 0, 5, 0, 0, 0, true, false, null));
            strategies.Add(new Strategy(1, 1, 5, 5, 0, 0, true, false, null));
            strategies.Add(new Strategy(1, -1, 5, 5, 0, 0, true, false, null));
            strategies.Add(new Strategy(-1, -1, 5, 5, 0, 0, true, false, null));
            strategies.Add(new Strategy(0, -1, 5, 5, 0, 0, true, false, null));
            strategies.Add(new Strategy(0, 1, 5, 5, 0, 0, true, false, null));

            this.MovementStrategy = new FigureMovement(strategies);
        }
    }
}
