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
    partial class NewItem : Form
    {
        User u;

        public NewItem(User user)
        {
            InitializeComponent();
            this.u = user;
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

        public bool ItemExists()
        {
            // under development
            string item = txtbxItem.Text;
            string size = txtbxSize.Text;
            string colour = txtbxColour.Text;

            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            string query = "SELECT ItemID FROM Items WHERE ItemName = '" + item + "' and ItemSize = '" + size + "' and ItemColour = '" + colour + "' and BufferNum = '" + 0 +  "' and Barcode = '" +  0 +  "' and EmailNum = '" + 0 + "";
            conn.Close();
            
            DataTable dtable = new DataTable();
            if (dtable.Rows.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void bttnConfirm_Click(object sender, EventArgs e)
        {
            if (ItemExists() == false)
            {
                SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                conn.Open();
                string item = txtbxItem.Text;
                string size = txtbxSize.Text;
                string colour = txtbxColour.Text;
                string getID = "SELECT MAX(ItemID) FROM Items";
                DataTable max = querys(getID);
                string query = "INSERT INTO Items (ItemID, ItemName,ItemSize,ItemColour) values('" + (Convert.ToInt32(max.Rows[0].ItemArray[0]) + 1).ToString() + "','" + item + "','" + size + "','" + colour + "')";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();

                DateTime d = DateTime.Now;
                string details = String.Format("{0} has added {1} {2} {3}: {4}",u.GetUsername(),item,size,colour,d.ToString());
                query = "INSERT INTO Updates (UserID,ItemID,UpdateDate,Details) values ('" + u.GetID() + "','" + (Convert.ToInt32(max.Rows[0].ItemArray[0]) + 1).ToString() + "','" + d.ToString() + "','" + details + "')";
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Item created successfully.");
                //Stock.Display();
            }

            else
            {
                MessageBox.Show("This item already exists.");
            }
        }

    }
}
