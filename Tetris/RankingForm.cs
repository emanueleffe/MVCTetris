using System.Collections.Generic;
using System.Windows.Forms;

namespace Tetris.View
{
    public partial class RankingForm : Form
    {
        private delegate void ButtonEventHandler(object sender, System.EventArgs e);

        public RankingForm(List<Model.Ranking> scores)
        {
            InitializeComponent();
            dataGrid.DataSource = scores;
        }
    }
}
