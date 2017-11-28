namespace FrontEndEngine.Screens.Contracts
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;

    using Contracts;
    using Chess.EngineFolder;
    using Managers.Assets;
    using Managers.HUD.Game;
    using Managers.DrawManagers;
    using Utility;
    using Chess.Classes.Board;

    internal abstract class EngineScreen : Screen
    {
        protected Engine _GameEngine;

        public EngineScreen(Engine gameEngine, ContentManager content, SpriteBatch sprBatch) : base(sprBatch)
        {
            this._GameEngine = gameEngine;

            BasicDrawings.SetAssetManager(this._AssetManager);
            BasicDrawings.SetSpriteBatch(this._SpriteBatch);

            StaticVariables.ScreenPixelSize = new Point(1280, 720);

            this.InitializeInputProvider();
        }

        protected override void InitializeInputProvider()
        {
            this._InputProvider.MouseOnLeftEdge += this.Camera.MoveLeft;
            this._InputProvider.MouseOnRightEdge += this.Camera.MoveRight;
            this._InputProvider.MouseOnUpperEdge += this.Camera.MoveUp;
            this._InputProvider.MouseOnLowerEdge += this.Camera.MoveDown;

            this._InputProvider.MouseOnTopLeftEdge += this.Camera.MoveUpLeft;
            this._InputProvider.MouseOnTopRightEdge += this.Camera.MoveUpRight;
            this._InputProvider.MouseOnBottomLeftEdge += this.Camera.MoveDownLeft;
            this._InputProvider.MouseOnBottomRightEdge += this.Camera.MoveDownRight;

            this._InputProvider.OnMouseWheelUp += this.Camera.ZoomIn;
            this._InputProvider.OnMouseWheelDown += this.Camera.ZoomOut;
            
            this._InputProvider.OnLeftClickMouse += this.OnMouseClick;
        }

        internal override void Draw()
        {
            this.DrawMap();
            base.Draw();
            this.UpdateNewHud();
        }

        private void DrawMap()
        {
            Point initPixelOffSets = GetInitOffSetsFromCamera();
            initPixelOffSets = new Point(initPixelOffSets.X - this.Camera.GetPixels(1), initPixelOffSets.Y - this.Camera.GetPixels(1));
            Point pixelOffSets = initPixelOffSets;

            Point initItemDrawPosition = new Point((int)Math.Floor(this.Camera.TopLeftUnitPosition.X - 1), (int)Math.Floor(this.Camera.TopLeftUnitPosition.Y - 1));
            Point currItemDrawPosition = initItemDrawPosition;
            int pixelsOfOneUnit = this.Camera.GetPixels(1);

            while (pixelOffSets.Y - Math.Abs(initPixelOffSets.Y) < StaticVariables.ScreenPixelSize.Y + pixelsOfOneUnit)
            {
                if (currItemDrawPosition.Y >= 0)
                {
                    while (pixelOffSets.X - Math.Abs(initPixelOffSets.X) < StaticVariables.ScreenPixelSize.X + pixelsOfOneUnit)
                    {
                        if (currItemDrawPosition.X >= 0)
                        {
                            ChessBlock tileToDraw = this._GameEngine.Board.GetBlock(currItemDrawPosition);

                            if (tileToDraw != null)
                            {
                                this.DrawGameObj(tileToDraw, pixelOffSets);
                                if (tileToDraw.Figure != null)
                                {
                                    this.DrawGameObj(tileToDraw.Figure, pixelOffSets);
                                }
                                if (tileToDraw.IsTagged())
                                {
                                    DrawBlueDot(pixelOffSets);
                                }
                            }
                        }
                        pixelOffSets.X += pixelsOfOneUnit;
                        currItemDrawPosition.X++;
                    }
                }

                pixelOffSets.X = initPixelOffSets.X;
                currItemDrawPosition.X = initItemDrawPosition.X;

                pixelOffSets.Y += pixelsOfOneUnit;
                currItemDrawPosition.Y++;
            }
        }

        private Point GetInitOffSetsFromCamera()
        {
            float xDecimal = (this.Camera.TopLeftUnitPosition.X - (float)Math.Floor(this.Camera.TopLeftUnitPosition.X));
            int xOffSet = -this.Camera.GetPixels(xDecimal);

            float yDecimal = (this.Camera.TopLeftUnitPosition.Y - (float)Math.Floor(this.Camera.TopLeftUnitPosition.Y));
            int yOffSet = -this.Camera.GetPixels(yDecimal);

            Point result = new Point(xOffSet, yOffSet);
            return result;
        }

        private void DrawBlueDot(Point pixelOffSet)
        {
            int allPixels = this.Camera.GetPixels(1);
            int pixelSize = allPixels / 3;
            int remaining = allPixels - pixelSize;

            Point newPos = new Point(pixelOffSet.X + (remaining / 2), pixelOffSet.Y + (remaining / 2));

            this.DrawBlueDot(newPos, new Point(pixelSize, pixelSize));
        }

        protected override void OnMouseClickNotOnHud(Point clickPos)
        {
            Vector2 unitClick = this.Camera.GetUnits(clickPos) + this.Camera.TopLeftUnitPosition;

            Point unitClickInPoint = new Point((int)Math.Floor(unitClick.X), (int)Math.Floor(unitClick.Y));
            this._GameEngine.ClickedOn(unitClickInPoint);
        }
        private void UpdateNewHud()
        {
            int count = this._GameEngine.HudItemsToAdd.Count;

            for (int i = 0; i < count; i++)
            {
                this._HUDManager.AddHUDItem(this._GameEngine.HudItemsToAdd[i]);
            }
            for (int i = 0; i < count; i++)
            {
                this._GameEngine.HudItemsToAdd.RemoveAt(0);
            }
        }
    }
}
