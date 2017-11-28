namespace FrontEndEngine.Managers.HUD.Editor
{
    using FrontEndEngine.Managers.Assets.Contacts;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using System;
    using Editor.HUDItems;
    using Contracts;

    class EditorHUDManager : HUDManager
    {
        public EditorHUDManager(SpriteBatch sb, AssetManager assetManager, InputManager gip) : base(sb, assetManager)
        {
            this._ListHUDItems = new List<HUDItem>();

            this.InitHudItems(assetManager, gip);
        }

        private void InitHudItems(AssetManager assetManager, InputManager gip)
        {
            HUDItem leftToolbar = new LeftToolFrame(gip, null);
            leftToolbar.TurnVisibilityOn();
            this.AddHUDItem(leftToolbar);
        }
    }
}
