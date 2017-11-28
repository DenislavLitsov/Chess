namespace FrontEndEngine.Chess.EngineFolder
{
    using System;
    using System.Collections.Generic;
    using Classes.Board;
    using Microsoft.Xna.Framework;
    using Utility;
    using Classes.Players;
    using Classes.Figures;
    using Classes.Figures.MoveEvents;
    using Managers.HUD;
    using Managers.HUD.Game.HUDItems;
    using FrontEndEngine.Utility;

    public abstract class Engine
    {
        private static Engine MainEngine;

        public Board Board;
        internal List<HUDItem> HudItemsToAdd;

        protected TurnHandler _TurnHandler;
        protected List<int> _PlayersThisEngineControlls;

        public Engine()
        {
            MainEngine = this;
            
            this.HudItemsToAdd = new List<HUDItem>();
        }

        public Engine(List<Player> players, List<int> playersThisEngineControlls)
        {
            MainEngine = this;

            this._TurnHandler = new TurnHandler(players);
            this._PlayersThisEngineControlls = playersThisEngineControlls;
            this.HudItemsToAdd = new List<HUDItem>();
        }

        internal void ClickedOn(Point unitClickInPoint)
        {
            if (!Board.IsPosValid(unitClickInPoint))
            {
                this.Board.UnTagBlocks();
                return;
            }

            ChessBlock clickedBlock = Board.GetBlock(unitClickInPoint);
            if (clickedBlock.IsTagged() && this.Board.ActiveBlock.Figure.Color == this._TurnHandler.GetCurrPlayer().Color)
            {
                MoveFigure(this.Board.ActiveBlock, clickedBlock, unitClickInPoint);
                this._TurnHandler.ChangeTurn(this.Board);
            }
            else
            {
                this.Board.ActivateBlock(unitClickInPoint);
            }

        }

        public void MoveFigure(ChessBlock from, ChessBlock to, Point toPos)
        {
            from.Figure.MovementStrategy.Move(this.Board, new Common.Move(from.Figure.GetPosition(), toPos), 0, this);
        }

        public void KillFigure(Figure toKill)
        {
            this.Board.RemoveFigure(toKill);
            this.Board.GetBlock(toKill.GetPosition()).Figure = null;
            this._TurnHandler.Players[toKill.Color].AddKilledUnits(toKill.Name);
        }

        public static Engine GetMainEngine()
        {
            return MainEngine;
        }
        
        internal void CreateSelectFigureHud(TransformIntoFigureWhenOnPosition transformIntoFigureWhenOnPosition, List<Figure> _FiguresToSelect)
        {
            List<string> figureSkinNames = new List<string>();
            foreach (var item in _FiguresToSelect)
            {
                figureSkinNames.Add(item.GetSkinName());
            }

            float xSize = 14f;
            float ySize = 2f;

            Vector2 sizeIn16x9 = new Vector2(xSize, ySize);
            Point size = StaticVariables.Convert16by9ToCurrSize(sizeIn16x9);

            int xPos = (StaticVariables.ScreenPixelSize.X - size.X) / 2;
            int yPos = (StaticVariables.ScreenPixelSize.Y - size.Y) / 2;

            Point position = new Point(xPos, yPos);

            HUDItem hudItem = new Selector(transformIntoFigureWhenOnPosition.ExecuteSelection, position, size, figureSkinNames, null);
            hudItem.TurnVisibilityOn();

            this.HudItemsToAdd.Add(hudItem);
        }
    }
}