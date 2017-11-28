namespace FrontEndEngine.Chess.Classes.MovementStrategies.Strategies
{
    using Board;
    using Common;
    using ConditionalMovements;
    using Figures;
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Strategy
    {
        public readonly Condition _Condition;

        public readonly int XDirection;
        public readonly int YDirection;

        public readonly int XMovementPoints;
        public readonly int YMovementPoints;

        public readonly int XMustMove;
        public readonly int YMustMove;

        public readonly bool CanAttack;
        public readonly bool CanMove;

        public Strategy(int xDir, int yDir)
        {
            this.XDirection = xDir;
            this.YDirection = yDir;

            this.XMovementPoints = 9999;
            this.YMovementPoints = 9999;

            this.XMustMove = 0;
            this.YMustMove = 0;

            this.CanAttack = true;
            this.CanMove = true;

            this._Condition = null;
        }

        public Strategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove)
        {
            this.XDirection = xDir;
            this.YDirection = yDir;

            this.XMovementPoints = xMovementPoints;
            this.YMovementPoints = yMovementPoints;

            this.XMustMove = xMustMove;
            this.YMustMove = yMustMove;

            this.CanAttack = true;
            this.CanMove = true;

            this._Condition = null;
        }

        public Strategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove, bool canAttack)
        {
            this.XDirection = xDir;
            this.YDirection = yDir;

            this.XMovementPoints = xMovementPoints;
            this.YMovementPoints = yMovementPoints;

            this.XMustMove = xMustMove;
            this.YMustMove = yMustMove;

            this.CanAttack = canAttack;
            this.CanMove = true;

            this._Condition = null;
        }

        public Strategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove, bool canAttack, Condition condition)
        {
            this.XDirection = xDir;
            this.YDirection = yDir;

            this.XMovementPoints = xMovementPoints;
            this.YMovementPoints = yMovementPoints;

            this.XMustMove = xMustMove;
            this.YMustMove = yMustMove;

            this.CanAttack = canAttack;
            this.CanMove = true;

            this._Condition = condition;
        }

        public Strategy(int xDir, int yDir, int xMovementPoints, int yMovementPoints, int xMustMove, int yMustMove, bool canAttack, bool canMove,Condition condition)
        {
            this.XDirection = xDir;
            this.YDirection = yDir;

            this.XMovementPoints = xMovementPoints;
            this.YMovementPoints = yMovementPoints;

            this.XMustMove = xMustMove;
            this.YMustMove = yMustMove;

            this.CanAttack = canAttack;
            this.CanMove = canMove;

            this._Condition = condition;
        }

        public virtual bool CanMoveTo(Figure figToMove, Board board, Move move)
        {
            int currX = move.From.X + this.XDirection;
            int currY = move.From.Y + this.YDirection;

            if (this.AllChecks(figToMove, board, move) == 0)
            {
                while (currX != move.To.X || currY != move.To.Y)
                {
                    Point pos = new Point(currX, currY);
                    if (board.IsPositionOutOfRange(pos) || board.IsObsticle(currX, currY) == false || (board.GetFigure(pos) != null && pos != move.To))
                    {
                        return false;
                    }

                    currX += XDirection;
                    currY += YDirection;
                }

                return true;
            }

            return false;
        }

        public virtual bool CanMoveWithOutCond(Figure figToMove, Board board, Move move)
        {
            int currX = move.From.X + this.XDirection;
            int currY = move.From.Y + this.YDirection;

            if (this.AllChecksWithOutCond(figToMove, board, move))
            {
                while (currX != move.To.X || currY != move.To.Y)
                {
                    Point pos = new Point(currX, currY);
                    if (board.IsPositionOutOfRange(pos) || board.IsObsticle(currX, currY) == false || (board.GetFigure(pos) != null && pos != move.To))
                    {
                        return false;
                    }

                    currX += XDirection;
                    currY += YDirection;
                }

                return true;
            }

            return false;
        }

        public virtual List<ChessBlock> GetAllPossibleMovementPositions(Figure figToMove, Board board)
        {
            List<ChessBlock> result = new List<ChessBlock>();

            int currX = figToMove.GetPosition().X + this.XDirection;
            int currY = figToMove.GetPosition().Y + this.YDirection;

            int maxX;
            int maxY;

            if (XDirection != 0)
            {
                maxX = ((XMovementPoints * this.XDirection) / (Math.Abs(this.XDirection))) + figToMove.GetPosition().X + this.XDirection;
            }
            else
            {
                maxX = currX;
            }

            if (YDirection != 0)
            {
                  maxY = ((YMovementPoints * this.YDirection) / (Math.Abs(this.YDirection))) + figToMove.GetPosition().Y + this.YDirection;
            }
            else
            {
                maxY = currY;
            }


            while (board.IsPositionOutOfRange(new Point(currX, currY)) == false && currX != maxX || currY != maxY)
            {
                Point currPos = new Point(currX, currY);
                Move currMove = new Move(figToMove.GetPosition(), currPos);

                bool isPosValid = board.IsPosValid(currPos);
                if (!isPosValid)
                {
                    break;
                }

                bool isFree = board.IsObsticle(currX, currY);

                int allChecks = AllChecks(figToMove, board, currMove);

                if (isFree == false || allChecks == 1)
                {
                    break;
                }
                else if (allChecks == 2)
                {
                    currX += XDirection;
                    currY += YDirection;
                    continue;
                }

                if (this.IsMustMoveFulfilled(currMove) == false)
                {
                    currX += XDirection;
                    currY += YDirection;
                    continue;
                }

                result.Add(board.GetBlock(currPos));

                if (board.GetFigure(currX, currY) != null)
                {
                    if (board.GetFigure(currX, currY).Color == figToMove.Color)
                    {
                        result.RemoveAt(result.Count - 1);
                    }

                    break;
                }

                currX += XDirection;
                currY += YDirection;
            }

            return result;
        }

        public bool IsInRange(Move move)
        {
            int absX = Math.Abs(move.From.X - move.To.X);
            int absY = Math.Abs(move.From.Y - move.To.Y);
            
            if (absX <= this.XMovementPoints && absY <= this.YMovementPoints)
            {
                return true;
            }

            return false;
        }

        public bool CanMoveToEndPos(Figure figToMove, Board board, Move move)
        {
            ChessBlock toBlock = board.GetBlock(move.To);
            if ((board.IsObsticle(move.To) && toBlock.Figure == null) || (toBlock.Figure != null && toBlock.Figure.Color != figToMove.Color && this.CanAttack && board.IsObsticle(move.To)))
            {
                if (this.XMustMove <= move.GetXMovement() && this.YMustMove <= move.GetYMovement())
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsDirectionSame(Move move)
        {
            if (move.From.X - move.To.X < 0 && this.XDirection > 0 || move.From.X - move.To.X > 0 && this.XDirection < 0 || move.From.X - move.To.X == 0 && this.XDirection == 0)
            {
                if (move.From.Y - move.To.Y < 0 && this.YDirection > 0 || move.From.Y - move.To.Y > 0 && this.YDirection < 0 || move.From.Y - move.To.Y == 0 && this.YDirection == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsMovementPossible(Move move)
        {
            if (this.XDirection != 0)
            {
                if (this.YDirection != 0)
                {
                    // both != 0
                    if (move.GetXMovement() % this.XDirection == 0 && move.GetYMovement() % this.YDirection == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    // x!= 0 y == 0
                    if (move.GetXMovement() % this.XDirection == 0 && move.GetYMovement() == 0)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (this.YDirection != 0)
                {
                    // x ==0 y != 0
                    if (move.GetXMovement() == 0 && move.GetYMovement() % this.YDirection == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    // both are zero
                    if (move.GetXMovement() % this.XDirection == 0 && move.GetYMovement() % this.YDirection == 0)
                    {
                        throw new Exception("WTF BOTH ARE 0 ?!");
                    }
                }
            }

            return false;
        }

        public bool IsMustMoveFulfilled(Move move)
        {
            int x = Math.Abs(move.From.X - move.To.X);
            int y = Math.Abs(move.From.Y - move.To.Y);

            if (x >= this.XMustMove && y >= this.YMustMove)
            {
                return true;
            }

            return false;
        }

        public bool IsConditionFullfiled(Move move, Board board)
        {
            if (this._Condition == null)
            {
                return true;
            }
            return this._Condition.IsConditionFulfilled(move, board);
        }

        /// <summary>
        /// zero = true
        /// one = false cuz checks
        /// two = false cuz stratCondition
        /// </summary>
        /// <param name="figToMove"></param>
        /// <param name="board"></param>
        /// <param name="move"></param>
        /// <returns></returns>
        public int AllChecks(Figure figToMove, Board board, Move move)
        {
            bool allChecks = this.AllChecksWithOutCond(figToMove, board, move);
            bool condition = this.IsConditionFullfiled(move, board);
            bool moveCondKept = board.IsMoveConditionKept(move);
            
            if (allChecks && condition && moveCondKept)
            {
                return 0;
            }
            else if (allChecks && moveCondKept)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public bool AllChecksWithOutCond(Figure figToMove, Board board, Move move)
        {
            bool isInRange = this.IsInRange(move);
            bool isDirectionSame = IsDirectionSame(move);
            bool isMovementPossible = IsMovementPossible(move);
            bool canMoveToEndPos = this.CanMoveToEndPos(figToMove, board, move);

            //must be false so it's possible
            bool isPositionOutOfRange = board.IsPositionOutOfRange(move.To);

            
            if (isInRange && isDirectionSame && isMovementPossible && canMoveToEndPos && isPositionOutOfRange == false)// && boardCond)
            {
                return true;
            }

            return false;
        }

        public virtual void Move(Figure figToMove, Board board, Move move, EngineFolder.Engine engine)
        {
            ChessBlock from = board.GetBlock(figToMove.GetPosition());
            ChessBlock to = board.GetBlock(move.To);
            if (to.Figure == null)
            {
                if (this.CanMove)
                {
                    board.MoveFigure(move);
                }

                board.UnTagBlocks();
            }
            else if (to.Figure.Color != from.Figure.Color)
            {
                Figure fromFig = from.Figure;
                Figure toFig = to.Figure;

                toFig.CurrentHealth -= fromFig.Damage;
                if (toFig.CurrentHealth <= 0)
                {
                    engine.KillFigure(toFig);
                    if (this.CanMove)
                    {
                        board.MoveFigure(move);
                    }
                }
                board.UnTagBlocks();
            }
        }

        public Strategy GetOppositeStrategy()
        {
            return new Strategy(-this.XDirection, -this.YDirection, this.XMovementPoints, this.YMovementPoints, this.XMustMove, this.YMustMove, this.CanAttack, this._Condition);
        }

        public Point GetMaxMovementPos(Point CurrPos, Board board)
        {
            int maxX = ((XMovementPoints * this.XDirection) / (Math.Abs(this.XDirection))) + CurrPos.X;
            int maxY = ((YMovementPoints * this.YDirection) / (Math.Abs(this.YDirection))) + CurrPos.Y;

            if (maxX < 0)
            {
                maxX = 0;
            }
            else if (maxX > board.GetMaxX())
            {
                maxX = board.GetMaxX();
            }

            if (maxY < 0)
            {
                maxY = 0;
            }
            else if (maxY > board.GetMaxY())
            {
                maxY = board.GetMaxY();
            }

            Point result = new Point(maxX, maxY);
            return result;
        }

        public bool HasCondition(Type cond)
        {
            if (this._Condition != null)
            {
                if (this._Condition is Conditions)
                {
                    Conditions conds = (Conditions)this._Condition;
                    foreach (var condition in conds.GetConditions())
                    {
                        if (condition.GetType() == cond)
                        {
                            return true;
                        }
                    }
                }
                else if (this._Condition.GetType() == cond)
                {
                    return true;
                }
            }

            return false;
        }

        protected void MoveFigure(Move move, Board board)
        {
            board.MoveFigure(move);
        }
    }
}