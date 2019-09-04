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
                DataTable dtMkb = new DataTable();
                dtMkb.Columns.Add("mkb", typeof(string));
                dtMkb.Columns.Add("diagnose", typeof(string));
                dtMkb.Load(reader);
                cmbMKB.ValueMember = "mkb";
                cmbMKB.DataSource = dtMkb;
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            // Load data on data gridview
            DataTable dtMedical = m.Select();
            dgvMedical.DataSource = dtMedical;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            m.pin = txtPIN.Text;
            m.FirstName = txtFirstName.Text;
            m.LastName = txtLastName.Text;
            m.DataTime = txtDataTime.Text;
            m.mkb = cmbMKB.Text;
            m.KLabKK = Convert.ToInt32(numUpDownКК.Value);
            m.KLabOther = Convert.ToInt32(numUpDownKLabOther.Value);
            m.KLabUrina = Convert.ToInt32(numUpDownKLabOther.Value);
            m.Rentgen = Convert.ToInt32(numUpDownRentgen.Value);
            m.UZD = Convert.ToInt32(numUpDownUZ.Value);
            m.KAT = Convert.ToInt32(numUpDownKAT.Value);
            m.suture = Convert.ToInt32(numUpDownSuture.Value);
            m.foreignMatter = Convert.ToInt32(numUpDownForeignMather.Value);
            m.bandaging = Convert.ToInt32(numUpDownBandaging.Value);
            m.Immobilization = Convert.ToInt32(numUpDownImobilizations.Value);
            m.other = Convert.ToInt32(numUpDownOther.Value);

            bool success = m.Insert(m);
            if (success)
            {
                MessageBox.Show("Uspeh");
            }
            else
            {
                MessageBox.Show("Problem");
            }

            // Load data on data gridview
            DataTable dtMedical = m.Select();
            dgvMedical.DataSource = dtMedical;

        }
    }
}
