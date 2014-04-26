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
            _con.AddClient(textBox1.ToString(), textBox2.ToString(), textBox3.ToString(), textBox4.ToString(), textBox5.ToString());
            //_con.ExecuteSQLNonQuery();
        }
    }
}
