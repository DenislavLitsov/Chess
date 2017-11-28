namespace FrontEndEngine.Chess.Classes.MovementStrategies
{
    using System.Collections.Generic;

    using Common;
    using Strategies;
    using Board;
    using Figures;
    using System.Linq;
    using System;
    using Microsoft.Xna.Framework;
    using ConditionalMovements;

    public class FigureMovement
    {
        private List<Strategy> _Strategies;

        public FigureMovement(List<Strategy> strategies)
        {
            this._Strategies = strategies;
        }

        public bool CanMoveTo(Figure figToMove, Board board, Move move)
        {
            foreach (Strategy strat in this._Strategies)
            {
                if (strat.CanMoveTo(figToMove, board, move) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public bool CanAttack(Figure figToMove, Board board, Move move)
        {
            foreach (var item in this._Strategies)
            {
                if (item.CanAttack == false)
                {
                    continue;
                }

                if (item.CanMoveTo(figToMove, board, move))
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanAttackWithOutCondType(Figure figToMove, Board board, Move move, Type Cond)
        {
            for (int i = 0; i < this._Strategies.Count; i++)
            {
                Strategy item = this._Strategies[i];
            
                if (item.CanAttack == false)
                {
                    continue;
                }

                //ne vliza tuk
                bool isNullNotNull = item._Condition != null;
                if (isNullNotNull)
                {
                    Type condType = item._Condition.GetType();

                    bool IsTypeSame = condType == Cond;
                    bool isTypeSubClass = condType.IsSubclassOf(Cond);
                    
                    if (isTypeSubClass || IsTypeSame)
                    {
                        if (item.CanMoveWithOutCond(figToMove, board, move))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (item.CanMoveTo(figToMove, board, move))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (item.CanMoveTo(figToMove, board, move))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<Strategy> GetAllStrategiesMovingTo(Figure figToMove, Board board, Move move)
        {
            List<Strategy> strats = new List<Strategy>();

            foreach (var item in this._Strategies)
            {
                if (item.CanMoveTo(figToMove, board, move))
                {
                    strats.Add(item);
                }
            }

            return strats;
        }

        public void Move(Board board, Move move, int movementNumber, EngineFolder.Engine engine)
        {
            Figure fig = board.GetFigure(move.From);
            List <Strategy> strats = this.GetAllStrategiesMovingTo(fig, board, move);

            strats[movementNumber].Move(fig, board, move, engine);
        }

        public List<ChessBlock> GetAllPossibleToMoveToChessBlocks(Figure figToMove, Board board)
        {
            List<List<ChessBlock>> chessBlocks = new List<List<ChessBlock>>();

            foreach (var item in this._Strategies)
            {
                chessBlocks.Add(item.GetAllPossibleMovementPositions(figToMove, board));
            }

            List<ChessBlock> result = new List<ChessBlock>();

            for (int y = 0; y < chessBlocks.Count; y++)
            {
                for (int x = 0; x < chessBlocks[y].Count; x++)
                {
                    result.Add(chessBlocks[y][x]);
                }
            }

            return result;
        }

        public void SetAllPossibleBlocksToAttack(Figure figToMove, Board board)
        {
            foreach (var item in this._Strategies)
            {
                if (item.CanAttack == false)
                {
                    continue;
                }
                List<ChessBlock> allMoves = item.GetAllPossibleMovementPositions(figToMove, board);

                foreach (var block in allMoves)
                {
                    block.AttackedBy.Add(figToMove);
                }
            }
        }

        public void RevertMovement()
        {
            for (int i = 0; i < this._Strategies.Count; i++)
            {
                this._Strategies[i] = this._Strategies[i].GetOppositeStrategy();
            }
        }
    }
}
