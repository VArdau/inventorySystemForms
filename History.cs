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
    partial class History : Form
    {
        List<Label> line0 = new List<Label> { };
        List<Label> line1 = new List<Label> { }; 
        List<Label> line2 = new List<Label> { };
        List<Label> line3 = new List<Label> { };
        List<List<Label>> lines = new List<List<Label>> { };
        int first = 0;
        User user;
        public History(User u)
        {
            InitializeComponent();
            user = u;
            
            Display();
        }

        // display  
        // lblInfo00 - 02 to 34
        private void Display()
        {
            DataTable dates = querys("Select UpdateID,UpdateDate,Details from Updates");
            for (int i = 0; i < dates.Rows.Count; i++)
            {
                DateTime expiryDate = Convert.ToDateTime(dates.Rows[i].ItemArray[1]);
                int comp = expiryDate.CompareTo(DateTime.Now.AddMonths(-1));
                if (comp < 0)
                {
                    SQLiteConnection conn = new SQLiteConnection(@"data source = db.db");
                    conn.Open();
                    //string query = String.Format("DELETE FROM Updates WHERE UpdateID = '{0}'", dates.Rows[i].ItemArray[0].ToString());
                    string query = "DELETE FROM Updates WHERE UpdateID = '" + dates.Rows[i].ItemArray[0].ToString() + "'";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }


            DataTable history = querys("Select Details from Updates");   
            for (int i = 0; i < history.Rows.Count; i++)
            {
                List<object> hisObj = history.Rows[i].ItemArray.ToList();
                Label l0 = new Label { };
                floHistory.Controls.Add(l0);
                l0.Font = new Font("Segoe UI", 9);
                l0.MinimumSize = new Size(700, 23);
                l0.Text =  hisObj[0].ToString();
                //l0.Text = user.GetUsername() + " has" + " Updated" + " Boho L" + " on 2020-12-20";
                //hisObj[1].ToString() + " has " +
            }

            //lblInfo00.Text = user.GetUsername() + " has" + " Updated" + " Boho L" + " on 2020-12-20" ;


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
