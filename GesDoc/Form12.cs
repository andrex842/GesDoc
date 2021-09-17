using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {

                SqlCommand cmd = new SqlCommand("select * from Prestamos", con);
                con.Open();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("select * from Prestamos WHERE PROCESO=@PROCESO", con);
                cmd.Parameters.AddWithValue("@PROCESO", "PRESTAMO TEMPORAL");
                con.Open();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();



            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("select * from Prestamos WHERE PROCESO=@PROCESO", con);
                cmd.Parameters.AddWithValue("@PROCESO", "PRESTAMO DEFINITIVO");
                con.Open();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();



            }

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dataGridView1);

        }
    }
}
