namespace FrontEndEngine.Chess.Classes.Board
{
    using Figures;
    using Common;
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class ChessBlock : GameObject
    {
        private bool _IsTagged;

        public ChessBlock(Figure figure, byte color, string skinPack)
        {
            #region SetColorName
            if (color == 0)
            {
                this.ColorName = "White";
            }
            else if (color == 1)
            {
                this.ColorName = "Black";
            }
            #endregion
            this.Color = color;
            this.Figure = figure;
            this.SkinPack = skinPack;

            this.IsObsticle = false;
            this._IsTagged = false;

            this.InitSkinName();

            this.AttackedBy = new List<Figure>();
        }

        public Figure Figure { get; set; }
        public List<Figure> AttackedBy { get; set; }

        public string ColorName { get; private set; }
        public string SkinPack { get; set; }
        public byte Color { get; private set; }

        public bool IsObsticle { get; private set; }
        
        public void InitSkinName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Game\Textures\Tiles\");
            sb.Append(this.SkinPack);
            sb.Append(@"\");
            sb.Append(this.ColorName);
            sb.Append("Tile");

            string result = sb.ToString();
            this.SetSkinName(result);
        }
        public bool IsTagged()
        {
            return this._IsTagged;
        }

        public void Tag()
        {
            this._IsTagged = true;
        }
        public void UnTag()
        {
            this._IsTagged = false;
        }

        public void SetFigure(Figure fig)
        {
            this.Figure = fig;
        }
        public void RemoveFigureFromHere()
        {
            this.Figure = null;
        }
    }
}
