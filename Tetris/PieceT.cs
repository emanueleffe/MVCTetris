using System.Drawing;

namespace Tetris.Model
{
    class PieceT : Piece
    {
        private const char name = 'T';
        private int x, y;
        private int rotation;
        private Image immT = Tetris.Properties.Resources.immT;

        public override Image Sprite
        {
            get
            {
                return immT;
            }
        }

        public PieceT()
        {
            this.x = 3;
            this.y = 0;
            this.rotation = 0;
        }
        
        private int[,] pattern0 = new int[2, 3]
        {
            { 0, 6, 0 },
            { 6, 6, 6 }
        };

        private int[,] pattern90 = new int[3, 2]
        {
            { 6, 0 },
            { 6, 6 },
            { 6, 0 }
        };

        private int[,] pattern180 = new int[2, 3]
        {
            { 6, 6, 6 },
            { 0, 6, 0 }
        };

        private int[,] pattern270 = new int[3, 2]
        {
            { 0, 6 },
            { 6, 6 },
            { 0, 6 }
        };

        public override void Rotate()
        {
            // cicla tra 0-3 (4 possibili rotazioni)
            rotation++;
            if (rotation % 4 == 0)
                rotation = 0;
            immT.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Modifica delle coordinate per far ruotare il pezzo centralmente
            switch (rotation)
            {
                case 0:
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    x--;
                    y++;
                    break;
                case 3:
                    y--;
                    break;
            }
        }

        public override int Rotation
        {
            get
            {
                return rotation;
            }
        }

        public override int[,] Pattern
        {
            get
            {
                int[,] patt = null;

                switch (rotation)
                {
                    case 0:
                        patt = pattern0;
                        break;
                    case 1:
                        patt = pattern90;
                        break;
                    case 2:
                        patt = pattern180;
                        break;
                    case 3:
                        patt = pattern270;
                        break;
                }
                return patt;
            }
        }

        public override int[,] NextRotation(int desiredRotation)
        {
            int[,] patt = null;

            desiredRotation++;
            if (desiredRotation % 4 == 0)
                desiredRotation = 0;

            switch (desiredRotation)
            {
                case 0:
                    patt = pattern0;
                    break;
                case 1:
                    patt = pattern90;
                    break;
                case 2:
                    patt = pattern180;
                    break;
                case 3:
                    patt = pattern270;
                    break;
            }

            return patt;
        }

        public override int XNextRotation()
        {
            int xNext = this.x;
            int nextRotation = rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
                nextRotation = 0;

            switch (nextRotation)
            {
                case 0:
                    break;
                case 1:
                    xNext++;
                    break;
                case 2:
                    xNext--;
                    break;
                case 3:
                    break;
            }
            return xNext;
        }

        public override int YNextRotation()
        {
            int yNext = this.y;
            int nextRotation = rotation;

            nextRotation++;
            if (nextRotation % 4 == 0)
                nextRotation = 0;

            switch (nextRotation)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    yNext++;
                    break;
                case 3:
                    yNext--;
                    break;
            }
            return yNext;
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
