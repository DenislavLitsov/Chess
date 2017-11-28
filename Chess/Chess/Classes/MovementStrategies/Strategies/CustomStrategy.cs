namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies
{
    using System;
    using Board;
    using Figures;
    using Common;

    public class CustomStrategy : Strategy
    {
        protected Strategy[] _Strategies;

        public CustomStrategy():
            base(0,0)
        { 
            
        }

        public CustomStrategy(int xMovementPoints, int yMovementPoints) :
            base(xMovementPoints, yMovementPoints)
        {

        }

        public override bool CanMoveTo(Figure figToMove, Board board, Move move)
        {
            foreach (Strategy strat in _Strategies)
            {
                if (strat.CanMoveTo(figToMove, board, move) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
