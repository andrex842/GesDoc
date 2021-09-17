using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Debe completar el campo codigo", "ERROR");
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar el campo año", "ERROR");
                return;
            }
            if (comboBox3.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar el campo mes", "ERROR");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Debe completar el campo primer nombre", "ERROR");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Debe completar el campo primer apellido", "ERROR");
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Debe completar el campo identificacion", "ERROR");
                return;
            }
            if (textBox9.Text == "")
            {
                MessageBox.Show("Debe completar el campo fecha inicial de la liquidacion", "ERROR");
                return;
            }
            if (textBox10.Text == "")
            {
                MessageBox.Show("Debe completar el campo fecha final de la liquidacion", "ERROR");
                return;
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show("Debe completar el campo numero del comprobante", "ERROR");
                return;
            }
            if (textBox8.Text == "")
            {

                MessageBox.Show("Debe completar el campo fecha del comprobante", "ERROR");
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");


                string query = "INSERT INTO COMPROBANTES_EGRESO(codigo,año,mes,primer_nombre,segundo_nombre,primer_apellido,segundoapellido,identificacion,fechainicial,fechafinal,numero,fecha) VALUES (@codigo, @año, @mes, @primer_nombre,@segundo_nombre, @primer_apellido, @segundoapellido, @identificacion, @fechainicial, @fechafinal, @numero, @fecha)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@codigo", textBox4.Text);
                cmd.Parameters.AddWithValue("@año", comboBox1.Text);
                cmd.Parameters.AddWithValue("@mes", comboBox3.Text);
                cmd.Parameters.AddWithValue("@primer_nombre", textBox1.Text);
                cmd.Parameters.AddWithValue("@segundo_nombre", textBox2.Text);
                cmd.Parameters.AddWithValue("@primer_apellido", textBox3.Text);
                cmd.Parameters.AddWithValue("@segundoapellido", textBox5.Text);
                cmd.Parameters.AddWithValue("@identificacion", textBox6.Text);
                cmd.Parameters.AddWithValue("@fechainicial", textBox9.Text);
                cmd.Parameters.AddWithValue("@fechafinal", textBox10.Text);
                cmd.Parameters.AddWithValue("@numero", textBox7.Text);
                cmd.Parameters.AddWithValue("@fecha", textBox8.Text);

                cmd.ExecuteNonQuery();


                MessageBox.Show("Datos Guardados Correctamente", "Perfecto");

                textBox4.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
        }
    }
}
