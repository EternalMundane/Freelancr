using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Freelancr
{
    public partial class MainForm : Form
    {
        List<Client> ClientList = new List<Client>();
        DatabaseConnector _connection = new DatabaseConnector();

        public MainForm()
        {
            InitializeComponent();
            
            try
            {
                if (!File.Exists("ClientDatabase.sqlite"))
                    _connection.GenerateSQLDatabase();
            }
            catch (FileLoadException e)
            {
                MessageBox.Show(e.ToString());
            }
            
            ClientList = _connection.LoadClientList();
            listBox1.DataSource = ClientList;
        }

        private void AddClientBtn_Click(object sender, EventArgs e)
        {
            //open client form
            AddClientForm addclient = new AddClientForm();
            addclient.Show();
        }

        public void LoadClientData()
        {

        }
    }
}
