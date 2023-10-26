using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;
using System.Data;
using System.Data.SQLite;
using Org.BouncyCastle.Tls;

namespace inventorySystemForms
{
    partial class Admin : Form
    {
        User u;
        DataTable pendingTable = new DataTable { };
        DataTable staff = new DataTable { };
        List<User> pendingUsers = new List<User> { };
        List<RadioButton> radios = new List<RadioButton> { };
        RadioButton currentRadio = new RadioButton { };
        List<Panel> panels = new List<Panel> { };
        List<Label> tabs = new List<Label> { };
        List<Panel> userPans = new List<Panel> { };
        List<User> employees = new List<User> { };
        List<User> managers = new List<User> { };
        List<User> admins = new List<User> { };
        List<List<User>> users = new List<List<User>> { };
        int currentRadUser = -1;
        int type = -1;
        List<RadioButton> userRadios = new List<RadioButton> { };

        public Admin(User u)
        {
            InitializeComponent();
            this.u = u;
            SetUp();
        }
        private void SetUp()
        {
            tabs = new List<Label> { lblEmployee, lblManager, lblAdmin };
            users = new List<List<User>> { employees, managers, admins };
            foreach (Label l in tabs) l.Click += Tab_Click;
            pendingTable = querys("Select UserID, Username, Role, Email From User Where Role = 'P'");
            staff = querys("SELECT UserID, Username, Role, Email From User Where Role != 'P'");

            for (int x = 0; x < pendingTable.Rows.Count; x++)
            {
                List<object> o = pendingTable.Rows[x].ItemArray.ToList();
                User p = new User(Convert.ToInt32(o[0]), o[1].ToString(), o[3].ToString(), o[2].ToString());
                pendingUsers.Add(p);
            }
            for (int x = 0; x < pendingUsers.Count; x++)
            {
                Panel p = new Panel { };
                p.MinimumSize = new Size(240, 40);
                p.MaximumSize = new Size(240, 40);
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Padding = new Padding(1, 0, 0, 0);
                panels.Add(p);
                floRequests.Controls.Add(p);

                Label l = new Label { };
                p.Controls.Add(l);
                l.Padding = new Padding(0, 10, 0, 0);
                l.AutoSize = true;
                l.BringToFront();
                l.Font = new Font("Segoe UI", 9);
                l.Left += 30;
                l.Text = pendingUsers[x].GetUsername();

                RadioButton r = new RadioButton { };
                r.Padding = new Padding(7, 10, 0, 0);
                r.Top += 2;
                r.MinimumSize = new Size(26, 26);
                r.MaximumSize = new Size(26, 26);
                radios.Add(r);
                r.Click += radBttn_Click;
                r.Text = "";
                r.BringToFront();
                p.Controls.Add(r);
            }

            //470
            for(int x = 0; x < staff.Rows.Count; x++)
            {
                List<object> o = staff.Rows[x].ItemArray.ToList();
                User p = new User(Convert.ToInt32(o[0]), o[1].ToString(), o[3].ToString(), o[2].ToString());
                if (p.GetRole() == "E") employees.Add(p);
                else if (p.GetRole() == "M") managers.Add(p);
                else if (p.GetRole() == "A") admins.Add(p);
            }
        }
        public void ShowUsers(Label l)
        {
            if (l.Text == "Employee") type = 0;
            else if (l.Text == "Manager") type = 1;
            else type = 2;

            while (true)
            {
                if (floUsers.Controls.Count == 0) break;
                else floUsers.Controls.RemoveAt(0);
            }
            userPans.Clear();
            userRadios.Clear();
            List<string> info = new List<string> { };
            for(int x = 0; x < users[type].Count; x++)
            {
                info = new List<string> { users[type][x].GetID().ToString(), users[type][x].GetUsername(), users[type][x].GetEmail() };
                Panel p = new Panel { };
                p.MinimumSize = new Size(465, 40);
                p.MaximumSize = new Size(465, 40);
                p.BorderStyle = BorderStyle.FixedSingle;
                userPans.Add(p);
                p.Padding = new Padding(2, 10, 0, 0);
                floUsers.Controls.Add(p);

                RadioButton r = new RadioButton { };
                r.Top += 7;
                r.Left += 5;
                r.MinimumSize = new Size(26, 26);
                r.MaximumSize = new Size(26, 26);
                r.Click += UserRad_Click;
                userRadios.Add(r);
                p.Controls.Add(r);

                Label l0 = new Label { };
                p.Controls.Add(l0);
                l0.AutoSize = true;
                l0.Top += 9;
                l0.Left += 25;
                l0.Text = info[0];
                l0.BringToFront();

                Label l1 = new Label { };
                p.Controls.Add(l1);
                l1.AutoSize = true;
                l1.Top += 9;
                l1.Left += (l0.Right + 10);
                l1.Text = info[1];

                Label l2 = new Label { };
                p.Controls.Add(l2);
                l2.AutoSize = true;
                l2.Top += 9;
                l2.Left += (l1.Right + 10);
                l2.Text = info[2];

            }
        }
        public void ConfirmationEmail(string userEmail)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Bob John", "automatedemailtestingta@gmail.com"));
            email.To.Add(new MailboxAddress("", userEmail));

