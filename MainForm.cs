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
        static Dictionary<int, Client> ClientCache = new Dictionary<int, Client>();
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
            listBox1.Refresh();
        }

        private void AddClientBtn_Click(object sender, EventArgs e)
        {
            //open client form
            AddClientForm addclient = new AddClientForm();
            addclient.ShowDialog();
            MessageBox.Show("Client has been added");
            LoadClientData();
        }

        public void LoadClientData()
        {
            ClientCache.Clear();
            listBox1.Items.Clear();
            listBox1.Refresh();
            ClientCache = _connection.LoadClientList();
            
            

            foreach (KeyValuePair<int, Client> item in ClientCache)
            {
                //build client name
                string fullname = item.Value.fname + " " + item.Value.lname;
                listBox1.Items.Add(fullname);
            }
            listBox1.Refresh();
        }
    }
}
