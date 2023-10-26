using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace inventorySystemForms
{
    partial class MixedBoxes : Form
    {
        MixBox current = new MixBox { };
        List<Panel> panels = new List<Panel> { };
        List<Label> panList0 = new List<Label> { };
        List<Label> panList1 = new List<Label> { };
        List<Label> panList2 = new List<Label> { };
        List<Label> panList3 = new List<Label> { };
        List<Label> panList4 = new List<Label> { };
        int first = 0;
        int section = 1;
        List<string> titles = new List<string> { };
        List<List<Label>> panList = new List<List<Label>> { };
        DataTable mixBox = new DataTable { };
        DataTable itemTable = new DataTable { };
        DataTable mixItems = new DataTable { };
        bool loaded = false;
        int max = 0;
        User u;
        List<MixBox> p1 = new List<MixBox> { };
        List<MixBox> p2 = new List<MixBox> { };
        List<MixBox> p3 = new List<MixBox> { };
        List<MixBox> p4 = new List<MixBox> { };
        List<MixBox> tf = new List<MixBox> { };
        List<List<MixBox>> MixBoxList = new List<List<MixBox>> { };
        List<RadioButton> rads = new List<RadioButton> { };
        int selected = -1;
        int boxID = -1;
        List<object> itemList = new List<object> { };

        public MixedBoxes(User u)
        {
            InitializeComponent();
            this.u = u;
            Setup();
            Display();
        }
        private void SetLists()
        {
            panels = new List<Panel> { pan0, pan1, pan2, pan3, pan4 };
            panList0 = new List<Label> { lblInfo00, lblInfo01 };
            panList1 = new List<Label> { lblInfo10, lblInfo11 };
            panList2 = new List<Label> { lblInfo20, lblInfo21 };
            panList3 = new List<Label> { lblInfo30, lblInfo31 };
            panList4 = new List<Label> { lblInfo40, lblInfo41 };
            panList = new List<List<Label>> { panList0, panList1, panList2, panList3, panList4 };
            MixBoxList = new List<List<MixBox>> { p1, p2, p3, p4, tf };
            rads = new List<RadioButton> { rad0, rad1, rad2, rad3, rad4 };
            titles = new List<string> { "P1", "P2", "P3", "P4", "TF" };
        }
        private void Setup()
        {
            SetLists();
            itemTable = querys("Select Items.ItemID, Items.ItemName, Items.ItemSize From Items");
            mixBox = querys("Select MixBoxes.MixBoxID, MixBoxes.SectionID From MixBoxes");
            mixItems = querys("Select MixBoxID, ItemID, TotalItems From Mix_Items");
            for (int x = 0; x < mixItems.Rows.Count; x++)
            {
                List<object> items = new List<object> { };
                List<object> totals = new List<object> { };

                for (int y = 0; y < mixItems.Rows.Count; y++)
                {
                    if (Convert.ToInt32(mixItems.Rows[y].ItemArray[0]) == x)
                    {
                        items.Add(mixItems.Rows[y].ItemArray[1]);
                        totals.Add(mixItems.Rows[y].ItemArray[2]);
                        boxID = Convert.ToInt32(mixItems.Rows[y].ItemArray[0]);
                    }
                }
                if (items.Count > 0)
                {
                    MixBox m = new MixBox();
                    m.SetBoxID(boxID);
                    for (int y = 0; y < items.Count; y++)
                    {
                        m.AddItem(items[y]);
                        m.AddTotal(totals[y]);
                    }
                    int location = 0;
                    for (int y = 0; y < mixBox.Rows.Count; y++)
                    {
                        if (Convert.ToInt32(mixBox.Rows[y].ItemArray[0]) == m.GetID()) location = Convert.ToInt32(mixBox.Rows[y].ItemArray[1]);
                    }
                    if (location - 1 != -1)
                    {
                        MixBoxList[location - 1].Add(m);
                    }
                }
            }
            for (int x = 1; x < itemTable.Rows.Count; x++)
            {
                List<object> os = itemTable.Rows[x].ItemArray.ToList();
                string add = os[0].ToString().Trim() + " - " + os[1].ToString().Trim();
                if (os[2].ToString() != "") add += ", " + os[2].ToString();
                cbxSearch.Items.Add(add);
            }
        }

        private void Display()
        {
            string role = u.GetRole();
            if (role == "E")
            {
                bttnCreate.Visible = false;
                bttnDelete.Visible = false;
            }

            selected = -1;
            foreach (RadioButton r in rads) r.Checked = false;
            lblPage.Text = String.Format("{0}/{1}", (first + 1), MixBoxList[section - 1].Count);
            floScroll.AutoScroll = false;
            lblSection.Text = titles[section - 1];
            try
            {
                SetLists();
                current = MixBoxList[section - 1][first];
                itemList = current.GetItems();
                List<object> totalList = current.GetTotals();
                int count = itemList.Count;
                if (count > 5)
                {
                    floScroll.AutoScroll = true;
                    for (int x = 5; x < count; x++)
                    {
                        Panel p = new Panel { };
                        this.Controls.Add(p);
                        p.Parent = floScroll;
                        p.Size = new Size(387, 55);
                        p.BorderStyle = BorderStyle.FixedSingle;
                        panels.Add(p); //+5 -8   356 -8
                        Label l0 = new Label { };
                        Label l1 = new Label { };
                        p.Controls.Add(l0);
                        p.Controls.Add(l1);
                        l0.Font = new Font("Segoe UI", 12);
                        l1.Font = new Font("Segoe UI", 12);
                        l0.Left += 31;
                        l1.Left += 357;
                        List<Label> l = new List<Label> { l0, l1 };
                        panList.Add(l);
                        RadioButton r = new RadioButton();
                        p.Controls.Add(r);
                        r.Left += 8;
                        rads.Add(r);
                    }
                }
                else floScroll.AutoScroll = false;
                foreach (RadioButton p in rads)
                {
                    p.Click += OnRadioClick;
                }
                if (itemList.Count == 0)
                {
                    foreach (Panel p in panels) p.Visible = false;
                    pan0.Visible = true;
                    lblInfo00.Text = "Empty";
                }
                else
                {
                    foreach (List<Label> ls in panList)
                    {
                        foreach (Label l in ls) l.Text = "";
                    }
                    for (int x = 0; x < count; x++)
                    {

                        if (itemList[x].ToString() != "")
                        {
                            List<object> s = querys(String.Format("Select ItemName, ItemColour, ItemSize From Items Where ItemID = '{0}'", itemList[x].ToString())).Rows[0].ItemArray.ToList();
                            panList[x][0].Text = String.Format("{0}\n{1} {2}", s[0].ToString(), s[1].ToString(), s[2].ToString());
                            panList[x][1].Text = totalList[x].ToString();
                        }
                        else
                        {
                            List<object> s = querys(String.Format("Select ItemName, ItemColour, ItemSize From Items Where ItemID = '{0}'", "0")).Rows[0].ItemArray.ToList();
                            panList[x][0].Text = String.Format("{0}", "No Desc");
                            panList[x][1].Text = totalList[x].ToString();
                        }
                    }
                    for (int x = 0; x < panels.Count; x++)
                    {
                        if (panList[x][0].Text == "")
                        {
                            panels[x].Visible = false;
                        }
                        else panels[x].Visible = true;
                    }
                }

            }
            catch
            {
                foreach (Panel p in panels) p.Visible = false;
                pan0.Visible = true;
                lblInfo00.Text = "Empty";
                lblInfo01.Text = "";
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
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            if (cbxSearch.Text != "")
            {
                string idStr = "";
                for (int x = 0; x < cbxSearch.Text.Length; x++)
                {
                    if ((int)cbxSearch.Text[x] > 47 && (int)cbxSearch.Text[x] < 58) idStr += cbxSearch.Text[x];
                    else break;
                }
                List<int> present = new List<int> { };
                DataTable d = querys("Select MixBoxID from Mix_Items Where ItemID = '" + idStr + "'");

                string query = "";
                SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                for (int x = 0; x < d.Rows.Count; x++)
                {
                    query = "Select SectionID From MixBoxes Where MixBoxID = '" + d.Rows[x].ItemArray[0].ToString() + "'";
                    cmd = new SQLiteCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    present.Add(Convert.ToInt32(result == null ? "" : result));
                }
                string message = "";
                if (present.Count > 0)
                {
                    message += "Item is present within: ";
                    for (int x = 0; x < present.Count; x++)
                    {
                        if (x > 0) message += ", ";
                        message += titles[present[x] - 1];
                    }
                }
                else
                {
                    message = "Item is not present in mixboxes";
                }
                MessageBox.Show(message);
            }
        }

        private void pcbxLeftSection_Click(object sender, EventArgs e)
        {
            // these will go between the sections and the items in the sections.
            // lblSection is at the top which shows which section you are viewing, lblInfo00-01 to lblInfo41
            if (section - 1 == 0) section = 5;
            else section--;
            first = 0;
            Display();
        }

        private void pcbxRightSection_Click(object sender, EventArgs e)
        {
            if (section + 1 == 6) section = 1;
            else section++;
            first = 0;
            Display();
        }

        private void pcbxUp_Click(object sender, EventArgs e)
        {
            if (first - 1 != -1) first--;
            Display();
        }

        private void pcbxDown_Click(object sender, EventArgs e)
        {
            if (first + 1 != MixBoxList[section - 1].Count) first++;
            Display();
        }

        private void bttnEdit_Click(object sender, EventArgs e)
        {
            if (selected > -1 && lblInfo00.Text != "Empty")
            {
                int newn = Convert.ToInt32(panList[selected][1].Text) - 1;
                string newNum = newn.ToString();
                if (newn > 0)
                {
                    panList[selected][1].Text = newNum;
                    EditMixNum(newNum, MixBoxList[section - 1][first].GetID().ToString(), itemList[selected].ToString());
                }
                Setup();
            }
        }
        private void OnRadioClick(object sender, EventArgs e)
        {
            RadioButton p = sender as RadioButton;
            foreach (RadioButton r in rads)
            {
                for (int x = 0; x < rads.Count; x++)
                {
                    if (rads[x] == p)
                    {
                        selected = x;
                    }
                    else rads[x].Checked = false;
                }
            }
        }

        private void bttnInc_Click(object sender, EventArgs e)
        {
            if (selected > -1 && lblInfo00.Text != "Empty")
            {
                int newn = Convert.ToInt32(panList[selected][1].Text) + 1;
                string newNum = newn.ToString();
                panList[selected][1].Text = newNum;
                EditMixNum(newNum, MixBoxList[section - 1][first].GetID().ToString(), itemList[selected].ToString());
                Setup();
            }
        }
        private void EditMixNum(string newNum, string mixID, string itemID)
        {
            string query = String.Format("Update Mix_Items Set TotalItems = {0} Where MixBoxID = '{1}' AND ItemID = '{2}'", newNum, mixID, itemID);
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void bttnCreate_Click(object sender, EventArgs e)
        {
            CreateMB c = new CreateMB(section);
            c.Show();
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            if (pan0.Visible == true && lblInfo00.Text != "Empty")
            {
                DialogResult d = MessageBox.Show("Delete box?", "Confirmation", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    string query = String.Format("Delete from MixBoxes where MixBoxID = '{0}'", current.GetID());
                    //MessageBox.Show(current.GetID().ToString());
                    SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    query = String.Format("Delete from Mix_Items Where MixBoxID = '{0}'", current.GetID());
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
                }
            }
        }
    }
}
