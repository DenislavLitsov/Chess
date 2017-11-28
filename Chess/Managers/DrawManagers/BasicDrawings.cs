namespace FrontEndEngine.Managers.DrawManagers
{
    using FrontEndEngine.Managers.Assets.Contacts;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal static class BasicDrawings
    {
        private static AssetManager _AssetManager;
        private static SpriteBatch _SpriteBatch;

        private static string _VerticalLineName = @"Game\Utility\VerticalLine";
        private static string _HorizontalLineName = @"Game\Utility\HorizontalLine";

        public static void SetAssetManager(AssetManager am)
        {
            _AssetManager = am;
        }
        public static void SetSpriteBatch(SpriteBatch sp)
        {
            _SpriteBatch = sp;
        }

        public static void DrawRectangle(Point startingPos, Point endingPos, int lineThickness)
        {
            int horizontalLineLength = endingPos.X - startingPos.X;
            int verticalLineLength = endingPos.Y - startingPos.Y;

            // DrawHorizontalLines
            Texture2D horizontalLine = _AssetManager.GetTexture(_HorizontalLineName);
            _SpriteBatch.Draw(horizontalLine, new Rectangle(startingPos.X, startingPos.Y, horizontalLineLength, lineThickness), Color.White);
            _SpriteBatch.Draw(horizontalLine, new Rectangle(startingPos.X, endingPos.Y, horizontalLineLength, lineThickness), Color.White);

            // DrawVerticalLines
            Texture2D verticalLine = _AssetManager.GetTexture(_VerticalLineName);
            _SpriteBatch.Draw(verticalLine, new Rectangle(startingPos.X, startingPos.Y, lineThickness, verticalLineLength), Color.White);
            _SpriteBatch.Draw(verticalLine, new Rectangle(endingPos.X, startingPos.Y, lineThickness, verticalLineLength), Color.White);
        }
    }
}
