namespace FrontEndEngine.Chess.Classes.Board
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Figures;
    using Microsoft.Xna.Framework;
    using MovementStrategies;
    using TurnConditions;
    using MovementStrategies.ConditionalMovements;

    public class Board
    {
        public List<List<Figure>> AllFigures;
        public List<IBoardConditionMove> MoveConditions;

        private List<List<ChessBlock>> _ChessBlocks;

        private List<ChessBlock> TaggedBlocks;
        private ChessBlock _ActiveBlock;

        private readonly string _SkinPack;

        public Board(int width, int height, byte colorCount, string skinPack)
        {
            this.MoveConditions = new List<IBoardConditionMove>();

            this._SkinPack = skinPack;

            this.InitializeSquareBoard(width, height);
            this.TaggedBlocks = new List<ChessBlock>();
            this.AllFigures = new List<List<Figure>>();
            for (int i = 0; i < colorCount; i++)
            {
                this.AllFigures.Add(new List<Figure>());
            }
        }

        public ChessBlock ActiveBlock
        {
            get
            {
                return _ActiveBlock;
            }

            private set
            {
                this._ActiveBlock = value;
            }
        }

        internal void ActivateBlock(Point point)
        {
            UnTagBlocks();

            ChessBlock newBlock = this.GetBlock(point);
            
            Figure fig = this.GetFigure(point);
            if (fig != null)
            {
                List<ChessBlock> allBlocksItCanMoveTo = 
                    fig.MovementStrategy.GetAllPossibleToMoveToChessBlocks(fig, this);

                this.TagNewBlocks(allBlocksItCanMoveTo);
            }

            this.ActiveBlock = newBlock;
        }

        private void InitializeSquareBoard(int width, int height)
        {
            this._ChessBlocks = new List<List<ChessBlock>>();
            for (int y = 0; y < height; y++)
            {
                this._ChessBlocks.Add(new List<ChessBlock>());
                for (int x = 0; x < width; x++)
                {
                    ChessBlock cb;
                    #region Init cb
                    if (y % 2 == 0)
                    {
                        if (x % 2 == 0)
                        {
                            cb = new ChessBlock(null, 0, this._SkinPack);
                        }
                        else
                        {
                            cb = new ChessBlock(null, 1, this._SkinPack);
                        }
                    }
                    else
                    {
                        if (x % 2 != 0)
                        {
                            cb = new ChessBlock(null, 0, this._SkinPack);
                        }
                        else
                        {
                            cb = new ChessBlock(null, 1, this._SkinPack);
                        }
                    }
                    #endregion

                    this._ChessBlocks[y].Add(cb);
                }
            }
        }

        public void CalcAllAttackingBlocks()
        {
            foreach (var item in this._ChessBlocks)
            {
                foreach (var chessBlock in item)
                {
                    chessBlock.AttackedBy = new List<Figure>();
                }
            }

            for (int y = 0; y < this.AllFigures.Count; y++)
            {
                foreach (var item in this.AllFigures[y])
                {
                    item.SetAllPossitionPossibleToAttack(this);
                }
            }
        }

        public ChessBlock GetBlock(Point pos)
        {
            return this.GetBlock(pos.X, pos.Y);
        }
        public ChessBlock GetBlock(int x, int y)
        {
            if (this.IsPositionOutOfRange(x, y))
            {
                return null;
            }

            return this._ChessBlocks[y][x];
        }

        public Figure GetFigure(Point pos)
        {
            return this.GetFigure(pos.X, pos.Y);
        }
        public Figure GetFigure(int x, int y)
        {
            return this.GetBlock(x, y).Figure;
        }

        public bool IsObsticle(Point pos)
        {
            return this.IsObsticle(pos.X, pos.Y);
        }
        public bool IsObsticle(int x, int y)
        {
            ChessBlock cb = GetBlock(x, y);
            if (cb.IsObsticle == false)
            {
                return true;
            }

            return false;
        }

        public bool IsPositionOutOfRange(Point pos)
        {
            bool result = this.IsPositionOutOfRange(pos.X, pos.Y);
            return result;
        }
        public bool IsPositionOutOfRange(int x, int y)
        {
            if (this._ChessBlocks.Count <= y || this._ChessBlocks[0].Count <= x || x < 0 || y < 0)
            {
                return true;
            }

            return false;
        }

        public bool IsPosValid(Point pos)
        {
            return this.IsPosValid(pos.X, pos.Y);
        }
        public bool IsPosValid(int x, int y)
        {
            if (x < 0 || y< 0 || y >= this._ChessBlocks.Count || x >= this._ChessBlocks[0].Count)
            {
                return false; 
            }

            return true;
        }

        public int GetMaxX()
        {
            int result = this._ChessBlocks[0].Count;
            return result;
        }
        public int GetMaxY()
        {
            int result = this._ChessBlocks.Count;
            return result;
        }

        public void TagNewBlocks(List<ChessBlock> newTaggedBlocks)
        {
            UnTagBlocks();

            foreach (ChessBlock block in newTaggedBlocks)
            {
                block.Tag();
            }
            this.TaggedBlocks = newTaggedBlocks;
        }
        public void UnTagBlocks()
        {
            this._ActiveBlock = null;
            foreach (ChessBlock block in this.TaggedBlocks)
            {
                block.UnTag();
            }
        }

        public void MoveFigure(Move move)
        {
            Figure figToMove = this.GetBlock(move.From).Figure;
            if (figToMove != null)
            {
                this.RemoveFigure(this.GetBlock(move.To).Figure);
                this.GetBlock(move.From).RemoveFigureFromHere();
                figToMove.MoveFigure(move.To);
                this.GetBlock(move.To).Figure = figToMove;
            }
            else
            {
                Console.WriteLine("Fig to move is null");
            }
        }

        public void AddNewFigure(Figure figToAdd, Point pos)
        {
            this.AllFigures[figToAdd.Color].Add(figToAdd);
            this.GetBlock(pos).Figure = figToAdd;

            figToAdd.SetInitPos(pos);
        }
        public void DeleteFigure(Point pos)
        {
            Figure figToRemove = this.GetBlock(pos).Figure;

            if (figToRemove == null)
            {
                return;
            }

            this.AllFigures[figToRemove.Color].Remove(figToRemove);
            this.GetBlock(pos).Figure = null;
        }

        public byte GetNumberOfFigureColors()
        {
            return (byte)this.AllFigures.Count;
        }
        public List<Figure> GetAllFigure(byte ofColor)
        {
            return this.AllFigures[ofColor];
        }

        public void RemoveFigure(Figure toRemove)
        {
            if (toRemove != null)
            {
                this.DeleteFigure(toRemove.GetPosition());
            }
        }

        public void TurnEnded()
        {
            this.CalcAllAttackingBlocks();
        }

        /// <summary>
        /// the attack Calculations are not in here cuz there is going to be a stack overflow
        /// </summary>
        /// <returns></returns>
        public Board GetCopy()
        {
            int x = this.GetMaxX();
            int y = this.GetMaxY();
            Board result = new Board(x, y, this.GetNumberOfFigureColors(), this._SkinPack);

            for (int Y = 0; Y < y; Y++)
            {
                for (int X = 0; X < x; X++)
                {
                    Point pos = new Point(X, Y);
                    Figure fig = this.GetFigure(pos);
                    if (fig == null)
                    {
                        continue;
                    }

                    Figure newFig = fig.GetCopy();
                    result.AddNewFigure(newFig, pos);
                }
            }

            result.MoveConditions = this.GetCopyConditions(this, result);

            return result;
        }

        public List<IBoardConditionMove> GetCopyConditions(Board oldBoard, Board newBoard)
        {
            List<IBoardConditionMove> newConds = new List<IBoardConditionMove>();

            foreach (var cond in this.MoveConditions)
            {

            }

            return newConds;
        }

        public bool IsSomethingAttackingThisPositionByEnemy(int colorOfFriendly, Point attackPos)
        {
            for (int i = 0; i < this.GetNumberOfFigureColors(); i++)
            {
                if (i == colorOfFriendly)
                {
                    continue;
                }

                List<Figure> figs = this.AllFigures[i];

                foreach (var fig in figs)
                {
                    if (fig.MovementStrategy.CanAttackWithOutCondType(fig, this, new Move(fig.GetPosition(), attackPos), typeof(Condition)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsMoveConditionKept(Move move)
        {
            foreach (var cond in MoveConditions)
            {
                if (cond.IsFulFilled(move) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}