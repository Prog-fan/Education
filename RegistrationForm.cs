using System;
using System.Windows.Forms;

namespace Organizer
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Authorization(object sender, EventArgs e)
        {
            RegistrationForm.ActiveForm.Hide();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
        }
    }
}
