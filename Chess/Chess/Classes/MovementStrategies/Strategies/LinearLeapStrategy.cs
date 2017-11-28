namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies
{
    using System;
    using Board;
    using Figures;
    using Common;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    public class LinearLeapStrategy : Strategy
    {
        public LinearLeapStrategy(int xDir, int yDir, int xMustLeap, int yMustLeap, int xMovementPoints, int yMovementPoints) : base(xDir, yDir, xMovementPoints, yMovementPoints, xMustLeap, yMustLeap)
        {
        }

        public LinearLeapStrategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove, bool canAttack) : base(xDir, yDir, xMovementPoints, yMovementPoints, xMustMove, yMustMove, canAttack)
        {
        }

        public override bool CanMoveTo(Figure figToMove, Board board, Move move)
        {
            if (this.AllChecks(figToMove, board, move) == 0)
            {
                return true;
            }

            return false;
        }

        public override List<ChessBlock> GetAllPossibleMovementPositions(Figure figToMove, Board board)
        {
            List<ChessBlock> result = new List<ChessBlock>();

            int currX = figToMove.GetPosition().X + this.XDirection;
            int currY = figToMove.GetPosition().Y + this.YDirection;

            int maxX = ((XMovementPoints * this.XDirection) / (Math.Abs(this.XDirection))) + currX;
            int maxY = ((YMovementPoints * this.YDirection) / (Math.Abs(this.YDirection))) + currY;
            
            while (currX < maxX && currY < maxY)
            {
                Point currPos = new Point(currX, currY);
                Move currMove = new Move(figToMove.GetPosition(), currPos);
                
                if (board.IsObsticle(currX, currY) == false || AllChecks(figToMove, board, currMove) == 0)
                {
                    continue;
                }

                result.Add(board.GetBlock(currPos));

                currX += XDirection;
                currY += YDirection;
            }

            return result;
        }
    }
}
