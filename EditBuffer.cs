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
using MimeKit;
using MailKit.Net.Smtp;

namespace inventorySystemForms
{
    partial class EditBuffer : Form
    {
        int temp = -1;
        int condit = -1;
        List<object> info = new List<object> { };
        User u;
        public EditBuffer(List<object> Info,User user)
        {
            InitializeComponent();
            info = Info;
            DisplayInfo(info);
            SetupData();
            this.u = user;
        }
        private void SetupData()
        {
            temp = Convert.ToInt32(info[5]);
            string query = "Select EmailNum From Items Where ItemId = '" + txtbxID.Text.Trim() + "'";
            DataTable dt = new DataTable();
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            {
                List<object> l = dt.Rows[0].ItemArray.ToList();
                condit = Convert.ToInt32(l[0]);
            }
        }

        private void DisplayInfo(List<object> id)
        {
            txtbxID.Text = info[0].ToString();
            txtbxItem.Text = info[1].ToString();
            txtbxColour.Text = info[2].ToString();
            txtbxSize.Text = info[3].ToString();
            txtbxBarcode.Text = info[4].ToString();
            txtbxTotal.Text = info[5].ToString();
        }

        private void AmendDatabase(string query)
        {
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void txtbxUpdate_Click(object sender, EventArgs e)
        {
            string id = txtbxID.Text.Trim();
            string total = txtbxTotal.Text.Trim();
            try
            {
                if (Convert.ToInt32(total) < 0) total = "0";

                string dbquery = String.Format("UPDATE Items SET BufferNum = {0} WHERE ItemID = '{1}'", total, id);
                AmendDatabase(dbquery);
                int newNum = Convert.ToInt32(total);
                CheckEmail(newNum);
                MessageBox.Show("Total successfully updated");
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Integer value must be entered");
            }

            //string id = txtbxID.Text.Trim();
            //string total = txtbxTotal.Text.Trim();
            //if (Convert.ToInt32(total) < 0) total = "0";
            //string dbquery = String.Format("UPDATE Items SET BufferNum = {0} WHERE ItemID = '{1}'", total, id);
            //string name = txtbxItem.Text.Trim();
            //AmendDatabase(dbquery);
            //int newNum = Convert.ToInt32(total);
            //CheckEmail(newNum);
            //MessageBox.Show("Total successfully updated");
            //DateTime d = DateTime.Now;
            //string details = String.Format("{0} has edited buffer number of item ID {1} to {2}: {3}", u.GetUsername(),id,total,d.ToString());
            //string query = "INSERT INTO Updates (UserID,ItemID,UpdateDate,Details) values ('" + u.GetID() + "','" + txtbxID.Text + "','" + d.ToString() + "','" + details + "')";
            //SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            //conn.Open();
            //SQLiteCommand cmd = new SQLiteCommand(query, conn);
            //cmd.ExecuteNonQuery();

            //conn.Clone();
            //this.Close();
        }
        private void CheckEmail(int newNum)
        {
            DataTable d = querys("SELECT Email From User Where Role = 'M'");
            List<string> emails = new List<string> { };
            for (int x = 0; x < d.Rows.Count; x++) emails.Add(d.Rows[x].ItemArray[0].ToString());
            if (condit < temp && condit >= newNum)
            {
                foreach(string e in emails) SendEmail(0, newNum, e);
            }
            if (condit > temp && newNum < (condit / 2))
            {
                foreach (string e in emails) SendEmail(1, newNum, e);
            }
            if (newNum == 0)
            {
                foreach (string e in emails) SendEmail(2, newNum, e);
            }
        }
        private void SendEmail(int type, int newNum, string emailSend)
        {
            string first = "Item: " + info[1] + ", ID: " + info[0] + " has low buffer stock.";
            string first1 = "Refill product soon.";
            string second = "Item: " + info[1] + ", ID: " + info[0] + " has very low buffer stock.";
            string second1 = "Refill product soon.";
            string third = "Item: " + info[1] + ", ID: " + info[0] + " is now empty within the buffer.";
            string third1 = "Refill product ASAP.";
            List<string> emails = new List<string> { first, second, third, first1, second1, third1 };

            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Inventory System", "automatedemailtestingta@gmail.com"));
            email.To.Add(new MailboxAddress("Kaftan Manager", emailSend));

            email.Subject = "Low stock warning - " + info[1].ToString();
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<p>" + emails[type] + "</p><p>" + emails[type + 3] + "</p><p>" + ("Items remaining: " + newNum) + "</p>"
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

