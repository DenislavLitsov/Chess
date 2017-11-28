namespace FrontEndEngine.Managers.Assets.Contacts
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using System;

    internal abstract class AssetManager
    {
        protected Dictionary<string, Texture2D> Textures;
        protected Dictionary<string, SpriteFont> Fonts;

        protected ContentManager _Content;

        public AssetManager(ContentManager content)
        {
            this._Content = content;
            this.Textures = new Dictionary<string, Texture2D>();
            this.Fonts = new Dictionary<string, SpriteFont>();
        }

        protected abstract void LoadTextures();
        protected abstract void LoadFonts();

        internal abstract void Initialize();

        protected virtual void UnloadAll()
        {
            this._Content.Unload();
        }
        
        public Texture2D GetTexture(string name)
        {
            return this.Textures[name];
        }

        public SpriteFont GetFont(string name)
        {
            return this.Fonts[name];
        }

        protected void LoadTexture(string nameOfTexture)
        {
            Texture2D textureToLoad = this._Content.Load<Texture2D>(nameOfTexture);
            this.Textures.Add(nameOfTexture, textureToLoad);
        }

        protected void LoadFont(string fontName)
        {
            SpriteFont font = this._Content.Load<SpriteFont>(fontName);
            this.Fonts.Add(fontName, font);
        }
    }
}
