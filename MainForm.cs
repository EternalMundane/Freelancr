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
        Dictionary<int, Client> ClientCache = new Dictionary<int, Client>();
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

            LoadClientData();
        }

        private void AddClientBtn_Click(object sender, EventArgs e)
        {
            //open client form
            AddClientForm addclient = new AddClientForm();
            addclient.Show();
        }

        public void LoadClientData()
        {
            ClientCache = _connection.LoadClientList();
            foreach (KeyValuePair<int, Client> item in ClientCache)
            {
                //build client name
                string fullname = item.Value.fname + " " + item.Value.lname;
                listBox1.Items.Add(fullname);
            }
        }
    }
}
