namespace FrontEndEngine.Chess.Classes.Figures.MoveEvents
{
    using Figures;

    public abstract class MoveEvent
    {
        protected readonly Figure _Figure;

        public MoveEvent(Figure figure)
        {
            this._Figure = figure;
        }

        public abstract void OnTurnEnd();
    }
}
