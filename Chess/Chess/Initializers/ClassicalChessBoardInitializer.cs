namespace FrontEndEngine.Chess.Initializers
{
    using Classes.Board;
    using Classes.Figures;
    using Classes.Figures.ClassicFigures;
    using Classes.Board.TurnConditions;
    using Common;
    using Microsoft.Xna.Framework;
    using System;

    public class ClassicalChessBoardInitializer : IBoardIniter
    {
        private Board _Result;
        private readonly string SkinPack;

        private Figure _KingOne;
        private Figure _KingTwo;
        
        public ClassicalChessBoardInitializer(string skinPack)
        {
            this.SkinPack = skinPack;
        }

        public Board GetBoard()
        {
            this._Result = new Board(8, 8, 2, this.SkinPack);
            this.AddPawns();
            this.AddKings();
            this.AddQueens();
            this.AddBishops();
            this.AddKnights();
            this.AddRooks();

            this.AddBoardConditions(_Result);

            this._Result.CalcAllAttackingBlocks();
            return this._Result;
        }

        private void AddPawns()
        {
            Figure fig;
            for (int i = 0; i < 8; i++)
            {
                Point currPos = new Point(i, 1);

                fig = new Pawn(this._Result, 1, 1, 1, this.SkinPack, currPos);
                fig.MovementStrategy.RevertMovement();
                this._Result.AddNewFigure(fig, currPos);
            }
            for (int i = 0; i < 8; i++)
            {
                Point currPos = new Point(i, 6);

                fig = new Pawn(this._Result, 0, 1, 1, this.SkinPack, currPos);
                this._Result.AddNewFigure(fig, currPos);
            }
        }

        private void AddKings()
        {
            Figure fig;
            fig = new King(1, 1, 1, this.SkinPack, this._Result, new Point(4, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            this._KingOne = fig;

            fig = new King(0, 1, 1, this.SkinPack, this._Result, new Point(4, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            this._KingTwo = fig;
        }

        private void AddQueens()
        {
            Figure fig;
            fig = new Queen(1, 1, 1, this.SkinPack, new Point(3, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());

            fig = new Queen(0, 1, 1, this.SkinPack, new Point(3, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
        }

        private void AddBishops()
        {
            Figure fig;
            fig = new Bishop(1, 1, 1, this.SkinPack, new Point(2, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            fig = new Bishop(1, 1, 1, this.SkinPack, new Point(5, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());

            fig = new Bishop(0, 1, 1, this.SkinPack, new Point(2, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            fig = new Bishop(0, 1, 1, this.SkinPack, new Point(5, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
        }

        private void AddKnights()
        {
            Figure fig;
            fig = new Knight(1, 1, 1, this.SkinPack, new Point(1, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            fig = new Knight(1, 1, 1, this.SkinPack, new Point(6, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());

            fig = new Knight(0, 1, 1, this.SkinPack, new Point(1, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            fig = new Knight(0, 1, 1, this.SkinPack, new Point(6, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
        }

        private void AddRooks()
        {
            Figure fig;
            fig = new Rook(1, 1, 1, this.SkinPack, new Point(0, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            fig = new Rook(1, 1, 1, this.SkinPack, new Point(7, 0));
            this._Result.AddNewFigure(fig, fig.GetPosition());

            fig = new Rook(0, 1, 1, this.SkinPack, new Point(0, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
            fig = new Rook(0, 1, 1, this.SkinPack, new Point(7, 7));
            this._Result.AddNewFigure(fig, fig.GetPosition());
        }

        private void AddBoardConditions(Board board)
        {

        }
    }
}