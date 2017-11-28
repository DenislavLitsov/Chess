namespace FrontEndEngine.Utility
{
    using Microsoft.Xna.Framework;
    using System;

    internal static class StaticVariables
    {
        internal static GraphicsDeviceManager GraphicsDeviceManager;

        public static Point ScreenPixelSize
        {
            get
            {
                Point result = new Point(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight);
                return result;
            }
            set
            {
                GraphicsDeviceManager.PreferredBackBufferWidth = value.X;
                GraphicsDeviceManager.PreferredBackBufferHeight = value.Y;
                GraphicsDeviceManager.ApplyChanges();
            }
        }

        public static Point Convert16by9ToCurrSize(Vector2 sizeInBase)
        {
            int xSize = (int)(sizeInBase.X * (ScreenPixelSize.X / 16));
            int ySize = (int)(sizeInBase.Y * (ScreenPixelSize.Y / 9));

            Point result = new Point(xSize, ySize);
            return result;
        }
    }
}
