using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox4, "Seleccione la ultima CAJA de la lista que se muestra");
            this.toolTip1.SetToolTip(this.pictureBox1, "Seleccione la ultima carpeta" + "\nCAD-SA y recuerde cambiar el ultimo digito para ser consecutivo");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = false;
            button10.Visible = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dtpinicial_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpfinal_ValueChanged(object sender, EventArgs e)
        {
            
        }


        public void button4_Click(object sender, EventArgs e)
        {


        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form4();
            Formulario1.Show();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Form5();
            Formulario1.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }
        public void ejecutar(string dato)
        {
            comboBox1.Text = dato;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            
        }
        public void ejecutar1(string dato1)
        {
            //**textBox10.Text = dato1; 
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            if (panel4.Visible == true)
            {
                button10.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");


            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
            cmd1.Parameters.AddWithValue("@Identificacion", txtidentificacion.Text);

            con.Open();
            SqlDataReader resultado1 = cmd1.ExecuteReader();

            if (resultado1.Read())
            {
                if (textBox5.Text == "1 DE 1")
                {
                    MessageBox.Show("Ya Existe esta Historia laboral" + "\n\nRecuerde que para actualizar debe dirigirse al modulo de Historias Laborales >> Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                con.Close();

            }
            
            else
            {
                Process.Start(@"\\ANDRES-AMADO\Serviaseo_1\scan\NAPS2\NAPS2.exe");
            }
            resultado1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                MessageBox.Show("Complete el campo de Nombre", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtidentificacion.Text == "")
            {
                MessageBox.Show("Complete el campo de Identificacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtcargo.Text == "")
            {
                MessageBox.Show("Complete el campo de Cargo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtcausa_retiro.Text == "")
            {
                MessageBox.Show("Complete el campo de Causa de Retiro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Complete el campo de Fecha Inicial", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Complete el campo de Fecha Final", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Complete el campo de Tomo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Seleccione la caja donde quedara archiva la Historia Laboral", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            DialogResult Res = MessageBox.Show("Imprimir caratula?", "Alerta", MessageBoxButtons.YesNo);

            if (Res == DialogResult.Yes)
            {
                
                Form18 frm = new Form18();
                frm.Show();

                frm.label4.Text = textBox16.Text.ToString().ToUpper();
                frm.label3.Text = txtidentificacion.Text.ToString().ToUpper();
                
                
                frm.label5.Text = txtcargo.Text.ToString().ToUpper();
                frm.label6.Text = txtcausa_retiro.Text.ToString().ToUpper();
                frm.label7.Text = textBox5.Text.ToString().ToUpper();
                frm.label10.Text = comboBox1.Text.ToString();
                if (frm.label10.Text == "ESTANTE ACTIVO")
                {
                    frm.label10.Location = new System.Drawing.Point(395, 645); 
                }
                else
                {
                    frm.label10.Location = new System.Drawing.Point(439, 644);
                }
                
                frm.label8.Text = textBox1.Text.ToString().ToUpper();
                frm.label9.Text = textBox2.Text.ToString().ToUpper();
                if (frm.label9.Text == "LABORANDO ACTUALMENTE")
                {
                    frm.label9.Location = new System.Drawing.Point(479, 717);
                }
                else
                {
                    frm.label9.Location = new System.Drawing.Point(547, 716);
                }

                frm.label1.Text = comboBox3.Text.ToString().ToUpper();
                if (frm.label1.Text == "ESTANTE ACTIVO")
                {
                    frm.label1.Location = new System.Drawing.Point(562, 644);
                }
                else
                {
                    frm.label1.Location = new System.Drawing.Point(603, 644);
                }


            }

            if (Res == DialogResult.No)
            {
                
                return;

            }
            button10.Visible = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechai = dtpinicial.Value;
            textBox1.Text = fechai.ToShortDateString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaf = dtpfinal.Value;
            textBox2.Text = fechaf.ToShortDateString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtcausa_retiro.Text = "LABORANDO ACTUALMENTE";
            txtcausa_retiro.Enabled = false;
            textBox2.Text = "LABORANDO ACTUALMENTE";
            textBox2.Enabled = false;
            cbmestado.Text = "ACTIVA";
            cbmestado.Enabled = false;
            textBox6.Text = "ACTIVO";
            textBox6.Enabled = false;
            textBox7.Text = "Estante Activo";
            textBox7.Enabled = false;
            comboBox3.Text = "Estante Activo";
            comboBox3.Enabled= false;
            dtpfinal.Enabled = false;
            comboBox1.Text ="ESTANTE ACTIVO";
            comboBox1.Enabled = false;
            pictureBox4.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 form1 = new Form4();
            form1.pasado += new Form4.pasar(ejecutar);
            form1.ShowDialog();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {            
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select CARPETA from Histrias_Laborales ORDER BY CARPETA ASC";
            comando.CommandTimeout = 160;
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(tabla);
            comboBox2.DataSource = tabla;
            comboBox2.DisplayMember = "Histrias_Laborales";
            comboBox2.ValueMember = "CARPETA";

            if (comboBox2.ValueMember == "CARPETA")
            {
                var ultimo = comboBox2.Items.Count - 1;
                comboBox2.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado
                var valor = comboBox2.SelectedValue;
            }
            conexion.Close();
        }
        
        private void button10_Click(object sender, EventArgs e)
        {

            if (textBox16.Text == "")
            {
                MessageBox.Show("Complete el campo de Nombre", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtidentificacion.Text == "")
            {
                MessageBox.Show("Complete el campo de Identificacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtcargo.Text == "")
            {
                MessageBox.Show("Complete el campo de Cargo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (cbmestado.Text == "")
            {
                MessageBox.Show("Seleccione el Estado de la Historia Laboral", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Seleccione la fecha inicial", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Seleccione la fecha final", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            SqlConnection cons = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");


            SqlCommand cmds = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE CARPETA = @Carpeta", cons);
            cmds.Parameters.AddWithValue("@Carpeta", comboBox2.Text);

            cons.Open();
            SqlDataReader resultados = cmds.ExecuteReader();

            if (resultados.Read())
            {
                MessageBox.Show("Ya Existe la Historia Laboral con codigo de carpeta con "+ comboBox2.Text + "\n\nRecuerde que para actualizar debe dirigirse al modulo de Historias Laborales >> Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            resultados.Close();
            cons.Close();

            SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");


            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
            cmd1.Parameters.AddWithValue("@Identificacion", txtidentificacion.Text);

            con.Open();
            SqlDataReader resultado2 = cmd1.ExecuteReader();

            if (resultado2.Read())
            {
                if (textBox5.Text == "1 DE 1")
                {
                    MessageBox.Show("Ya Existe esta Historia laboral" + "\n\nRecuerde que para actualizar debe dirigirse al modulo de Historias Laborales >> Actualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               else if (textBox5.Text == "1 DE 2")
                {

                    SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                    con1.Open();
                    string query2 = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega ,@estante, @estado)";
                    SqlCommand cmd2 = new SqlCommand(query2, con1);


                    cmd2.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                    cmd2.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                    cmd2.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                    cmd2.Parameters.AddWithValue("@cargo", txtcargo.Text);
                    cmd2.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                    cmd2.Parameters.AddWithValue("@caja", comboBox1.Text);
                    cmd2.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                    cmd2.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                    cmd2.Parameters.AddWithValue("@tomo", textBox5.Text);
                    cmd2.Parameters.AddWithValue("@bodega", textBox6.Text);
                    cmd2.Parameters.AddWithValue("@estante", textBox7.Text);
                    cmd2.Parameters.AddWithValue("@estado", cbmestado.Text);
                    cmd2.ExecuteNonQuery();

                    textBox16.Clear();
                    txtidentificacion.Clear();
                    txtcargo.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtcausa_retiro.Clear();
                    cbmestado.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                    con1.Close();
                }
                else if (textBox5.Text == "1 DE 3")
                {

                    SqlConnection cona = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                    cona.Open();
                    string query2 = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega,@estante, @estado)";
                    SqlCommand cmd3 = new SqlCommand(query2, cona);


                    cmd3.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                    cmd3.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                    cmd3.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                    cmd3.Parameters.AddWithValue("@cargo", txtcargo.Text);
                    cmd3.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                    cmd3.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                    cmd3.Parameters.AddWithValue("@caja", comboBox1.Text);
                    cmd3.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                    cmd3.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                    cmd3.Parameters.AddWithValue("@tomo", textBox5.Text);
                    cmd3.Parameters.AddWithValue("@bodega", textBox6.Text);
                    cmd3.Parameters.AddWithValue("@estante", textBox7.Text);
                    cmd3.Parameters.AddWithValue("@estado", cbmestado.Text);
                    cmd3.ExecuteNonQuery();

                    textBox16.Clear();
                    txtidentificacion.Clear();
                    txtcargo.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtcausa_retiro.Clear();
                    cbmestado.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    comboBox1.Text = "";
                    cona.Close();
                }
                else if (textBox5.Text == "2 DE 2")
                {
                    
                    SqlConnection con2 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                    con2.Open();
                    string query2 = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega,@estante, @estado)";
                    SqlCommand cmd4 = new SqlCommand(query2, con2);


                    cmd4.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                    cmd4.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                    cmd4.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                    cmd4.Parameters.AddWithValue("@cargo", txtcargo.Text);
                    cmd4.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                    cmd4.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                    cmd4.Parameters.AddWithValue("@caja", comboBox1.Text);
                    cmd4.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                    cmd4.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                    cmd4.Parameters.AddWithValue("@tomo", textBox5.Text);
                    cmd4.Parameters.AddWithValue("@bodega", textBox6.Text);
                    cmd4.Parameters.AddWithValue("@estante", textBox7.Text);
                    cmd4.Parameters.AddWithValue("@estado", cbmestado.Text);
                    cmd4.ExecuteNonQuery();

                    textBox16.Clear();
                    txtidentificacion.Clear();
                    txtcargo.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtcausa_retiro.Clear();
                    cbmestado.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    comboBox1.Text = "";
                    con2.Close();
                }
                else if (textBox5.Text == "2 DE 3")
                {

                    SqlConnection con3 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                    con3.Open();
                    string query2 = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega,@estante, @estado)";
                    SqlCommand cmd5 = new SqlCommand(query2, con3);


                    cmd5.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                    cmd5.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                    cmd5.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                    cmd5.Parameters.AddWithValue("@cargo", txtcargo.Text);
                    cmd5.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                    cmd5.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                    cmd5.Parameters.AddWithValue("@caja", comboBox1.Text);
                    cmd5.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                    cmd5.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                    cmd5.Parameters.AddWithValue("@tomo", textBox5.Text);
                    cmd5.Parameters.AddWithValue("@bodega", textBox6.Text);
                    cmd5.Parameters.AddWithValue("@estante", textBox7.Text);
                    cmd5.Parameters.AddWithValue("@estado", cbmestado.Text);
                    cmd5.ExecuteNonQuery();

                    textBox16.Clear();
                    txtidentificacion.Clear();
                    txtcargo.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtcausa_retiro.Clear();
                    cbmestado.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    comboBox1.Text = "";
                    con3.Close();
                }
                else if (textBox5.Text == "3 DE 3")
                {

                    SqlConnection con4 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                    con4.Open();
                    string query2 = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega,@estante, @estado)";
                    SqlCommand cmd6 = new SqlCommand(query2, con4);


                    cmd6.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                    cmd6.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                    cmd6.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                    cmd6.Parameters.AddWithValue("@cargo", txtcargo.Text);
                    cmd6.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                    cmd6.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                    cmd6.Parameters.AddWithValue("@caja", comboBox1.Text);
                    cmd6.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                    cmd6.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                    cmd6.Parameters.AddWithValue("@tomo", textBox5.Text);
                    cmd6.Parameters.AddWithValue("@bodega", textBox6.Text);
                    cmd6.Parameters.AddWithValue("@estante", textBox7.Text);
                    cmd6.Parameters.AddWithValue("@estado", cbmestado.Text);
                    cmd6.ExecuteNonQuery();

                    textBox16.Clear();
                    txtidentificacion.Clear();
                    txtcargo.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtcausa_retiro.Clear();
                    cbmestado.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    comboBox1.Text = "";
                    con4.Close();
                }
                else if (textBox5.Text == "4 DE 4")
                {

                    SqlConnection con5 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                    con5.Open();
                    string query2 = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega,@estante, @estado)";
                    SqlCommand cmd7 = new SqlCommand(query2, con5);


                    cmd7.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                    cmd7.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                    cmd7.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                    cmd7.Parameters.AddWithValue("@cargo", txtcargo.Text);
                    cmd7.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                    cmd7.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                    cmd7.Parameters.AddWithValue("@caja", comboBox1.Text);
                    cmd7.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                    cmd7.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                    cmd7.Parameters.AddWithValue("@tomo", textBox5.Text);
                    cmd7.Parameters.AddWithValue("@bodega", textBox6.Text);
                    cmd7.Parameters.AddWithValue("@estante", textBox7.Text);
                    cmd7.Parameters.AddWithValue("@estado", cbmestado.Text);
                    cmd7.ExecuteNonQuery();

                    textBox16.Clear();
                    txtidentificacion.Clear();
                    txtcargo.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    txtcausa_retiro.Clear();
                    cbmestado.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    comboBox1.Text = "";
                    con5.Close();
                }
                else
                {
                    MessageBox.Show("Ya Existe esta Historia laboral", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                resultado2.Close();
            }
            else
            {
                SqlConnection con6 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                con6.Open();
                string query = "INSERT INTO Histrias_Laborales(NOMBRE_COMPLETO,IDENTIFICACION,CAUSA_DE_RETIRO,CARGO,FECHA_INICAL,FECHA_FINAL,CAJA,CONS_CAJA,CARPETA,TOMO,BODEGA,ESTANTE, ESTADO) VALUES (@nombre_completo, @identificacion, @causa_de_retiro, @cargo, @fecha_inicial, @fecha_final, @caja, @CONS_CAJA, @carpeta, @tomo, @bodega,@estante, @estado)";

                SqlCommand cmd = new SqlCommand(query, con6);


                cmd.Parameters.AddWithValue("@nombre_completo", textBox16.Text);
                cmd.Parameters.AddWithValue("@identificacion", txtidentificacion.Text);
                cmd.Parameters.AddWithValue("@causa_de_retiro", txtcausa_retiro.Text);
                cmd.Parameters.AddWithValue("@cargo", txtcargo.Text);
                cmd.Parameters.AddWithValue("@fecha_inicial", textBox1.Text);
                cmd.Parameters.AddWithValue("@fecha_final", textBox2.Text);
                cmd.Parameters.AddWithValue("@caja", comboBox1.Text);
                cmd.Parameters.AddWithValue("@CONS_CAJA", comboBox3.Text);
                cmd.Parameters.AddWithValue("@carpeta", comboBox2.Text);
                cmd.Parameters.AddWithValue("@tomo", textBox5.Text);
                cmd.Parameters.AddWithValue("@bodega", textBox6.Text);
                cmd.Parameters.AddWithValue("@estante", textBox7.Text);
                cmd.Parameters.AddWithValue("@estado", cbmestado.Text);
                cmd.ExecuteNonQuery();

                textBox16.Clear();
                txtidentificacion.Clear();
                txtcargo.Clear();
                textBox1.Clear();
                textBox2.Clear();
                txtcausa_retiro.Clear();
                cbmestado.SelectedIndex = 0;
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                comboBox1.Text = "";
                comboBox3.Text = "";
                con6.Close();
            }
            




            DialogResult result = MessageBox.Show("Datos Almacenados Correctamente" + "\n\nDesea Crear otra Historia Laboral?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                panel2b.Visible = false;
                

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Gracias por hacer uso correcto de nuestra aplicacion", "Agradecimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel2b.Visible = false;
                
            }
            

        }

        private void panel2b_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
