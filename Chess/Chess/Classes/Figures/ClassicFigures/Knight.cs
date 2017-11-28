namespace FrontEndEngine.Chess.Classes.Figures.ClassicFigures
{
    using Microsoft.Xna.Framework;
    using MovementStrategies;
    using MovementStrategies.ConditionalMovements;
    using MovementStrategies.Strategies;
    using System;
    using System.Collections.Generic;

    public class Knight : Figure
    {
        public Knight(byte color, int damage, int maxHealth, string skinPack, Point pos) : base(color, damage, maxHealth, "Knight", skinPack, pos)
        {
            List<Strategy> strategies = new List<Strategy>();
            Condition kingCond = new FigureNotGoingToCheck(this, "King");
            strategies.Add(new Strategy(1, 2, 1, 2, 0, 1, true, kingCond));
            strategies.Add(new Strategy(1, -2, 1, 2, 0, 1, true, kingCond));
            strategies.Add(new Strategy(-1, 2, 1, 2, 0, 1, true, kingCond));
            strategies.Add(new Strategy(-1, -2, 1, 2, 0, 1, true, kingCond));
            strategies.Add(new Strategy(2, 1, 2, 1, 1, 0, true, kingCond));
            strategies.Add(new Strategy(2, -1, 2, 1, 1, 0, true, kingCond));
            strategies.Add(new Strategy(-2, 1, 2, 1, 1, 0, true, kingCond));
            strategies.Add(new Strategy(-2, -1, 2, 1, 1, 0, true, kingCond));
            this.MovementStrategy = new FigureMovement(strategies);
        }
    }
}