            email.Subject = "Kaftan Account Accepted";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Your Kaftan account has been accepted, you can now access the system."
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587);


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

        private void bttnAccept_Click(object sender, EventArgs e)
        {
            int radNum = -1;
            for (int x = 0; x < radios.Count; x++)
            {
                if (currentRadio == radios[x]) radNum = x;
            }
            RoleOptions o = new RoleOptions { };
            DialogResult d = o.ShowDialog();
            string newRole = "";
            try
            {
                if (d != DialogResult.Cancel)
                {
                    if (d == DialogResult.OK) newRole = "A";
                    else if (d == DialogResult.Yes) newRole = "M";
                    else if (d == DialogResult.No) newRole = "E";
                    switch (newRole)
                    {
                        case "A":
                            admins.Add(pendingUsers[radNum]);
                            break;
                        case "M":
                            managers.Add(pendingUsers[radNum]);
                            break;
                        case "E":
                            employees.Add(pendingUsers[radNum]);
                            break;
                    }
                    pendingUsers[radNum].SetRole(newRole);
                    ConfirmationEmail(pendingUsers[radNum].GetEmail());
                    panels[radNum].Visible = false;
                    panels.RemoveAt(radNum);
                    radios.RemoveAt(radNum);
                    int id = pendingUsers[radNum].GetID();
                    pendingUsers.RemoveAt(radNum);

                    string query = String.Format("Update User Set Role = '{0}' Where UserID = '{1}'", newRole, id);
                    SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    
                }
            }
            catch { }
        }

        private void bttnDeny_Click(object sender, EventArgs e)
        {
            int num = -1;
            User removed = new User { };
            for (int i = 0; i < radios.Count; i++)
            {
                if (radios[i] == currentRadio)
                {
                    num = i;
                    removed = pendingUsers[num];

                }
                else
                {

                }
            }
            int id = removed.GetID();
            pendingUsers.Remove(removed);
            radios.RemoveAt(num);
            panels[num].Visible = false;
            panels.RemoveAt(num);

            string query = String.Format("Delete FROM User WHERE UserID = '{0}'", id);
            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void bttnManage_Click(object sender, EventArgs e)
        {
            if (currentRadUser != -1)
            {
                EditUser ed = new EditUser(u, users[type][currentRadUser]);
                ed.ShowDialog();
            }
        }
        private void radBttn_Click(object sender, EventArgs e)
        {
            currentRadio = sender as RadioButton;
            foreach (RadioButton r in radios)
            {
                if (r != currentRadio) r.Checked = false;
            }
        }
        private void Tab_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            currentRadUser = -1;
            foreach(Label tab in tabs)
            {
                if (l == tab) tab.BorderStyle = BorderStyle.Fixed3D;
                else tab.BorderStyle = BorderStyle.FixedSingle;
            }
            ShowUsers(l);
        }

        private void UserRad_Click(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            for(int x = 0; x < userRadios.Count; x++)
            {
                if (userRadios[x] == r)
                {
                    userRadios[x].Checked = true;
                    currentRadUser = x;
                }
                else userRadios[x].Checked = false;
            }
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            if (currentRadUser != -1)
            {
                DialogResult d = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    string query = String.Format("Delete FROM User WHERE UserID = '{0}'", users[type][currentRadUser].GetID());
                    SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    query = String.Format("Delete FROM Updates Where UserID = '{0}'", users[type][currentRadUser].GetID());
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("User deleted");
                    userPans[currentRadUser].Visible = false;
                    currentRadUser = -1;
                }
                
            }
        }
    }
}
