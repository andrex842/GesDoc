using System;
using System.Drawing;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;

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

        private void Form13_Load(object sender, EventArgs e)
        {
            label2.Text = Form6.Img;
            label1.Text = Form6.cc;
            string ruta = (@"\\Andres-amado\e\Historias_Laborales\" + label1.Text + ".pdf");
            if (ruta!=null)
            {
                axAcroPDF1.LoadFile(ruta);
                this.axAcroPDF1.Size = new System.Drawing.Size(868, 778);
            }
            else
            {
                MessageBox.Show("Imagenes no encontradas", "Lo Sentimos");
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(@"\\Andres-amado\e\Historias_Laborales\" + label1.Text + ".pdf");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Imagenes no encontradas", "Lo Sentimos");
            }
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
