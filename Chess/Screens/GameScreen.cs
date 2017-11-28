namespace FrontEndEngine.Screens
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using System;

    using Contracts;
    using Managers;
    using Managers.Assets;
    using Microsoft.Xna.Framework;

    using Utility;
    using Managers.HUD.Game;
    using Managers.Assets.Contacts;
    using Managers.DrawManagers;

    using Chess.EngineFolder;
    using Chess.Classes.Board;
    using System.Collections.Generic;
    using Managers.HUD;

    internal class GameScreen : EngineScreen
    {
        public GameScreen(Engine gameEngine, ContentManager content, SpriteBatch sprBatch) : 
            base(gameEngine, content, sprBatch)
        {
            this._AssetManager = new GameAssetManager(content);
            this._HUDManager = new GameHUDManager(sprBatch, this._AssetManager);
        }

        internal override void Draw()
        {
            base.Draw();
        }

        protected override void InitializeInputProvider()
        {
            this._InputProvider = new GameInputProvider();

            base.InitializeInputProvider();
        }
    }
}