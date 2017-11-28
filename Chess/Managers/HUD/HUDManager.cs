namespace FrontEndEngine.Managers.HUD
{
    using Assets.Contacts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    internal abstract class HUDManager
    {
        protected List<HUDItem> _ListHUDItems;

        public HUDManager(SpriteBatch sb, AssetManager assetManager)
        {
            HUDItem.SetSpriteBatch(sb);
            HUDItem.SetAssetManager(assetManager);
        }

        public void DrawAllHudItems()
        {
            List<HUDItem> itemsToRemove = new List<HUDItem>();
            foreach (var item in this._ListHUDItems)
            {
                if (item.ShouldBeDestoyed)
                {
                    itemsToRemove.Add(item);
                    continue;
                }
                if (item.IsVisible)
                {
                    item.Draw();
                }
            }

            for (int i = 0; i < itemsToRemove.Count; i++)
            {
                this._ListHUDItems.Remove(itemsToRemove[i]);
            }
        }

        public HUDItem GetHUDItemAt(Point atPixelPostition)
        {
            foreach (HUDItem item in this._ListHUDItems)
            {
                if (item.IsVisible)
                {
                    HUDItem atPos = item.GetItemAtPosition(atPixelPostition);
                    if (atPos != null)
                    {
                        return atPos;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// does not return child HUD items you should get them from the HUD items itself
        /// </summary>
        /// <returns></returns>
        public List<HUDItem> GetHUDItems()
        {
            return this._ListHUDItems;
        }

        public virtual void Update()
        {

        }

        internal void AddHUDItem(HUDItem item)
        {
            this._ListHUDItems.Add(item);
        }

        private void DestroyUnUsedHuds()
        {

        }
    }
}