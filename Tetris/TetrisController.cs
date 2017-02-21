using System.Drawing;
using System.Windows.Forms;

using Tetris.View;
using Tetris.Model;

namespace Tetris.Controller
{
    class TetrisController
    {
        // Riferimenti agli oggetti
        private Partita partita;
        private Tetris_Form tView;
        private Punteggio_Nome puntForm;
        private Form_Classifica classificaForm;
        // Variabili di disegno
        private Graphics g;
        private SolidBrush brush = new SolidBrush(Color.DarkSlateGray);
        private Rectangle sidebar = new Rectangle(250, 0, 125, 400);
        private Rectangle contenitorePezzo;
        // Immagini 25x25px per visualizzare i pezzi già fissati
        private Image immI_25 = Tetris.Properties.Resources.immI_25;
        private Image immJ_25 = Tetris.Properties.Resources.immJ_25;
        private Image immL_25 = Tetris.Properties.Resources.immL_25;
        private Image immO_25 = Tetris.Properties.Resources.immO_25;
        private Image immS_25 = Tetris.Properties.Resources.immS_25;
        private Image immT_25 = Tetris.Properties.Resources.immT_25;
        private Image immZ_25 = Tetris.Properties.Resources.immZ_25;
        // Variabili funzionali
        private bool pezzoFissato = false;
        private int difficolta;
        // Costanti
        private const int dimensioneBlocco = 25;

        public TetrisController()
        {
            this.tView = new Tetris_Form();
            this.tView.KeyDown += new KeyEventHandler(Tetris_Form_KeyDown);
            this.tView.Paint += new PaintEventHandler(Tetris_Form_Disegna);
            this.tView.t.Tick += new System.EventHandler(Tetris_Form_Tick);
            this.tView.bMostraClassifica.Click += new System.EventHandler(Tetris_Form_MostraClassifica);
            this.tView.bPausaRiprendi.Click += new System.EventHandler(Tetris_Form_PausaRiprendi);
            this.puntForm = new Punteggio_Nome();
        }

        public void IniziaPartita()
        {
            // Inizializzazione oggetto Partita e avvio del form
            this.partita = new Partita();
            this.tView.ShowDialog();
            this.difficolta = this.partita.Difficolta;
        }

        private void Tetris_Form_KeyDown(object sender, KeyEventArgs e)
        {
            // Gestione dell'evento KeyDown
            switch (e.KeyData)
            {
                // Per ogni pulsante eseguo il movimento ed aggiorno
                // la posizione del pezzo dov'è situato
                // e quella successiva
                case Keys.Up:
                    partita.RuotaPezzo();
                    tView.Invalidate(new Rectangle(partita.PezzoAttuale.X * dimensioneBlocco,
                                                   partita.PezzoAttuale.Y * dimensioneBlocco,
                                                   partita.PezzoAttuale.Sprite.Width,
                                                   partita.PezzoAttuale.Sprite.Height));
                    tView.Invalidate(contenitorePezzo);
                    tView.Update();
                    break;
                case Keys.Down:
                    SpostaInBasso();
                    break;
                case Keys.Left:
                    partita.SpostaASinistra();
                    tView.Invalidate(contenitorePezzo);
                    contenitorePezzo.X -= dimensioneBlocco;
                    tView.Invalidate(contenitorePezzo);
                    tView.Update();
                    break;
                case Keys.Right:
                    partita.SpostaADestra();
                    tView.Invalidate(contenitorePezzo);
                    contenitorePezzo.X += dimensioneBlocco;
                    tView.Invalidate(contenitorePezzo);
                    tView.Update();
                    break;
            }
        }

        // Gestione dell'evento Tick: il pezzo viene spostato in basso
        private void Tetris_Form_Tick(object sender, System.EventArgs e)
        {
            SpostaInBasso();
        }

        private void Tetris_Form_MostraClassifica(object sender, System.EventArgs e)
        {
            PausaGioco();
            classificaForm = new Form_Classifica(partita.punteggi);
            classificaForm.ShowDialog();
            RiprendiGioco();
        }

        // Metodo per mettere in pausa il gioco
        private void PausaGioco()
        {
            tView.t.Enabled = false;
            this.tView.KeyDown -= new KeyEventHandler(Tetris_Form_KeyDown);
        }

        // Metodo per riprendere il gioco dalla pausa
        private void RiprendiGioco()
        {
            this.tView.KeyDown += new KeyEventHandler(Tetris_Form_KeyDown);
            tView.t.Enabled = true;
        }

        // Metodo per fare lo switch tra pausa e ripresa del gioco
        private void PausaRiprendiGioco()
        {
            if (tView.t.Enabled == true)
                PausaGioco();
            else
                RiprendiGioco();
        }

        // Metodo che gestisce l'evento click del form sulla label bPausaRiprendi
        private void Tetris_Form_PausaRiprendi(object sender, System.EventArgs e)
        {
            PausaRiprendiGioco();
        }

