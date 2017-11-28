namespace FrontEndEngine.Managers.Assets
{
    using Microsoft.Xna.Framework.Content;

    using Contacts;

    internal class GameAssetManager : AssetManager
    {
        public GameAssetManager(ContentManager content) : base(content)
        {

        }

        internal override void Initialize()
        {
            this.LoadTextures();
            this.LoadFonts();
            this.LoadHUD();
            this.LoadUtility();
        }

        protected override void LoadTextures()
        {
            this.LoadFigures();
            this.LoadTiles();
        }

        protected override void LoadFonts()
        {
            this.LoadFont(@"Game\Fonts\Normal");
        }

        private void LoadFigures()
        {
            this.LoadMedievalFigures();
        }

        private void LoadMedievalFigures()
        {
            LoadTexture(@"Game\Textures\Figures\Medieval\BlackBishop");
            LoadTexture(@"Game\Textures\Figures\Medieval\BlackKing");
            LoadTexture(@"Game\Textures\Figures\Medieval\BlackKnight");
            LoadTexture(@"Game\Textures\Figures\Medieval\BlackPawn");
            LoadTexture(@"Game\Textures\Figures\Medieval\BlackQueen");
            LoadTexture(@"Game\Textures\Figures\Medieval\BlackRook");

            LoadTexture(@"Game\Textures\Figures\Medieval\WhiteBishop");
            LoadTexture(@"Game\Textures\Figures\Medieval\WhiteKing");
            LoadTexture(@"Game\Textures\Figures\Medieval\WhiteKnight");
            LoadTexture(@"Game\Textures\Figures\Medieval\WhitePawn");
            LoadTexture(@"Game\Textures\Figures\Medieval\WhiteQueen");
            LoadTexture(@"Game\Textures\Figures\Medieval\WhiteRook");

            LoadTexture(@"Game\Textures\Figures\WW2\Tiger");
            LoadTexture(@"Game\Textures\Figures\WW2\Durchsbruchwagen");
            LoadTexture(@"Game\Textures\Figures\WW2\FW");
            LoadTexture(@"Game\Textures\Figures\WW2\Hellcat");
            LoadTexture(@"Game\Textures\Figures\WW2\Messerschmitt");
            LoadTexture(@"Game\Textures\Figures\WW2\P-30");
            LoadTexture(@"Game\Textures\Figures\WW2\Panther");
            LoadTexture(@"Game\Textures\Figures\WW2\Spitfire");
            LoadTexture(@"Game\Textures\Figures\WW2\T-34");
            LoadTexture(@"Game\Textures\Figures\WW2\Warhalk");
            LoadTexture(@"Game\Textures\Figures\WW2\Wildcat");
            LoadTexture(@"Game\Textures\Figures\WW2\Yak 9k");
            
            LoadTexture(@"Game\Textures\Figures\WW2\Water");
        }

        private void LoadTiles()
        {
            LoadTexture(@"Game\Textures\Tiles\Medieval\WhiteTile");
            LoadTexture(@"Game\Textures\Tiles\Medieval\BlackTile");
            LoadTexture(@"Game\Textures\Tiles\WW2\WhiteTile");
            LoadTexture(@"Game\Textures\Tiles\WW2\BlackTile");
        }

        private void LoadHUD()
        {
            LoadTexture(@"Game\HUDItems\Common\RectAngle");
            //LoadTexture(@"Game\HUDItems\TileInspector");
        }

        private void LoadUtility()
        {
            LoadTexture(@"Game\Utility\BlueDot");
            LoadTexture(@"Game\Utility\DebugDot");
            LoadTexture(@"Game\Utility\VerticalLine");
            LoadTexture(@"Game\Utility\HorizontalLine");
        }
    }
}
