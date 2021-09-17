using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {

                if (TxtConsultaid1.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion");
                }

                if (comboBox3.Text == "")
                {
                    MessageBox.Show("Por favor Seleccione El Dato a Consultar", "Sin Informacion");
                }




                if (comboBox3.Text == "IDENTIFICACION")

                {
                    comboBox3.Text = "identificacion";

                    SqlCommand cmd = new SqlCommand("SELECT * FROM COMPROBANTES_EGRESO WHERE " + comboBox3.Text + "=@identificacion", con);
                    cmd.Parameters.AddWithValue("@identificacion", TxtConsultaid1.Text);
                    con.Open();

                    SqlDataAdapter adaptador = new SqlDataAdapter();
                    adaptador.SelectCommand = cmd;
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dataGridView1.DataSource = tabla;

                    con.Close();


                }


                if (comboBox3.Text == "AÑO")

                {
                    comboBox3.Text = "año";
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM COMPROBANTES_EGRESO WHERE " + comboBox3.Text + "=@año", con);
                    cmd1.Parameters.AddWithValue("@año", TxtConsultaid1.Text);
                    con.Open();

                    SqlDataAdapter adaptador1 = new SqlDataAdapter();
                    adaptador1.SelectCommand = cmd1;
                    DataTable tabla1 = new DataTable();
                    adaptador1.Fill(tabla1);
                    dataGridView1.DataSource = tabla1;


                    con.Close();


                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dataGridView1);
        }
    }
}
