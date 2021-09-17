using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.textBox2, "Este es el resultado de la consulta, Copie el número de cedula.");
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            autocompletar();
        }
        void autocompletar()
        {
            SqlConnection conex = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
            DataTable datos = new DataTable();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT NOMBRE_COMPLETO FROM Histrias_Laborales ", conex);
            adaptador.Fill(datos);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["NOMBRE_COMPLETO"].ToString());
            }
            
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = lista;


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT IDENTIFICACION FROM Histrias_Laborales WHERE NOMBRE_COMPLETO = @NOMBRE_COMPLETO";
                cmd.Parameters.AddWithValue("@NOMBRE_COMPLETO", textBox1.Text);
                SqlDataReader resultado = cmd.ExecuteReader();
                if (resultado.Read())
                {

                    textBox2.Text = resultado["IDENTIFICACION"].ToString();


                    resultado.Close();
                }
                
                else
                {
                MessageBox.Show("Historia Laboral no registrada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

                }
            conn.Close();



        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }
    }
}
