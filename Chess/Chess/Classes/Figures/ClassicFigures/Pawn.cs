namespace FrontEndEngine.Chess.Classes.Figures.ClassicFigures
{
    using Microsoft.Xna.Framework;
    using MoveEvents;
    using MovementStrategies;
    using MovementStrategies.ConditionalMovements;
    using MovementStrategies.Strategies;
    using System;
    using System.Collections.Generic;

    public class Pawn : Figure
    {
        public Pawn(Board.Board board, byte color, int damage, int maxHealth, string skinPack, Point pos) : base(color, damage, maxHealth, "Pawn", skinPack, pos)
        {
            Condition kingCond = new FigureNotGoingToCheck(this, "King");

            List<Strategy> strategies = new List<Strategy>();
            strategies.Add(new Strategy(0, -1, 0, 1, 0, 0, false, kingCond));
            this.MovementStrategy = new FigureMovement(strategies);

            Condition cond = new MovementBeforeNumberOfMoves(this, 1);
            List<Condition> conds = new List<Condition>();
            conds.Add(cond);
            conds.Add(kingCond);
            Conditions condsClass = new Conditions(conds);
            strategies.Add(new Strategy(0, -1, 0, 2, 0, 0, false, condsClass));

            Condition attackCond = new IfEnemyIsThere(this);
            conds = new List<Condition>();
            conds.Add(attackCond);
            conds.Add(kingCond);
            condsClass = new Conditions(conds);

            strategies.Add(new Strategy(1, -1, 1, 1, 0, 0, true, condsClass));
            strategies.Add(new Strategy(-1, -1, 1, 1, 0, 0, true, condsClass));

            MoveEvent moveEvent;

            List<Figure> transformingInto = new List<Figure>();
            transformingInto.Add(new Queen(color, damage, maxHealth, skinPack, new Point(0, 0)));
            transformingInto.Add(new Rook(color, damage, maxHealth, skinPack, new Point(0, 0)));
            transformingInto.Add(new Bishop(color, damage, maxHealth, skinPack, new Point(0, 0)));
            transformingInto.Add(new Knight(color, damage, maxHealth, skinPack, new Point(0, 0)));

            if (this.GetPosition().Y == 1)
            {
                moveEvent = new TransformIntoFigureWhenOnPosition(new Point(-1, 7), transformingInto, this, board);
            }
            else
            {
                moveEvent = new TransformIntoFigureWhenOnPosition(new Point(-1, 0), transformingInto, this, board);
            }

            this._MoveEvent = moveEvent;
        }
    }
}