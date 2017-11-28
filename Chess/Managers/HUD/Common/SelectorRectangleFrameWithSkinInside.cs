namespace FrontEndEngine.Managers.HUD.Common
{
    using System;
    using Microsoft.Xna.Framework;
    internal class SelectorRectangleFrameWithSkinInside : RectangleFrameWithSkinInside
    {
        private Action<int> _OnClick;
        private int _Number;

        public SelectorRectangleFrameWithSkinInside(Action<int> onClick, int number, string skinOfSquare, string skinOfContent, Point pixelPosition, Point pixelSize, HUDItem parentHudItem) : 
            base(skinOfSquare, skinOfContent, pixelPosition, pixelSize, parentHudItem)
        {
            this._OnClick = onClick;
            this._Number = number;
        }

        public override void OnMouseClick(Point clickPos)
        {
            this._OnClick(_Number);
            this._ParentHudItem.DestroyHUDItem();
        }
    }
}
