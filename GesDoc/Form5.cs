using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form5 : Form
    {
        public delegate void pasar1(string dato1);
        public event pasar1 pasado1;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT CARPETA FROM Histrias_Laborales  GROUP BY CARPETA", con);
                con.Open();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pasado1(label1.Text); 
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
