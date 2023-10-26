using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace inventorySystemForms
{
    partial class SetAmountEmail : Form
    {
        List<object> info = new List<object> { };
        User u;
        int prev = -1;

        public SetAmountEmail(List<object> Info,User user)
        {
            InitializeComponent();
            info = Info;
            this.u = user;
            Setup();
        }

        private void Setup()
        {
            DataTable d = querys("SELECT ItemName, EmailNum From Items Where ItemID = '" + info[0].ToString() + "'");
            txtbxID.Text = info[0].ToString();
            txtbxName.Text = d.Rows[0].ItemArray[0].ToString();
            txtbxReminder.Text = d.Rows[0].ItemArray[1].ToString();
            prev = Convert.ToInt32(txtbxReminder.Text);
        }

        private void bttnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int newNum = Convert.ToInt32(txtbxReminder.Text);
                if (newNum > -1 && newNum != prev)
                {
                    SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                    conn.Open();
                    string dbquery = String.Format("UPDATE Items SET EmailNum = {0} WHERE ItemID = '{1}'", txtbxReminder.Text, txtbxID.Text);
                    SQLiteCommand cmd = new SQLiteCommand(dbquery, conn);
                    cmd.ExecuteNonQuery();
                    DateTime d = DateTime.Now;
                    string details = String.Format("{0} has changed from {1} to {2} for Item {3}: {4} by {5} at {6}", "Email reminder number", prev.ToString(), txtbxReminder.Text, info[0], info[1], u.GetUsername(), d.ToString());
                    dbquery = String.Format("INSERT INTO Updates(UserID,ItemID,UpdateDate,Details) values ('{0}','{1}','{2}','{3}')", u.GetID(), txtbxID.Text, d.ToString(), details);
                    cmd = new SQLiteCommand(dbquery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Have set a new reminder for this item.");
                    this.Close();
                }
                else if (newNum < 0)
                {
                    MessageBox.Show("Invalid number, must be greater than 0");
                    txtbxReminder.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You must enter a whole number");

            }
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
    }
}
