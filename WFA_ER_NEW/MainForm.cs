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
            ClearFielda();
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
                ClearFielda();
                // Load data on data gridview
                DataTable dtMedical = m.Select();
                dgvMedical.DataSource = dtMedical;
                MessageBox.Show("Uspeh");
            }
            else
            {
                MessageBox.Show("Problem");
            }

            

        }


        //Method Clear Fields
        private void ClearFielda()
        {
            txtAmbNo.Text = "";
            txtPIN.Text = "";
            txtPIN.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDataTime.Text = "";
            cmbMKB.Text = "";
            numUpDownКК.Value = 0;
            numUpDownKLabOther.Value = 0;
            numUpDownKLabUrina.Value = 0;
            numUpDownRentgen.Value = 0;
            numUpDownUZ.Value = 0;
            numUpDownKAT.Value = 0;
            numUpDownSuture.Value = 0;
            numUpDownImobilizations.Value = 0;
            numUpDownForeignMather.Value = 0;
            numUpDownBandaging.Value = 0;
            numUpDownOther.Value = 0;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            m.ambNo = Convert.ToInt32(txtAmbNo.Text);
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

            bool success = m.Update(m);
            if (success)
            {
                ClearFielda();
                // Load data on data gridview
                DataTable dtMedical = m.Select();
                dgvMedical.DataSource = dtMedical;
                MessageBox.Show("Uspeh");
            }
            else
            {
                MessageBox.Show("Problem");
            }
        }

        private void DgvMedical_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get Data from DataGridView
            int rowIndex = e.RowIndex;
            txtAmbNo.Text = dgvMedical.Rows[rowIndex].Cells[0].Value.ToString();
            txtPIN.Text = dgvMedical.Rows[rowIndex].Cells[1].Value.ToString();
            txtFirstName.Text = dgvMedical.Rows[rowIndex].Cells[2].Value.ToString();
            txtLastName.Text = dgvMedical.Rows[rowIndex].Cells[3].Value.ToString();
            txtDataTime.Text = dgvMedical.Rows[rowIndex].Cells[4].Value.ToString();
            cmbMKB.Text = dgvMedical.Rows[rowIndex].Cells[5].Value.ToString();
            numUpDownКК.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[6].Value);
            numUpDownKLabOther.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[7].Value);
            numUpDownKLabUrina.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[8].Value);
            numUpDownRentgen.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[9].Value);
            numUpDownUZ.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[10].Value);
            numUpDownKAT.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[11].Value);
            numUpDownSuture.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[12].Value);
            numUpDownForeignMather.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[13].Value);
            numUpDownBandaging.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[14].Value);
            numUpDownImobilizations.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[15].Value);
            numUpDownOther.Value = Convert.ToInt32(dgvMedical.Rows[rowIndex].Cells[16].Value);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            m.ambNo = Convert.ToInt32(txtAmbNo.Text);
            bool success = m.Delete(m);
            if (success)
            {
                ClearFielda();
                // Load data on data gridview
                DataTable dtMedical = m.Select();
                dgvMedical.DataSource = dtMedical;
                MessageBox.Show("Uspeh");
            }
            else
            {
                MessageBox.Show("Problem");
            }

        }
    }
}
