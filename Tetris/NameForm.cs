using System;
using System.Windows.Forms;

namespace Tetris.Model
{
    public partial class NameForm : Form
    {
        private static string name = null;

        public NameForm()
        {
            InitializeComponent();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        // Click event on "Ok" button
        private void bOk_Click(object sender, EventArgs e)
        {
            Validate();
        }

        // KeyDown event: pressing Enter in the TextBox will trigger the Validate method
        private void tName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                Validate();
        }

        // Method used to validate the input. If it's valid it saves the name and closes the form
        private void Validate()
        {
            if ((tName.Text.Length < 13) && (tName.Text.Length > 0))
            {
                Name = tName.Text;
                this.Close();
            }
            else
                MessageBox.Show("Name too long or not valid");
        }
    }
}
