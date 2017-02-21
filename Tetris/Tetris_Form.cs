using System.Drawing;
using System.Windows.Forms;

namespace Tetris.View
{
    public partial class Tetris_Form : Form
    {
        private delegate void KeyEventHandler(object sender, KeyEventArgs e);
        private delegate void PaintEventHandler(object sender, PaintEventArgs e);
        private delegate void TickEventHandler(object sender, System.EventArgs e);
        private delegate void ButtonEventHandler(object sender, System.EventArgs e);

        public Timer t;

        public Tetris_Form()
        {
            InitializeComponent();
            this.t = new Timer();
            Inizializza();
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
        }

        public string Punti
        {
            set
            {
                this.punti.Text = value;
            }
        }

        // Metodo per inizializzare (o reinizializzare) il timer e le due label
        public void Inizializza()
        {
            this.t.Enabled = true;
            this.t.Interval = 600;
            this.diff.Text = "Livello: 1";
            this.punti.Text = "Punteggio: 0";
        }

        public string Diff
        {
            set
            {
                this.diff.Text = value;
            }
        }

        private int IntervalloTimer
        {
            get
            {
                return t.Interval;
            }
            set
            {
                t.Interval = value;
            }
        }
    }
}
