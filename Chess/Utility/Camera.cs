namespace FrontEndEngine.Utility
{
    using Microsoft.Xna.Framework;
    using System;

    internal class Camera
    {
        private Vector2 _Position;
        private Vector2 _NewPosOfCamera;

        private float _CurrUnitToPixels;
        private float _FutureUnitToPixels;

        public Camera()
        {
            this._CurrUnitToPixels = 64;
            this._FutureUnitToPixels = _CurrUnitToPixels;
            this.MovementSpeedInUnits = 0.10f;
            this.ZoomSpeed = 2f;
            this.TopLeftUnitPosition = new Vector2(0, 0);
            this._NewPosOfCamera = new Vector2(0, 0);
        }

        private float _UnitToPixels
        {
            get { return this._CurrUnitToPixels; }
            set { this._FutureUnitToPixels = value; }
        }
        public Vector2 TopLeftUnitPosition
        {
            get { return this._Position; }
            private set { this._NewPosOfCamera = value; }
        }
        public Vector2 BottomRightUnitPosition
        {
            get
            {
                Vector2 result = new Vector2(TopLeftUnitPosition.X, TopLeftUnitPosition.Y);
                result.X += (StaticVariables.ScreenPixelSize.X / this._UnitToPixels);
                result.Y += (StaticVariables.ScreenPixelSize.Y / this._UnitToPixels);

                return result;
            }
        }

        internal int GetPixels(object offSet)
        {
            throw new NotImplementedException();
        }

        public Vector2 GetCameraUnitSize()
        {
            float x = this.GetUnits(StaticVariables.ScreenPixelSize.X);
            float y = this.GetUnits(StaticVariables.ScreenPixelSize.Y);

            Vector2 result = new Vector2(x, y);
            return result;
        }

        public float MovementSpeedInUnits { get; set; }
        public float ZoomSpeed { get; set; }

        public int GetPixels(float units)
        {
            int result = (int)(units * this._UnitToPixels);
            return result;
        }
        public Point GetPixels(Vector2 units)
        {
            int x = this.GetPixels(units.X);
            int y = this.GetPixels(units.Y);
            Point result = new Point(x, y);
            return result;
        }

        public float GetUnits(int pixels)
        {
            float result = (float)pixels / this._UnitToPixels;
            return result;
        }
        public Vector2 GetUnits(Point pixels)
        {
            float x = this.GetUnits(pixels.X);
            float y = this.GetUnits(pixels.Y);
            Vector2 result = new Vector2(x, y);
            return result;
        }

        public void ZoomIn(Point pixelFocus)
        {
            Vector2 initMouseUnitPos = new Vector2(GetUnits(pixelFocus.X) + this.TopLeftUnitPosition.X, GetUnits(pixelFocus.Y) + this.TopLeftUnitPosition.Y);
            this._UnitToPixels += ZoomSpeed;
            float newUnitToPixel = this._UnitToPixels + ZoomSpeed;
            Vector2 newLenghtToTopLeftUnitPos = new Vector2((float)pixelFocus.X / newUnitToPixel, (float)pixelFocus.Y / newUnitToPixel);
            this.SetTopLeftUnitPositionTo(initMouseUnitPos - newLenghtToTopLeftUnitPos);
        }
        public void ZoomOut(Point pixelFocus)
        {
            Vector2 initMouseUnitPos = new Vector2(GetUnits(pixelFocus.X) + this.TopLeftUnitPosition.X, GetUnits(pixelFocus.Y) + this.TopLeftUnitPosition.Y);
            if (this._UnitToPixels - ZoomSpeed <= 0)
            {
                return;
            }
            this._UnitToPixels -= ZoomSpeed;
            float newUnitToPixel = this._UnitToPixels - ZoomSpeed;
            Vector2 newLenghtToTopLeftUnitPos = new Vector2((float)pixelFocus.X / newUnitToPixel, (float)pixelFocus.Y / newUnitToPixel);
            this.SetTopLeftUnitPositionTo(initMouseUnitPos - newLenghtToTopLeftUnitPos);
        }

        public void MoveUp()
        {
            float value = this.TopLeftUnitPosition.Y - this.MovementSpeedInUnits;
            this.TopLeftUnitPosition = new Vector2(TopLeftUnitPosition.X, value);
        }
        public void MoveDown()
        {
            float value = (float)((decimal)this.TopLeftUnitPosition.Y + (decimal)this.MovementSpeedInUnits);
            this.TopLeftUnitPosition = new Vector2(TopLeftUnitPosition.X, value);
        }
        public void MoveRight()
        {
            float value = (float)((decimal)(this.TopLeftUnitPosition.X) + (decimal)(this.MovementSpeedInUnits));
            this.TopLeftUnitPosition = new Vector2(value, TopLeftUnitPosition.Y);
        }
        public void MoveLeft()
        {
            float value = this.TopLeftUnitPosition.X - this.MovementSpeedInUnits;
            this.TopLeftUnitPosition = new Vector2(value, TopLeftUnitPosition.Y);
        }
        public void MoveUpLeft()
        {
            float upValue = this.TopLeftUnitPosition.Y - this.MovementSpeedInUnits;
            float leftValue = this.TopLeftUnitPosition.X - this.MovementSpeedInUnits;
            this.TopLeftUnitPosition = new Vector2(leftValue, upValue);
        }
        public void MoveUpRight()
        {
            float upValue = this.TopLeftUnitPosition.Y - this.MovementSpeedInUnits;
            float rightValue = (float)((decimal)(this.TopLeftUnitPosition.X) + (decimal)(this.MovementSpeedInUnits));
            this.TopLeftUnitPosition = new Vector2(rightValue, upValue);
        }
        public void MoveDownLeft()
        {
            float downValue = (float)((decimal)this.TopLeftUnitPosition.Y + (decimal)this.MovementSpeedInUnits);
            float leftValue = this.TopLeftUnitPosition.X - this.MovementSpeedInUnits;
            this.TopLeftUnitPosition = new Vector2(leftValue, downValue);
        }
        public void MoveDownRight()
        {
            float downValue = (float)((decimal)this.TopLeftUnitPosition.Y + (decimal)this.MovementSpeedInUnits);
            float rightValue = (float)((decimal)(this.TopLeftUnitPosition.X) + (decimal)(this.MovementSpeedInUnits));
            this.TopLeftUnitPosition = new Vector2(rightValue, downValue);
        }

        public void SetTopLeftUnitPositionTo(Vector2 topLeftUnitPos)
        {
            this.TopLeftUnitPosition = topLeftUnitPos;
        }
        public void SetCenterUnitPosTo(Vector2 center)
        {
            Vector2 cameraSize = this.GetCameraUnitSize();
            Vector2 newTopLeftPos = center - (cameraSize / 2f);

            this.SetTopLeftUnitPositionTo(newTopLeftPos);
        }

        public void Update()
        {
            this._Position = _NewPosOfCamera;
            this._CurrUnitToPixels = this._FutureUnitToPixels;
        }
    }
}