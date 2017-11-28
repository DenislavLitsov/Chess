namespace FrontEndEngine.Managers.HUD.Common
{
    using System;
    using Microsoft.Xna.Framework;

    class RectangleFrameWithSkinInside : HUDItem
    {
        private Point _PixelPos;
        private Point _PixelSize;

        private string _Skin;

        public RectangleFrameWithSkinInside(string skinOfSquare, string skinOfContent, Point pixelPosition, Point pixelSize, HUDItem parentHudItem) :
            base(parentHudItem)
        {
            this._PixelPos = pixelPosition;
            this._PixelSize = pixelSize;
            this._Skin = skinOfSquare;

            this.AddRectangleHudItem(skinOfContent, pixelPosition, pixelSize);
        }

        public override string GetFrameName()
        {
            return this._Skin;
        }

        public override Point GetPixelPosition()
        {
            return this._PixelPos;
        }

        public override Point GetPixelSize()
        {
            return this._PixelSize;
        }

        public override void OnMouseClick(Point clickPos)
        {
        }

        public override void OnMouseOver()
        {
        }

        private void AddRectangleHudItem(string skinOfContent, Point pixelPosition, Point pixelSize)
        {
            HUDItem item = new RectangleHudItem(skinOfContent, pixelPosition, pixelSize, this);
            item.TurnVisibilityOn();

            this._ChildHUDItems.Add(item);
        }
    }
}