        // Metodo che si occupa del disegno dei pezzi e della board nel Form
        private void Tetris_Form_Disegna(object sender, PaintEventArgs e)
        {
            // Gestione dell'evento Paint
            e.Graphics.FillRectangle(brush, sidebar);
            DisegnaBlocchi(g, e);
            DisegnaPezzo(partita.PezzoAttuale, g, e);
            DisegnaPezzoSuccessivo(partita.PezzoSuccessivo, g, e);
        }

        // Metodo per disegnare i blocchi già fissati nella griglia
        private void DisegnaBlocchi(Graphics g, PaintEventArgs e)
        {
            for(int i = 0; i < partita.GrigliaP.Griglia.GetLength(0); i++)
                for(int j = 0; j < partita.GrigliaP.Griglia.GetLength(1); j++)
                    switch(partita.GrigliaP.Griglia[i, j])
                    {
                        case 1:
                            e.Graphics.DrawImage(immI_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 2:
                            e.Graphics.DrawImage(immO_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 3:
                            e.Graphics.DrawImage(immL_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 4:
                            e.Graphics.DrawImage(immJ_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 5:
                            e.Graphics.DrawImage(immZ_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 6:
                            e.Graphics.DrawImage(immT_25,
                                                 j * 25,
                                                 i * 25);
                            break;
                        case 7:
                            e.Graphics.DrawImage(immS_25,
                                                 j * 25,
                                                 i * 25);
                            break;
            }
        }

        // Metodo per disegnare il pezzo in gioco
        private void DisegnaPezzo(Pezzo p, Graphics g, PaintEventArgs e)
        {
            contenitorePezzo = new Rectangle(partita.PezzoAttuale.X * dimensioneBlocco,
                                       partita.PezzoAttuale.Y * dimensioneBlocco,
                                       partita.PezzoAttuale.Sprite.Width,
                                       partita.PezzoAttuale.Sprite.Height);
            e.Graphics.DrawImage(p.Sprite,
                                 contenitorePezzo);
        }

        // Metodo per disegnare il pezzo successivo nella sidebar
        private void DisegnaPezzoSuccessivo(Pezzo p, Graphics g, PaintEventArgs e)
        {
            e.Graphics.DrawImage(p.Sprite,
                                 p.Nome=='I'? 295:280,
                                 50);
        }

        // Metodo che si occupa di decrementare l'intervallo del timer presente nel Form
        private void DiminuisciIntervalloTimer()
        {
            // L'intervallo del timer non può essere inferiore a 200
            // Gli step di decremento sono di 50
            if (tView.t.Interval >= 200)
                tView.t.Interval -= 50;
        }

        // Metodo per spostare in basso il pezzo in gioco
        private void SpostaInBasso()
        {
            // Verifico se la partita sia ancora valida
            if (partita.InGioco)
            {
                // Verifico che il pezzo non stato fissato e in tal caso
                // il pezzo viene spostato giù.
                if (!pezzoFissato)
                {
                    pezzoFissato = partita.SpostaInBasso();
                    if (pezzoFissato)
                    {
                        tView.Invalidate();
                        // Se il pezzo è stato fissato estraggo i nuovi pezzi e
                        // reinizializzo la variabile pezzoFissato
                        partita.EstraiPezzi();
                        pezzoFissato = false;

                        // Aggiorno la label dei punteggi con il nuovo punteggio
                        // e verifico se la difficoltà sia aumentata rispetto all'attuale
                        // se aumentata modifico l'intervallo del timer e aggiorno la 
                        // label sul Livello attuale
                        tView.Punti = "Punteggio: " + partita.Punteggio.ToString();
                        if (difficolta < partita.Difficolta)
                        {
                            DiminuisciIntervalloTimer();
                            difficolta = partita.Difficolta;
                            tView.Diff = "Livello: " + difficolta.ToString();
                        }
                    }
                }
            }
            else
            {
                // Caso in cui il gioco sia terminato:
                // disabilito l'oggetto Timer e mostro una MessageBox con il punteggio
                // Premendo "ok" la partita ricomincia da capo, reinizializzo le variabili
                // e reinizializzo le label e il timer del Form
                this.tView.t.Enabled = false;
                MessageBox.Show("Hai Perso! Punteggio finale: " + partita.Punteggio);
                InserisciRecord();
                partita.InizializzaPartita();
                this.tView.Inizializza();
                this.tView.Invalidate();

            }
            tView.Invalidate(contenitorePezzo);
            contenitorePezzo.Y += dimensioneBlocco;
            tView.Invalidate(contenitorePezzo);
            tView.Update();
        }

        // Metodo per mostrare il form di inserimento del nome per poter salvare il punteggio
        // e per l'aggiunta dello stesso al file classifica.xml
        private void InserisciRecord()
        {
            this.puntForm.ShowDialog();
            partita.SalvaPunteggio(puntForm.Nome, partita.Punteggio);
        }
    }
}
