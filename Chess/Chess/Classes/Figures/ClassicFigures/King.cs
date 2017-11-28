namespace FrontEndEngine.Chess.Classes.Figures.ClassicFigures
{
    using Microsoft.Xna.Framework;
    using MovementStrategies;
    using MovementStrategies.ConditionalMovements;
    using MovementStrategies.Strategies;
    using MovementStrategies.Strategies.ComplexStrategies;

    using System;
    using System.Collections.Generic;

    public class King : Figure
    {
        public King(byte color, int damage, int maxHealth, string skinPack, Board.Board board, Point pos) : base(color, damage, maxHealth, "King", skinPack, pos)
        {
            List<Strategy> strategies = new List<Strategy>();
            Condition kingCond = new IfNoEnemyCanGoThere(this);
            strategies.Add(new Strategy(1, 1, 1, 1, 0, 0, true, kingCond));
            strategies.Add(new Strategy(-1, 1, 1, 1, 0, 0, true, kingCond));
            strategies.Add(new Strategy(1, -1, 1, 1, 0, 0, true, kingCond));
            strategies.Add(new Strategy(-1, -1, 1, 1, 0, 0, true, kingCond));

            strategies.Add(new Strategy(0, 1, 0, 1, 0, 0, true, kingCond));
            strategies.Add(new Strategy(1, 0, 1, 0, 0, 0, true, kingCond));
            strategies.Add(new Strategy(-1, 0, 1, 0, 0, 0, true, kingCond));
            strategies.Add(new Strategy(0, -1, 0, 1, 0, 0, true, kingCond));

            Condition CastleCondition = new CastleCondition(this, "Rook");

            List<Condition> conds = new List<Condition>();
            conds.Add(kingCond);
            conds.Add(CastleCondition);

            Condition Cond = new Conditions(conds);

            Strategy castleRight = new Castle(1, 0, 2, 0, 1, 0, false, Cond, "Rook");
            Strategy castleLeft = new Castle(-1, 0, 2, 0, 1, 0, false, Cond, "Rook");

            strategies.Add(castleRight);
            strategies.Add(castleLeft);

            this.MovementStrategy = new FigureMovement(strategies);
        }
    }
}
