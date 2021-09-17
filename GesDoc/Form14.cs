using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.Usuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {



                SqlCommand cmd = new SqlCommand("SELECT Usuario,Pass FROM UsuariosGesDoc WHERE Usuario=@Usuario AND Pass=@Pass ", con);
                cmd.Parameters.AddWithValue("@Usuario", label2.Text);
                cmd.Parameters.AddWithValue("@Pass", textBox1.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");

                    string query = "UPDATE UsuariosGesDoc SET Pass=@Pass WHERE Usuario=@Usuario";
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand(query, con1);

                    cmd1.Parameters.AddWithValue("@Usuario", label2.Text);
                    cmd1.Parameters.AddWithValue("@Pass", textBox2.Text);
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    MessageBox.Show("Contraseña Actualizada correctamente" + "\n\nDebe Volver a Ingresar al Aplicativo", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();

                }
                else
                {

                    MessageBox.Show("Contraseña Actual, No Coincide...", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
            }
        }
    }
}
