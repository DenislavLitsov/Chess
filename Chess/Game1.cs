namespace FrontEndEngine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using Managers;
    using Utility;

    using Chess.EngineFolder;
    using Chess.Classes.Players;
    using System.Collections.Generic;

    public class Game1 : Game
    {
        private GraphicsDeviceManager _GraphicsDeviceManager;
        private SpriteBatch _SpriteBatch;

        private Engine _GameEngine;

        internal ScreensManager ScreensManager;

        public Game1()
        {
            _GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            InitializeFrontEndEngine();
            InitializeStaticVariables();

            this.ScreensManager = new ScreensManager(this.Content, this._SpriteBatch);

            InitializeGame();
            //InitializeEditor();

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
        }
        
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (this.IsActive)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                this.ScreensManager.CurrScreen.Update();
            }
            
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PeachPuff);
            this._SpriteBatch.Begin();
            this.ScreensManager.CurrScreen.Draw();
            base.Draw(gameTime);
            //System.Console.WriteLine(1000 / gameTime.ElapsedGameTime.Milliseconds);
            this._SpriteBatch.End();
        }

        private void InitializeFrontEndEngine()
        {
            this.IsMouseVisible = true;
            this._SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private void InitializeGame()
        {
            Player first = new Player(0);
            Player second = new Player(1);
        
            List<Player> players = new List<Player>();
            players.Add(first);
            players.Add(second);
            
            List<int> playersIndex = new List<int>();
            playersIndex.Add(0);
            playersIndex.Add(1);
        
            this._GameEngine = new TwoPlayersOneComputerEngine(players, playersIndex);
            this.ScreensManager.InitGameScreen(this._GameEngine);
        }

        private void InitializeEditor()
        {
            this._GameEngine = new EditorEngine();
            this.ScreensManager.InitEditorScreen(this._GameEngine);
        }

        private void InitializeStaticVariables()
        {
            StaticVariables.GraphicsDeviceManager = _GraphicsDeviceManager;
        }
    }
}