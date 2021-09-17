using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        DateTime hoy = DateTime.Now;
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            labelu.Text = Form1.Usuario;
            labelf.Text = hoy.ToShortDateString();
            
           
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                if (textBox2.Text != "")
                {
                                    
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label50.Visible = true;
                    textBox3.Visible = true;
                    comboBox2.Visible = true;
                    textBox4.Visible = true;
                    textBox34.Visible = true;

                }
                else
                {
                    MessageBox.Show("Debe Completar la cantidad de folios", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe Completar el Campo de Identificacion", "Perfecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           if (textBox3.Text != "")
            {

                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label51.Visible = true;
                textBox5.Visible = true;
                comboBox3.Visible = true;
                textBox6.Visible = true;
                textBox35.Visible = true;
            }
            if (textBox5.Text != "")
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                textBox7.Visible = true;
                comboBox4.Visible = true;
                textBox8.Visible = true;
                textBox36.Visible = true;
                label52.Visible = true;
            }
           if (textBox7.Text != "")
            {
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                textBox9.Visible = true;
                comboBox5.Visible = true;
                textBox10.Visible = true;
                textBox37.Visible = true;
                label53.Visible = true;
            }
            if (textBox9.Text != "")
            {
                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                textBox11.Visible = true;
                comboBox6.Visible = true;
                textBox12.Visible = true;
                textBox38.Visible = true;
                label54.Visible = true;
            }
            if (textBox11.Text != "")
            {
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                textBox13.Visible = true;
                comboBox7.Visible = true;
                textBox14.Visible = true;
                textBox39.Visible = true;
                label55.Visible = true;
            }
            if (textBox13.Text != "")
            {
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                textBox15.Visible = true;
                comboBox8.Visible = true;
                textBox16.Visible = true;
                textBox40.Visible = true;
                label56.Visible = true;
            }
            if (textBox15.Text != "")
            {
                label25.Visible = true;
                label26.Visible = true;
                label27.Visible = true;
                textBox17.Visible = true;
                comboBox9.Visible = true;
                textBox18.Visible = true;
                textBox41.Visible = true;
                label57.Visible = true;
            }
            if (textBox17.Text != "")
            {
                label28.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
                textBox19.Visible = true;
                comboBox10.Visible = true;
                textBox20.Visible = true;
                textBox42.Visible = true;
                label58.Visible = true;
            }
            if (textBox19.Text != "")
            {
                label31.Visible = true;
                label32.Visible = true;
                label33.Visible = true;
                textBox21.Visible = true;
                comboBox11.Visible = true;
                textBox22.Visible = true;
                textBox43.Visible = true;
                label59.Visible = true;
            }
            if (textBox21.Text != "")
            {
                label34.Visible = true;
                label35.Visible = true;
                label36.Visible = true;
                textBox23.Visible = true;
                comboBox12.Visible = true;
                textBox24.Visible = true;
                textBox44.Visible = true;
                label60.Visible = true;
            }
            if (textBox23.Text != "")
            {
                label37.Visible = true;
                label38.Visible = true;
                label39.Visible = true;
                textBox25.Visible = true;
                comboBox13.Visible = true;
                textBox26.Visible = true;
                textBox45.Visible = true;
                label61.Visible = true;
            }
            if (textBox25.Text != "")
            {
                label40.Visible = true;
                label41.Visible = true;
                label42.Visible = true;
                textBox27.Visible = true;
                comboBox14.Visible = true;
                textBox28.Visible = true;
                textBox46.Visible = true;
                label62.Visible = true;
            }
            if (textBox27.Text != "")
            {
                label43.Visible = true;
                label44.Visible = true;
                label45.Visible = true;
                textBox29.Visible = true;
                comboBox15.Visible = true;
                textBox30.Visible = true;
                textBox47.Visible = true;
                label63.Visible = true;
            }
            if (textBox29.Text != "")
            {
                label46.Visible = true;
                label47.Visible = true;
                label48.Visible = true;
                textBox31.Visible = true;
                comboBox16.Visible = true;
                textBox32.Visible = true;
                textBox48.Visible = true;
                label64.Visible = true;
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox1.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox3.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox5.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox7.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox9.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox11.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox13.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox15.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox9_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox17.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox10_Click(object sender, EventArgs e)
        {
            if (textBox19.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox19.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox11_Click(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox21.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox12_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox23.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox13_Click(object sender, EventArgs e)
        {
            if (textBox25.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox25.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox14_Click(object sender, EventArgs e)
        {
            if (textBox27.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox27.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox15_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox29.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        private void comboBox16_Click(object sender, EventArgs e)
        {
            if (textBox31.Text == "")
            {
                MessageBox.Show("Por favor Ingrese la Identificacion ", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", textBox31.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("La identificacion no registrada en la base de datos", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                con.Close();
            }
        }

        string dato1;
        string dato2;
        string dato3;
        string dato4;
        string dato5;
        string dato6;
        string dato7;
        string dato8;
        string dato9;
        string dato10;
        string dato11;
        string dato12;
        string dato13;
        string dato14;
        string dato15;
        string dato16;
        string dato17;
        string dato18;
        string dato19;
        string dato20;
        string dato21;
        string dato22;
        string dato23;
        string dato24;
        string dato25;
        string dato26;
        string dato27;
        string dato28;
        string dato29;
        string dato30;
        string dato31;
        string dato32;
        string dato33;
        string dato34;
        string dato35;
        string dato36;
        string dato37;
        string dato38;
        string dato39;
        string dato40;
        string dato41;
        string dato42;
        string dato43;
        string dato44;
        string dato45;
        string dato46;
        string dato47;
        string dato48;
        string dato49;
        string dato50;
        string dato51;
        string dato52;
        string dato53;
        string dato54;
        string dato55;
        string dato56;
        string dato57;
        string dato58;
        string dato59;
        string dato60;
        string dato61;
        string dato62;
        string dato63;
        string dato64;
        string dato65;
        string dato66;
        string dato67;
        string dato68;
        string dato69;
        string dato70;
        string dato71;
        string dato72;
        string dato73;
        string dato74;
        string dato75;
        string dato76;
        string dato77;
        string dato78;
        string dato79;
        string dato80;

        string correo1;
        string correo2;
        string correo3;
        string correo4;
        string correo5;
        string correo6;
        string correo7;
        string correo8;
        string correo9;
        string correo10;
        string correo11;
        string correo12;
        string correo13;
        string correo14;
        string correo15;
        string correo16;


        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**; MultipleActiveResultSets=true"))
            {
                if (textBox1.Text != "")
                {

                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox1.Text);

                    con.Open();
                    SqlDataReader resultado1 = cmd1.ExecuteReader();

                    if (resultado1.Read())
                    {
                        string query = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd2 = new SqlCommand(query, con);
                        cmd2.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado1["NOMBRE_COMPLETO"].ToString());
                        cmd2.Parameters.AddWithValue("@identificacion", textBox1.Text);
                        cmd2.Parameters.AddWithValue("@TIPOD", comboBox1.Text);
                        cmd2.Parameters.AddWithValue("@FOLIOS", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd2.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd2.Parameters.AddWithValue("@Descripcion", textBox33.Text);

                        cmd2.ExecuteNonQuery();

                        dato1 = resultado1["NOMBRE_COMPLETO"].ToString();
                        dato2 = textBox1.Text;
                        dato3 = comboBox1.Text;
                        dato4 = textBox2.Text;
                        dato65 = textBox33.Text;

                    }
                    con.Close();

                }

                if (textBox3.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox3.Text);

                    con.Open();
                    SqlDataReader resultado2 = cmd1.ExecuteReader();

                    if (resultado2.Read())
                    {
                        string query2 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd3 = new SqlCommand(query2, con);
                        cmd3.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado2["NOMBRE_COMPLETO"].ToString());
                        cmd3.Parameters.AddWithValue("@identificacion", textBox3.Text);
                        cmd3.Parameters.AddWithValue("@TIPOD", comboBox2.Text);
                        cmd3.Parameters.AddWithValue("@FOLIOS", textBox4.Text);
                        cmd3.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd3.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd3.Parameters.AddWithValue("@Descripcion", textBox34.Text);
                        cmd3.ExecuteNonQuery();

                        dato5 = resultado2["NOMBRE_COMPLETO"].ToString();
                        dato6 = textBox3.Text;
                        dato7 = comboBox2.Text;
                        dato8 = textBox4.Text;
                        dato66 = textBox34.Text;
                    }
                    con.Close();

                }
                if (textBox5.Text != "")
                {


                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox5.Text);

                    con.Open();
                    SqlDataReader resultado3 = cmd1.ExecuteReader();

                    if (resultado3.Read())
                    {
                        string query3 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd4 = new SqlCommand(query3, con);
                        cmd4.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado3["NOMBRE_COMPLETO"].ToString());
                        cmd4.Parameters.AddWithValue("@identificacion", textBox5.Text);
                        cmd4.Parameters.AddWithValue("@TIPOD", comboBox3.Text);
                        cmd4.Parameters.AddWithValue("@FOLIOS", textBox6.Text);
                        cmd4.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd4.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd4.Parameters.AddWithValue("@Descripcion", textBox35.Text);

                        cmd4.ExecuteNonQuery();
                        dato9 = resultado3["NOMBRE_COMPLETO"].ToString();
                        dato10 = textBox5.Text;
                        dato11 = comboBox3.Text;
                        dato12 = textBox6.Text;
                        dato67 = textBox35.Text;

                    }
                    con.Close();


                }
                if (textBox7.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox7.Text);

                    con.Open();
                    SqlDataReader resultado4 = cmd1.ExecuteReader();

                    if (resultado4.Read())
                    {
                        string query4 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd5 = new SqlCommand(query4, con);
                        cmd5.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado4["NOMBRE_COMPLETO"].ToString());
                        cmd5.Parameters.AddWithValue("@identificacion", textBox7.Text);
                        cmd5.Parameters.AddWithValue("@TIPOD", comboBox4.Text);
                        cmd5.Parameters.AddWithValue("@FOLIOS", textBox8.Text);
                        cmd5.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd5.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd5.Parameters.AddWithValue("@Descripcion", textBox36.Text);
                        cmd5.ExecuteNonQuery();
                        dato13 = resultado4["NOMBRE_COMPLETO"].ToString();
                        dato14 = textBox7.Text;
                        dato15 = comboBox4.Text;
                        dato16 = textBox8.Text;
                        dato68 = textBox36.Text;

                    }
                    con.Close();


                }
                if (textBox9.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox9.Text);

                    con.Open();
                    SqlDataReader resultado5 = cmd1.ExecuteReader();

                    if (resultado5.Read())
                    {
                        string query5 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd6 = new SqlCommand(query5, con);
                        cmd6.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado5["NOMBRE_COMPLETO"].ToString());
                        cmd6.Parameters.AddWithValue("@identificacion", textBox9.Text);
                        cmd6.Parameters.AddWithValue("@TIPOD", comboBox5.Text);
                        cmd6.Parameters.AddWithValue("@FOLIOS", textBox10.Text);
                        cmd6.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd6.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd6.Parameters.AddWithValue("@Descripcion", textBox37.Text);
                        cmd6.ExecuteNonQuery();
                        dato17 = resultado5["NOMBRE_COMPLETO"].ToString();
                        dato18 = textBox9.Text;
                        dato19 = comboBox5.Text;
                        dato20 = textBox10.Text;
                        dato69 = textBox37.Text;

                    }
                    con.Close();


                }
                if (textBox11.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox11.Text);

                    con.Open();
                    SqlDataReader resultado6 = cmd1.ExecuteReader();

                    if (resultado6.Read())
                    {
                        string query6 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd7 = new SqlCommand(query6, con);
                        cmd7.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado6["NOMBRE_COMPLETO"].ToString());
                        cmd7.Parameters.AddWithValue("@identificacion", textBox11.Text);
                        cmd7.Parameters.AddWithValue("@TIPOD", comboBox6.Text);
                        cmd7.Parameters.AddWithValue("@FOLIOS", textBox12.Text);
                        cmd7.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd7.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd7.Parameters.AddWithValue("@Descripcion", textBox38.Text);
                        cmd7.ExecuteNonQuery();
                        dato21 = resultado6["NOMBRE_COMPLETO"].ToString();
                        dato22 = textBox11.Text;
                        dato23 = comboBox6.Text;
                        dato24 = textBox12.Text;
                        dato70 = textBox38.Text;

                    }
                    con.Close();


                }
                if (textBox13.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox13.Text);

                    con.Open();
                    SqlDataReader resultado7 = cmd1.ExecuteReader();

                    if (resultado7.Read())
                    {
                        string query7 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd8 = new SqlCommand(query7, con);
                        cmd8.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado7["NOMBRE_COMPLETO"].ToString());
                        cmd8.Parameters.AddWithValue("@identificacion", textBox13.Text);
                        cmd8.Parameters.AddWithValue("@TIPOD", comboBox7.Text);
                        cmd8.Parameters.AddWithValue("@FOLIOS", textBox14.Text);
                        cmd8.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd8.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd8.Parameters.AddWithValue("@Descripcion", textBox39.Text);
                        cmd8.ExecuteNonQuery();
                        dato25 = resultado7["NOMBRE_COMPLETO"].ToString();
                        dato26 = textBox13.Text;
                        dato27 = comboBox7.Text;
                        dato28 = textBox14.Text;
                        dato71 = textBox39.Text;

                    }
                    con.Close();


                }
                if (textBox15.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox15.Text);

                    con.Open();
                    SqlDataReader resultado8 = cmd1.ExecuteReader();

                    if (resultado8.Read())
                    {
                        string query8 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd9 = new SqlCommand(query8, con);
                        cmd9.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado8["NOMBRE_COMPLETO"].ToString());
                        cmd9.Parameters.AddWithValue("@identificacion", textBox15.Text);
                        cmd9.Parameters.AddWithValue("@TIPOD", comboBox8.Text);
                        cmd9.Parameters.AddWithValue("@FOLIOS", textBox16.Text);
                        cmd9.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd9.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd9.Parameters.AddWithValue("@Descripcion", textBox40.Text);
                        cmd9.ExecuteNonQuery();
                        dato29 = resultado8["NOMBRE_COMPLETO"].ToString();
                        dato30 = textBox15.Text;
                        dato31 = comboBox8.Text;
                        dato32 = textBox16.Text;
                        dato72 = textBox40.Text;

                    }
                    con.Close();


                }
                if (textBox17.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox17.Text);

                    con.Open();
                    SqlDataReader resultado9 = cmd1.ExecuteReader();

                    if (resultado9.Read())
                    {
                        string query9 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd10 = new SqlCommand(query9, con);
                        cmd10.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado9["NOMBRE_COMPLETO"].ToString());
                        cmd10.Parameters.AddWithValue("@identificacion", textBox17.Text);
                        cmd10.Parameters.AddWithValue("@TIPOD", comboBox9.Text);
                        cmd10.Parameters.AddWithValue("@FOLIOS", textBox18.Text);
                        cmd10.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd10.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd10.Parameters.AddWithValue("@Descripcion", textBox41.Text);
                        cmd10.ExecuteNonQuery();
                        dato33 = resultado9["NOMBRE_COMPLETO"].ToString();
                        dato34 = textBox17.Text;
                        dato35 = comboBox9.Text;
                        dato36 = textBox18.Text;
                        dato73 = textBox41.Text;

                    }
                    con.Close();


                }
                if (textBox19.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox19.Text);

                    con.Open();
                    SqlDataReader resultado10 = cmd1.ExecuteReader();

                    if (resultado10.Read())
                    {
                        string query10 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd11 = new SqlCommand(query10, con);
                        cmd11.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado10["NOMBRE_COMPLETO"].ToString());
                        cmd11.Parameters.AddWithValue("@identificacion", textBox19.Text);
                        cmd11.Parameters.AddWithValue("@TIPOD", comboBox10.Text);
                        cmd11.Parameters.AddWithValue("@FOLIOS", textBox20.Text);
                        cmd11.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd11.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd11.Parameters.AddWithValue("@Descripcion", textBox42.Text);
                        cmd11.ExecuteNonQuery();
                        dato37 = resultado10["NOMBRE_COMPLETO"].ToString();
                        dato38 = textBox19.Text;
                        dato39 = comboBox10.Text;
                        dato40 = textBox20.Text;
                        dato74 = textBox42.Text;


                    }
                    con.Close();


                }
                if (textBox21.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox21.Text);

                    con.Open();
                    SqlDataReader resultado11 = cmd1.ExecuteReader();

                    if (resultado11.Read())
                    {
                        string query11 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd12 = new SqlCommand(query11, con);
                        cmd12.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado11["NOMBRE_COMPLETO"].ToString());
                        cmd12.Parameters.AddWithValue("@identificacion", textBox21.Text);
                        cmd12.Parameters.AddWithValue("@TIPOD", comboBox11.Text);
                        cmd12.Parameters.AddWithValue("@FOLIOS", textBox22.Text);
                        cmd12.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd12.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd12.Parameters.AddWithValue("@Descripcion", textBox43.Text);
                        cmd12.ExecuteNonQuery();
                        dato41 = resultado11["NOMBRE_COMPLETO"].ToString();
                        dato42 = textBox21.Text;
                        dato43 = comboBox11.Text;
                        dato44 = textBox22.Text;
                        dato75 = textBox43.Text;


                    }
                    con.Close();


                }
                if (textBox23.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox23.Text);

                    con.Open();
                    SqlDataReader resultado12 = cmd1.ExecuteReader();

                    if (resultado12.Read())
                    {
                        string query12 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd13 = new SqlCommand(query12, con);
                        cmd13.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado12["NOMBRE_COMPLETO"].ToString());
                        cmd13.Parameters.AddWithValue("@identificacion", textBox23.Text);
                        cmd13.Parameters.AddWithValue("@TIPOD", comboBox12.Text);
                        cmd13.Parameters.AddWithValue("@FOLIOS", textBox24.Text);
                        cmd13.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd13.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd13.Parameters.AddWithValue("@Descripcion", textBox44.Text);
                        cmd13.ExecuteNonQuery();
                        dato45 = resultado12["NOMBRE_COMPLETO"].ToString();
                        dato46 = textBox23.Text;
                        dato47 = comboBox12.Text;
                        dato48 = textBox24.Text;
                        dato76 = textBox44.Text;


                    }
                    con.Close();


                }
                if (textBox25.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox25.Text);

                    con.Open();
                    SqlDataReader resultado13 = cmd1.ExecuteReader();

                    if (resultado13.Read())
                    {
                        string query13 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd14 = new SqlCommand(query13, con);
                        cmd14.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado13["NOMBRE_COMPLETO"].ToString());
                        cmd14.Parameters.AddWithValue("@identificacion", textBox25.Text);
                        cmd14.Parameters.AddWithValue("@TIPOD", comboBox13.Text);
                        cmd14.Parameters.AddWithValue("@FOLIOS", textBox26.Text);
                        cmd14.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd14.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd14.Parameters.AddWithValue("@Descripcion", textBox45.Text);
                        cmd14.ExecuteNonQuery();
                        dato49 = resultado13["NOMBRE_COMPLETO"].ToString();
                        dato50 = textBox25.Text;
                        dato51 = comboBox13.Text;
                        dato52 = textBox26.Text;
                        dato77 = textBox45.Text;


                    }
                    con.Close();


                }
                if (textBox27.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox27.Text);

                    con.Open();
                    SqlDataReader resultado14 = cmd1.ExecuteReader();

                    if (resultado14.Read())
                    {
                        string query14 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd15 = new SqlCommand(query14, con);
                        cmd15.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado14["NOMBRE_COMPLETO"].ToString());
                        cmd15.Parameters.AddWithValue("@identificacion", textBox27.Text);
                        cmd15.Parameters.AddWithValue("@TIPOD", comboBox14.Text);
                        cmd15.Parameters.AddWithValue("@FOLIOS", textBox28.Text);
                        cmd15.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd15.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd15.Parameters.AddWithValue("@Descripcion", textBox46.Text);
                        cmd15.ExecuteNonQuery();
                        dato53 = resultado14["NOMBRE_COMPLETO"].ToString();
                        dato54 = textBox27.Text;
                        dato55 = comboBox14.Text;
                        dato56 = textBox28.Text;
                        dato78 = textBox46.Text;


                    }
                    con.Close();


                }
                if (textBox29.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox29.Text);

                    con.Open();
                    SqlDataReader resultado15 = cmd1.ExecuteReader();

                    if (resultado15.Read())
                    {
                        string query15 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd16 = new SqlCommand(query15, con);
                        cmd16.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado15["NOMBRE_COMPLETO"].ToString());
                        cmd16.Parameters.AddWithValue("@identificacion", textBox29.Text);
                        cmd16.Parameters.AddWithValue("@TIPOD", comboBox15.Text);
                        cmd16.Parameters.AddWithValue("@FOLIOS", textBox30.Text);
                        cmd16.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd16.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd16.Parameters.AddWithValue("@Descripcion", textBox47.Text);
                        cmd16.ExecuteNonQuery();
                        dato57 = resultado15["NOMBRE_COMPLETO"].ToString();
                        dato58 = textBox29.Text;
                        dato59 = comboBox15.Text;
                        dato60 = textBox30.Text;
                        dato79 = textBox47.Text;


                    }
                    con.Close();


                }
                if (textBox31.Text != "")
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion", con);
                    cmd1.Parameters.AddWithValue("@Identificacion", textBox31.Text);

                    con.Open();
                    SqlDataReader resultado16 = cmd1.ExecuteReader();

                    if (resultado16.Read())
                    {
                        string query17 = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                        SqlCommand cmd18 = new SqlCommand(query17, con);
                        cmd18.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado16["NOMBRE_COMPLETO"].ToString());
                        cmd18.Parameters.AddWithValue("@identificacion", textBox31.Text);
                        cmd18.Parameters.AddWithValue("@TIPOD", comboBox16.Text);
                        cmd18.Parameters.AddWithValue("@FOLIOS", textBox32.Text);
                        cmd18.Parameters.AddWithValue("@FECHA", labelf.Text);
                        cmd18.Parameters.AddWithValue("@Usuario", labelu.Text);
                        cmd18.Parameters.AddWithValue("@Descripcion", textBox48.Text);
                        cmd18.ExecuteNonQuery();
                        dato61 = resultado16["NOMBRE_COMPLETO"].ToString();
                        dato62 = textBox31.Text;
                        dato63 = comboBox16.Text;
                        dato64 = textBox32.Text;
                        dato80 = textBox48.Text;


                    }

                    con.Close();


                }

                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("jefedearchivo@serviaseo.com", Form1.Usuario, Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = "TRANSFERENCIA DOCUMENTAL DEL USUARIO "+ Form1.Usuario;
                //Aquí ponemos el mensaje que incluirá el correo
                if (textBox1.Text != "")
                {
                    correo1 = "Realiza la transferencia del tipo documental " + dato3 + ", Descrito como: "+dato65+", con " + dato4 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato1 + " Identificado con la C.C. " + dato2+".";
                    mail.Body = "El usuario: " + "\n\n "+Form1.Usuario + "\n\n " + correo1;
                }
                
                    if (textBox3.Text != "")
                    {
                        correo2 = "Realiza la transferencia del tipo documental " + dato7 + ", Descrito como: " + dato66 + ", con " + dato8 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato5 + " Identificado con la C.C. " + dato6 + ".";
                        mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 ;
                    }
                    
                        if (textBox5.Text != "")
                        {
                            correo3 = "Realiza la transferencia del tipo documental " + dato11 + ", Descrito como: " + dato67 + ", con " + dato12 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato9 + " Identificado con la C.C. " + dato10 + ".";
                            mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 ;
                        }
                            if (textBox7.Text != "")
                            {
                                correo4 = "Realiza la transferencia del tipo documental " + dato15 + ", Descrito como: " + dato68 + ", con " + dato16 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato13 + " Identificado con la C.C. " + dato14 + ".";
                                mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + correo4 ;
                            }
                                if (textBox9.Text != "")
                                {
                                    correo5 = "Realiza la transferencia del tipo documental " + dato19 + ", Descrito como: " + dato69 + ", con " + dato20 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato17 + " Identificado con la C.C. " + dato18 + ".";
                                    mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 ;
                                }
                                    if (textBox11.Text != "")
                                    {
                                        correo6 = "Realiza la transferencia del tipo documental " + dato23 + ", Descrito como: " + dato70 + ", con " + dato24 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato21 + " Identificado con la C.C. " + dato22 + ".";
                                        mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 ;
                                    }
                                        if (textBox13.Text != "")
                                        {
                                            correo7 = "Realiza la transferencia del tipo documental " + dato27 + ", Descrito como: " + dato71 + ", con " + dato28 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato25 + " Identificado con la C.C. " + dato26 + ".";
                                            mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 ;
                                        }
                                            if (textBox15.Text != "")
                                            {
                                                correo8 = "Realiza la transferencia del tipo documental " + dato31 + ", Descrito como: " + dato72 + ", con " + dato32 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato29 + " Identificado con la C.C. " + dato30 + ".";
                                                mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 ;
                                            }
                                                if (textBox17.Text != "")
                                                {
                                                    correo9 = "Realiza la transferencia del tipo documental " + dato35 + ", Descrito como: " + dato73 + ", con " + dato36 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato33 + " Identificado con la C.C. " + dato34 + ".";
                                                    mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 ;
                                                }
                                                    if (textBox19.Text != "")
                                                    {
                                                        correo10 = "Realiza la transferencia del tipo documental " + dato39 + ", Descrito como: " + dato74 + ", con " + dato40 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato37 + " Identificado con la C.C. " + dato38 + ".";
                                                        mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 ;
                                                    }
                                                        if (textBox21.Text != "")
                                                        {
                                                            correo11 = "Realiza la transferencia del tipo documental " + dato43 + ", Descrito como: " + dato75 + ", con " + dato44 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato41 + " Identificado con la C.C. " + dato42 + ".";
                                                            mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2  + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 + "\n" + correo11 ;
                                                        }
                                                            if (textBox23.Text != "")
                                                            {
                                                                correo12 = "Realiza la transferencia del tipo documental " + dato47 + ", Descrito como: " + dato76 + ", con " + dato48 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato45 + " Identificado con la C.C. " + dato46 + ".";
                                                                mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 + "\n" + correo11 + "\n" + correo12 ;
                                                            }
                                                                if (textBox25.Text != "")
                                                                {
                                                                    correo13 = "Realiza la transferencia del tipo documental " + dato51 + ", Descrito como: " + dato77 + ", con " + dato52 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato49 + " Identificado con la C.C. " + dato50 + ".";
                                                                    mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 +"\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 + "\n" + correo11 + "\n" + correo12 + "\n" + correo13 ;
                                                                }
                                                                    if (textBox27.Text != "")
                                                                    {
                                                                        correo14 = "Realiza la transferencia del tipo documental " + dato55 + ", Descrito como: " + dato78 + ", con " + dato56 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato53 + " Identificado con la C.C. " + dato54 + ".";
                                                                        mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 + "\n" + correo11 + "\n" + correo12 + "\n" + correo13 + "\n" + correo14 ;
                                                                    }
                                                                        if (textBox29.Text != "")
                                                                        {
                                                                            correo15 = "Realiza la transferencia del tipo documental " + dato59 + ", Descrito como: " + dato79 + ", con " + dato60 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato57 + " Identificado con la C.C. " + dato58 + ".";
                                                                            mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 + "\n" + correo3 +  "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 + "\n" + correo11 + "\n" + correo12 + "\n" + correo13 + "\n" + correo14 + "\n" + correo15 ;
                                                                        }
                                                                            if (textBox31.Text != "")
                                                                            {
                                                                                correo16 = "Realiza la transferencia del tipo documental " + dato63 + ", Descrito como: " + dato80 + ", con " + dato64 + " Cantidad de Folios, Correspondiente a la Historia Laboral de: " + dato61 + " Identificado con la C.C. " + dato62 + ".";
                                                                                mail.Body = "El usuario: " + Form1.Usuario + "\n\n " + correo1 + "\n" + correo2 +  "\n" + correo3 + "\n" + correo4 + "\n" + correo5 + "\n" + correo6 + "\n" + correo7 + "\n" + correo8 + "\n" + correo9 + "\n" + correo10 + "\n" + correo11 + "\n" + correo12 + "\n" + correo13 + "\n" + correo14 + "\n" + correo15 + "\n" + correo16;
                                                                            }


                
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add("archivo@serviaseo.com");


                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                                       //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("jefedearchivo@serviaseo.com", "Bogota2019**");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                DialogResult result = MessageBox.Show("Datos Almacenados Correctamente \n\nEl personal de archivo recibira un correo y se encargara de recibir su transferencia" + "\n\n¿ Desea Realziar Otra Transferencia ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    label27.Visible = false;
                    label28.Visible = false;
                    label29.Visible = false;
                    label30.Visible = false;
                    label31.Visible = false;
                    label32.Visible = false;
                    label33.Visible = false;
                    label34.Visible = false;
                    label35.Visible = false;
                    label36.Visible = false;
                    label37.Visible = false;
                    label38.Visible = false;
                    label39.Visible = false;
                    label40.Visible = false;
                    label41.Visible = false;
                    label42.Visible = false;
                    label43.Visible = false;
                    label44.Visible = false;
                    label45.Visible = false;
                    label46.Visible = false;
                    label47.Visible = false;
                    label48.Visible = false;
                    label50.Visible = false;
                    label51.Visible = false;
                    label52.Visible = false;
                    label53.Visible = false;
                    label54.Visible = false;
                    label55.Visible = false;
                    label56.Visible = false;
                    label57.Visible = false;
                    label58.Visible = false;
                    label59.Visible = false;
                    label60.Visible = false;
                    label61.Visible = false;
                    label62.Visible = false;
                    label63.Visible = false;
                    label64.Visible = false;

                    //**TextBox
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
                    textBox17.Clear();
                    textBox18.Clear();
                    textBox19.Clear();
                    textBox20.Clear();
                    textBox21.Clear();
                    textBox22.Clear();
                    textBox23.Clear();
                    textBox24.Clear();
                    textBox25.Clear();
                    textBox26.Clear();
                    textBox27.Clear();
                    textBox28.Clear();
                    textBox29.Clear();
                    textBox30.Clear();
                    textBox31.Clear();
                    textBox32.Clear();
                    textBox33.Clear();
                    textBox34.Clear();
                    textBox35.Clear();
                    textBox36.Clear();
                    textBox37.Clear();
                    textBox38.Clear();
                    textBox39.Clear();
                    textBox40.Clear();
                    textBox41.Clear();
                    textBox42.Clear();
                    textBox43.Clear();
                    textBox44.Clear();
                    textBox45.Clear();
                    textBox46.Clear();
                    textBox47.Clear();
                    textBox48.Clear();

                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    textBox11.Visible = false;
                    textBox12.Visible = false;
                    textBox13.Visible = false;
                    textBox14.Visible = false;
                    textBox15.Visible = false;
                    textBox16.Visible = false;
                    textBox17.Visible = false;
                    textBox18.Visible = false;
                    textBox19.Visible = false;
                    textBox20.Visible = false;
                    textBox21.Visible = false;
                    textBox22.Visible = false;
                    textBox23.Visible = false;
                    textBox24.Visible = false;
                    textBox25.Visible = false;
                    textBox26.Visible = false;
                    textBox27.Visible = false;
                    textBox28.Visible = false;
                    textBox29.Visible = false;
                    textBox30.Visible = false;
                    textBox31.Visible = false;
                    textBox32.Visible = false;
                    textBox34.Visible = false;
                    textBox35.Visible = false;
                    textBox36.Visible = false;
                    textBox37.Visible = false;
                    textBox38.Visible = false;
                    textBox39.Visible = false;
                    textBox40.Visible = false;
                    textBox41.Visible = false;
                    textBox42.Visible = false;
                    textBox43.Visible = false;
                    textBox44.Visible = false;
                    textBox45.Visible = false;
                    textBox46.Visible = false;
                    textBox47.Visible = false;
                    textBox48.Visible = false;

                    //**ComboBox
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    comboBox3.SelectedIndex = 0;
                    comboBox4.SelectedIndex = 0;
                    comboBox5.SelectedIndex = 0;
                    comboBox6.SelectedIndex = 0;
                    comboBox7.SelectedIndex = 0;
                    comboBox8.SelectedIndex = 0;
                    comboBox9.SelectedIndex = 0;
                    comboBox10.SelectedIndex = 0;
                    comboBox11.SelectedIndex = 0;
                    comboBox12.SelectedIndex = 0;
                    comboBox13.SelectedIndex = 0;
                    comboBox14.SelectedIndex = 0;
                    comboBox15.SelectedIndex = 0;
                    comboBox16.SelectedIndex = 0;
                    comboBox1.Visible = true;
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    comboBox13.Visible = false;
                    comboBox14.Visible = false;
                    comboBox15.Visible = false;
                    comboBox16.Visible = false;


                }
                else if (result == DialogResult.No)
                {
                    
                    MessageBox.Show("Gracias por hacer uso correcto de nuestra aplicacion", "Agradecimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    label27.Visible = false;
                    label28.Visible = false;
                    label29.Visible = false;
                    label30.Visible = false;
                    label31.Visible = false;
                    label32.Visible = false;
                    label33.Visible = false;
                    label34.Visible = false;
                    label35.Visible = false;
                    label36.Visible = false;
                    label37.Visible = false;
                    label38.Visible = false;
                    label39.Visible = false;
                    label40.Visible = false;
                    label41.Visible = false;
                    label42.Visible = false;
                    label43.Visible = false;
                    label44.Visible = false;
                    label45.Visible = false;
                    label46.Visible = false;
                    label47.Visible = false;
                    label48.Visible = false;
                    label50.Visible = false;
                    label51.Visible = false;
                    label52.Visible = false;
                    label53.Visible = false;
                    label54.Visible = false;
                    label55.Visible = false;
                    label56.Visible = false;
                    label57.Visible = false;
                    label58.Visible = false;
                    label59.Visible = false;
                    label60.Visible = false;
                    label61.Visible = false;
                    label62.Visible = false;
                    label63.Visible = false;
                    label64.Visible = false;

                    //**TextBox
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
                    textBox17.Clear();
                    textBox18.Clear();
                    textBox19.Clear();
                    textBox20.Clear();
                    textBox21.Clear();
                    textBox22.Clear();
                    textBox23.Clear();
                    textBox24.Clear();
                    textBox25.Clear();
                    textBox26.Clear();
                    textBox27.Clear();
                    textBox28.Clear();
                    textBox29.Clear();
                    textBox30.Clear();
                    textBox31.Clear();
                    textBox32.Clear();
                    textBox33.Clear();
                    textBox34.Clear();
                    textBox35.Clear();
                    textBox36.Clear();
                    textBox37.Clear();
                    textBox38.Clear();
                    textBox39.Clear();
                    textBox40.Clear();
                    textBox41.Clear();
                    textBox42.Clear();
                    textBox43.Clear();
                    textBox44.Clear();
                    textBox45.Clear();
                    textBox46.Clear();
                    textBox47.Clear();
                    textBox48.Clear();

                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    textBox9.Visible = false;
                    textBox10.Visible = false;
                    textBox11.Visible = false;
                    textBox12.Visible = false;
                    textBox13.Visible = false;
                    textBox14.Visible = false;
                    textBox15.Visible = false;
                    textBox16.Visible = false;
                    textBox17.Visible = false;
                    textBox18.Visible = false;
                    textBox19.Visible = false;
                    textBox20.Visible = false;
                    textBox21.Visible = false;
                    textBox22.Visible = false;
                    textBox23.Visible = false;
                    textBox24.Visible = false;
                    textBox25.Visible = false;
                    textBox26.Visible = false;
                    textBox27.Visible = false;
                    textBox28.Visible = false;
                    textBox29.Visible = false;
                    textBox30.Visible = false;
                    textBox31.Visible = false;
                    textBox32.Visible = false;
                    textBox34.Visible = false;
                    textBox35.Visible = false;
                    textBox36.Visible = false;
                    textBox37.Visible = false;
                    textBox38.Visible = false;
                    textBox39.Visible = false;
                    textBox40.Visible = false;
                    textBox41.Visible = false;
                    textBox42.Visible = false;
                    textBox43.Visible = false;
                    textBox44.Visible = false;
                    textBox45.Visible = false;
                    textBox46.Visible = false;
                    textBox47.Visible = false;
                    textBox48.Visible = false;

                    //**ComboBox
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    comboBox3.SelectedIndex = 0;
                    comboBox4.SelectedIndex = 0;
                    comboBox5.SelectedIndex = 0;
                    comboBox6.SelectedIndex = 0;
                    comboBox7.SelectedIndex = 0;
                    comboBox8.SelectedIndex = 0;
                    comboBox9.SelectedIndex = 0;
                    comboBox10.SelectedIndex = 0;
                    comboBox11.SelectedIndex = 0;
                    comboBox12.SelectedIndex = 0;
                    comboBox13.SelectedIndex = 0;
                    comboBox14.SelectedIndex = 0;
                    comboBox15.SelectedIndex = 0;
                    comboBox16.SelectedIndex = 0;
                    comboBox1.Visible = true;
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    comboBox13.Visible = false;
                    comboBox14.Visible = false;
                    comboBox15.Visible = false;
                    comboBox16.Visible = false;

                }
               
                


            }
        }


       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea realizar una carga masiva?", "Carga Masiva", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Form Formulario1 = new Form16();
                Formulario1.Show();
            }
            else
            {
                return;
            }
        }
    }
}
