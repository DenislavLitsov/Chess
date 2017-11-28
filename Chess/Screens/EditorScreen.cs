namespace FrontEndEngine.Screens
{
    using System;

    using Contracts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Chess.EngineFolder;
    using Microsoft.Xna.Framework.Content;
    using FrontEndEngine.Managers;
    using Managers.HUD.Editor;
    using FrontEndEngine.Managers.Assets;

    internal class EditorScreen : EngineScreen
    {
        public EditorScreen(Engine gameEngine, ContentManager content, SpriteBatch sprBatch) : base(gameEngine, content, sprBatch)
        {
            this._AssetManager = new EditorAssetManager(content);
            this._HUDManager = new EditorHUDManager(sprBatch, this._AssetManager, this._InputProvider);
        }

        protected override void InitializeInputProvider()
        {
            this._InputProvider = new GameInputProvider();

            base.InitializeInputProvider();
        }

        protected override void OnMouseClickNotOnHud(Point clickPos)
        {
        }
    }
}
