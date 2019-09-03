using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_ER_NEW.erClasses;

namespace WFA_ER_NEW
{
    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=PLAMEN-ISO\\SQLEXPRESS; Initial Catalog=Ambulance; Integrated Security=true");
        medicalClass m = new medicalClass();
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LoginForm obj = new LoginForm();
            obj.Show();
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand("SELECT * FROM mkb10", conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("mkb", typeof(string));
                dt.Columns.Add("diagnose", typeof(string));
                dt.Load(reader);
                cmbMKB.ValueMember = "mkb";
                cmbMKB.DataSource = dt;
                conn.Close();

            }
            catch (Exception)
            {


            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            m.pin = txtPIN.Text;
            m.FirstName = txtFirstName.Text;
            m.LastName = txtLastName.Text;
            m.DataTime = txtDataTime.Text;
            m.mkb = cmbMKB.Text;

            bool success = m.Insert(m);
            if (success)
            {
                MessageBox.Show("Uspeh");
            }
            else
            {
                MessageBox.Show("Problem");
            }

        }
    }
}
