namespace FrontEndEngine.Managers.HUD.Editor.HUDItems
{
    using System;
    using Common;
    using Microsoft.Xna.Framework;
    using Contracts;
    using Utility;

    class LeftToolFrame : HUDItem
    {
        private const float _X_SIZE16x9 = 3f;
        private const float _Y_SIZE16x9 = 9f;

        private readonly Point _PIXEL_POS = new Point(0, 0);

        public LeftToolFrame(InputManager ip, HUDItem parentHudItem) : base(parentHudItem)
        {
            this.InitTextInputHuds(ip);
        }

        private void InitTextInputHuds(InputManager im)
        {
            HUDItem toAdd = new TextInput(im, new Point(0, 0), StaticVariables.Convert16by9ToCurrSize(new Vector2(1f, 0.5f)), this);
            toAdd.TurnVisibilityOn();
            this.ChildHUDItems.Add(toAdd);
        }

        public override string GetFrameName()
        {
            string result = @"Game\HUDItems\EditorHUDS\WhiteRectangle";
            return result;
        }

        public override Point GetPixelPosition()
        {
            return this._PIXEL_POS;
        }

        public override Point GetPixelSize()
        {
            Point result = StaticVariables.Convert16by9ToCurrSize(new Vector2(_X_SIZE16x9, _Y_SIZE16x9));
            return result;
        }

        public override void OnMouseClick(Point clickPos)
        {
        }

        public override void OnMouseOver()
        {
        }
    }
}
