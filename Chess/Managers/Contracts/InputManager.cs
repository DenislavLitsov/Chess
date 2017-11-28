namespace FrontEndEngine.Managers.Contracts
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework;
    using Utility;
    using System.Linq;

    internal delegate void MouseClick(Point mousePixelPos);
    internal delegate void MouseWheel(Point mousePixelPos);
    internal delegate void MovedMouse(Point newPos);
    internal delegate void MouseOnEdge();

    internal abstract class InputManager
    {
        internal event MouseWheel OnMouseWheelUp;
        internal event MouseWheel OnMouseWheelDown;

        internal event MouseClick OnLeftClickMouse;

        internal event MouseOnEdge MouseOnUpperEdge;
        internal event MouseOnEdge MouseOnLowerEdge;
        internal event MouseOnEdge MouseOnRightEdge;
        internal event MouseOnEdge MouseOnLeftEdge;
        internal event MouseOnEdge MouseOnTopLeftEdge;
        internal event MouseOnEdge MouseOnTopRightEdge;
        internal event MouseOnEdge MouseOnBottomLeftEdge;
        internal event MouseOnEdge MouseOnBottomRightEdge;

        //see method ManageMouseMovement
        //internal event MovedMouse OnMouseMoved;

        private ButtonState _LastLeftButtonState;

        private  Keys[] _CurrPressedKeys;
        private Keys[] _LastPressedKeys;

        private Keys[] _CurrReleasedKeys;
        private Keys[] _LastReleasedKeys;


        private Utility.Mouse _Mouse;

        private int _CurrMouseWheelValue;
        private int _LastMouseWheelValue;

        public InputManager()
        {
            this._LastLeftButtonState = ButtonState.Released;

            this._CurrPressedKeys = new Keys[0];
            this._LastPressedKeys = new Keys[0];

            this._CurrReleasedKeys = new Keys[0];
            this._LastReleasedKeys = new Keys[0];

            this._CurrMouseWheelValue = 0;
            this._LastMouseWheelValue = 0;

            this._Mouse = new Utility.Mouse();
        }

        public Keys[] CurrPressedKeys
        {
            get
            {
                return this._CurrPressedKeys;
            }
        }

        public Keys[] CurrReleasedKeys
        {
            get
            {
                return this._CurrReleasedKeys;
            }
        }

        public Keys[] LastReleasedKeys { get => _LastReleasedKeys; }

        public void Update()
        {
            this.ManageKeyboard();
            this.ManageMouse();
        }

        public Point GetMousePosition()
        {
            Point pos = Microsoft.Xna.Framework.Input.Mouse.GetState().Position;
            return pos;
        }

        private void ManageKeyboard()
        {
            this._LastPressedKeys = _CurrPressedKeys;
            this._CurrPressedKeys = Keyboard.GetState().GetPressedKeys();

            this._LastReleasedKeys = this.CurrReleasedKeys;

            List<Keys> keysClicked = new List<Keys>();
            foreach (var item in _LastPressedKeys)
            {
                if (!this._CurrPressedKeys.Contains(item))
                {
                    keysClicked.Add(item);
                }
            }

            this._CurrReleasedKeys = keysClicked.ToArray();
        }

        private void ManageMouse()
        {
            this._LastMouseWheelValue = _CurrMouseWheelValue;
            this._CurrMouseWheelValue = Microsoft.Xna.Framework.Input.Mouse.GetState().ScrollWheelValue;
            
            ManageWheelMovement();
            ManageMouseMovement();
            ManageMouseClick();
        }

        private void ManageWheelMovement()
        {
            if (this._CurrMouseWheelValue != this._LastMouseWheelValue)
            {
                if (this._CurrMouseWheelValue > this._LastMouseWheelValue)
                {
                    this.OnMouseWheelUp(this.GetMousePosition());
                }
                else
                {
                    this.OnMouseWheelDown(this.GetMousePosition());
                }
            }
        }

        private void ManageMouseMovement()
        {
            Point mousePos = this._Mouse.PixelPosition;

            if (mousePos.X <= 0 && mousePos.Y <= 0)
            {
                this.MouseOnTopLeftEdge.Invoke();
            }
            else if (mousePos.X >= StaticVariables.ScreenPixelSize.X && mousePos.Y <= 0)
            {
                this.MouseOnTopRightEdge();
            }
            else if (mousePos.X <= 0 && mousePos.Y >= StaticVariables.ScreenPixelSize.Y)
            {
                this.MouseOnBottomLeftEdge();
            }
            else if (mousePos.X >= StaticVariables.ScreenPixelSize.X && mousePos.Y >= StaticVariables.ScreenPixelSize.Y)
            {
                this.MouseOnBottomRightEdge();
            }
            else if(mousePos.X <= 0)
            {
                this.MouseOnLeftEdge.Invoke();
            }
            else if(mousePos.Y <= 0)
            {
                this.MouseOnUpperEdge.Invoke();
            }
            else if(mousePos.X >= StaticVariables.ScreenPixelSize.X)
            {
                this.MouseOnRightEdge.Invoke();
            }
            else if(mousePos.Y >= StaticVariables.ScreenPixelSize.Y)
            {
                this.MouseOnLowerEdge.Invoke();
            }
        }

        private void ManageMouseClick()
        {
            if (Microsoft.Xna.Framework.Input.Mouse.GetState().LeftButton == ButtonState.Pressed && this._LastLeftButtonState == ButtonState.Released)
            {
                this._LastLeftButtonState = ButtonState.Pressed;
                Point mousePos = this.GetMousePosition();
                this.OnLeftClickMouse.Invoke(mousePos);
            }
            else if (Microsoft.Xna.Framework.Input.Mouse.GetState().LeftButton == ButtonState.Released)
            {
                this._LastLeftButtonState = ButtonState.Released;
            }
        }
    }
}