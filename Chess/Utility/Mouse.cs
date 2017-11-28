namespace FrontEndEngine.Utility
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;

    internal class Mouse
    {
        public Mouse()
        {

        }

        public Point PixelPosition
        {
            get
            {
                MouseState state = Microsoft.Xna.Framework.Input.Mouse.GetState();
                Point position = new Point(state.X, state.Y);

                return position;
            }

            set
            {
                throw new NotImplementedException("dobavi tuk da smenq poziciqta");

            }
        }
    }
}