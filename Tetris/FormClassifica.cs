using System.Collections.Generic;
using System.Windows.Forms;

namespace Tetris.View
{
    public partial class Form_Classifica : Form
    {
        public Form_Classifica(List<Model.Classifica> punteggi)
        {
            InitializeComponent();
            dataGridView1.DataSource = punteggi;
        }
    }
}
