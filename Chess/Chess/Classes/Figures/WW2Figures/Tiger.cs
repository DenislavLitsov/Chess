namespace FrontEndEngine.Chess.Classes.Figures.WW2Figures
{
    using System.Collections.Generic;
    
    using FrontEndEngine.Chess.Classes.MovementStrategies;
    using FrontEndEngine.Chess.Classes.MovementStrategies.Strategies;

    class Tiger : WW2Figure
    {
        public Tiger(byte color) : base(color, 1, 1, "Tiger")
        {
        }
    }
}