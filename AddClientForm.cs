using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Freelancr
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void AddClientDbBtn_Click(object sender, EventArgs e)
        {
            DatabaseConnector _con = new DatabaseConnector();
            //convert textbox to int
            _con.AddClient(Convert.ToInt32(IdtextBox.Text), FNameTextBox.Text, LNameTextBox.Text, PhoneTextBox.Text, CompanyTextBox.Text);
            this.Close();
            //_con.ExecuteSQLNonQuery();
        }
    }
}
