using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace GesDoc
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        DateTime hoy = DateTime.Now;
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            textBox9.Enabled = false;
            button2.Visible = false;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (txtident.Text == "")
            {
                MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    textBox9.Text = resultado["ESTADO_PRE"].ToString();
                    comboBox1.Text = resultado["AREASOL"].ToString();

                    if (textBox9.Text == "PRESTAMO TEMPORAL")
                    {
                        comboBox4.Visible = false;
                        comboBox1.Enabled = false;

                        MessageBox.Show("Historia Laboral en Prestamo Temporal \n\nse encuentra en el area de: " + comboBox1.Text, "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        panel1.Visible = true;
                        button2.Enabled = false;
                    }

                    if (textBox9.Text == "PRESTAMO DEFINITIVO")
                    {
                        comboBox4.Visible = false;
                        comboBox1.Enabled = false;

                        MessageBox.Show("Historia Laboral en Prestamo Definitivo \n\nse encuentra en el area de: " + comboBox1.Text, "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        panel1.Visible = true;
                        button2.Enabled = false;
                    }

                }
                else
                {
                    MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox4.Text=="")
            {
                MessageBox.Show("Error", "Complete los Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Error", "Complete los Datos del area solicitante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Configuración del Mensaje
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            mail.From = new MailAddress("jefedearchivo@serviaseo.com", Form1.Usuario, Encoding.UTF8);
            //Aquí ponemos el asunto del correo
            mail.Subject = "SOLICITUD CARPETA " + comboBox4.Text;
            //Aquí ponemos el mensaje que incluirá el correo
            mail.Body = "El usuario: " + Form1.Usuario + " Realiza la solicitud de la Historia Laboral de: " + textBox42.Text + " Identificada con C.C. " + textBox1.Text + " Ubicado en la caja: " + label2.Text + " En la carpeta: " + label3.Text;
            //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
            mail.To.Add("auxarchivo@serviaseo.com");


            //Configuracion del SMTP
            SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
            //Especificamos las credenciales con las que enviaremos el mail
            SmtpServer.Credentials = new System.Net.NetworkCredential("jefedearchivo@serviaseo.com", "Bogota2019**");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);


            SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            string query = "UPDATE Histrias_Laborales SET ESTADO_PRE =@ESTADO_PRE, AREASOL =@AREASOL WHERE IDENTIFICACION=@identificacion";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ESTADO_PRE", comboBox4.Text);
            cmd.Parameters.AddWithValue("@identificacion", textBox1.Text);
            cmd.Parameters.AddWithValue("@AREASOL", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlConnection con2 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            string query2 = "INSERT INTO Prestamos (NOMBRE_COMPLETO,IDENTIFICACION,PRESTAMO,PROCESO,AREASOL,FECHA_PRE,ESTADO) VALUES (@nombre_completo, @identificacion, @PRESTAMO, @PROCESO, @AREASOL, @FECHA_PRE, @ESTADO)";
            con2.Open();

            SqlCommand cmd2 = new SqlCommand(query2, con2);


            cmd2.Parameters.AddWithValue("@nombre_completo", textBox42.Text);
            cmd2.Parameters.AddWithValue("@PROCESO", comboBox4.Text);
            cmd2.Parameters.AddWithValue("@PRESTAMO", comboBox4.Text);
            cmd2.Parameters.AddWithValue("@identificacion", textBox1.Text);
            cmd2.Parameters.AddWithValue("@AREASOL", comboBox1.Text);
            cmd2.Parameters.AddWithValue("@FECHA_PRE", hoy.ToShortDateString());
            cmd2.Parameters.AddWithValue("@ESTADO", textBox9.Text);
            cmd2.ExecuteNonQuery();

            con2.Close();

            DialogResult result = MessageBox.Show("Solicitud enviada correctamente" + "\n\nEl personal de Archivo sera notificado mediante correo de su solicitud y en breve la atenderan" + "\n\nDesea Solicitar otra Historia Laboral?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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

        private void txtident_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                if (txtident.Text == "")
                {
                    MessageBox.Show("Por favor Ingrese El Dato a Consultar", "Sin Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                        textBox9.Text = resultado["ESTADO_PRE"].ToString();
                        comboBox1.Text = resultado["AREASOL"].ToString();

                        if (textBox9.Text == "PRESTAMO TEMPORAL")
                        {
                            comboBox4.Visible = false;
                            comboBox1.Enabled = false;

                            MessageBox.Show("Historia Laboral en Prestamo Temporal \n\nse encuentra en el area de: " + comboBox1.Text, "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            panel1.Visible = true;
                            button2.Enabled = false;
                        }

                        if (textBox9.Text == "PRESTAMO DEFINITIVO")
                        {
                            comboBox4.Visible = false;
                            comboBox1.Enabled = false;

                            MessageBox.Show("Historia Laboral en Prestamo Definitivo \n\nse encuentra en el area de: " + comboBox1.Text, "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            panel1.Visible = true;
                            button2.Enabled = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Datos No Encontrados", "Lo Sentimos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

        }
    }
}
