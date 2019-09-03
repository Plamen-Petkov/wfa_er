using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WFA_ER_NEW
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=PLAMEN-ISO\\SQLEXPRESS; Initial Catalog=Ambulance; Integrated Security=true");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void CmbBoxUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand("SELECT UserName FROM Users", conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("UserName", typeof(string));
                dt.Load(reader);
                cmbBoxUName.ValueMember = "UserName";
                cmbBoxUName.DataSource = dt;
                conn.Close();

            }
            catch (Exception)
            {


            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                MessageBox.Show("Полетата са празни");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Select * from Users where UserName=@UserName and PassWord=@PassWord", conn);
                cmd.Parameters.AddWithValue("@UserName", cmbBoxUName.Text);
                cmd.Parameters.AddWithValue("@PassWord", txtPass.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
               
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MainForm obj = new MainForm();
                    this.Hide();
                    obj.Show();
                    
                }
                else
                {
                    MessageBox.Show("Please check your username or Password");
                }
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
