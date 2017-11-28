namespace FrontEndEngine.Chess.Common
{
    using System;

    using Microsoft.Xna.Framework;

    public struct Move
    {
        private Point _From;

        public Move(Point from, Point to)
            : this()
        {
            this.From = from;
            this.To = to;
        }

        public Point From
        {
            get
            {
                return _From;
            }

            set
            {
                this._From = value;
            }
        }

        public Point To { get; private set; }

        public bool IsDirectionLeft()
        {
            if (this.From.X > this.To.X)
            {
                return true;
            }

            return false;
        }

        public bool isDirectionUp()
        {
            if (this.From.Y > this.To.Y)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// will return 1 0 -1
        /// </summary>
        /// <returns></returns>
        public int GetXDir()
        {
            int result = -(this.From.X - this.To.X);

            if (result > 0)
            {
                result = 1;
            }
            else if (result < 0)
            {
                result = -1;
            }

            return result;
        }


        /// <summary>
        /// will return 1 0 -1
        /// </summary>
        /// <returns></returns>
        public int GetYDir()
        {
            int result = -(this.From.Y - this.To.Y);

            if (result > 0)
            {
                result = 1;
            }
            else if (result < 0)
            {
                result = -1;
            }

            return result;
        }

        public int GetXMovement()
        {
            int result = Math.Abs(this.From.X - this.To.X);
            return result;
        }
        public int GetYMovement()
        {
            int result = Math.Abs(this.From.Y - this.To.Y);
            return result;
        }
    }
}
