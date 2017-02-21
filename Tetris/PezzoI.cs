using System.Drawing;

namespace Tetris.Model
{
    class PezzoI : Pezzo
    {
        private const char nome = 'I';
        private int x, y;
        private int rotazione;
        private Image immI = Tetris.Properties.Resources.immI;

        public override Image Sprite
        {
            get
            {
                return immI;
            }
        }

        public PezzoI()
        {
            this.x = 4;
            this.y = 0;
            this.rotazione = 0;
        }

        private int[,] pattern0 = new int[4, 1]
        {
            { 1 },
            { 1 },
            { 1 },
            { 1 }
        };

        private int[,] pattern90 = new int[1, 4]
        {
            { 1, 1, 1, 1 }
        };

        public override void Ruota()
        {
            // cicla tra 0-3 (4 possibili rotazioni)
            rotazione++;
            if (rotazione % 4 == 0)
                rotazione = 0;
            immI.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Modifica delle coordinate per far ruotare il pezzo centralmente
            switch(rotazione)
            {
                case 0:
                    y -= 2;
                    x++;
                    break;
                case 1:
                    y++;
                    x--;
                    break;
                case 2:
                    x += 2;
                    y--;
                    break;
                case 3:
                    x -= 2;
                    y += 2;
                break;
            }
        }

        public override int Rotazione
        {
            get
            {
                return rotazione;
            }
        }

        public override int[,] Pattern
        {
            get
            {
                int[,] patt = null;

                switch (rotazione)
                {
                    case 0:
                        patt = pattern0;
                        break;
                    case 1:
                        patt = pattern90;
                        break;
                    case 2:
                        patt = pattern0;
                        break;
                    case 3:
                        patt = pattern90;
                        break;
                }
                return patt;

            }
        }

        public override int[,] RotazioneSuccessiva(int rotazioneDaOttenere)
        {
            int[,] patt = null;

            rotazioneDaOttenere++;
            if (rotazioneDaOttenere % 4 == 0)
                rotazioneDaOttenere = 0;

            switch (rotazioneDaOttenere)
            {
                case 0:
                    patt = pattern0;
                    break;
                case 1:
                    patt = pattern90;
                    break;
                case 2:
                    patt = pattern0;
                    break;
                case 3:
                    patt = pattern90;
                    break;
            }

            return patt;
        }

        public override int xRotazioneSuccessiva()
        {
            int xSuccessiva = this.x;
            int rotazioneSuccessiva = rotazione;

            rotazioneSuccessiva++;
            if (rotazioneSuccessiva % 4 == 0)
                rotazioneSuccessiva = 0;

            switch (rotazioneSuccessiva)
            {
                case 0:
                    xSuccessiva++;
                    break;
                case 1:
                    xSuccessiva--;
                    break;
                case 2:
                    xSuccessiva += 2;
                    break;
                case 3:
                    xSuccessiva -= 2;
                    break;
            }
            return xSuccessiva;
        }

        public override int yRotazioneSuccessiva()
        {
            int ySuccessiva = this.y;
            int rotazioneSuccessiva = rotazione;

            rotazioneSuccessiva++;
            if (rotazioneSuccessiva % 4 == 0)
                rotazioneSuccessiva = 0;

            switch (rotazioneSuccessiva)
            {
                case 0:
                    ySuccessiva -= 2;
                    break;
                case 1:
                    ySuccessiva++;
                    break;
                case 2:
                    ySuccessiva--;
                    break;
                case 3:
                    ySuccessiva += 2;
                    break;
            }
            return ySuccessiva;
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
