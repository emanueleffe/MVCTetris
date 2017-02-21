using System.Drawing;

namespace Tetris.Model
{
    class PezzoO : Pezzo
    {
        private const char nome = 'O';
        private int x, y;
        private int rotazione;
        private Image immO = Tetris.Properties.Resources.immO;

        public override Image Sprite
        {
            get
            {
                return immO;
            }
        }

        public PezzoO()
        {
            this.x = 4;
            this.y = 0;
            this.rotazione = 0;
        }

        private int[,] pattern0 = new int[2, 2]
        {
            { 2, 2 },
            { 2, 2 }
        };

        public override void Ruota()
        {
            rotazione = 0;
        }

        public override int Rotazione
        {
            get
            {
                return rotazione;
            }
        }

        public override int[,] RotazioneSuccessiva(int rotazioneDaOttenere)
        {
            return pattern0;
        }

        public override int xRotazioneSuccessiva()
        {
            int xSuccessiva = this.x;
            
            return xSuccessiva;
        }

        public override int yRotazioneSuccessiva()
        {
            int ySuccessiva = this.y;
            
            return ySuccessiva;
        }


        public override int[,] Pattern
        {
            get
            {
                return pattern0;
            }
        }

        public override char Nome
        {
            get
            {
                return nome;
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
