namespace FrontEndEngine.Chess.Classes.Figures.MoveEvents
{
    using System;

    using Figures;
    using EngineFolder;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class TransformIntoFigureWhenOnPosition : MoveEvent
    {
        private Point _PointToReach;
        private List<Figure> _FiguresToSelect;
        private Board.Board _Board;

        /// <summary>
        /// if x or y less than 0 then its not needed
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="toReach"></param>
        public TransformIntoFigureWhenOnPosition(Point toReach, List<Figure> figsToTransformInto,Figure figure, Board.Board board) :
            base(figure)
        {
            this._PointToReach = toReach;
            this._FiguresToSelect = figsToTransformInto;
            this._Board = board;
        }

        public override void OnTurnEnd()
        {
            bool isXOnPos = false;
            bool isYOnPos = false;

            if (this._Figure.GetPosition().X == this._PointToReach.X || this._PointToReach.X < 0)
            {
                isXOnPos = true;
            }
            if (this._Figure.GetPosition().Y == this._PointToReach.Y || this._PointToReach.Y < 0)
            {
                isYOnPos = true;
            }

            if (isXOnPos && isYOnPos)
            {
                this.Execute();
            }
        }

        public void ExecuteSelection(int number)
        {
            Figure newFig = this._FiguresToSelect[number].GetCopy();
            newFig.SetInitPos(this._Figure.GetPosition());
            this._Board.RemoveFigure(this._Figure);
            this._Board.AddNewFigure(newFig, newFig.GetPosition());
        }

        private void Execute()
        {
            Engine.GetMainEngine().CreateSelectFigureHud(this, this._FiguresToSelect);
        }
    }
}
