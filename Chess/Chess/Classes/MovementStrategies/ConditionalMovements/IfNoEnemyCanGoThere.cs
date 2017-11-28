namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using System;
    using System.Collections.Generic;

    using Board;
    using Common;
    using Figures;
    using Microsoft.Xna.Framework;

    public class IfNoEnemyCanGoThere : Condition
    {
        private Figure _Figure;

        public IfNoEnemyCanGoThere(Figure fig)
        {
            this._Figure = fig;
        }

        public override bool IsConditionFulfilled(Move move, Board board)
        {
            Board copyBoard = board.GetCopy();
            
            copyBoard.DeleteFigure(move.From);
            copyBoard.AddNewFigure(this._Figure.GetCopy(), move.To);

            for (byte colorNum = 0; colorNum < board.GetNumberOfFigureColors(); colorNum++)
            {
                if (colorNum == this._Figure.Color)
                {
                    continue;
                }

                List<Figure> figures = copyBoard.GetAllFigure((byte)colorNum);
                foreach (var figure in figures)
                {
                    Move mov = new Move(figure.GetPosition(), move.To);
                    if (figure.MovementStrategy.CanAttackWithOutCondType(figure, copyBoard, mov, typeof(IfNoEnemyCanGoThere)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
