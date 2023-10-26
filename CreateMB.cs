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
    public partial class CreateMB : Form
    {
        int section;
        DataTable itemTable = new DataTable { };
        List<Label> boxItems = new List<Label> { };
        List<Button> buttonItems = new List<Button> { };

        public CreateMB(int section)
        {
            InitializeComponent();
            this.section = section;
            SetUp();
        }

        private void SetUp()
        {
            lblItemName.Text = "";
            lblDetails.Text = "";
            itemTable = querys("Select ItemID, ItemName From Items Where ItemID != '0'");
            cbxItem.Items.Clear();
            for (int x = 0; x < itemTable.Rows.Count; x++)
            {
                List<object> itList = itemTable.Rows[x].ItemArray.ToList();
                string name = itList[1].ToString();
                if (name == "") name = "NAMELESS";
                cbxItem.Items.Add(itList[0].ToString() + " - " + name);
            }
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            if (lblItemName.Text == "" || Convert.ToInt32(txtbxQuantity.Text) < 1)
            {
                MessageBox.Show("Please enter details");
            }
            else
            {
                Button b = new Button { };
                floItemList.Controls.Add(b);
                b.Size = new Size(23, 23);
                b.Text = "-";
                b.Click += bttnRemove_Click;
                buttonItems.Add(b);

                //new label
                //flobox.controls.add(label)
                //label information (INCL FONT)

                Label l0 = new Label { };
                floItemList.Controls.Add(l0);
                l0.Font = new Font("Segoe UI", 9);
                boxItems.Add(l0);
                l0.Text += lblItemName.Text.Trim();
                l0.Text += ": ";
                l0.Text += txtbxQuantity.Text;
                l0.MinimumSize = new Size(170, 23);
                l0.Padding = new Padding(0, 5, 0, 0);
                lblItemName.Text = "";
                lblDetails.Text = "";
                txtbxQuantity.Text = "0";
            }
        }

        private void bttnCreateBox_Click(object sender, EventArgs e)
        {
            if (boxItems.Count > 0)
            {
                string query = "";
                SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                query = "Select MAX(MixBoxID) From MixBoxes";
                cmd = new SQLiteCommand(query, conn);
                object result = cmd.ExecuteScalar();
                string text = result == null ? "" : result.ToString();
                int maxID = Convert.ToInt32(text);
                query = String.Format("INSERT INTO MixBoxes(MixBoxID, SectionID) VALUES('{0}', '{1}')", maxID + 1, section);
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                for (int x = 0; x < boxItems.Count; x++)
                {
                    string idStr = "";
                    for (int y = 0; y < boxItems[x].Text.Length; y++)
                    {
                        if ((int)boxItems[x].Text[y] > 47 && (int)boxItems[x].Text[y] < 58)
                        {
                            idStr += boxItems[x].Text[y];
                            boxItems[x].Text = boxItems[x].Text.Substring(y + 1);
                            y--;
                        }
                        else break;
                    }
                    int itemID = Convert.ToInt32(idStr);
                    idStr = "";
                    for (int y = 0; y < boxItems[x].Text.Length; y++)
                    {
                        if ((int)boxItems[x].Text[y] > 47 && (int)boxItems[x].Text[y] < 58)
                        {
                            idStr += boxItems[x].Text[y];
                        }
                    }
                    int total = Convert.ToInt32(idStr);

                    query = String.Format("INSERT INTO Mix_Items(MixBoxID, ItemID, TotalItems) VALUES('{0}', '{1}', '{2}')", maxID + 1, itemID, total);
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                foreach (Button b in buttonItems) b.Visible = false;
                foreach (Label l in boxItems) l.Visible = false;
                buttonItems.Clear();
                boxItems.Clear();
                MessageBox.Show("Mixbox created");
            }
            
        }

        private void bttnRemove_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int numb = -1;
            for (int x = 0; x < buttonItems.Count; x++)
            {
                if (b == buttonItems[x])
                {
                    numb = x;
                }
            }
            if (numb > -1)
            {
                boxItems[numb].Visible = false;
                buttonItems[numb].Visible = false;
                boxItems.RemoveAt(numb);
                buttonItems.RemoveAt(numb);
            }
        }

        private void cbxItem_TextChanged(object sender, EventArgs e)
        {
            string item = cbxItem.Text.ToUpper();
            cbxItem.Items.Clear();
            for (int x = 0; x < itemTable.Rows.Count; x++)
            {
                List<object> itList = itemTable.Rows[x].ItemArray.ToList();
                string name = itList[1].ToString();
                if (name.Contains(item)) cbxItem.Items.Add(itList[0].ToString() + " - " + name);
                cbxItem.SelectionStart = cbxItem.Text.Length;
                cbxItem.SelectionLength = 0;
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

        private void cbxItem_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doesnt work properly - need to fix

        }
        private int GetIDFromStr(string word)
        {
            word = cbxItem.Text;

            return 0;
        }

        private void cbxItem_SelectedValueChanged(object sender, EventArgs e)
        {
            lblItemName.Text = cbxItem.Text;
            string idStr = "";
            for (int x = 0; x < lblItemName.Text.Length; x++)
            {
                if ((int)lblItemName.Text[x] > 47 && (int)lblItemName.Text[x] < 58) idStr += lblItemName.Text[x];
                else break;
            }
            int id = Convert.ToInt32(idStr);
            DataTable d = querys("Select ItemColour, ItemSize From Items Where ItemID = '" + id + "'");
            List<object> details = d.Rows[0].ItemArray.ToList();
            lblDetails.Text = details[0].ToString() + " " + details[1].ToString();
        }
    }
}
