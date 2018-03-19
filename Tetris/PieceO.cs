using System.Drawing;

namespace Tetris.Model
{
    class PieceO : Piece
    {
        private const char name = 'O';
        private int x, y;
        private int rotation;
        private Image immO = Tetris.Properties.Resources.immO;

        public override Image Sprite
        {
            get
            {
                return immO;
            }
        }

        public PieceO()
        {
            this.x = 4;
            this.y = 0;
            this.rotation = 0;
        }

        private int[,] pattern0 = new int[2, 2]
        {
            { 2, 2 },
            { 2, 2 }
        };

        public override void Rotate()
        {
            rotation = 0;
        }

        public override int Rotation
        {
            get
            {
                return rotation;
            }
        }

        public override int[,] NextRotation(int desiredRotation)
        {
            return pattern0;
        }

        public override int XNextRotation()
        {
            return this.x;
        }

        public override int YNextRotation()
        {
            return this.y;
        }


        public override int[,] Pattern
        {
            get
            {
                return pattern0;
            }
        }

        public override char Name
        {
            get
            {
                return name;
            }
        }

        public override int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public override int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
