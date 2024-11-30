using System;
using System.Windows.Forms;

namespace Organizer
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        //показ/скрытие пароля. логическое значение меняется на противоположное
        private void VisiblePassword(object sender, EventArgs e)
        {
              txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        //вспывающая подсказка при наведении мышки
        private void SnowTooltips (object sender, EventArgs e)
        {
            //блок с обьявлением нового экземпляра всплывающей подсказкой
            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 1000,
                InitialDelay = 1000,
                ReshowDelay = 100,
                ShowAlways = true
            };

            toolTip.SetToolTip(txtPassword, "Введите пароль");
            toolTip.SetToolTip(txtLogin, "Введите логин");
        }

        private void RegViev(object sender, EventArgs e)
        {
            AuthorizationForm.ActiveForm.Hide();
            RegistrationForm regForm = new RegistrationForm();
            regForm.ShowDialog();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            AuthorizationForm.ActiveForm.Hide();
            OrganizerForm organizer = new OrganizerForm();  
            organizer.ShowDialog();
        }
    }
}