namespace FrontEndEngine.Managers.HUD.Game
{
    using HUDItems;
    using Assets.Contacts;
    using Microsoft.Xna.Framework.Graphics;
    using Utility;
    using System.Collections.Generic;

    internal class GameHUDManager : HUDManager
    {
        public GameHUDManager(SpriteBatch sprBatch, AssetManager assetManager) :
            base(sprBatch, assetManager)
        {
            this._ListHUDItems = new List<HUDItem>();
        }

        private void InitHudItems(Camera currCamera)
        {
            //TileInspector ti = new TileInspector();
            //this.AddHUDItem(ti);
        }
    }
}