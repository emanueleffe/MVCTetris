using System;

namespace Tetris.Model
{
    class ProviderPezzi
    {
        private Random rnd = new Random();

        public Pezzo EstraiPezzo()
        {
            Pezzo pezzoAttuale = null;

            switch (rnd.Next(0, 7))
            {
                case 0:
                    pezzoAttuale = new PezzoT();
                    break;
                case 1:
                    pezzoAttuale = new PezzoO();
                    break;
                case 2:
                    pezzoAttuale = new PezzoI();
                    break;
                case 3:
                    pezzoAttuale = new PezzoS();
                    break;
                case 4:
                    pezzoAttuale = new PezzoJ();
                    break;
                case 5:
                    pezzoAttuale = new PezzoL();
                    break;
                case 6:
                    pezzoAttuale = new PezzoZ();
                    break;
            }

            return pezzoAttuale;
        }
    }
}
