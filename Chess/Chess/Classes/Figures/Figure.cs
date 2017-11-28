namespace FrontEndEngine.Chess.Classes.Figures
{
    using Common;
    using MovementStrategies;
    using MovementStrategies.Strategies;
    using MovementStrategies.ConditionalMovements;
    using System.Collections.Generic;
    using System;
    using Microsoft.Xna.Framework;
    using System.Text;
    using Board;
    using MoveEvents;

    public class Figure : GameObject
    {
        private FigureMovement _MovementStrategy;

        protected MoveEvent _MoveEvent;

        public readonly byte Color;
        public readonly string ColorName;
        public readonly string SkinPack;

        private Point _Position;

        private string _Name;
        private int _Damage;
        private int _MaxHealth;
        private int _CurrentHealth;

        public Figure(byte color, int damage, int maxHealth, string name, string skinPack, Point position)
        {
            #region SetColorName
            if (color == 0)
            {
                this.ColorName = "White";
            }
            else if (color == 1)
            {
                this.ColorName = "Black";
            }
            #endregion
            this.Color = color;

            this.SkinPack = skinPack;

            this.Damage = damage;
            this._MaxHealth = maxHealth;
            this._CurrentHealth = maxHealth;
            this._Name = name;
            this.InitSkinName();

            this.SetInitPos(position);
            this.MovesMade = 0;
        }

        public Figure(MoveEvent moveEvent, byte color, int damage, int maxHealth, string name, string skinPack, Point position) :
            this(color, damage, maxHealth, name, skinPack, position)
        {
            this._MoveEvent = moveEvent;
        }

        public FigureMovement MovementStrategy
        {
            get
            {
                return _MovementStrategy;
            }

            protected set
            {
                this._MovementStrategy = value;
            }
        }

        public int Damage
        {
            get
            {
                return _Damage;
            }

            set
            {
                this._Damage = value;
            }
        }
        public int MaxHealth
        {
            get
            {
                return _MaxHealth;
            }

            set
            {
                this._MaxHealth = value;
            }
        }
        public int CurrentHealth
        {
            get
            {
                return this._CurrentHealth;
            }
            set
            {
                this._CurrentHealth = value;
            }
        }

        public string Name { get { return this._Name; } }
        public int MovesMade { get; private set; }

        internal void SetInitPos(Point pos)
        {
            this._Position = pos;
        }

        internal void MoveFigure(Point newPos)
        {
            this.MovesMade++;

            this._Position = new Point(newPos.X, newPos.Y);

            if (this._MoveEvent != null)
            {
                this._MoveEvent.OnTurnEnd();
            }
        }

        internal Point GetPosition()
        {
            return this._Position;
        }

        public void RevertMovementStrategy()
        {
            this._MovementStrategy.RevertMovement();
        }

        public void SetAllPossitionPossibleToAttack(Board board)
        {
            this.MovementStrategy.SetAllPossibleBlocksToAttack(this, board);
        }

        public void InitSkinName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Game\Textures\Figures\");
            sb.Append(this.SkinPack);
            sb.Append(@"\");
            sb.Append(this.ColorName);
            sb.Append(this.Name);

            string result = sb.ToString();
            this.SetSkinName(result);
        }

        public Figure GetCopy()
        {
            Figure result = new Figure(this.Color, this.Damage, this.MaxHealth, this.Name, this.SkinPack, new Point(this._Position.X, this._Position.Y));
            result.CurrentHealth = this.CurrentHealth;
            result.MovesMade = this.MovesMade;
            result.MovementStrategy = this.MovementStrategy;

            return result;
        }
    }
}