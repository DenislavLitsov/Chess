namespace FrontEndEngine.Managers.HUD.Common
{
    using System;
    using Microsoft.Xna.Framework;
    using FrontEndEngine.Managers.Contracts;
    using Microsoft.Xna.Framework.Input;

    class TextInput : HUDItem
    {
        protected readonly Point _PIXEL_POS;
        protected readonly Point _PIXEL_SIZE;

        private bool _IsActive;
        private string _Text;

        private InputManager _InputManager;

        public TextInput(InputManager im, Point pixelPos, Point pixelSize, HUDItem parentHudItem) : base(parentHudItem)
        {
            this._InputManager = im;

            this._PIXEL_POS = pixelPos;
            this._PIXEL_SIZE = pixelSize;

            this._IsActive = false;
            this._Text = "";
        }

        public string Text { get => _Text; }

        public override string GetFrameName()
        {
            return @"Game\HUDItems\Common\Square";
        }

        public override Point GetPixelPosition()
        {
            return this._PIXEL_POS;
        }

        public override Point GetPixelSize()
        {
            return this._PIXEL_SIZE;
        }

        public override void OnMouseClick(Point clickPos)
        {
            this._IsActive = true;
        }

        public override void OnMouseOver()
        {
        }

        public override void Draw()
        {
            base.Draw();

            Keys[] releasedKeys = this._InputManager.CurrReleasedKeys;
            if (this._IsActive)
            {
                foreach (var item in releasedKeys)
                {
                    if (item == Keys.Back)
                    {
                        this._Text = this._Text.Remove(this._Text.Length - 1);
                    }
                    else
                    {
                        string itemName = item.ToString();
                        this._Text += itemName[itemName.Length - 1];
                    }
                }
            }

            _SpriteBatch.DrawString(_AssetManager.GetFont(@"Game\Fonts\Normal"), this.Text, new Vector2(this.GetPixelPosition().X, this.GetPixelPosition().Y), Color.Black);
        }

        internal override void TurnVisibilityOff()
        {
            this._IsActive = false;
            base.TurnVisibilityOff();
        }
    }
}
