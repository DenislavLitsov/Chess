namespace FrontEndEngine.Managers.HUD.Game.HUDItems
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    using Common;
    using Utility;

    internal class Selector : HUDItem
    {
        private Action<int> _OnSelection;
        private List<HUDItem> _SelectionSquares;

        private Point _PixelPos;
        private Point _PixelSize;

        private const float MAXIMAL_X_16x9_SIZE = 1f;
        private const float MAXIMAL_Y_16x9_SIZE = 1f;
        private const float SQARE_SPACING = 0.1f;

        public Selector(Action<int> onSelection, Point pixelPosition, Point pixelSize, List<string> squareContentSkinNames, HUDItem parentHudItem):
            base(parentHudItem)
        {
            this._PixelPos = pixelPosition;
            this._PixelSize = pixelSize;

            this._OnSelection = onSelection;
            this._SelectionSquares = new List<HUD.HUDItem>();

            this.CreateSquares(squareContentSkinNames);
        }

        public override string GetFrameName()
        {
            string squareSkinName = @"Game\HUDItems\Common\RectAngle";
            return squareSkinName;
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
            Console.WriteLine("asd");
        }

        public override void OnMouseOver()
        {
        }

        protected void CreateSquares(List<string> squareContentSkinNames)
        {
            int itemsCount = squareContentSkinNames.Count;

            int spacing = StaticVariables.Convert16by9ToCurrSize(new Vector2(SQARE_SPACING, 0)).X;
            Point maximalSize = StaticVariables.Convert16by9ToCurrSize(new Vector2(MAXIMAL_X_16x9_SIZE, MAXIMAL_Y_16x9_SIZE));

            int XSize = this.GetXSquareSize(itemsCount, spacing);
            if (XSize > maximalSize.X)
            {
                XSize = maximalSize.X;
            }

            int startingX = this.GetStartingX(itemsCount, XSize, spacing);
            int startingY = this.GetStartingY(XSize);

            int currX = startingX;
            int currY = startingY;

            Point size = new Point(XSize, XSize);

            for (int index = 0; index < itemsCount; index++)
            {
                CreateSquareFrameAndItemInside(index, squareContentSkinNames[index], new Point(currX, currY), size);

                currX += size.X + spacing;
            }
        }

        protected void CreateSquareFrameAndItemInside(int number, string ItemSkin, Point squarePos, Point squareSize)
        {
            HUDItem item = new SelectorRectangleFrameWithSkinInside(this._OnSelection, number, this.GetFrameName(), ItemSkin, squarePos, squareSize, this);
            item.TurnVisibilityOn();

            this.ChildHUDItems.Add(item);
        }

        private int GetXSquareSize(int items, int spacing)
        {
            int total = this._PixelSize.X;
            total -= (((spacing - 1) * items));

            int squareSize = total / items;

            return squareSize;
        }

        private int GetStartingX(int itemsCount, int xSize, int spacing)
        {
            int selectorXpos = this._PixelPos.X;
            int selectorXSize = this._PixelSize.X;

            int totalFilledSpace = (itemsCount * xSize) + (spacing * (itemsCount - 1));
            int startingPos = ((selectorXSize - totalFilledSpace) / 2) + selectorXpos;

            return startingPos;
        }

        private int GetStartingY(int ySize)
        {
            int selectorYpos = this._PixelPos.Y;
            int selectorYSize = this._PixelSize.Y;

            int result = selectorYpos + (selectorYSize / 2) - (ySize / 2);

            return result;
        }
    }
}
