using System.Drawing;

namespace Tetris.Model
{
    public abstract class Piece
    {
        public abstract int[,] Pattern
        {
            get;
        }

        public abstract int Rotation
        {
            get;
        }

        public abstract char Name
        {
            get;
        }

        public abstract int X
        {
            get;
            set;
        }

        public abstract int Y
        {
            get;
            set;
        }

        public abstract Image Sprite
        {
            get;
        }

        public abstract int XNextRotation();

        public abstract int YNextRotation();

        public abstract int[,] NextRotation(int desiredRotation);

        public abstract void Rotate();
    }
}
