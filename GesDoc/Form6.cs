using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox3, "Click, Para Buscar Por Apellido");
        }
        string Path = @"E:\";
        private void Form6_Load(object sender, EventArgs e)
        {
            panel22.Visible = false;
            if (Form1.Usuario =="ADRIANA.GOMEZ")
            {
                pictureBox2.Enabled = true;
                pictureBox2.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        internal static string Img;
        internal static string cc;
   

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void axAcroPDF2_Enter(object sender, EventArgs e)
        {
            Img = txtnombre_completo.Text;
            cc = textBox3.Text;

            Form13 fm = new Form13();
            fm.Show();
        }

        
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Ingrese los datos a consultar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Directory.Exists(Path + txtid.Text))
            {
                

                DirectoryInfo di = new DirectoryInfo(Path + txtid.Text);

                  pictureBox1.Image = Image.FromFile(di + @"\" + txtid.Text + ".JPG");
                
                foreach (var item in di.GetFiles("*.pdf"))
                {

                    comboBox1.Items.Add(item.Name);
                    
                  
                }
            }
            else
            {
                MessageBox.Show("Archivo Sin imagenes ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {


                    SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd.Parameters.AddWithValue("@Identificacion", txtid.Text);

                    con.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();

                    if (resultado.Read())
                    {
                    
                        panel22.Visible = true;
                        panel1.Visible = false;

                        txtnombre_completo.Enabled = false;
                        textBox3.Enabled = false;
                        txtcausa_retiro.Enabled = false;
                        txtcargo.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox8.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                        textBox6.Enabled = false;
                        textBox7.Enabled = false;
                        textBox9.Enabled = false;
                        textBox10.Enabled = false;



                        txtnombre_completo.Text = resultado["NOMBRE_COMPLETO"].ToString();
                        textBox3.Text = resultado["IDENTIFICACION"].ToString();
                        txtcausa_retiro.Text = resultado["CAUSA_DE_RETIRO"].ToString();
                        txtcargo.Text = resultado["CARGO"].ToString();
                        textBox1.Text = resultado["FECHA_INICAL"].ToString();
                        textBox2.Text = resultado["FECHA_FINAL"].ToString();
                        textBox8.Text = resultado["CAJA"].ToString();
                        textBox10.Text = resultado["CONS_CAJA"].ToString();
                        textBox4.Text = resultado["CARPETA"].ToString();
                        textBox5.Text = resultado["TOMO"].ToString();
                        textBox6.Text = resultado["BODEGA"].ToString();
                        textBox7.Text = resultado["ESTANTE"].ToString();
                        textBox9.Text = resultado["ESTADO"].ToString();
                        label19.Text = resultado["ESTADO_PRE"].ToString();
                        label20.Text = resultado["AREASOL"].ToString();

                        if (label19.Text == "PRESTAMO DEFINITIVO")
                        {
                            MessageBox.Show("Historia Laboral en Prestamo solicitado por el area " + label20.Text, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        if (label19.Text == "PRESTAMO TEMPORAL")
                        {
                            MessageBox.Show("Historia Laboral en Prestamo solicitado por el area " + label20.Text, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }


                        if (textBox5.Text == "1 DE 1")
                        {

                            comboBox2.Text = textBox5.Text;
                            MessageBox.Show("Historia Laboral con un Tomo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (textBox5.Text != "1 DE 1")
                        {

                            MessageBox.Show("Historia Laboral con mas de un Tomo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SqlCommand comando = new SqlCommand();
                            DataTable tabla = new DataTable();

                            SqlConnection conexion = new SqlConnection();
                            conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
                            conexion.Open();
                            comando.Connection = conexion;
                            comando.CommandType = CommandType.Text;
                            comando.CommandText = "Select * from Histrias_Laborales where identificacion =@identificacion";
                            comando.Parameters.AddWithValue("@Identificacion", txtid.Text);
                            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                            adaptador.Fill(tabla);
                            comboBox2.DataSource = tabla;
                            comboBox2.DisplayMember = "Histrias_Laborales";
                            comboBox2.ValueMember = "TOMO";

                            if (comboBox2.ValueMember == "TOMO")
                            {
                                var ultimo = comboBox2.Items.Count - 1;


                            }


                        }


                }

            }
           

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            

            

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

           

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Img = txtnombre_completo.Text;
            cc = textBox3.Text;

            Form13 fm = new Form13();
            fm.Show();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "1 DE 1")
            {
                using (SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE TOMO = @Tomo AND Identificacion = @Identificacion", con1);
                    cmd.Parameters.AddWithValue("@Tomo", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Identificacion", textBox3.Text);

                    con1.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();

                    if (resultado.Read())
                    {
                        textBox1.Text = resultado["FECHA_INICAL"].ToString();
                        textBox2.Text = resultado["FECHA_FINAL"].ToString();
                        textBox4.Text = resultado["CARPETA"].ToString();
                        comboBox2.Text = resultado["TOMO"].ToString();
                        txtcausa_retiro.Text = resultado["CAUSA_DE_RETIRO"].ToString();
                        txtcargo.Text = resultado["CARGO"].ToString();
                    }
                }
            }
            

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void axAcroPDF2_Enter_1(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            Process.Start(@"\\ANDRES-AMADO\Serviaseo_1\scan\NAPS2\NAPS2.exe");
        }

        private void txtid_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Directory.Exists(Path + txtid.Text))
                {
                    DirectoryInfo di = new DirectoryInfo(Path + txtid.Text);

         
                        pictureBox1.Image = Image.FromFile(di + @"\" + txtid.Text + ".JPG");
                  
                    foreach (var item in di.GetFiles("*.pdf"))
                    {
                        comboBox1.Items.Add(item.Name);
                    }
                }
                else
                {
                    MessageBox.Show("Archivo Sin imagenes ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {


                    SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd.Parameters.AddWithValue("@Identificacion", txtid.Text);

                    con.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();

                    if (resultado.Read())
                    {




                        panel22.Visible = true;
                        panel1.Visible = false;

                        txtnombre_completo.Enabled = false;
                        textBox3.Enabled = false;
                        txtcausa_retiro.Enabled = false;
                        txtcargo.Enabled = false;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox8.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                        textBox6.Enabled = false;
                        textBox7.Enabled = false;
                        textBox9.Enabled = false;
                        textBox10.Enabled = false;



                        txtnombre_completo.Text = resultado["NOMBRE_COMPLETO"].ToString();
                        textBox3.Text = resultado["IDENTIFICACION"].ToString();
                        txtcausa_retiro.Text = resultado["CAUSA_DE_RETIRO"].ToString();
                        txtcargo.Text = resultado["CARGO"].ToString();
                        textBox1.Text = resultado["FECHA_INICAL"].ToString();
                        textBox2.Text = resultado["FECHA_FINAL"].ToString();
                        textBox8.Text = resultado["CAJA"].ToString();
                        textBox10.Text = resultado["CONS_CAJA"].ToString();
                        textBox4.Text = resultado["CARPETA"].ToString();
                        textBox5.Text = resultado["TOMO"].ToString();
                        textBox6.Text = resultado["BODEGA"].ToString();
                        textBox7.Text = resultado["ESTANTE"].ToString();
                        textBox9.Text = resultado["ESTADO"].ToString();
                        label19.Text = resultado["ESTADO_PRE"].ToString();
                        label20.Text = resultado["AREASOL"].ToString();

                        if (label19.Text == "PRESTAMO DEFINITIVO")
                        {
                            MessageBox.Show("Historia Laboral en Prestamo solicitado por el area " + label20.Text, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        if (label19.Text == "PRESTAMO TEMPORAL")
                        {
                            MessageBox.Show("Historia Laboral en Prestamo solicitado por el area " + label20.Text, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }


                        if (textBox5.Text == "1 DE 1")
                        {

                            comboBox2.Text = textBox5.Text;
                            MessageBox.Show("Historia Laboral con un Tomo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (textBox5.Text != "1 DE 1")
                        {

                            MessageBox.Show("Historia Laboral con mas de un Tomo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SqlCommand comando = new SqlCommand();
                            DataTable tabla = new DataTable();

                            SqlConnection conexion = new SqlConnection();
                            conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
                            conexion.Open();
                            comando.Connection = conexion;
                            comando.CommandType = CommandType.Text;
                            comando.CommandText = "Select * from Histrias_Laborales where identificacion =@identificacion";
                            comando.Parameters.AddWithValue("@Identificacion", txtid.Text);
                            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                            adaptador.Fill(tabla);
                            comboBox2.DataSource = tabla;
                            comboBox2.DisplayMember = "Histrias_Laborales";
                            comboBox2.ValueMember = "TOMO";

                            if (comboBox2.ValueMember == "TOMO")
                            {
                                var ultimo = comboBox2.Items.Count - 1;


                            }


                        }


                    }
                    else
                    {
                        panel22.Visible = false;
                        MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }

        private void pictureBox3_Click_2(object sender, EventArgs e)
        {
            Form Formulario1 = new Form17();
            Formulario1.Show();
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Path + txtid.Text);

            System.Diagnostics.Process.Start(di + label21.Text + comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            panel22.Visible = false;
            panel1.Visible = true;
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
    }
}
