using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string Path = @"E:\";
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (txtiden.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion a Consultar", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            
            if (Directory.Exists(Path + txtiden.Text))
            {
                DirectoryInfo di = new DirectoryInfo(Path + txtiden.Text);
                pictureBox2.Image = Image.FromFile(di + @"\" + txtiden.Text + ".JPG");
               
                foreach (var item in di.GetFiles("*.pdf"))
                {

                    comboBox2.Items.Add(item.Name);
                }
            }
            else
            {
               
                MessageBox.Show("Archivo Sin imagenes ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {



                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", txtiden.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    panel2.Visible = true;
                    panel1.Visible = false;
                    textBox1.Enabled = false;
                    dtpinicial.Enabled = false;




                    txtnombre_completo.Text = resultado["NOMBRE_COMPLETO"].ToString();
                    textBox3.Text = resultado["IDENTIFICACION"].ToString();
                    txtcausa_retiro.Text = resultado["CAUSA_DE_RETIRO"].ToString();
                    txtcargo.Text = resultado["CARGO"].ToString();
                    textBox1.Text = resultado["FECHA_INICAL"].ToString();
                    textBox2.Text = resultado["FECHA_FINAL"].ToString();
                    textBox8.Text = resultado["CAJA"].ToString();
                    textBox9.Text = resultado["CONS_CAJA"].ToString();
                    textBox4.Text = resultado["CARPETA"].ToString();
                    comboBox1.Text = resultado["TOMO"].ToString();
                    textBox6.Text = resultado["BODEGA"].ToString();
                    textBox7.Text = resultado["ESTANTE"].ToString();
                    cbmestado.Text = resultado["ESTADO"].ToString();
                    

                    MessageBox.Show("Datos Encontrados", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    if (txtiden.Text == "1 DE 1")
                    {

                        MessageBox.Show("Historia Laboral con un Tomo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (txtiden.Text != "1 DE 1")
                    {
                       
                        MessageBox.Show("Historia Laboral con mas de un Tomo"+"\n\nRecuerde Seleccionar el Tomo que va a modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand comando = new SqlCommand();
                        DataTable tabla = new DataTable();

                        SqlConnection conexion = new SqlConnection();
                        conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
                        conexion.Open();
                        comando.Connection = conexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = "Select * from Histrias_Laborales where identificacion =@identificacion";
                        comando.Parameters.AddWithValue("@Identificacion", txtiden.Text);
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        adaptador.Fill(tabla);
                        comboBox1.DataSource = tabla;
                        comboBox1.DisplayMember = "Histrias_Laborales";
                        comboBox1.ValueMember = "TOMO";

                        if (comboBox1.ValueMember == "TOMO")
                        {
                            var ultimo = comboBox1.Items.Count - 1;


                        }
                        

                    }
                   

                }
                else
                {
                    panel2.Visible = false;
                    MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
        }

        private void dtpinicial_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {



        }

        private void Form7_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                   

        }

        private void button1_Click(object sender, EventArgs e)
        {
           


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cbmestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbmestado.SelectedIndex == 1)
            {
                textBox2.Enabled = false;
                textBox2.Text = "LABORANDO ACTUALMENTE";
                dtpfinal.Enabled = false;

                MessageBox.Show("Recuerde Realizar la solicitud de la Historia Laboral Fisica." + "\n\nDesde el modulo PRESTAMOS", "Recordatorio", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                textBox2.Enabled = true;
                dtpfinal.Enabled = true;
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

            MessageBox.Show("Recuerde cargar las imagenes correspondientes a la Historia Laboral" + "\n\nCon Numero De Cedula " + textBox3.Text, "Recordatorio", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(@"\\ANDRES-AMADO\Serviaseo_1\scan\NAPS2\NAPS2.exe");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");


            string query = "UPDATE Histrias_Laborales SET NOMBRE_COMPLETO = @nombre_completo, IDENTIFICACION = @Identificacion, CAUSA_DE_RETIRO = @causa_de_retiro, CARGO = @cargo, FECHA_INICAL = @fecha_inicial, FECHA_FINAL = @fecha_final, CAJA = @caja, CONS_CAJA = @CONS_CAJA, CARPETA = @carpeta, TOMO = @Tomo, BODEGA = @bodega, ESTANTE = @estante, ESTADO = @estado WHERE IDENTIFICACION = @identificacion AND TOMO = @Tomo";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@nombre_completo", txtnombre_completo.Text);
            cmd.Parameters.AddWithValue("@Identificacion", textBox3.Text);
            cmd.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
            cmd.Parameters.AddWithValue("@cargo", txtcargo.Text);
            cmd.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
            cmd.Parameters.AddWithValue("@fecha_final", textBox2.Text);
            cmd.Parameters.AddWithValue("@caja", textBox8.Text);
            cmd.Parameters.AddWithValue("@CONS_CAJA", textBox9.Text);
            cmd.Parameters.AddWithValue("@carpeta", textBox4.Text);
            cmd.Parameters.AddWithValue("@Tomo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@bodega", textBox6.Text);
            cmd.Parameters.AddWithValue("@estante", textBox7.Text);
            cmd.Parameters.AddWithValue("@estado", cbmestado.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            txtnombre_completo.Clear();
            textBox3.Clear();
            txtcausa_retiro.Clear();
            txtcargo.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = 0;
            textBox6.Clear();
            textBox7.Clear();
            
            cbmestado.SelectedIndex = 0;

            DialogResult result = MessageBox.Show("Datos Actualizados Correctamente" + "\n\nDesea Actualizar otra Historia Laboral?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Gracias por hacer uso correcto de nuestra aplicacion", "Agradecimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel2.Visible = false;
                panel1.Visible = false;
            }

        }

        private void dtpinicial_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime fechai = dtpinicial.Value;
            textBox1.Text = fechai.ToShortDateString();

        }

        private void dtpfinal_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaf = dtpfinal.Value;
            textBox2.Text = fechaf.ToShortDateString();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "LABORANDO ACTUALMENTE";
            textBox2.Enabled = false;
            dtpfinal.Enabled = false;
            textBox9.Text = "Estante Activo";
            textBox9.Enabled = false;
            textBox7.Text = "Estante Activo";
            textBox7.Enabled = false;
            textBox6.Text = "ACTIVO";
            textBox6.Enabled = false;
            cbmestado.Text = "ACTIVO";
            cbmestado.Enabled = false;



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "1 DE 1")
            {
                using (SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE TOMO = @Tomo AND Identificacion = @Identificacion", con1);
                    cmd.Parameters.AddWithValue("@Tomo", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Identificacion", textBox3.Text);

                    con1.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();

                    if (resultado.Read())
                    {
                        textBox1.Text = resultado["FECHA_INICAL"].ToString();
                        textBox2.Text = resultado["FECHA_FINAL"].ToString();
                        textBox4.Text = resultado["CARPETA"].ToString();
                        txtcausa_retiro.Text = resultado["CAUSA_DE_RETIRO"].ToString();
                        txtcargo.Text = resultado["CARGO"].ToString();
                    }
                }
            }
        }

        private void txtiden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtiden.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese la Identificacion a Consultar", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                if (Directory.Exists(Path + txtiden.Text))
                {
                    DirectoryInfo di = new DirectoryInfo(Path + txtiden.Text);
                    
                        pictureBox2.Image = Image.FromFile(di + @"\" + txtiden.Text + ".JPG");
                   

                    foreach (var item in di.GetFiles("*.pdf"))
                    {

                        comboBox2.Items.Add(item.Name);
                    }
                }
                
                else
                {
                    comboBox2.Text = "SIN IMAGENES";
                    comboBox2.Enabled = false;
                    MessageBox.Show("Archivo Sin imagenes ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
                using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {



                    SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd.Parameters.AddWithValue("@Identificacion", txtiden.Text);

                    con.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();

                    if (resultado.Read())
                    {
                        panel2.Visible = true;
                        panel1.Visible = false;
                        textBox1.Enabled = false;
                        dtpinicial.Enabled = false;




                        txtnombre_completo.Text = resultado["NOMBRE_COMPLETO"].ToString();
                        textBox3.Text = resultado["IDENTIFICACION"].ToString();
                        txtcausa_retiro.Text = resultado["CAUSA_DE_RETIRO"].ToString();
                        txtcargo.Text = resultado["CARGO"].ToString();
                        textBox1.Text = resultado["FECHA_INICAL"].ToString();
                        textBox2.Text = resultado["FECHA_FINAL"].ToString();
                        textBox8.Text = resultado["CAJA"].ToString();
                        textBox9.Text = resultado["CONS_CAJA"].ToString();
                        textBox4.Text = resultado["CARPETA"].ToString();
                        comboBox1.Text = resultado["TOMO"].ToString();
                        textBox6.Text = resultado["BODEGA"].ToString();
                        textBox7.Text = resultado["ESTANTE"].ToString();
                        cbmestado.Text = resultado["ESTADO"].ToString();


                        MessageBox.Show("Datos Encontrados", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        if (txtiden.Text == "1 DE 1")
                        {

                            MessageBox.Show("Historia Laboral con un Tomo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else if (txtiden.Text != "1 DE 1")
                        {

                            MessageBox.Show("Historia Laboral con mas de un Tomo" + "\n\nRecuerde Seleccionar el Tomo que va a modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SqlCommand comando = new SqlCommand();
                            DataTable tabla = new DataTable();

                            SqlConnection conexion = new SqlConnection();
                            conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
                            conexion.Open();
                            comando.Connection = conexion;
                            comando.CommandType = CommandType.Text;
                            comando.CommandText = "Select * from Histrias_Laborales where identificacion =@identificacion";
                            comando.Parameters.AddWithValue("@Identificacion", txtiden.Text);
                            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                            adaptador.Fill(tabla);
                            comboBox1.DataSource = tabla;
                            comboBox1.DisplayMember = "Histrias_Laborales";
                            comboBox1.ValueMember = "TOMO";

                            if (comboBox1.ValueMember == "TOMO")
                            {
                                var ultimo = comboBox1.Items.Count - 1;


                            }


                        }


                    }
                    else
                    {
                        panel2.Visible = false;
                        MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }
        }
        public void ejecutar(string dato)
        {
            textBox8.Text = dato;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 form1 = new Form4();
            form1.pasado += new Form4.pasar(ejecutar);
            form1.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerde cargar las imagenes correspondientes a la Historia Laboral" + "\n\nCon Numero De Cedula " + textBox3.Text+"El Anexo: "+ comboBox2.Text, "Recordatorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
             Process.Start(@"\\ANDRES-AMADO\Serviaseo_1\scan\NAPS2\NAPS2.exe");
        }
    }
}
