using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventorySystemForms
{
    partial class Menu : Form
    {
        User u;

        public Menu(User u)
        {
            InitializeComponent();
            this.u = u;
            if(u.GetRole() == "E" || u.GetRole() == "M")
            {
                pcbxAdmin.Visible = false;
            }
        }

        private void bttnStock_Click(object sender, EventArgs e)
        {
            var page = new Stock(u);
            page.Closed += (s, args) => this.Close();
            page.Show();
            this.Hide();
        }

        private void bttnBuffer_Click(object sender, EventArgs e)
        {
            var page = new Buffer(u);
            page.Closed += (s, args) => this.Close();
            page.Show();
            this.Hide();
        }

        private void pcbxAdmin_Click(object sender, EventArgs e)
        {
            Admin a = new Admin(u);
            a.Show();
        }
    }
}
