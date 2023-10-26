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
using System.Xml.Linq;
using MimeKit;
using MailKit.Net.Smtp;

namespace inventorySystemForms
{
    public partial class RegisterAccount : Form
    {
        public RegisterAccount()
        {
            InitializeComponent();
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

        private void bttnConfirm_Click(object sender, EventArgs e)
        {
            // username, email, password, check password
            // make a db
            if (txtbxPassword.Text == txtbxConfirmPassword.Text)
            {
                string dbquery = "Insert into User(Username, Password, Role, Email) values ('" + txtbxUsername.Text + "', '" + txtbxPassword.Text + "', 'P', '" + txbxEmail.Text + "')  ";
                AmendDatabase(dbquery);

                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Bob John", "automatedemailtestingta@gmail.com"));
                email.To.Add(new MailboxAddress("", txbxEmail.Text));

                email.Subject = "Kaftan Management; Account created";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Your account has been created and is pending to be accepted into the system."
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate("automatedemailtestingta", "pltvhnjfcwxbecov");

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                MessageBox.Show("Account pending; an admin will review your request shortly.");
                this.Close();
            }

            else if (txtbxPassword.Text != txtbxConfirmPassword.Text)
            {
                MessageBox.Show("Passwords dont match");
            }

            else
            {
                Console.WriteLine("wth happened");
            }

            

        }
    }
}
