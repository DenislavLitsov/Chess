namespace FrontEndEngine.Chess.Common
{
    using Microsoft.Xna.Framework;

    public abstract class GameObject
    {
        private Vector2 _OffSet;
        private Point _Position;
        private float _Layer;
        private float _Rotation;
        private string _SkinName;

        public GameObject()
        {
            this._OffSet = new Vector2(1, 1);
        }

        public GameObject(float layer) :
            base()
        {
            this.Layer = layer;
        }

        public GameObject(string skinName) :
            base()
        {
            this._SkinName = skinName;
            this.Layer = 1;
        }

        protected void SetSkinName(string name)
        {
            this._SkinName = name;
        }

        public Vector2 OffSet
        {
            get { return this._OffSet; }
            set { this._OffSet = value; }
        }

        public float Layer
        {
            get => _Layer;
            private set
            {
                if (value > 1 || value < 0)
                {
                    throw new System.Exception("Wtf it's not in range: " + value);
                }
                _Layer = value;
            }
        }
        public float Rotation { get => _Rotation; set => _Rotation = value; }
        public Point Position { get => _Position; set => _Position = value; }

        public string GetSkinName()
        {
            return this._SkinName;
        }
    }
}
