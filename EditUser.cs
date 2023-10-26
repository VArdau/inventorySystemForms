using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventorySystemForms
{
    partial class EditUser : Form
    {
        User u;
        User edit;
        DataTable d = new DataTable { };
        public EditUser(User u, User edit )
        {
            InitializeComponent();
            this.edit = edit;
            this.u = u;
            SetUp();
        }
        private void SetUp()
        {
            txtUsername.Text = edit.GetUsername();
            txtEmail.Text = edit.GetEmail();
            if (edit.GetRole() == "E") cbxRole.SelectedIndex = 0;
            else if (edit.GetRole() == "M") cbxRole.SelectedIndex = 1;
            else cbxRole.SelectedIndex = 2;
        }
        private DataTable querys(string query)
        {
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            adapter.Fill(dt);
            conn.Close();

            return dt;
        }
        private void bttnConfirm_Click(object sender, EventArgs e)
        {
            string query = String.Format("Update User Set Username = '{0}', Role = '{1}', Email = '{2}' Where UserID = '{3}'", txtUsername.Text, cbxRole.Text[0], txtEmail.Text, edit.GetID());
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            if (txtPassword.Text != "")
            {
                query = String.Format("Update User Set Password = '{0}' Where UserID = '{1}'", txtPassword.Text, edit.GetID());
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("User updated");
            this.Close();
        }
    }
}
