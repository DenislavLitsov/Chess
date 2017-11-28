namespace FrontEndEngine.Managers.HUD.Common
{
    using System;
    using Microsoft.Xna.Framework;

    internal class RectangleHudItem : HUDItem
    {
        private Point _PixelPos;
        private Point _PixelSize;

        private string _Skin;

        public RectangleHudItem(string skin, Point pixelPosition, Point pixelSize, HUDItem parentHudItem) :
            base(parentHudItem)
        {
            this._PixelPos = pixelPosition;
            this._PixelSize = pixelSize;
            this._Skin = skin;
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
    }
}
