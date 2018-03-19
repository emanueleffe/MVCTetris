using System;

namespace Tetris.Model
{
    class TetrisGrid
    {
        public const int gridColumns = 10;
        public const int gridRows = 16;
        private static int[,] grid = new int[gridRows, gridColumns];

        public TetrisGrid()
        {
            EmptyGrid();
        }

        public int[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public void EmptyGrid()
        {
            for (int i = 0; i < gridRows; i++)
                for (int j = 0; j < gridColumns; j++)
                    grid[i, j] = 0;
        }
    }
}
