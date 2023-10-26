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
    partial class Stock : Form
    {
        User u;
        List<Label> panList0 = new List<Label> { };
        List<Label> panList1 = new List<Label> { };
        List<Label> panList2 = new List<Label> { };
        List<Label> panList3 = new List<Label> { };
        List<Label> panList4 = new List<Label> { };
        List<Label> panList5 = new List<Label> { };
        List<Panel> panelList = new List<Panel> { };
        List<Panel> panListMore = new List<Panel> { };
        List<PictureBox> picList = new List<PictureBox> { };
        int first = 1;
        int max = 0;
        List<List<Label>> panels = new List<List<Label>> { };
        List<object> itemInfo = new List<object> { };

        public Stock(User u)
        {
            InitializeComponent();
            this.u = u;
            Display();
        }
        private void Display()
        {
            panList0 = new List<Label> { lblInfo00, lblInfo01, lblInfo02, lblInfo03, lblInfo04, lblInfo05, lblInfo06, lblInfo07, lblInfo08 };
            panList1 = new List<Label> { lblInfo10, lblInfo11, lblInfo12, lblInfo13, lblInfo14, lblInfo15, lblInfo16, lblInfo17, lblInfo18 };
            panList2 = new List<Label> { lblInfo20, lblInfo21, lblInfo22, lblInfo23, lblInfo24, lblInfo25, lblInfo26, lblInfo27, lblInfo28 };
            panList3 = new List<Label> { lblInfo30, lblInfo31, lblInfo32, lblInfo33, lblInfo34, lblInfo35, lblInfo36, lblInfo37, lblInfo38 };
            panList4 = new List<Label> { lblInfo40, lblInfo41, lblInfo42, lblInfo43, lblInfo44, lblInfo45, lblInfo46, lblInfo47, lblInfo48 };
            panList5 = new List<Label> { lblInfo50, lblInfo51, lblInfo52, lblInfo53, lblInfo54, lblInfo55, lblInfo56, lblInfo57, lblInfo58 };
            panels = new List<List<Label>> { panList0, panList1, panList2, panList3, panList4, panList5 };
            panelList = new List<Panel> { pan0, pan1, pan2, pan3, pan4, pan5 };
            panListMore = new List<Panel> { panMenu0, panMenu1, panMenu2, panMenu3, panMenu4, panMenu5 };
            picList = new List<PictureBox> { pcbxMore0, pcbxMore1, pcbxMore2, pcbxMore3, pcbxMore4, pcbxMore5 };
            DataTable maxim = querys("Select MAX(ItemID) from Items");
            max = Convert.ToInt32(maxim.Rows[0].ItemArray[0]);
            DataTable infoTable = querys("Select Items.ItemID, Items.ItemName, Items.ItemColour, Items.ItemSize From Items");
            string role = u.GetRole();
            if (role == "E")
            {
                bttnHistory.Visible = false;
                bttnCreateItem.Visible = false;
                foreach (PictureBox pic in picList)
                {
                    pic.Visible = false;
                }

            }
            for (int x = 0; x < panels.Count; x++)
            {
                try
                {
                    List<object> itemInfo = infoTable.Rows[first + x].ItemArray.ToList();
                    if (itemInfo[0].ToString() != "")
                    {
                        panels[x][0].Text = itemInfo[0].ToString();
                        panels[x][1].Text = itemInfo[1].ToString();
                        panels[x][2].Text = itemInfo[2].ToString() + "\n" + itemInfo[3].ToString();

                        //Queries locations
                        for (int y = 1; y < 6; y++)
                        {
                            DataTable location = querys("Select TotalBoxes from Boxes Where itemID = '" + itemInfo[0].ToString() + "' AND SectionID = '" + y + "'");
                            try
                            {
                                panels[x][2 + y].Text = location.Rows[0].ItemArray[0].ToString();
                            }
                            catch
                            {
                                panels[x][2 + y].Text = "0";
                            }
                        }
                        int adding = 0;
                        //Adds up locations to set total
                        for (int y = 3; y < 8; y++)
                        {
                            adding += Convert.ToInt32(panels[x][y].Text);
                        }
                        panels[x][8].Text = adding.ToString();

                        //Sets colours
                        if (pan0.BackColor == SystemColors.Control)
                        {
                            pan0.BackColor = SystemColors.ControlLight;
                        }
                        else
                        {
                            pan0.BackColor = SystemColors.Control;
                        }
                        for (int y = 1; y < panelList.Count; y++)
                        {
                            if (panelList[y - 1].BackColor == SystemColors.Control) panelList[y].BackColor = SystemColors.ControlLight;
                            else panelList[y].BackColor = SystemColors.Control;
                        }
                    }
                    else if (first + 5 != max)
                    {
                        first++;
                        x--;
                    }
                }
                catch
                {
                    first--;
                    x--;
                }
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

        private void pcbxBack_Click(object sender, EventArgs e)
        {
            var page = new Menu(u);
            page.Closed += (s, args) => this.Close();
            page.Show();
            this.Hide();
        }

        private void bttnLogout_Click(object sender, EventArgs e)
        {
            var page = new LoginForm();
            page.Closed += (s, args) => this.Close(); //
            page.Show(); //
            this.Hide();
        }

        private void bttnMixedBoxes_Click(object sender, EventArgs e)
        {
            MixedBoxes m = new MixedBoxes(u);
            m.Show();
        }

        private void bttnHistory_Click(object sender, EventArgs e)
        {
            History h = new History(u);
            h.Show();
        }
        //Add button


        private void bttnCreateItem_Click(object sender, EventArgs e)
        {
            NewItem n = new NewItem(u);
            n.Show();
        }


        private void pcbxMore0_Click(object sender, EventArgs e)
        {
            // makes the panel appear which should be hidden, the panel is for the menu (panMenu0). This should be changed so when the button is clicked again it would hide (rn only makes it visible)
            // also there are many menu panels so there is probably a better way of doing this.
            // we have 6 panels in total, and for now i only made three interactive to see what we can do to make it take up less space.
            
        }

        private void pcbxMore1_Click(object sender, EventArgs e)
        {
            foreach (Panel p in panListMore)
            {
                if (p.Name != panMenu1.Name) p.Visible = false;
            }
            if (panMenu1.Visible == true)
            {
                panMenu1.Visible = false;
            }
            else
            {
                panMenu1.Visible = true;
            }
        }

        private void pcbxMore2_Click(object sender, EventArgs e)
        {
            foreach (Panel p in panListMore)
            {
                if (p.Name != panMenu2.Name) p.Visible = false;
            }
            if (panMenu2.Visible == true)
            {
                panMenu2.Visible = false;
            }
            else
            {
                panMenu2.Visible = true;
            }
            // panMenu3, 4, 5 arent a funtion for now.
        }

        private void bttnEdit0_Click(object sender, EventArgs e)
        {
            List<string> split = new List<string> { };
            split = lblInfo02.Text.Split("\n").ToList();
            List<string> s = new List<string> { lblInfo00.Text, lblInfo01.Text };
            for(int x = 0; x < split.Count; x++)
            {
                s.Add(split[x]);
            }
            for(int x = 3; x < panList0.Count; x++)
            {
                s.Add(panList0[x].Text);
            }
            EditItem i = new EditItem(s, u);
            i.Show();
        }



        private void bttnSearch_Click(object sender, EventArgs e)
        {
            if (txtbxSearch.Text == "")
            {
                first = 1;
            }
            // search button for the items
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            string search = txtbxSearch.Text;
            string query = "Select * FROM Items WHERE ItemName LIKE '" + search + "%'";
            DataTable searchedData = querys(query);

            conn.Close();
            first = 0;
            int lessThan = panels.Count;
            if (lessThan > searchedData.Rows.Count) lessThan = searchedData.Rows.Count;

            foreach (List<Label> list in panels)
            {
                foreach (Label l in list)
                {
                    l.Text = "";
                }
            }

            for (int x = 0; x < lessThan; x++)
            {
                List<object> itemInfo = searchedData.Rows[first + x].ItemArray.ToList();
                panels[x][0].Text = itemInfo[0].ToString();
                panels[x][1].Text = itemInfo[1].ToString();
                panels[x][2].Text = itemInfo[2].ToString() + "\n" + itemInfo[3].ToString();
                for (int y = 1; y < 6; y++)
                {
                    DataTable location = querys("Select boxID from Boxes Where itemID = '" + itemInfo[0].ToString() + "' AND sectionID = '" + y + "'");
                    panels[x][2 + y].Text = location.Rows.Count.ToString();
                }
                int adding = 0;
                for (int y = 3; y < 8; y++)
                {
                    adding += Convert.ToInt32(panels[x][y].Text);
                }
                panels[x][8].Text = adding.ToString();

            }

        }
        private void DeleteItem(string idDel)
        {
            DialogResult del = MessageBox.Show("Delete item", "Are you sure?", MessageBoxButtons.YesNo);
            if (del == DialogResult.Yes)
            {
                SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                conn.Open();
                string delQuery = "Delete from Items Where ItemID = '" + idDel + "'";
                SQLiteCommand cmd = new SQLiteCommand(delQuery, conn);
                cmd.ExecuteNonQuery();
                Display();
                DateTime d = DateTime.Now;
                string details = String.Format("{0} has deleted Item: {1}: {2}", u.GetUsername(), idDel, d.ToString());
                string query = "INSERT INTO Updates (UserID,ItemID,UpdateDate,Details) values ('" + u.GetID() + "','" + idDel + "','" + d.ToString() + "','" + details + "')";
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void pcbxUp_Click(object sender, EventArgs e)
        {
            // scrolling through the data

            if (first -1 != 0)
            {
                foreach (Panel p in panListMore) p.Visible = false;
                first--;
                Display();
            }
        }

        private void pcbxDown_Click(object sender, EventArgs e)
        {
            if (lblInfo50.Text != max.ToString())
            {
                foreach (Panel p in panListMore) p.Visible = false;
                first++;
                Display();
            }
        }
        private void bttnDelete0_Click(object sender, EventArgs e)
        {
            // this will delete the item
            // again each item has a delete so there are 6 delete buttons
            DeleteItem(lblInfo00.Text);
        }
        private void bttnDelete1_Click(object sender, EventArgs e)
        {
            DeleteItem(lblInfo10.Text);
        }

        private void bttnDelete2_Click(object sender, EventArgs e)
        {
            DeleteItem(lblInfo20.Text);
        }

        private void bttnDelete3_Click(object sender, EventArgs e)
        {
            DeleteItem(lblInfo30.Text);
        }

        private void bttnDelete4_Click(object sender, EventArgs e)
        {
            DeleteItem(lblInfo40.Text);
        }

        private void bttnDelete5_Click(object sender, EventArgs e)
        {
            DeleteItem(lblInfo50.Text);
        }

        private void bttnEdit1_Click(object sender, EventArgs e)
        {
            List<string> split = new List<string> { };
            split = lblInfo12.Text.Split("\n").ToList();
            List<string> s = new List<string> { lblInfo10.Text, lblInfo11.Text };
            for (int x = 0; x < split.Count; x++)
            {
                s.Add(split[x]);
            }
            for (int x = 3; x < panList1.Count; x++)
            {
                s.Add(panList1[x].Text);
            }
            EditItem i = new EditItem(s, u);
            i.Show();
        }

        private void bttnEdit2_Click(object sender, EventArgs e)
        {
            List<string> split = new List<string>{ };
            List<string> s = new List<string> { lblInfo20.Text, lblInfo21.Text };
            split = lblInfo22.Text.Split("\n").ToList();
            for (int x = 0; x < split.Count; x++)
            {
                s.Add(split[x]);
            }
            for (int x = 3; x < panList2.Count; x++)
            {
                s.Add(panList2[x].Text);
            }
            EditItem i = new EditItem(s, u);
            i.Show();
        }

        private void bttnEdit3_Click(object sender, EventArgs e)
        {
            List<string> split = new List<string> { };
            List<string> s = new List<string> { lblInfo30.Text, lblInfo31.Text };
            split = lblInfo32.Text.Split("\n").ToList();
            for (int x = 0; x < split.Count; x++)
            {
                s.Add(split[x]);
            }
            for (int x = 3; x < panList3.Count; x++)
            {
                s.Add(panList3[x].Text);
            }
            EditItem i = new EditItem(s, u);
            i.Show();
        }

        private void bttnEdit4_Click(object sender, EventArgs e)
        {
            List<string> split = new List<string> { };
            List<string> s = new List<string> { lblInfo40.Text, lblInfo41.Text };
            split = lblInfo42.Text.Split("\n").ToList();
            for (int x = 0; x < split.Count; x++)
            {
                s.Add(split[x]);
            }
            for (int x = 3; x < panList4.Count; x++)
            {
                s.Add(panList4[x].Text);
            }
            EditItem i = new EditItem(s,u);
            i.Show();
        }

        private void bttnEdit5_Click(object sender, EventArgs e)
        {
            List<string> split = new List<string> { };
            List<string> s = new List<string> { lblInfo50.Text, lblInfo51.Text };
            split = lblInfo52.Text.Split("\n").ToList();
            for (int x = 0; x < split.Count; x++)
            {
                s.Add(split[x]);
            }
            for (int x = 3; x < panList5.Count; x++)
            {
                s.Add(panList5[x].Text);
            }
            EditItem i = new EditItem(s, u);
            i.Show();
        }

        private void pcbxMore3_Click(object sender, EventArgs e)
        {
            foreach(Panel p in panListMore)
            {
                if (p.Name != panMenu3.Name) p.Visible = false;
            }
            if (panMenu3.Visible == true)
            {
                panMenu3.Visible = false;
            }
            else
            {
                panMenu3.Visible = true;
            }
        }

        private void pcbxMore4_Click(object sender, EventArgs e)
        {
            foreach (Panel p in panListMore)
            {
                if (p.Name != panMenu4.Name) p.Visible = false;
            }
            if (panMenu4.Visible == true)
            {
                panMenu4.Visible = false;
            }
            else
            {
                panMenu4.Visible = true;
            }
        }

        private void pcbxMore5_Click(object sender, EventArgs e)
        {
            foreach (Panel p in panListMore)
            {
                if (p.Name != panMenu5.Name) p.Visible = false;
            }
            if (panMenu5.Visible == true)
            {
                panMenu5.Visible = false;
            }
            else
            {
                panMenu5.Visible = true;
            }
        }

        private void pcbxMore0_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Panel p in panListMore)
            {
                if (p.Name != panMenu0.Name) p.Visible = false;
            }
            if (panMenu0.Visible == true)
            {
                panMenu0.Visible = false;
            }
            else
            {
                panMenu0.Visible = true;
            }
        }
    }
}
