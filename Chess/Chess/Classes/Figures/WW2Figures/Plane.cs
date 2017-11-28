namespace FrontEndEngine.Chess.Classes.Figures.WW2Figures
{
    using FrontEndEngine.Chess.Classes.MovementStrategies;
    using FrontEndEngine.Chess.Classes.MovementStrategies.Strategies;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    class Plane : Figure
    {
        public Plane(byte color, string name, int xRange, int yRange) : base(color, 1, 3, name, "WW2", new Point(0, 0))
        {
            List<Strategy> strategies = new List<Strategy>();
            
            for (int y = 1; y < yRange; y++)
            {
                int x = 0;
                strategies.Add(new Strategy(x, y, x, y, x - 1, y - 1, true));
                strategies.Add(new Strategy(x, -y, x, y, x - 1, y - 1, true));
            }

            for (int x = 1; x < xRange; x++)
            {
                int y = 0;

                strategies.Add(new Strategy(x, y, x, y, x - 1, y - 1, true));
                strategies.Add(new Strategy(-x, y, x, y, x - 1, y - 1, true));
            }
            
            strategies.Add(new Strategy(1, 1, 1, 1, 1 - 1, 1 - 1, true));
            strategies.Add(new Strategy(1, -1, 1, 1, 1 - 1, 1 - 1, true));
            strategies.Add(new Strategy(-1, 1, 1, 1, 1 - 1, 1 - 1, true));
            strategies.Add(new Strategy(-1, -1, 1, 1, 1 - 1, 1 - 1, true));

            //for (int y = 0; y < yRange; y++)
            //{
            //    for (int x = 0; x < xRange; x++)
            //    {
            //        if (x == 0 && y == 0)
            //        {
            //            continue;
            //        }
            //        strategies.Add(new Strategy(x, y, x, y, x - 1, y - 1, true));
            //        strategies.Add(new Strategy(-x, y, x, y, x - 1, y - 1, true));
            //        strategies.Add(new Strategy(x, -y, x, y, x - 1, y - 1, true));
            //        strategies.Add(new Strategy(-x, -y, x, y, x - 1, y - 1, true));
            //    }
            //}
            this.MovementStrategy = new FigureMovement(strategies);
        }
    }
}
