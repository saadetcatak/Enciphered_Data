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

namespace Enciphered_Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection=new SqlConnection("Data Source=SAADET\\SQLEXPRESS01;Initial Catalog=DbTest;Integrated Security=True");

        void listele()
        {
            connection.Open();
            SqlDataAdapter dataAdapter= new SqlDataAdapter("Select*From TblVeriler",connection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        void sifrecoz()
        {
            string adcozum=TxtAd.Text;
            byte[] adcozumdizi = Convert.FromBase64String(adcozum);
            string adverisi=ASCIIEncoding.ASCII.GetString(adcozumdizi);
            TxtAd.Text= adverisi;

            string soyadcozum = TxtSoyad.Text;
            byte[] soyadcozumdizi = Convert.FromBase64String(soyadcozum);
            string soyadverisi = ASCIIEncoding.ASCII.GetString(soyadcozumdizi);
            TxtSoyad.Text = soyadverisi;

            string mailcozum = TxtMail.Text;
            byte[] mailcozumdizi = Convert.FromBase64String(mailcozum);
            string mailverisi = ASCIIEncoding.ASCII.GetString(mailcozumdizi);
            TxtMail.Text = mailverisi;

            string sifrecozum = TxtSifre.Text;
            byte[] sifrecozumdizi = Convert.FromBase64String(sifrecozum);
            string sifreverisi = ASCIIEncoding.ASCII.GetString(sifrecozumdizi);
            TxtSifre.Text = adverisi;

            string hesapnocozum = TxtHesapNo.Text;
            byte[] hesapnocozumdizi = Convert.FromBase64String(hesapnocozum);
            string hesapnoverisi = ASCIIEncoding.ASCII.GetString(hesapnocozumdizi);
            TxtHesapNo.Text = hesapnoverisi;
        }
        void temizle()
        { 
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            TxtHesapNo.Text = "";
            TxtSifre.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ad=TxtAd.Text;
            byte[] addizi=ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre=Convert.ToBase64String(addizi);
            
            string soyad=TxtSoyad.Text;
            byte[] soyaddizi=ASCIIEncoding.ASCII.GetBytes(soyad);
            string soyadsifre=Convert.ToBase64String(soyaddizi);

            string mail = TxtMail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = TxtSifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = TxtHesapNo.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapnosifre = Convert.ToBase64String(hesapnodizi);

            connection.Open();
            SqlCommand command = new SqlCommand("Insert into TblVeriler (Ad,Soyad,Mail,Sifre,HesapNo) values (@p1,@p2,@p3,@p4,@p5)", connection);
            command.Parameters.AddWithValue("@p1", adsifre);
            command.Parameters.AddWithValue("@p2", soyadsifre);
            command.Parameters.AddWithValue("@p3", mailsifre);
            command.Parameters.AddWithValue("@p4", sifresifre);
            command.Parameters.AddWithValue("@p5", hesapnosifre);
            command.ExecuteNonQuery();
            connection.Close();
            temizle();
            MessageBox.Show("Veriler Eklendi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnSifreCoz_Click(object sender, EventArgs e)
        {
            sifrecoz();
            //string adcozum=TxtAd.Text;
            //byte[] adcozumdizi=Convert.FromBase64String(adcozum);
            //string adverisi=ASCIIEncoding.ASCII.GetString(adcozumdizi);
            //label6.Text = adverisi;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int deger = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[deger].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[deger].Cells[2].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[deger].Cells[3].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[deger].Cells[4].Value.ToString();
            TxtHesapNo.Text = dataGridView1.Rows[deger].Cells[5].Value.ToString();
           

        }
    }
}
