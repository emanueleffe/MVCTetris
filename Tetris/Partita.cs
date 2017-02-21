using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tetris.Model
{
    class Partita
    {
        // Riferimenti agli oggetti
        private GrigliaTetris g = new GrigliaTetris();
        private ProviderPezzi provider = new ProviderPezzi();
        private Pezzo pezzoAttuale, pezzoSuccessivo;
        // variabili funzionali
        private bool inGioco = false;
        private int punteggio;
        private int difficolta;
        public List<Classifica> punteggi = new List<Classifica>();


        // Costruttore della classe, inizializza la partita non appena viene creato
        public Partita()
        {
            InizializzaPartita();
        }

        // metodo per poter verificare e/o settare quando la partita è in corso
        public bool InGioco
        {
            get
            {
                return inGioco;
            }
            set
            {
                inGioco = value;
            }
        }

        // Inizializzazione (o reinizializzazione) della partita
        public void InizializzaPartita()
        {
            pezzoAttuale = null;
            pezzoSuccessivo = null;
            g.SvuotaGriglia();
            inGioco = true;
            Punteggio = 0;
            Difficolta = 1;
            EstraiPezzi();
            if (!File.Exists("classifica.xml"))
                CreaFileClassifica();
            CaricaPunteggi();
        }

        public void CreaFileClassifica()
        {
            XmlSerializer writer = new XmlSerializer(punteggi.GetType(), "Tetris.Model");
            FileStream file = File.Create("classifica.xml");

            writer.Serialize(file, punteggi);
            file.Close();
        }

        private void CaricaPunteggi()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(punteggi.GetType(), "Tetris.Model");
                object obj;
                using (StreamReader reader = new StreamReader("classifica.xml"))
                {
                    obj = serializer.Deserialize(reader.BaseStream);
                    reader.Close();
                }
                punteggi = (List<Classifica>)obj;
            }
            catch(InvalidOperationException)
            {
                CreaFileClassifica();
                CaricaPunteggi();
            }            
        }

        public void SalvaPunteggio(string nome, int punti)
        {
            var punteggio = new Classifica()
            {
                Punteggio = punti,
                Nome = nome
            };

            punteggi.Add(punteggio);

            try
            {
                XmlSerializer writer = new XmlSerializer(punteggi.GetType(), "Tetris.Model");

                FileStream file = File.Create("classifica.xml");

                writer.Serialize(file, punteggi);
                file.Close();
            }
            catch (UnauthorizedAccessException)
            {
                System.Windows.Forms.MessageBox.Show("Impossibile scrivere sul file 'Classifica.xml'.\nProbabilmente è in sola lettura\n");
            }
            catch(IOException)
            {
                System.Windows.Forms.MessageBox.Show("Impossibile salvare il file 'Classifica.xml'.\nProbabilmente il disco è pieno.");
            }
            
        }

        // Metodo per ottenere il pezzo estratto
        public Pezzo PezzoAttuale
        {
            get
            {
                return pezzoAttuale;
            }
        }

        // Metodo per ottenere il pezzo successivo estratto
        public Pezzo PezzoSuccessivo
        {
            get
            {
                return pezzoSuccessivo;
            }
        }

        // Metodo per terminare la partita
        private void TerminaPartita()
        {
            InGioco = false;
        }

        // Metodo per l'estrazione dei pezzi
        public void EstraiPezzi()
        {
            // se è il primo avvio vanno estratti entrambi i pezzi
            if (pezzoAttuale == null && pezzoSuccessivo == null)
            {

                    pezzoAttuale = provider.EstraiPezzo();
                    pezzoSuccessivo = provider.EstraiPezzo();
            }
            // se non è il primo avvio si assegna al pezzo attuale quello 
            // estratto precedentemente e per quello successivo se ne estrae uno nuovo 
            else
            {
                pezzoAttuale = pezzoSuccessivo;
                pezzoSuccessivo = provider.EstraiPezzo();
            }
        }

        // Metodo che restituisce il numero di righe del pezzo attuale
        private int RighePezzoAttuale
        {
            get
            {
                return pezzoAttuale.Pattern.GetLength(0);
            }
        }

        // Metodo che restituisce il numero di colonne del pezzo attuale
        private int ColonnePezzoAttuale
        {
            get
            {
                return pezzoAttuale.Pattern.GetLength(1);
            }
        }

        // Metodo per verificare se un movimento può essere effettuato
        private bool PuoMuovere(int x, int y)
        {
            bool puoMuovere = true;

            // Verifico se il pezzo, alle coordinate passate, può starci
            for (int i = y, riga = 0; i < (y + RighePezzoAttuale); i++, riga++)
                for (int j = x, colonna = 0; j < (x + ColonnePezzoAttuale); j++, colonna++)
                    if ((g.Griglia[i, j] != 0) && (pezzoAttuale.Pattern[riga, colonna] != 0))
                        puoMuovere = false;

            return puoMuovere;
        }

        // Metodo per "fissare" il pezzo alla griglia sottostante
        private void FissaPezzo()
        {
            for (int i = pezzoAttuale.Y, rigaPezzo = 0; i < (pezzoAttuale.Y + RighePezzoAttuale); i++, rigaPezzo++)
                for (int j = pezzoAttuale.X, colonnaPezzo = 0; (j < (pezzoAttuale.X + ColonnePezzoAttuale)); j++, colonnaPezzo++)
                    if (pezzoAttuale.Pattern[rigaPezzo, colonnaPezzo] != 0)
                        g.Griglia[i, j] = pezzoAttuale.Pattern[rigaPezzo, colonnaPezzo];
        }

        // Metodo per la rotazione del pezzo
        private bool PuoRuotare()
        {
            bool puoRuotare = true;

            // acquisisco una matrice temporanea della rotazione successiva all'attuale
            int[,] rotazioneTemp = pezzoAttuale.RotazioneSuccessiva(pezzoAttuale.Rotazione);
            // acquisisco le nuove x e y per la rotazione
            int xSuccessiva = pezzoAttuale.xRotazioneSuccessiva(), 
                ySuccessiva = pezzoAttuale.yRotazioneSuccessiva();
            // Verifico se la rotazione successiva esce fuori dalla griglia
            if ((ySuccessiva + rotazioneTemp.GetLength(0)) > g.Griglia.GetLength(0))
                puoRuotare = false;
            if ((xSuccessiva + rotazioneTemp.GetLength(1)) > g.Griglia.GetLength(1))
                puoRuotare = false;
            if (xSuccessiva < 0)
                puoRuotare = false;

            int i, j;
            if (puoRuotare)
                for (i = ySuccessiva; (i < (ySuccessiva + rotazioneTemp.GetLength(0))); i++)
                    for (j = xSuccessiva; (j < (xSuccessiva + rotazioneTemp.GetLength(1))); j++)
                        if (g.Griglia[i, j] != 0)
                            puoRuotare = false;

            return puoRuotare;
        }

        // Metodo per spostare il pezzo a sinistra, invocato dal Controller
        public void SpostaASinistra()
        {
            // Controllo che il pezzo non sia già al bordo sinistro
            if (pezzoAttuale.X != 0)
            {
                // Controllo che il pezzo possa muoversi con il metodo PuoMuovere()
                // passandogli la coordinata x decrementata e la y inalterata
                if (PuoMuovere(pezzoAttuale.X - 1, pezzoAttuale.Y))
                {
                    // Decremento il valore di X, poiché il metodo PuoMuovere ha
                    // dato come esito True
                    pezzoAttuale.X--;
                }
            }
        }

        // Metodo per spostare il pezzo a destra, invocato dal Controller
        public void SpostaADestra()
        {
            // Controllo che il pezzo non sia già al bordo destro
            if ((pezzoAttuale.X + ColonnePezzoAttuale) < g.Griglia.GetLength(1))
            {
                // Controllo che il pezzo possa muoversi con il metodo PuoMuovere()
                // passandogli la coordinata x incrementata e la y inalterata
                if (PuoMuovere(pezzoAttuale.X + 1, pezzoAttuale.Y))
                {
                    // Incremento il valore di X, poiché il metodo PuoMuovere ha
                    // dato come esito True.
                    pezzoAttuale.X++;
                }
            }
        }

        // Metodo per spostare il pezzo in basso, invocato dal Controller
        public bool SpostaInBasso()
        {
            bool pezzoFissato = false;

            // Controllo che la partita sia ancora in gioco
            if ((g.Griglia[0, 4] != 0) || (g.Griglia[0, 3] != 0))
                TerminaPartita();
            else
            {
                // Controllo che il pezzo non sia già al bordo inferiore
                if (((pezzoAttuale.Y + RighePezzoAttuale) < g.Griglia.GetLength(0)) && 
                    (PuoMuovere(pezzoAttuale.X, pezzoAttuale.Y + 1)))
                    pezzoAttuale.Y++;
                else
                {
                    // Il pezzo non può più muoversi, deve essere "fissato" alla
                    // griglia sottostante e verificare che non si sia formata
                    // una linea completa, ed in tal caso rimuoverla
                    FissaPezzo();
                    pezzoFissato = true;
                    VerificaLineaCompleta();
                }
            }

            return pezzoFissato;
        }

        // Metodo per ruotare il pezzo, invocato dal Controller
        public bool RuotaPezzo()
        {
            bool val = false;

            if (PuoRuotare())
            {
                pezzoAttuale.Ruota();
                val = true;
            }

            return val;
        }

        private bool VerificaLineaCompleta()
        {
            bool lineaCompleta = true;

            for (int i = 0; i < g.Griglia.GetLength(0); i++)
            {
                lineaCompleta = true;

                // Si verifica se c'è almeno un elemento == 0, se c'è la linea non è completa
                // e l'if seguente verrà saltato. Si prosegue alla linea successiva (se c'è)
                for (int j = 0; (j < g.Griglia.GetLength(1)) && (lineaCompleta == true); j++)
                    if (g.Griglia[i, j] == 0)
                        lineaCompleta = false;
                if (lineaCompleta)
                {
                    // Acquisisco la riga completa (i) e copio su di essa tutti gli elementi
                    // della riga sopra, faccio lo stesso fino ad arrivare alla riga 0
                    // dove viene settata a 0 poiché tutto è sceso di una riga
                    for (int k = i; k > 0; k--)
                        for (int j = 0; j < g.Griglia.GetLength(1); j++)
                            g.Griglia[k, j] = g.Griglia[k - 1, j];
                    //setto a 0 la riga 0
                    for (int j = 0; j < g.Griglia.GetLength(1); j++)
                        g.Griglia[0, j] = 0;

                    // Per ogni linea completata si incrementa il punteggio di 10
                    Punteggio += 10;

                    // Ogni 100 punti (10 righe completate) la difficoltà aumenta
                    if (Punteggio % 100 == 0)
                        Difficolta++;
                }
                
            }

            return lineaCompleta;
        }

        public int Difficolta
        {
            get
            {
                return difficolta;
            }
            private set
            {
                difficolta = value;
            }
        }

        public int Punteggio
        {
            get
            {
                return punteggio;
            }
            private set
            {
                punteggio = value;
            }
        }

        public GrigliaTetris GrigliaP
        {
            get
            {
                return g;
            }
        }
    }
}
