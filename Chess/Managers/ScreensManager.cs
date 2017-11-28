namespace FrontEndEngine.Managers
{
    using System;
    using System.Collections.Generic;

    using Screens.Contracts;
    using Screens;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using Chess.EngineFolder;

    internal class ScreensManager
    {
        private ContentManager _Content;
        private SpriteBatch _SpriteBatch;

        internal Screen CurrScreen;

        public ScreensManager(ContentManager content, SpriteBatch sprBatch)
        {
            this._Content = content;
            this._SpriteBatch = sprBatch;
        }

        internal void InitGameScreen(Engine eng)
        {
            this.CurrScreen = new GameScreen(eng, this._Content, this._SpriteBatch);
            this.CurrScreen.NowIsWorking();
        }

        internal void InitEditorScreen(Engine eng)
        {
            this.CurrScreen = new EditorScreen(eng, this._Content, this._SpriteBatch);
            this.CurrScreen.NowIsWorking();
        }

        internal void Update()
        {
            CurrScreen.Update();
        }

        internal void Draw()
        {
            CurrScreen.Draw();
        }
    }
}
