namespace FrontEndEngine.Chess.Classes.MovementStrategies.ConditionalMovements
{
    using System;
    using System.Collections.Generic;
    using Board;
    using Common;
    using Figures;

    public class FigureNotGoingToCheck : Condition
    {
        private readonly Figure _MainFigure;
        private readonly string _FigureToDefend;

        public FigureNotGoingToCheck(Figure mainFig, string figureToDefend)
        {
            this._MainFigure = mainFig;
            this._FigureToDefend = figureToDefend;
        }

        public override bool IsConditionFulfilled(Move move, Board board)
        {
            Board newBoard = board.GetCopy();
            newBoard.MoveFigure(move);

            List<Figure> figsToDefend = this.GetFigsWithName(board);
            foreach (Figure fig in figsToDefend)
            {
                if (newBoard.IsSomethingAttackingThisPositionByEnemy(fig.Color, fig.GetPosition()))
                {
                    return false;
                }
            }

            return true;
        }

        private List<Figure> GetFigsWithName(Board board)
        {
            List<Figure> allFriendlyFigs = board.GetAllFigure(this._MainFigure.Color);
            List<Figure> result = new List<Figure>();

            foreach (var fig in allFriendlyFigs)
            {
                if (fig.Name == this._FigureToDefend)
                {
                    result.Add(fig);
                }
            }
            return result;
        }
    }
}
