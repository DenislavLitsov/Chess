namespace FrontEndEngine.Chess.Initializers
{
    using System;
    using System.IO;

    using FrontEndEngine.Chess.Classes.Board;
    //using Chess.Classes.Figures.WW2Figures;
    using FrontEndEngine.Chess.Classes.Figures;
    using FrontEndEngine.Chess.Classes.Figures.WW2Figures;

    class WW2FromFileInitializer : IBoardIniter
    {
        private StreamReader _FileReader;

        public WW2FromFileInitializer()
        {
            this._FileReader = new StreamReader(@"Map.txt");
        }

        public Board GetBoard()
        {
            Board board = this.InitBoardSettings();
            this.InitBoardUnits(board);

            _FileReader.Close();
            _FileReader.Dispose();
            return board;
        }

        private Board InitBoardSettings()
        {
            int width = int.Parse(_FileReader.ReadLine());
            int height = int.Parse(_FileReader.ReadLine());
            int people = int.Parse(_FileReader.ReadLine()) + 1;
            string skinPack = "WW2";

            Board result = new Board(width, height, (byte)people, skinPack);
            return result;
        }

        private void InitBoardUnits(Board board)
        {
            for (int y = 0; y < board.GetMaxY(); y++)
            {
                int maxX = board.GetMaxX();
                int currXPos = 0;
                string line = _FileReader.ReadLine();

                for (int x = 0; x < maxX; x++)
                {
                    if (line[x] != '#')
                    {
                        if (line[x] == '(')
                        {
                            int endingX = this.getEndingOfName(line, x);

                            string figureName = line.Substring(x + 1, endingX - x - 1);
                            
                            board.AddNewFigure(this.GetFigure(figureName), new Microsoft.Xna.Framework.Point(currXPos, y));

                            maxX += endingX - x;
                            x += endingX - x;
                        }
                        else
                        {
                            throw new Exception("maxX-a se preeba nqkyde ne se dobavq ili maha kato horata");
                        }
                    }

                    currXPos++;
                }
            }
        }

        private int getEndingOfName(string str, int currX)
        {
            for (int x = currX; x < str.Length; x++)
            {
                if (str[x] == ')')
                {
                    return x;
                }
            }

            throw new Exception("No ) found");
        }

        private Figure GetFigure(string fig)
        {
            string[] str = fig.Split(',');
            Figure result;
        
            switch (str[0])
            {
                case "Tiger":
                    result = new Tiger(byte.Parse(str[1]));
                    break;
                case "Durchsbruchwagen":
                    result = new Durchsbruchwagen(byte.Parse(str[1]));
                    break;
                case "FW":
                    result = new FW(byte.Parse(str[1]));
                    break;
                case "Hellcat":
                    result = new Hellcat(byte.Parse(str[1]));
                    break;
                case "Messerschmitt":
                    result = new Messerschmitt(byte.Parse(str[1]));
                    break;
                case "Panther":
                    result = new Panther(byte.Parse(str[1]));
                    break;
                case "Spitfire":
                    result = new Spitfire(byte.Parse(str[1]));
                    break;
                case "T-34":
                    result = new T_34(byte.Parse(str[1]));
                    break;
                case "Warhalk":
                    result = new Warhalk(byte.Parse(str[1]));
                    break;
                case "Wildcat":
                    result = new Wildcat(byte.Parse(str[1]));
                    break;
                case "Yak 9k":
                    result = new Yak_9k(byte.Parse(str[1]));
                    break;
                case "Water":
                    result = new Water(byte.Parse(str[1]));
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
