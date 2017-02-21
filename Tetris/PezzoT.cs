﻿using System.Drawing;

namespace Tetris.Model
{
    class PezzoT : Pezzo
    {
        private const char nome = 'T';
        private int x, y;
        private int rotazione;
        private Image immT = Tetris.Properties.Resources.immT;

        public override Image Sprite
        {
            get
            {
                return immT;
            }
        }

        public PezzoT()
        {
            this.x = 3;
            this.y = 0;
            this.rotazione = 0;
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

        public override void Ruota()
        {
            // cicla tra 0-3 (4 possibili rotazioni)
            rotazione++;
            if (rotazione % 4 == 0)
                rotazione = 0;
            immT.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Modifica delle coordinate per far ruotare il pezzo centralmente
            switch (rotazione)
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
                        patt = pattern180;
                        break;
                    case 3:
                        patt = pattern270;
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
                    patt = pattern180;
                    break;
                case 3:
                    patt = pattern270;
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
                    break;
                case 1:
                    xSuccessiva++;
                    break;
                case 2:
                    xSuccessiva--;
                    break;
                case 3:
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
                    break;
                case 1:
                    break;
                case 2:
                    ySuccessiva++;
                    break;
                case 3:
                    ySuccessiva--;
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
