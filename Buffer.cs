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
using MimeKit;
using MailKit.Net.Smtp;

namespace inventorySystemForms
{
    partial class Buffer : Form
    {
        int max = 0;
        int first = 1;

        List<Label> panList0 = new List<Label> { };
        List<Label> panList1 = new List<Label> { };
        List<Label> panList2 = new List<Label> { };
        List<Label> panList3 = new List<Label> { };
        List<Label> panList4 = new List<Label> { };
        List<List<Label>> panels = new List<List<Label>> { };
        List<Panel> panelList = new List<Panel> { };
        List<object> itemInfo = new List<object> { };
        DataTable bufferTable = new DataTable { };
        List<PictureBox> picList = new List<PictureBox> { };
        User u;
        DataTable dates = new DataTable { };
        List<Panel> panListMore = new List<Panel> { };

        public Buffer(User u)
        {
            InitializeComponent();
            this.u = u;
            Display();
            CheckStock();
        }
        private void CheckStock()
        {
            DataTable month = querys("Select ItemID, MonthStock, LastUpdated from MonthAgo");
            int datet = Convert.ToDateTime(month.Rows[0].ItemArray[2]).Date.CompareTo(DateTime.Now.Date.AddMonths(-1));
            if (datet < 0)
            {
                for (int i = 0; i < month.Rows.Count; i++)
                {
                    int diff = Convert.ToInt32(bufferTable.Rows[i].ItemArray[5]) - Convert.ToInt32(month.Rows[i].ItemArray[1]);
                    if (Convert.ToInt32(bufferTable.Rows[i].ItemArray[5]) != 0)
                    {
                        double percDou = Convert.ToSingle(diff / Convert.ToInt32(bufferTable.Rows[i].ItemArray[5]));
                        percDou *= 100;
                        string percStr = "";
                        for (int x = 0; x < percDou.ToString().Length; x++)
                        {
                            if (Convert.ToChar(percDou.ToString()[x]) != '.')
                            {
                                percStr += percDou.ToString()[x];
                            }
                            else break;
                        }
                        try
                        {
                            int percInt = Convert.ToInt32(percStr);
                            if (percInt < 2)
                            {
                                SlowEmail(month.Rows[i].ItemArray[0].ToString());
                            }
                        }
                        catch { }
                    }
                }
                for(int x = 0; x < month.Rows.Count; x++)
                {
                    AmendDatabase("Update MonthAgo SET LastUpdated = '" + DateTime.Now.ToString() + "' Where ItemID = '" + month.Rows[x].ItemArray[0].ToString() + "'");
                }
            }
        }
        private void SlowEmail(string ID)
        {
            DataTable managers = querys("Select Email from User Where Role = 'M'");
            for(int x = 0; x < managers.Rows.Count; x++)
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Inventory System", "automatedemailtestingta@gmail.com"));
                email.To.Add(new MailboxAddress("Kaftan Manager", managers.Rows[x].ItemArray[0].ToString()));

                email.Subject = "Slow selling item - " + ID;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "<p>Item ID:" + ID + " has sold less than or equal to 1% of it's buffer stock this month</p>"
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate("automatedemailtestingta", "pltvhnjfcwxbecov");

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
        }
        private void Display()
        {

            //ID, ItemName, Details, Barcode, BufferNum
            panList0 = new List<Label> { lblInfo00, lblInfo01, lblInfo02, lblInfo03, lblInfo04 };
            panList1 = new List<Label> { lblInfo10, lblInfo11, lblInfo12, lblInfo13, lblInfo14 };
            panList2 = new List<Label> { lblInfo20, lblInfo21, lblInfo22, lblInfo23, lblInfo24 };
            panList3 = new List<Label> { lblInfo30, lblInfo31, lblInfo32, lblInfo33, lblInfo34 };
            panList4 = new List<Label> { lblInfo40, lblInfo41, lblInfo42, lblInfo43, lblInfo44 };
            panelList = new List<Panel> { pan0, pan1, pan2, pan3, pan4 };
            panels = new List<List<Label>> { panList0, panList1, panList2, panList3, panList4 };
            panListMore = new List<Panel> { panMenu0, panMenu1, panMenu2, panMenu3, panMenu4 };
            picList = new List<PictureBox> { pcbxMore0, pcbxMore1, pcbxMore2, pcbxMore3, pcbxMore4};
            string role = u.GetRole();
            if (role == "E")
            {
                foreach (PictureBox pic in picList)
                {
                    pic.Visible = false;
                }

            }

            //id item details barcode total
            //DataTable maxim = querys("Select MAX(BufferID) from Buffer");
            DataTable maxim = querys("Select COUNT(ItemID) FROM Items WHERE BufferNum > 0");
            int max = Convert.ToInt32(maxim.Rows[0].ItemArray[0]);
            bufferTable = querys("Select ItemID,ItemName,ItemColour,ItemSize,Barcode,BufferNum FROM Items");
            
            for (int x = 0; x < panelList.Count; x++)
            {
                itemInfo = bufferTable.Rows[x + first].ItemArray.ToList();
                //DataTable boxTable = querys("Select ItemID, Barcode, BufferNum");
                if (itemInfo[0].ToString() != "")
                {
                    panels[x][0].Text = itemInfo[0].ToString();
                    panels[x][1].Text = itemInfo[1].ToString();
                    panels[x][2].Text = itemInfo[2].ToString() + "\n" + itemInfo[3].ToString();
                    panels[x][3].Text = itemInfo[4].ToString();
                    panels[x][4].Text = itemInfo[5].ToString();

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
        }
        //for the display there is lblInfo00 - 04 to lblInfo44(ID, item, details, barcode, total)
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
        private void bttnLogout_Click(object sender, EventArgs e)
        {
            var page = new LoginForm();
            page.Closed += (s, args) => this.Close(); //
            page.Show(); //
            this.Hide();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            if (txtbxSearch.Text == "")
            {
                first = 0;
            }
            //// search button for the items
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            string search = txtbxSearch.Text;
            string query = "Select ItemID,ItemName,ItemColour,ItemSize,Barcode FROM Items " +
            "WHERE ItemName LIKE '" + search + "%'";
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
                panels[x][3].Text = itemInfo[4].ToString();

                //for (int y = 1; y < panels.Count; y++)
                //{
                //    DataTable location = querys("Select ItemID FROM Items Where ItemID = '" + itemInfo[0].ToString() + "'");
                //    panels[x][panels.Count].Text = location.Rows.Count.ToString();
                //}
            }
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

        private void bttnScan_Click(object sender, EventArgs e)
        {

            try
            {
                string query = "update Items SET BufferNum = BufferNum - 1 where Barcode = '" + txtbxBarcode1.Text + "'";
                AmendDatabase(query);
            }
            catch (Exception)
            {

                MessageBox.Show("Either an incorrect barcode or non integer value was entered.");
            }

            //string getBufferNum = "SELECT BufferNum WHERE "
            //string query = "update Items SET BufferNum = BufferNum - 1 where Barcode = '" + txtbxBarcode1.Text + "'";

            //AmendDatabase(query);
        }

        private void pcbxBack_Click(object sender, EventArgs e)
        {
            var page = new Menu(u);
            page.Closed += (s, args) => this.Close();
            page.Show();
            this.Hide();

        }

        private void pcbxDown_Click(object sender, EventArgs e)
        {
            if (lblInfo40.Text != max.ToString())
            {
                foreach (Panel p in panListMore) p.Visible = false;
                first++;
                Display();
            }
        }

        private void pcbxUp_Click(object sender, EventArgs e)
        {
            // scrolling through the data
            if (first != 1)
            {
                foreach (Panel p in panListMore) p.Visible = false;
                first--;
                Display();
            }

        }

        private void pcbxMore0_Click(object sender, EventArgs e)
        {
            if (panMenu0.Visible == true)
            {
                panMenu0.Visible = false;
            }
            else
            {
                panMenu0.Visible = true;
            }
        }

        private void bttnEdit0_Click(object sender, EventArgs e)
        {
            EditBuffer b = new EditBuffer(bufferTable.Rows[0 + first].ItemArray.ToList(),u);
            b.Show();
        }

        private void pcbxMore1_Click(object sender, EventArgs e)
        {
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
            if (panMenu2.Visible == true)
            {
                panMenu2.Visible = false;
            }
            else
            {
                panMenu2.Visible = true;
            }
        }

        private void pcbxMore3_Click(object sender, EventArgs e)
        {
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
            if (panMenu4.Visible == true)
            {
                panMenu4.Visible = false;
            }
            else
            {
                panMenu4.Visible = true;
            }
        }

        private void bttnEditTotal1_Click(object sender, EventArgs e)
        {
            EditBuffer b = new EditBuffer(bufferTable.Rows[1 + first].ItemArray.ToList(),u);
            b.Show();
        }

        private void bttnEditTotal2_Click(object sender, EventArgs e)
        {
            EditBuffer b = new EditBuffer(bufferTable.Rows[2 + first].ItemArray.ToList(),u);
            b.Show();
        }

        private void bttnEditTotal3_Click(object sender, EventArgs e)
        {
            EditBuffer b = new EditBuffer(bufferTable.Rows[3 + first].ItemArray.ToList(),u);
            b.Show();
        }

        private void bttnEditTotal_Click(object sender, EventArgs e)
        {
            EditBuffer b = new EditBuffer(bufferTable.Rows[4 + first].ItemArray.ToList(),u);
            b.Show();
        }

        private void btttnEmail0_Click(object sender, EventArgs e)
        {
            SetAmountEmail a = new SetAmountEmail(bufferTable.Rows[0 + first].ItemArray.ToList(),u);
            a.Show();
            

        }

        private void bttnEmail1_Click(object sender, EventArgs e)
        {
            SetAmountEmail a = new SetAmountEmail(bufferTable.Rows[0 + first].ItemArray.ToList(),u);
            a.Show();

        }

        private void bttnEmail2_Click(object sender, EventArgs e)
        {
            SetAmountEmail a = new SetAmountEmail(bufferTable.Rows[0 + first].ItemArray.ToList(),u);
            a.Show();

        }

        private void bttnEmail3_Click(object sender, EventArgs e)
        {
            SetAmountEmail a = new SetAmountEmail(bufferTable.Rows[0 + first].ItemArray.ToList(),u);
            a.Show();

        }

        private void bttnEmail4_Click(object sender, EventArgs e)
        {
            SetAmountEmail a = new SetAmountEmail(bufferTable.Rows[0 + first].ItemArray.ToList(),u);
            a.Show();

        }

        private void bttnScanIn_Click(object sender, EventArgs e)
        {
            try
            {
                string queryGet = String.Format("UPDATE Items SET Barcode = {0} WHERE ItemID = '{1}'", txtbxBarcode0.Text, txtbxID.Text);
                AmendDatabase(queryGet);

            }
            catch (Exception)
            {

                MessageBox.Show("Integer values must be entered into the boxes");
            }

            //// scan in where ID, set Barcode0 in Items
            //string queryGet = String.Format("UPDATE Items SET Barcode = {0} WHERE ItemID = '{1}'", txtbxBarcode0.Text, txtbxID.Text);
            //AmendDatabase(queryGet);
        }

        private void bttnHistory_Click(object sender, EventArgs e)
        {
            History form = new History(u);
            form.Show();
        }
    }
}

