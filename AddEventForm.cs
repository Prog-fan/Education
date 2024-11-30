using System;
using System.Windows.Forms;

namespace Organizer
{
    public partial class AddEventForm : Form
    {
        public AddEventForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
