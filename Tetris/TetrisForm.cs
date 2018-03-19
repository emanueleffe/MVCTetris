using System.Drawing;
using System.Windows.Forms;

namespace Tetris.View
{
    public partial class TetrisForm : Form
    {
        private delegate void KeyEventHandler(object sender, KeyEventArgs e);
        private delegate void PaintEventHandler(object sender, PaintEventArgs e);
        private delegate void EventHandler(object sender, System.EventArgs e);

        public Timer t;

        public TetrisForm()
        {
            InitializeComponent();
            this.t = new Timer();
            Initialize();
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
        }

        public string Score
        {
            set
            {
                this.score.Text = value;
            }
        }

        // Initialization (or re-initialization) of timer and labels
        public void Initialize()
        {
            this.t.Enabled = true;
            this.t.Interval = 600;
            this.diff.Text = "Level: 1";
            this.score.Text = "Score: 0";
        }

        public string Diff
        {
            set
            {
                this.diff.Text = value;
            }
        }

        private int TimerInterval
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
