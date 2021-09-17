using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            autocompletar();
        }
        private const int cGrip = 16;
        private const int cCaption = 32;
        int cont = 0;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {


        }


        private void Loging(string Usuario, string Pass)
        {
            SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            if (textBox4.Text == "")
            {

                MessageBox.Show("Debe completar los campos de Usuario y Contraseña", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Usuario,Pass FROM UsuariosGesDoc WHERE Usuario=@Usuario AND Pass=@Contraseña ", con);
                cmd.Parameters.AddWithValue("Usuario", Usuario);
                cmd.Parameters.AddWithValue("Contraseña", Pass);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    Form2 frm = new Form2();
                    frm.Show();


                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            finally

            {
                con.Close();
            }

        }
        internal static string Usuario;

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        SqlConnection conex = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
        DataTable datos = new DataTable();

        void autocompletar ()
            {

            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM UsuariosGesDoc ", conex);
            adaptador.Fill(datos);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["Usuario"].ToString());
            }
            
            textBox4.AutoCompleteMode = AutoCompleteMode.Append;
            textBox4.AutoCompleteCustomSource = lista;

            


            }

        private void Form1_Load(object sender, EventArgs e)
        {
            Usuario = textBox4.Text;
            this.Opacity = 0.0;
            timer1.Start();
            var posi = this.PointToScreen(panel1.Location);
            posi = pictureBox3.PointToClient(posi);
            panel1.Location = posi;
            panel1.Parent = pictureBox3;
            panel1.BackColor = Color.FromArgb(130,0,0,0);
            label8.Parent = pictureBox3;
            label7.Parent = pictureBox3;

            


        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            cont += 1;
            if (cont == 300) 
            {
                timer1.Stop();
               
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Usuario = textBox4.Text;
            
            
                
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
                pictureBox4.Image = Properties.Resources.ojo;

            }

            else
            {
                textBox3.PasswordChar = '*';
                pictureBox4.Image = Properties.Resources.ojocerrado;

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Loging(textBox4.Text, textBox3.Text);
                Usuario = textBox4.Text;
              

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(30, 0, 0, 0);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Usuario = textBox4.Text;
            
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            Loging(textBox4.Text, textBox3.Text);
            Usuario = textBox4.Text;
        }
    }

}
