using System;

namespace Tetris.Model
{
    class GrigliaTetris
    {
        public const int colonneGriglia = 10;
        public const int righeGriglia = 16;
        private static int[,] griglia = new int[righeGriglia, colonneGriglia];

        public GrigliaTetris()
        {
            SvuotaGriglia();
        }

        public int[,] Griglia
        {
            get { return griglia; }
            set { griglia = value; }
        }

        public void SvuotaGriglia()
        {
            for (int i = 0; i < righeGriglia; i++)
                for (int j = 0; j < colonneGriglia; j++)
                    griglia[i, j] = 0;
        }
    }
}
