namespace FrontEndEngine.Chess.Classes.Players
{
    using System.Collections.Generic;

    public class Player
    {
        private Dictionary<string, int> _LostUnits;
        private Dictionary<string, int> _KilledUnits;

        private int _MovesMade;

        public Player(byte color)
        {
            this.Color = color;
            this._LostUnits = new Dictionary<string, int>();
            this._KilledUnits = new Dictionary<string, int>();
        }

        public byte Color { get; private set; }

        public int MovesMade
        {
            get
            {
                return _MovesMade;
            }

            set
            {
                this._MovesMade = value;
            }
        }

        public void AddLostUnit(string name)
        {
            if (this._LostUnits.ContainsKey(name))
            {
                this._LostUnits[name]++;
            }
            else
            {
                this._LostUnits.Add(name, 1);
            }
        }
        public void AddKilledUnits(string name)
        {
            if (this._KilledUnits.ContainsKey(name))
            {
                this._KilledUnits[name]++;
            }
            else
            {
                this._KilledUnits.Add(name, 1);
            }
        }

        public void Moved()
        {
            this.MovesMade++;
        }
    }
}
