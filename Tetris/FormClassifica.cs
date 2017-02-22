using System.Collections.Generic;
using System.Windows.Forms;

namespace Tetris.View
{
    public partial class FormClassifica : Form
    {
        private delegate void ButtonEventHandler(object sender, System.EventArgs e);

        public FormClassifica(List<Model.Classifica> punteggi)
        {
            InitializeComponent();
            grigliaDati.DataSource = punteggi;
        }
    }
}
