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

namespace GesDoc
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Width = 463;
            panel1.Height = 157;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;


        }

        private void Form20_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = false;
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.Width = 450;
            panel2.Height = 157;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            panel3.Visible = true;
            panel3.Width = 441;
            panel3.Height = 157;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel2.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Width = 428;
            panel4.Height = 157;

            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {



                SqlCommand cmd = new SqlCommand("SELECT * FROM UsuariosGesDoc ", con);
                con.Open();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Debe completar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Debe asignarle una Dependencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label2.Text = "0000";

            SqlConnection con2 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            string query2 = "INSERT INTO UsuariosGesDoc (Usuario,Pass,Dependencia) VALUES (@Usuario, @Pass, @Dependencia)";
            con2.Open();

            SqlCommand cmd2 = new SqlCommand(query2, con2);


            cmd2.Parameters.AddWithValue("@Usuario", textBox1.Text);
            cmd2.Parameters.AddWithValue("@Pass", label2.Text);
            cmd2.Parameters.AddWithValue("@Dependencia", comboBox1.Text);
            cmd2.ExecuteNonQuery();
            con2.Close();

            MessageBox.Show("Usuario " + textBox1.Text + " Creado Correctamente" + "\n\n Recuerde Que la contraseña creada para su primer ingreso es 0000 ", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta a punto de eliminar un Usuario" + "\n\nDesea Continuar?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {               
                using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM UsuariosGesDoc WHERE Usuario=@Usuario", con);
                    cmd.Parameters.AddWithValue("@Usuario", textBox2.Text);

                    con.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();

                    if (resultado.Read())
                    {
                        SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");

                        string query = "DELETE UsuariosGesDoc WHERE Usuario = @Usuario";
                        con1.Open();
                        SqlCommand cmd1 = new SqlCommand(query, con1);

                        cmd1.Parameters.AddWithValue("@Usuario", textBox2.Text);
                        cmd1.ExecuteNonQuery();
                        con1.Close();

                        MessageBox.Show("Usuario Eliminado Correctamente", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Clear();

                    }
                    else
                    {

                        MessageBox.Show("El Usuario Actualmente, No Existe en la Base de Datos", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("A cancelado la Opcion", "Continuar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text=="")
            {
                MessageBox.Show("Seleccione la Dependencia", "Continuar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UsuariosGesDoc WHERE Usuario=@Usuario", con);
                cmd.Parameters.AddWithValue("@Usuario", textBox3.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");

                    string query = "UPDATE UsuariosGesDoc SET Dependencia = @Dependencia WHERE Usuario = @Usuario";
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand(query, con1);

                    cmd1.Parameters.AddWithValue("@Usuario", textBox3.Text);
                    cmd1.Parameters.AddWithValue("@Dependencia", comboBox2.Text);
                    cmd1.ExecuteNonQuery();
                    con1.Close();

                    MessageBox.Show("Dependencia Actualizada Correctamente", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Clear();
                    comboBox2.SelectedIndex=0;

                        

                }
                else
                {

                    MessageBox.Show("Usuario No Existe...", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dataGridView1);
        }
    }
}
