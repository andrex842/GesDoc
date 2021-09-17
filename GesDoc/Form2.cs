using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace GesDoc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox4, "Cambiar Contraseña");
            this.toolTip1.SetToolTip(this.linkLabel1, "Refrescar Página");
            this.toolTip1.SetToolTip(this.pictureBox5, "Gestión de Usuarios");
            this.toolTip1.SetToolTip(this.pictureBox7, "Para Habilitar debe extender el Menu");





        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            
            
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            


        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {


        }

        private void button10_Click(object sender, EventArgs e)
        {



        }

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button13_Click(object sender, EventArgs e)
        {
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Form2_Load(object sender, EventArgs e)
        {
           

            SqlConnection con1 = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            SqlCommand cmd1 = new SqlCommand("SELECT Dependencia FROM UsuariosGesDoc WHERE Usuario=@Usuario", con1);
            cmd1.Parameters.AddWithValue("@Usuario", Form1.Usuario);

            con1.Open();
            SqlDataReader resultado1 = cmd1.ExecuteReader();

            if (resultado1.Read())
            {
                label4.Text = resultado1["Dependencia"].ToString();
            }
            con1.Close();


            if (label4.Text== "ADMINISTRADOR")
            {
                pictureBox5.Visible = true;

            }
            else
            {
                pictureBox5.Visible = false;
            }

            Sidebar.Visible = false;
            Sidebar.Width = 65;
            Linea.Width = 54;
            Header.Visible = false;
            Animation2.Show(Sidebar);
            Animation3.Show(Header);

            libroscomprobantes.Visible = false;
            HLp1.Visible = false;
            linkLabel1.Text = Form1.Usuario;
           
            HLp1.Visible = false;
            PrestamosDoc.Visible = false;
            CP1.Visible = false;
            Transfer.Visible = false;

            if(Sidebar.Width == 65)
            {
                bunifuFlatButton1.Enabled = false;
                bunifuFlatButton2.Enabled = false;
                bunifuFlatButton3.Enabled = false;
                bunifuFlatButton18.Enabled = false;

                this.toolTip1.SetToolTip(this.Sidebar, "Para habilitar debe dar click en el menu");
                

            }
            else
            {
                this.toolTip1.SetToolTip(this.bunifuFlatButton1, "Gestionar Historias Laborales");
                this.toolTip1.SetToolTip(this.bunifuFlatButton3, "Gestionar Prestamos Documentales");
                this.toolTip1.SetToolTip(this.bunifuFlatButton2, "Gestionar Libros Contables");
            }
           
            



            if (label4.Text == "ADMINISTRADOR")
            {
                pictureBox5.Visible = true;
              

                using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
                {
                    con.Open();

                    string cadena = "SELECT * FROM Prestamos WHERE PROCESO lIKE '%PRESTAMO DEFINITIVO%'";
                    SqlCommand comando = new SqlCommand(cadena, con);
                    SqlDataReader registro = comando.ExecuteReader();


                    if (registro.Read())
                    {

                        PopupNotifier popup = new PopupNotifier();

                        popup.AnimationDuration = 1000;
                        popup.AnimationInterval = 1;
                        popup.BodyColor = System.Drawing.Color.FromArgb(21, 20, 20);
                        popup.BorderColor = System.Drawing.Color.FromArgb(230, 237, 125);
                        popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
                        popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        popup.ContentPadding = new Padding(0);
                        popup.Delay = 4000;
                        popup.GradientPower = 100;
                        popup.HeaderHeight = 1;
                        popup.Scroll = true;
                        popup.ShowCloseButton = false;
                        popup.ShowGrip = false;



                        popup.Image = GesDoc.Properties.Resources.prte_;
                        popup.TitleText = "GesDoc" + "\nGestion Documental";
                        popup.ContentText = "\n\nTIENE SOLICITUDES PENDIENTES POR ATENDER" + "\n\nPRESTAMO DEFINITIVO";

                        popup.Click += Popup_Click;

                        popup.Popup();

                    }
                    
                    registro.Close();

                    string cadena2 = "SELECT * FROM Prestamos WHERE PROCESO lIKE '%PRESTAMO TEMPORAL%'";
                    SqlCommand comando3 = new SqlCommand(cadena2, con);
                    SqlDataReader registro3 = comando3.ExecuteReader();


                    if (registro3.Read())
                    {

                        PopupNotifier popup = new PopupNotifier();

                        popup.AnimationDuration = 1000;
                        popup.AnimationInterval = 1;
                        popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
                        popup.ContentColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
                        popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
                        popup.ContentPadding = new Padding(0);
                        popup.Delay = 4000;
                        popup.GradientPower = 100;
                        popup.HeaderHeight = 1;
                        popup.Scroll = true;
                        popup.ShowCloseButton = false;
                        popup.ShowGrip = false;

                        popup.Click += Popup_Click;



                        popup.Image = GesDoc.Properties.Resources.prte_;
                        popup.TitleText = "GesDoc" + "\nGestion Documental";
                        popup.ContentText = "\n\nTIENE SOLICITUDES PENDIENTES POR ATENDER" + "\n\nPRESTAMO TEMPORAL";

                        popup.Popup();

                       
                    }
                    registro3.Close();
                    con.Close();
                }
            }

            else
            {

                pictureBox5.Visible = false;
                
                
            }


        }

        private void Popup_Click(object sender, EventArgs e)
        {
            AbrirForm7(new Form12());
        }

        
        private void button12_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbrirForm9(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh9 = forma as Form;
            fh9.TopLevel = false;
            fh9.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh9);
            this.panel2b.Tag = fh9;
            fh9.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Cambiar la Contraseña?", "Cambio Contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Form Formulario1 = new Form14();
                Formulario1.Show();

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Gracias por hacer uso correcto de nuestra aplicacion", "Agradecimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void AbrirForm10(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh10 = forma as Form;
            fh10.TopLevel = false;
            fh10.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh10);
            this.panel2b.Tag = fh10;
            fh10.Show();
        }

        private void AbrirForm11(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh11 = forma as Form;
            fh11.TopLevel = false;
            fh11.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh11);
            this.panel2b.Tag = fh11;
            fh11.Show();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            


        }

        private void AbrirForm12(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh12 = forma as Form;
            fh12.TopLevel = false;
            fh12.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh12);
            this.panel2b.Tag = fh12;
            fh12.Show();
        }
    

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2_Load(sender, e);
        }
        private void AbrirForm13(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh13 = forma as Form;
            fh13.TopLevel = false;
            fh13.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh13);
            this.panel2b.Tag = fh13;
            fh13.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            Form Formulario1 = new Form20();
            Formulario1.Show();
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        
        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (label4.Text == "CONTABILIDAD" || label4.Text == "GERENCIA" || label4.Text == "NIVEL NACIONAL" || label4.Text == "NOMINA" || label4.Text == "OPERACIONES" || label4.Text == "PLANEACION" || label4.Text == "RECURSOS HUMANOS" || label4.Text == "SST")
            {
                HLp1.Visible = true;
                bunifuFlatButton8.Visible = false;
                bunifuFlatButton9.Visible = false;
                HLp1.Width = 168;
                HLp1.Height=55;
                libroscomprobantes.Visible = false;
                CP1.Visible = false;
                PrestamosDoc.Visible = false;
                Transfer.Visible = false;


            }
            
            else 
            { 
            HLp1.Visible = true;
            HLp1.Height = 167;
            HLp1.Width = 171;
            libroscomprobantes.Visible = false;
            PrestamosDoc.Visible = false;
            CP1.Visible = false;
            Transfer.Visible = false;
            }
        }
        private void AbrirForm1(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh1 = forma as Form;
            fh1.TopLevel = false;
            fh1.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh1);
            this.panel2b.Tag = fh1;
            fh1.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            AbrirForm1(new Form6());
            HLp1.Visible = false;
           
            


        }

        private void HLp1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirForm(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh = forma as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh);
            this.panel2b.Tag = fh;
            fh.Show();
        }
        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            HLp1.Visible = false;
            AbrirForm(new Form3());
           
        }
        private void AbrirForm2(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh2 = forma as Form;
            fh2.TopLevel = false;
            fh2.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh2);
            this.panel2b.Tag = fh2;
            fh2.Show();
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            HLp1.Visible = false;
            AbrirForm2(new Form7());
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (label4.Text == "CONTABILIDAD" || label4.Text == "GERENCIA" || label4.Text == "NIVEL NACIONAL" || label4.Text == "NOMINA" || label4.Text == "OPERACIONES" || label4.Text == "PLANEACION" || label4.Text == "RECURSOS HUMANOS" || label4.Text == "SST")
            {

                PrestamosDoc.Visible = false;
                bunifuFlatButton14.Visible = false;
                CP1.Width = 167;
                CP1.Height = 50;
                HLp1.Visible = false;
                libroscomprobantes.Visible = true;
                CP1.Visible = false;
                libroscomprobantes.Height = 206;
                libroscomprobantes.Width = 201;
                CP1.Location = new System.Drawing.Point(248, 373);
                Transfer.Visible = false;
                

            }
            
            else
            {
                libroscomprobantes.Visible = true;
                libroscomprobantes.Height = 206;
                libroscomprobantes.Width = 201;
                CP1.Location = new System.Drawing.Point(248, 373);
                CP1.Visible = false;
                PrestamosDoc.Visible = false;
                Transfer.Visible = false;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (label4.Text == "CONTABILIDAD" || label4.Text == "GERENCIA" || label4.Text == "NIVEL NACIONAL" || label4.Text == "NOMINA" || label4.Text == "OPERACIONES" || label4.Text == "PLANEACION" || label4.Text == "RECURSOS HUMANOS" || label4.Text == "SST")
            {
                PrestamosDoc.Visible = true;
                bunifuFlatButton10.Visible = false;
                PrestamosDoc.Width = 166;
                PrestamosDoc.Height = 116;
                HLp1.Visible = false;
                libroscomprobantes.Visible = false;
                CP1.Visible = false;
                Transfer.Visible = false;

            }
            else 
            { 
                PrestamosDoc.Visible = true;
                PrestamosDoc.Width = 171;
                PrestamosDoc.Height = 167;
                HLp1.Visible = false;
                libroscomprobantes.Visible = false;
                CP1.Visible = false;
                Transfer.Visible = false;
            }

        }
        private void AbrirForm3(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh3 = forma as Form;
            fh3.TopLevel = false;
            fh3.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh3);
            this.panel2b.Tag = fh3;
            fh3.Show();
        }
        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
         
            AbrirForm3(new Form8());
            PrestamosDoc.Visible = false;
        }
        private void AbrirForm4(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh4 = forma as Form;
            fh4.TopLevel = false;
            fh4.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh4);
            this.panel2b.Tag = fh4;
            fh4.Show();
        }
        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            PrestamosDoc.Visible = false;
            AbrirForm4(new Form9());
          
        }
        private void AbrirForm7(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh7 = forma as Form;
            fh7.TopLevel = false;
            fh7.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh7);
            this.panel2b.Tag = fh7;
            fh7.Show();
        }
        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            
            PrestamosDoc.Visible = false;
            AbrirForm7(new Form12());
        }

        private void button11_Click_1(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (label4.Text == "CONTABILIDAD" || label4.Text == "GERENCIA" || label4.Text == "NIVEL NACIONAL" || label4.Text == "NOMINA" || label4.Text == "OPERACIONES" || label4.Text == "PLANEACION" || label4.Text == "RECURSOS HUMANOS" || label4.Text == "SST")
            {

                PrestamosDoc.Visible = false;
                bunifuFlatButton14.Visible = false;
                CP1.Width = 130;
                CP1.Height = 56;
                HLp1.Visible = false;
                libroscomprobantes.Visible = true;
                CP1.Visible = true;

            }
            else 
            { 
                CP1.Visible = true;
                CP1.Width = 130;
                CP1.Height = 113;
            }
        }
        private void AbrirForm6(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh6 = forma as Form;
            fh6.TopLevel = false;
            fh6.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh6);
            this.panel2b.Tag = fh6;
            fh6.Show();
        }
        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            CP1.Visible = false;
            
            AbrirForm6(new Form11());
        }
        private void AbrirForm5(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh5 = forma as Form;
            fh5.TopLevel = false;
            fh5.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh5);
            this.panel2b.Tag = fh5;
            fh5.Show();
        }
        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            CP1.Visible = false;
            
            AbrirForm5(new Form10());
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            CP1.Visible = false;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            CP1.Visible = false;
        }

        private void Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Sidebar_MouseHover(object sender, EventArgs e)
        {

            if (Sidebar.Width == 244)
            {
                Sidebar.Visible = false;
                Sidebar.Width = 65;
                Linea.Width = 54;
                Animation2.Show(Sidebar);
                bunifuFlatButton1.Enabled = false;
                bunifuFlatButton2.Enabled = false;
                bunifuFlatButton3.Enabled = false;
                bunifuFlatButton18.Enabled = false;
                HLp1.Visible = false;
                PrestamosDoc.Visible = false;
                CP1.Visible = false;
                Transfer.Visible = false;




            }
            else
            {
                Sidebar.Visible = false;
                Sidebar.Width = 244;
                Linea.Width = 244;
                Animation2.Show(Sidebar);

                bunifuFlatButton1.Enabled = true;
                bunifuFlatButton2.Enabled = true;
                bunifuFlatButton3.Enabled = true;
                bunifuFlatButton18.Enabled = true;

            }




            libroscomprobantes.Visible = false;
            HLp1.Visible = false;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {

            if (Sidebar.Width == 244)
            {
                Sidebar.Visible = false;
                Sidebar.Width = 65;
                Linea.Width = 54;
                Animation2.Show(Sidebar);
                bunifuFlatButton1.Enabled = false;
                bunifuFlatButton2.Enabled = false;
                bunifuFlatButton3.Enabled = false;
                bunifuFlatButton18.Enabled = false;
                HLp1.Visible = false;
                PrestamosDoc.Visible = false;
                CP1.Visible = false;
                Transfer.Visible = false;




            }
            else
            {
                Sidebar.Visible = false;
                Sidebar.Width = 244;
                Linea.Width = 244;
                Animation2.Show(Sidebar);

                bunifuFlatButton1.Enabled = true;
                bunifuFlatButton2.Enabled = true;
                bunifuFlatButton3.Enabled = true;
                bunifuFlatButton18.Enabled = true;

            }




            libroscomprobantes.Visible = false;
            HLp1.Visible = false;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            
            
        }

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {
            if (label4.Text == "CONTABILIDAD" || label4.Text == "GERENCIA" || label4.Text == "NIVEL NACIONAL" || label4.Text == "NOMINA" || label4.Text == "OPERACIONES" || label4.Text == "PLANEACION" || label4.Text == "RECURSOS HUMANOS" || label4.Text == "SST")
            {
                Transfer.Visible = true;
                bunifuFlatButton16.Visible = false;
                Transfer.Width = 141;
                Transfer.Height = 62;
                HLp1.Visible = false;
                libroscomprobantes.Visible = false;
                CP1.Visible = false;
                Transfer.Visible = true;
                PrestamosDoc.Visible = false;


            }
            
            else
            {
                Transfer.Visible = true;
                Transfer.Height = 115;
                Transfer.Width = 149;

                PrestamosDoc.Visible = false;
                HLp1.Visible = false;
                libroscomprobantes.Visible = false;
                CP1.Visible = false;
            }
        }

        private void AbrirForm8(object forma)
        {
            if (this.panel2b.Controls.Count > 0)
                this.panel2b.Controls.RemoveAt(0);
            Form fh2 = forma as Form;
            fh2.TopLevel = false;
            fh2.Dock = DockStyle.Fill;
            this.panel2b.Controls.Add(fh2);
            this.panel2b.Tag = fh2;
            fh2.Show();
        }
        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton17_Click_1(object sender, EventArgs e)
        {
            Transfer.Visible = false;
            AbrirForm8(new Form15());
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
