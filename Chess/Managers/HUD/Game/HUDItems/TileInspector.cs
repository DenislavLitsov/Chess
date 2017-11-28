namespace FrontEndEngine.Managers.HUD.Game.HUDItems
{
    using System;
    using Microsoft.Xna.Framework;
    
    using Utility;
    using Chess.Classes.Board;

    internal class TileInspector : HUDItem
    {
        private readonly Vector2 _TileOffSet = new Vector2();

        private readonly float _XPos;
        private readonly float _YSize;

        private ChessBlock _CurrInsepcting;

        public TileInspector(HUDItem parentHudItem):
            base(parentHudItem)
        {
            this._XPos = 2.5f;
            this._YSize = 2f;
            this._IsVisible = true;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override string GetFrameName()
        {
            return @"Game\HUDItems\TileInspector";
        }

        public override Point GetPixelPosition()
        {
            Point size = this.GetPixelSize();
            Point pos = new Point(StaticVariables.ScreenPixelSize.X - size.X, StaticVariables.ScreenPixelSize.Y - size.Y);

            return pos;
        }

        public override Point GetPixelSize()
        {
            Vector2 size16x9 = new Vector2((16f - _XPos), _YSize);
            Point result = StaticVariables.Convert16by9ToCurrSize(size16x9);
            return result;
        }

        public override void OnMouseClick(Point clickPos)
        {
            throw new NotImplementedException();
        }
        public override void OnMouseOver()
        {
            throw new NotImplementedException();
        }

        private void DrawContent()
        {
            throw new NotImplementedException();
        }
    }
}
