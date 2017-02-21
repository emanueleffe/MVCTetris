using System;
using System.Windows.Forms;

namespace Tetris.Model
{
    public partial class Punteggio_Nome : Form
    {
        private static string nome = null;

        public Punteggio_Nome()
        {
            InitializeComponent();
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            private set
            {
                nome = value;
            }
        }

        // Gestione dell'evento Click sul pulsante "Ok"
        private void bOk_Click(object sender, EventArgs e)
        {
            Convalida();
        }

        // Gestione dell'evento Keydown in caso si prema Invio quando si ha il focus nella TextBox
        private void tNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Convalida();
        }

        // Metodo utilizzato per convalidare l'input. Se è valido salva il nome e chiude il form.
        private void Convalida()
        {
            if ((tNome.Text.Length < 13) && (tNome.Text.Length > 0))
            {
                Nome = tNome.Text;
                this.Close();
            }
            else
                MessageBox.Show("Nome inserito troppo lungo o non valido.");
        }
    }
}
