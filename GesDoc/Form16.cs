using System;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Net.Mail;
using System.Diagnostics;



namespace GesDoc
{
    public partial class Form16 : Form
    {
        int s;
        public Form16()
        {
            InitializeComponent();
        }
        DateTime hoy = DateTime.Now;
        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            string archFuente = @"\\ANDRES-AMADO\e\Carga_Masiva_Transfer.xlsx";
            string nomArch = Path.GetFileName(archFuente);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                {
                    return;
                }
                else
                {
                    File.Copy(archFuente, Path.Combine(save.FileName));
                    MessageBox.Show("Archivo Descargado Correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(save.FileName);


                }

            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            //Prueba Carga SQL

            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(txtruta.Text);
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range range = xlWorksheet.UsedRange;
            int rows = range.Rows.Count;
            int cols = range.Columns.Count;
            for (int i = 2; i <= rows; i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Identificacion", range.Cells[i, 1].Value2.ToString());
                SqlDataReader resultado = cmd.ExecuteReader();

                if (resultado.Read())
                {


                    SqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "INSERT INTO transfer (IDENTIFICACION, NOMBRE_COMPLETO, TIPOD , Descripcion, FOLIOS,FECHA,Usuario) VALUES (@identificacion, @NOMBRE_COMPLETO,@TIPOD , @Descripcion, @FOLIOS, @FECHA, @Usuario)";
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@IDENTIFICACION", range.Cells[i, 1].Value2.ToString());
                    cmd2.Parameters.AddWithValue("@NOMBRE_COMPLETO", (resultado["NOMBRE_COMPLETO"], range.Cells[i, 2].Value2).ToString());
                    cmd2.Parameters.AddWithValue("@TIPOD", range.Cells[i, 3].Value2.ToString());
                    cmd2.Parameters.AddWithValue("@FOLIOS", range.Cells[i, 4].Value2.ToString());
                    cmd2.Parameters.AddWithValue("@FECHA", (labelf.Text, range.Cells[i, 5].Value2).ToString());
                    cmd2.Parameters.AddWithValue("@Usuario", (labelu.Text, range.Cells[i, 6].Value2).ToString());
                    cmd2.Parameters.AddWithValue("@Descripcion", range.Cells[i, 7].Value2.ToString());
                    resultado.Close();
                    cmd2.ExecuteNonQuery();
                    

                }
                else
                {
                    MessageBox.Show("No existe la identificación registrada con numero: " + range.Cells[i, 2].Value2.ToString() + "\n\n Revise los datos capturados con el numero de cedula registrado" + "\n\nPor tal motivo,la transferencia de este numero de cedula no se podra realizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                resultado.Close();

            }

            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(xlWorksheet);
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            conn.Close();
            //Configuración del Mensaje

            //Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
            //string path = textBox1.Text;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            mail.From = new MailAddress("jefedearchivo@serviaseo.com", Form1.Usuario, Encoding.UTF8);
            //Aquí ponemos el asunto del correo
            mail.Subject = "TRANSFERENCIA DOCUMENTAL MASIVA DEL USUARIO " + Form1.Usuario;
            //Aquí ponemos el mensaje que incluirá el correo
            mail.Body = "El usuario Realiza una carga masiva";

            //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
            mail.To.Add("archivo@serviaseo.com");


            //Configuracion del SMTP
            SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                                   //Especificamos las credenciales con las que enviaremos el mail
            SmtpServer.Credentials = new System.Net.NetworkCredential("jefedearchivo@serviaseo.com", "Bogota2019**");
            SmtpServer.EnableSsl = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mail.Attachments.Add(new Attachment(txtruta.Text));
            SmtpServer.Send(mail);



        }

        private void Form16_Load(object sender, EventArgs e)
        {
            labelu.Text = Form1.Usuario;
            labelf.Text = hoy.ToShortDateString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Abrir fichero";
            //theDialog.Filter = "Excel Files |*.xls;*.xlsx,;*.csv";
            theDialog.InitialDirectory = @"C:\Escritorio";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                txtruta.Text = theDialog.FileName;
            }
            else
            {
                MessageBox.Show("Debe seleccionar el archivo Excel", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            using (SqlConnection conn = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Histrias_Laborales WHERE Identificacion = @Identificacion";
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(txtruta.Text);
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range range = xlWorksheet.UsedRange;
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;

                for (int i = 2; i <= rows; i++)
                {

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Identificacion", range.Cells[i, 1].Value2.ToString());
                    SqlDataReader resultado = cmd.ExecuteReader();

                    
                    if (resultado.Read())
                    {
                        s++;
                        string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0; IMEX=0';", txtruta.Text);
                        using (OleDbConnection cnn = new OleDbConnection(conexion))
                        {

                            cnn.Open();
                            using (OleDbCommand cmde = cnn.CreateCommand())
                            {
                                cmde.CommandText = "INSERT INTO [Hoja1$B:B" + s + "]  values (@NOMBRE_COMPLETO)";
                                
                                cmde.Parameters.Clear();
                                cmde.Parameters.AddWithValue("@NOMBRE_COMPLETO", resultado["NOMBRE_COMPLETO"].ToString());

                                cmde.ExecuteNonQuery();
                            }
                            using (OleDbCommand cmdr = cnn.CreateCommand())
                            {
                                cmdr.CommandText = "INSERT INTO [Hoja1$F:F" + s + "]  values (@Usuario)";
                                cmdr.Parameters.Clear();
                                cmdr.Parameters.AddWithValue("@Usuario", labelu.Text);

                                cmdr.ExecuteNonQuery();
                            }
                            using (OleDbCommand cmdd = cnn.CreateCommand())
                            {
                                cmdd.CommandText = "INSERT INTO [Hoja1$E:E" + s + "]  values (@FECHA)";
                                cmdd.Parameters.Clear();
                                cmdd.Parameters.AddWithValue("@FECHA", labelf.Text);

                                cmdd.ExecuteNonQuery();
                            }

                            cnn.Close();

                        }
                        resultado.Close();
                        this.Activate();


                    }

                }

                conn.Close();
                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(xlWorksheet);
                xlWorkbook.Save();
                xlWorkbook.Close(true);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (System.Diagnostics.Process p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }

            }

        }
        private void relaseObjt(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error" + ex.ToString());

            }
        }
    }
}
