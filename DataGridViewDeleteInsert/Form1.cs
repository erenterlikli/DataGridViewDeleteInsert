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


namespace DataGridViewDeleteInsert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=EREN\\SQLEXPRESS;Integrated Security=True");
        private void Goster(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Goster("Select * from Kutuphane.dbo.kitap");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into Kutuphane.dbo.kitap(kitapadi,yazaradi,yayinevi,sayfa,turu) Values(@adi, @yazarinadi, @yayin, @sayfano, @kitapturu)",baglan);
            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@yazarinadi", textBox2.Text);
            komut.Parameters.AddWithValue("@yayin", textBox3.Text);
            komut.Parameters.AddWithValue("@sayfano", textBox4.Text);
            komut.Parameters.AddWithValue("@kitapturu", comboBox1.Text);

            komut.ExecuteNonQuery();
            Goster("Select *from Kutuphane.dbo.kitap");
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Kutuphane.dbo.kitap where kitapadi= @adi", baglan);
            komut.Parameters.AddWithValue("@adi", textBox5.Text);
            komut.ExecuteNonQuery();
            Goster("Select *from Kutuphane.dbo.kitap");
            baglan.Close();
            textBox5.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
