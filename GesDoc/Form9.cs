using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        DateTime hoy = DateTime.Now;
        private void Form9_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            button2.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtident.Text == "")
            {
                MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion=@Identificacion", con);
                cmd.Parameters.AddWithValue("@Identificacion", txtident.Text);

                con.Open();
                SqlDataReader resultado = cmd.ExecuteReader();
                if (resultado.Read())
                {
                    panel2.Visible = true;
                    panel1.Visible = false;
                    button2.Visible = true;


                    textBox1.Text = resultado["IDENTIFICACION"].ToString();
                    textBox42.Text = resultado["NOMBRE_COMPLETO"].ToString();
                    textBox3.Text = resultado["AREASOL"].ToString();

                    textpro.Enabled = false;
                    textBox9.Enabled = false;

                    SqlCommand comando = new SqlCommand();
                    DataTable tabla = new DataTable();

                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "Select * from Prestamos where identificacion =@identificacion";
                    comando.Parameters.AddWithValue("@Identificacion", textBox1.Text);
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                    comboBox2.DataSource = tabla;
                    comboBox2.DisplayMember = "Prestamos";
                    comboBox2.ValueMember = "Id";

                    if (comboBox2.ValueMember == "Id")
                    {
                        var ultimo = comboBox2.Items.Count - 1;
                        comboBox2.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado
                        var valor = comboBox2.SelectedValue;
                    }

                }
                else
                {
                    MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con.Close();
                using (SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                    {
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion=@IDENTIFICACION", con1);
                        cmd1.Parameters.AddWithValue("@IDENTIFICACION", txtident.Text);

                        con1.Open();
                        SqlDataReader resultado1 = cmd1.ExecuteReader();

                        if (resultado1.Read())
                        {


                            label2.Text = resultado1["CAJA"].ToString();
                            label3.Text = resultado1["CARPETA"].ToString();


                        }
                    con1.Close();
                }

            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Configuración del Mensaje
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            mail.From = new MailAddress("jefedearchivo@serviaseo.com", Form1.Usuario, Encoding.UTF8);
            //Aquí ponemos el asunto del correo
            mail.Subject = "DEVOLUCIÓN CARPETA DEL AREA " + textBox3.Text;
            //Aquí ponemos el mensaje que incluirá el correo
            mail.Body = "El usuario: " + Form1.Usuario + " Realiza la devolución de la Historia Laboral de: " + textBox42.Text + " Identificada con C.C. " + textBox1.Text + " Donde su ubicación debe ser en la caja: " + label2.Text + " En la carpeta: " + label3.Text;
            //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
            mail.To.Add("auxarchivo@serviaseo.com");


            //Configuracion del SMTP
            SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
            //Especificamos las credenciales con las que enviaremos el mail
            SmtpServer.Credentials = new System.Net.NetworkCredential("jefedearchivo@serviaseo.com", "Bogota2019**");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);


            SqlConnection con3 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");



            string query3 = "UPDATE Prestamos SET FECHA_DEV =@FECHA_DEV, ESTADO =@ESTADO, PROCESO =@PROCESO WHERE ID=@id";
            con3.Open();
            SqlCommand cmd3 = new SqlCommand(query3, con3);

            cmd3.Parameters.AddWithValue("@FECHA_DEV", hoy.ToShortDateString());
            cmd3.Parameters.AddWithValue("@id", comboBox2.Text);
            cmd3.Parameters.AddWithValue("@ESTADO", textBox9.Text);
            cmd3.Parameters.AddWithValue("@PROCESO", textpro.Text);
            cmd3.ExecuteNonQuery();
            con3.Close();

            SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            string query = "UPDATE Histrias_Laborales SET ESTADO_PRE =@ESTADO_PRE WHERE IDENTIFICACION=@identificacion";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ESTADO_PRE", textBox9.Text);
            cmd.Parameters.AddWithValue("@identificacion", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();


            textBox1.Clear();
            textpro.Clear();
            textBox3.Clear();
            textBox42.Clear();
            textBox9.Clear();
            comboBox2.Text = "";

            DialogResult result = MessageBox.Show("Solicitud enviada correctamente" + "\n\nDesea Solicitar otra Historia Laboral?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
                button2.Visible = false;
            }

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtident_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtident.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion=@Identificacion", con);
                    cmd.Parameters.AddWithValue("@Identificacion", txtident.Text);

                    con.Open();
                    SqlDataReader resultado = cmd.ExecuteReader();
                    if (resultado.Read())
                    {
                        panel2.Visible = true;
                        panel1.Visible = false;
                        button2.Visible = true;


                        textBox1.Text = resultado["IDENTIFICACION"].ToString();
                        textBox42.Text = resultado["NOMBRE_COMPLETO"].ToString();
                        textBox3.Text = resultado["AREASOL"].ToString();

                        textpro.Enabled = false;
                        textBox9.Enabled = false;

                        SqlCommand comando = new SqlCommand();
                        DataTable tabla = new DataTable();

                        SqlConnection conexion = new SqlConnection();
                        conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
                        conexion.Open();
                        comando.Connection = conexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = "Select * from Prestamos where identificacion =@identificacion";
                        comando.Parameters.AddWithValue("@Identificacion", textBox1.Text);
                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        adaptador.Fill(tabla);
                        comboBox2.DataSource = tabla;
                        comboBox2.DisplayMember = "Prestamos";
                        comboBox2.ValueMember = "Id";

                        if (comboBox2.ValueMember == "Id")
                        {
                            var ultimo = comboBox2.Items.Count - 1;
                            comboBox2.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado
                            var valor = comboBox2.SelectedValue;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    con.Close();
                    using (SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                    {
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM Histrias_Laborales WHERE Identificacion=@IDENTIFICACION", con1);
                        cmd1.Parameters.AddWithValue("@IDENTIFICACION", txtident.Text);

                        con1.Open();
                        SqlDataReader resultado1 = cmd1.ExecuteReader();

                        if (resultado1.Read())
                        {


                            label2.Text = resultado1["CAJA"].ToString();
                            label3.Text = resultado1["CARPETA"].ToString();


                        }
                        con1.Close();
                    }

                }
            }
        }
    }
}
