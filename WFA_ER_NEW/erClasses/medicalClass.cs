using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_ER_NEW.erClasses
{
    class medicalClass
    {
        public int ambNo { get; set; }
        public string pin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DataTime { get; set; }
        public string mkb { get; set; }
        public int KLabKK { get; set; }
        public int KLabOther { get; set; }
        public int KLabUrina { get; set; }
        public int Rentgen { get; set; }
        public int UZD { get; set; }
        public int KAT { get; set; }
        public int suture { get; set; }
        public int foreignMatter { get; set; }
        public int bandaging { get; set; }
        public int Immobilization { get; set; }
        public int other { get; set; }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        // Selecting data from data base

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM ambulance";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //Inserting data from Database

        public bool Insert(medicalClass m)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "INSERT INTO ambulance (pin , FirstName, LastName, DataTime, mkb, KLabKK, KLabOther, KLabUrina, Rentgen, UZD, KAT, suture, foreignMatter, bandaging, Immobilization, other) VALUES (@pin , @FirstName, @LastName, @DataTime, @mkb, @KLabKK, @KLabOther, @KLabUrina, @Rentgen, @UZD, @KAT, @suture, @foreignMatter, @bandaging, @Immobilization, @other)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pin", m.pin);
                cmd.Parameters.AddWithValue("@FirstName", m.FirstName);
                cmd.Parameters.AddWithValue("@LastName", m.LastName);
                cmd.Parameters.AddWithValue("@DataTime", m.DataTime);
                cmd.Parameters.AddWithValue("@mkb", m.mkb);
                cmd.Parameters.AddWithValue("@KLabKK", KLabKK);
                cmd.Parameters.AddWithValue("@KLabOther", m.KLabOther);
                cmd.Parameters.AddWithValue("@KLabUrina", m.KLabUrina);
                cmd.Parameters.AddWithValue("@Rentgen", m.Rentgen);
                cmd.Parameters.AddWithValue("@UZD", m.UZD);
                cmd.Parameters.AddWithValue("@KAT", m.KAT);
                cmd.Parameters.AddWithValue("@suture", m.suture);
                cmd.Parameters.AddWithValue("@foreignMatter", m.foreignMatter);
                cmd.Parameters.AddWithValue("@bandaging", m.bandaging);
                cmd.Parameters.AddWithValue("@Immobilization", m.Immobilization);
                cmd.Parameters.AddWithValue("@other", m.other);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        // Update data
        public bool Update(medicalClass m)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "UPDATE ambulance SET pin=@pin, FirstName=@FirstName, LastName=@LastName, DataTime=@DataTime, mkb=@mkb, KLabKK=@KLabKK, KLabOther=@KLabOther, KLabUrina=@KLabUrina, Rentgen=@Rentgen, UZD=@UZD, KAT=@KAT, suture=@suture, foreignMatter=@foreignMatter, bandaging=@bandaging, Immobilization=@Immobilization, other=@other WHERE ambNo=@ambNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ambNo", m.ambNo);
                cmd.Parameters.AddWithValue("@pin", m.pin);
                cmd.Parameters.AddWithValue("@FirstName", m.FirstName);
                cmd.Parameters.AddWithValue("@LastName", m.LastName);
                cmd.Parameters.AddWithValue("@DataTime", m.DataTime);
                cmd.Parameters.AddWithValue("@mkb", m.mkb);
                cmd.Parameters.AddWithValue("@KLabKK", KLabKK);
                cmd.Parameters.AddWithValue("@KLabOther", m.KLabOther);
                cmd.Parameters.AddWithValue("@KLabUrina", m.KLabUrina);
                cmd.Parameters.AddWithValue("@Rentgen", m.Rentgen);
                cmd.Parameters.AddWithValue("@UZD", m.UZD);
                cmd.Parameters.AddWithValue("@KAT", m.KAT);
                cmd.Parameters.AddWithValue("@suture", m.suture);
                cmd.Parameters.AddWithValue("@foreignMatter", m.foreignMatter);
                cmd.Parameters.AddWithValue("@bandaging", m.bandaging);
                cmd.Parameters.AddWithValue("@Immobilization", m.Immobilization);
                cmd.Parameters.AddWithValue("@other", m.other);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        //Method Delete
        public bool Delete(medicalClass m)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "DELETE FROM ambulance WHERE ambNo=@ambNo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ambNo", m.ambNo);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
