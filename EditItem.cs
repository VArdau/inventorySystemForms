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

    //id, item, colour, size, p1, p2, p3, p4, top floor, total, buffer
    partial class EditItem : Form
    {
        string startItem;
        User u;
        List<string> save = new List<string> { };

        List<string> info = new List<string> { };

        public EditItem(List<string> Info, User user)
        {
            InitializeComponent();
            this.u = user;
            info = Info;
            DisplayInfo(info);
        }

        private void DisplayInfo(List<string> id)
        {

            txtbxID.Text = info[0];
            txtbxItem.Text = info[1];
            txtbxColour.Text = info[2];
            txtbxSize.Text = info[3];

            txtbxP1.Text = info[4];
            txtbxP2.Text = info[5];
            txtbxP3.Text = info[6];
            txtbxP4.Text = info[7];
            txtbxTF.Text = info[8];
            for (int x = 1; x < 9; x++) save.Add(info[x]);
        }

        private void AmendDatabase(string txtQuery)
        {
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            string query = txtQuery;
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void bttnUpdate_Click(object sender, EventArgs e)
        {
            // this will update the items through textboxes.
            // the textboxes are: txtbxID, txtbxItem, txtbxDetails, txtbxP1, txtbxP2, txtbxP3, txtxbxP4, txtbxTF, txtbxTotal, txtbxBuffer 
            string id = txtbxID.Text;
            string name = txtbxItem.Text;
            string colour = txtbxColour.Text;
            string size = txtbxSize.Text;
            string p1 = txtbxP1.Text;
            string p2 = txtbxP2.Text;
            string p3 = txtbxP3.Text;
            string p4 = txtbxP4.Text;
            string tf = txtbxTF.Text;

            List<string> currentList = new List<string>() { name, colour, size, p1, p2, p3, p4, tf };
            List<string> fields = new List<string>() { "name", "colour", "size", "p1", "p2", "p3", "p4", "top floor" };


            string total = txtbxTotal.Text;
            string dbquery = String.Format("UPDATE Items SET ItemName = '{0}', ItemColour = '{1}', ItemSize = '{2}' WHERE ItemID = '{3}'", name, colour, size, id);
            AmendDatabase(dbquery);
            string p1query = String.Format("UPDATE Boxes SET TotalBoxes = '{0}' WHERE ItemID = '{1}' AND SectionID = '1'", p1, id);
            AmendDatabase(p1query);
            string p2query = String.Format("UPDATE Boxes SET TotalBoxes = '{0}' WHERE ItemID = '{1}' AND SectionID = '2'", p2, id);
            AmendDatabase(p2query);
            string p3query = String.Format("UPDATE Boxes SET TotalBoxes = '{0}' WHERE ItemID = '{1}' AND SectionID = '3'", p3, id);
            AmendDatabase(p3query);
            string p4query = String.Format("UPDATE Boxes SET TotalBoxes = '{0}' WHERE ItemID = '{1}' AND SectionID = '4'", p4, id);
            AmendDatabase(p4query);
            string tfquery = String.Format("UPDATE Boxes SET TotalBoxes = '{0}' WHERE ItemID = '{1}' AND SectionID = '5'", tf, id);
            AmendDatabase(tfquery);


            MessageBox.Show("Item successfully updated");
            
            DateTime d = DateTime.Now;

            for (int i = 0; i < save.Count; i++)
            {
                if (save[i] != currentList[i])
                {
                    string details = String.Format("{0} has changed from {1} to {2} for Item {3}: {4} by {5} at {6}", fields[i], save[i], currentList[i], id, info[1], u.GetUsername(), d.ToString());
                    string query = String.Format("INSERT INTO Updates (UserID,ItemID,UpdateDate,Details) values ('{0}','{1}','{2}','{3}')", u.GetID(), name, d.ToString(), details);
                    SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                //else
                //{
                //    MessageBox.Show("No change to this field made");
                //}

            }
   
            this.Close();
        }
    }
}


            
            

            


