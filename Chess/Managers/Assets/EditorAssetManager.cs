namespace FrontEndEngine.Managers.Assets
{
    using Microsoft.Xna.Framework.Content;

    class EditorAssetManager : GameAssetManager
    {
        public EditorAssetManager(ContentManager content) : base(content)
        {
        }

        protected override void LoadTextures()
        {
            this.LoadTexture(@"Game\HUDItems\EditorHUDS\WhiteRectangle");
            this.LoadTexture(@"Game\HUDItems\Common\Square");

            base.LoadTextures();
        }


        protected override void LoadFonts()
        {

            base.LoadFonts();
        }
    }
}
