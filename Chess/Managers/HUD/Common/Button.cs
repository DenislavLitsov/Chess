using System;
using Microsoft.Xna.Framework;

namespace FrontEndEngine.Managers.HUD.Common
{

    class Button : HUDItem
    {
        public Button(HUDItem parentHudItem) : base(parentHudItem)
        {
        }

        public override string GetFrameName()
        {
            throw new NotImplementedException();
        }

        public override Point GetPixelPosition()
        {
            throw new NotImplementedException();
        }

        public override Point GetPixelSize()
        {
            throw new NotImplementedException();
        }

        public override void OnMouseClick(Point clickPos)
        {
            throw new NotImplementedException();
        }

        public override void OnMouseOver()
        {
            throw new NotImplementedException();
        }
    }
}
