namespace FrontEndEngine.Managers.HUD
{
    using Assets.Contacts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using System;

    internal abstract class HUDItem
    {
        public bool _ShouldBeDestroyed;

        protected static SpriteBatch _SpriteBatch;
        protected static AssetManager _AssetManager;

        protected HUDItem _ParentHudItem;
        protected List<HUDItem> _ChildHUDItems;
        protected bool _IsVisible;

        public HUDItem(HUDItem parentHudItem)
        {
            this._ParentHudItem = parentHudItem;
            this._ChildHUDItems = new List<HUDItem>();
        }

        public List<HUDItem> ChildHUDItems
        {
            get { return this._ChildHUDItems; }
        }

        public bool ShouldBeDestoyed
        {
            get { return this._ShouldBeDestroyed; }
            protected set { this._ShouldBeDestroyed = value; }
        }

        public bool IsVisible
        {
            get { return this._IsVisible; }
        }

        public virtual void Draw()
        {
            this.DrawFrame();

            List<HUDItem> itemsToRemove = new List<HUDItem>();

            foreach (var item in this._ChildHUDItems)
            {
                if (item.ShouldBeDestoyed)
                {
                    itemsToRemove.Add(item);
                    continue;
                }

                if (item.IsVisible == true)
                {
                    item.Draw();
                }
            }

            for (int i = 0; i < itemsToRemove.Count; i++)
            {
                this.ChildHUDItems.Remove(itemsToRemove[i]);
            }
        }

        internal HUDItem GetItemAtPosition(Point atPixelPos)
        {
            Point startingPos = this.GetPixelPosition();
            Point endingPos = startingPos + this.GetPixelSize();

            if (atPixelPos.X >= startingPos.X && atPixelPos.Y >= startingPos.Y && atPixelPos.X <= endingPos.X && atPixelPos.Y <= endingPos.Y && this.ChildHUDItems.Count == 0)
            {
                return this;
            }
            else
            {
                foreach (var item in this._ChildHUDItems)
                {
                    if (item.IsVisible)
                    {
                        if (item.GetItemAtPosition(atPixelPos) != null)
                        {
                            return item;
                        }
                    }
                }
            }

            return null;
        }

        public static void SetSpriteBatch(SpriteBatch sp)
        {
            _SpriteBatch = sp;
        }
        public static void SetAssetManager(AssetManager am)
        {
            _AssetManager = am;
        }

        public abstract Point GetPixelSize();
        public abstract Point GetPixelPosition();
        public abstract string GetFrameName();

        public abstract void OnMouseOver();
        public abstract void OnMouseClick(Point clickPos);

        internal virtual void TurnVisibilityOn()
        {
            this._IsVisible = true;
        }
        internal virtual void TurnVisibilityOff()
        {
            this._IsVisible = false;
        }

        protected void DrawFrame()
        {
            Point size = this.GetPixelSize();
            Point position = this.GetPixelPosition();
            
            string skinName = this.GetFrameName();
            
            _SpriteBatch.Draw(_AssetManager.GetTexture(skinName), new Rectangle(position.X, position.Y, size.X, size.Y), Color.White);
        }

        public void DestroyHUDItem()
        {
            this.ShouldBeDestoyed = true;
            foreach (var item in this._ChildHUDItems)
            {
                item.DestroyHUDItem();
            }
        }
    }
}