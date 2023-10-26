using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;

namespace inventorySystemForms
{
    partial class LoginForm : Form
    {
        User u;
        List<object> info = new List<object>();
        public LoginForm()
        {
            InitializeComponent();
        }


        /// Create Connection <summary>
        ///// Create Connection
        ///// </summary>
        //SqlConnection conn = new SqlConnection(@"Data Source = db.db");
        //string username;
        //string GetUsername()
        //{
        //    username = txtbxUsername.Text;
        //    return username;
        //}

        /// btnLogIn Log in Clicked.
        private void bttnConfirm_Click(object sender, EventArgs e)
        {
            string username, userPassword;
            username = txtbxUsername.Text;
            userPassword = txtbxPassword.Text;

            SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
            conn.Open();

            string query = "select * from User where Username = '" + username + "' AND Password = '" + userPassword + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            

            // In video talk about how you tried to talk about renaming table from the query.
            if (dt.Rows.Count > 0)
            {
                info = dt.Rows[0].ItemArray.ToList();
                if (info[3].ToString() != "P")
                { 
                    List<string> strings = new List<string> { };
                    foreach (object item in info) strings.Add(item.ToString());
                    u = new User(Convert.ToInt32(strings[0]), strings[1], strings[2], strings[3], strings[4]);
                    username = txtbxUsername.Text;
                    userPassword = txtbxPassword.Text;
                    var page = new Menu(u); //when opening a new form: copy these 4 lines of code and change var page = new FORM to whatever your opening
                    page.Closed += (s, args) => this.Close(); //
                    page.Show(); //
                    this.Hide(); //
                }
                else if(info[3].ToString() == "P")
                {
                    MessageBox.Show("Account has not been given access yet.");
                    txtbxPassword.Clear();
                }
            }
            else
            {

                MessageBox.Show("Invalid Details");
                txtbxPassword.Clear();
            }

        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            RegisterAccount account = new RegisterAccount();
            account.Show();
        }
    }
}