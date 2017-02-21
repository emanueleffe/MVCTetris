using System.Drawing;

namespace Tetris.Model
{
    public abstract class Pezzo
    {
        public abstract int[,] Pattern
        {
            get;
        }

        public abstract int Rotazione
        {
            get;
        }

        public abstract char Nome
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

        public abstract int xRotazioneSuccessiva();

        public abstract int yRotazioneSuccessiva();

        public abstract int[,] RotazioneSuccessiva(int rotazioneDaOttenere);

        public abstract void Ruota();
    }
}
