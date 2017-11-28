namespace FrontEndEngine.Chess.Classes.Figures.ModernFigures
{
    using System;
    using Microsoft.Xna.Framework;

    public class Tank : Figure
    {
        public Tank(byte color, int damage, int maxHealth, string name, string skinPack, Point position) : base(color, damage, maxHealth, name, skinPack, position)
        {
        }
    }
}
