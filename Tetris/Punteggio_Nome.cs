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

        private void button1_Click(object sender, EventArgs e)
        {
            Convalida();
        }

        private void Convalida()
        {
            if ((tNome.Text.Length < 13) && (tNome.Text.Length > 0))
            {
                Nome = tNome.Text;
                this.Close();
            }
            else
                MessageBox.Show("Nome troppo lungo o non valido\nLunghezza massima: 12 caratteri");
        }

        private void tNome_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Enter:
                    Convalida();
                    break;
            }
        }
    }
}
