namespace FrontEndEngine.Screens.Contracts
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    using Utility;
    using Managers.Assets.Contacts;
    using Managers.Contracts;
    using Managers.HUD;
    using Chess.Common;

    internal abstract class Screen
    {
        public Camera Camera;

        protected SpriteBatch _SpriteBatch;
        protected AssetManager _AssetManager;
        protected InputManager _InputProvider;
        protected HUDManager _HUDManager;

        private bool _IsInit;
        private Vector2 _ORIGIN = new Vector2(0, 0);

        public Screen(SpriteBatch sprBatch)
        {
            this._SpriteBatch = sprBatch;
            this.Camera = new Camera();
            this._IsInit = false;
        }

        internal virtual void Draw()
        {
            this.Camera.Update();
            this._HUDManager.DrawAllHudItems();
        }

        internal virtual void Update()
        {
            this._HUDManager.Update();
            this._InputProvider.Update();
        }

        internal void NowIsWorking()
        {
            if (!this._IsInit)
            {
                this._AssetManager.Initialize();
            }
        }

        protected void DrawGameObj(GameObject objToDraw, Point pixelPosToDraw)
        {
            int width = (int)(this.Camera.GetPixels(objToDraw.OffSet.X));
            int height = (int)(this.Camera.GetPixels(objToDraw.OffSet.Y));

            Rectangle rect = new Rectangle(pixelPosToDraw.X, pixelPosToDraw.Y, width, height);

            this._SpriteBatch.Draw(this._AssetManager.GetTexture(objToDraw.GetSkinName()), rect, null, Color.White, objToDraw.Rotation, _ORIGIN, SpriteEffects.None, 1f);
        }

        protected void DrawSprite(string spriteName, Point pos, Point size)
        {
            this._SpriteBatch.Draw(this._AssetManager.GetTexture(spriteName), new Rectangle(pos.X, pos.Y, size.X, size.Y), Color.White);
        }

        protected void DrawSpriteWithCenter(string spriteName, Point center, Point size)
        {
            Point pos = new Point(center.X - (size.X / 2), center.Y - (size.Y / 2));

            this._SpriteBatch.Draw(this._AssetManager.GetTexture(spriteName), new Rectangle(pos.X, pos.Y, size.X, size.Y), Color.White);
        }

        protected void DrawString(string stringToDraw, Point pos)
        {
            this._SpriteBatch.DrawString(this._AssetManager.GetFont(@"Game\Fonts\Normal"), stringToDraw, new Vector2(pos.X, pos.Y), Color.Black);
        }

        protected void DrawStringWithCenter(string stringToDraw, Point center)
        {
            SpriteFont font = this._AssetManager.GetFont(@"Game\Fonts\Normal");
            Vector2 pixelSizeOfStr = font.MeasureString(stringToDraw);
            Vector2 pixelPos = new Vector2(center.X - (pixelSizeOfStr.X / 2f), center.Y - (pixelSizeOfStr.Y / 2f));

            this._SpriteBatch.DrawString(font, stringToDraw, pixelPos, Color.Black);
        }

        protected void DrawBlueDot(Point pos, Point size)
        {
            this.DrawSprite(@"Game\Utility\BlueDot", pos, size);
        }

        protected void DrawDebugDot(Point pos, Point size)
        {
            this.DrawSprite(@"Game\Utility\DebugDot", pos, size);
        }

        protected abstract void InitializeInputProvider();

        protected abstract void OnMouseClickNotOnHud(Point clickPos);

        protected void OnMouseClick(Point clickPos)
        {
            HUDItem hudItem = this._HUDManager.GetHUDItemAt(clickPos);
            if (hudItem != null)
            {
                hudItem.OnMouseClick(clickPos);
            }
            else
            {
                this.OnMouseClickNotOnHud(clickPos);
            }
        }
    }
}
