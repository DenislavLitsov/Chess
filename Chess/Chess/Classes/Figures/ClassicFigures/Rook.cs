namespace FrontEndEngine.Chess.Classes.Figures.ClassicFigures
{
    using Microsoft.Xna.Framework;
    using MovementStrategies;
    using MovementStrategies.ConditionalMovements;
    using MovementStrategies.Strategies;
    using System;
    using System.Collections.Generic;

    public class Rook : Figure
    {
        public Rook(byte color, int damage, int maxHealth, string skinPack, Point pos) : base(color, damage, maxHealth, "Rook", skinPack, pos)
        {
            List<Strategy> strategies = new List<Strategy>();
            Condition kingCond = new FigureNotGoingToCheck(this, "King");
            strategies.Add(new Strategy(0, 1, 9999, 9999, 0, 0, true, kingCond));
            strategies.Add(new Strategy(1, 0, 9999, 9999, 0, 0, true, kingCond));
            strategies.Add(new Strategy(-1, 0, 9999, 9999, 0, 0, true, kingCond));
            strategies.Add(new Strategy(0, -1, 9999, 9999, 0, 0, true, kingCond));
            this.MovementStrategy = new FigureMovement(strategies);
        }
    }
}
