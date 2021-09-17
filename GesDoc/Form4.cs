using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GesDoc
{
    public partial class Form4 : Form
    {
        public delegate void pasar(string dato);
        public event pasar pasado;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {



            using (SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;"))
            {
                SqlCommand cmd = new SqlCommand("select CAJA, count(CAJA) AS CANTIDAD from Histrias_Laborales group by CAJA having count(CAJA)>0", con);
                con.Open();

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;

                con.Close();
            }



        }


       
        public void button4_Click(object sender, EventArgs e)
        {

            pasado(label1.Text);
            this.Close();

            if (label4.Text == "0")
            {
                SqlConnection con = new SqlConnection("Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**;");

                con.Open();
                string query2 = "DELETE FROM CAJAS WHERE NUMERO=@NUMERO";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@NUMERO", comboBox2.Text);
                cmd2.ExecuteNonQuery();
                con.Close();
            }


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                        
            if (Convert.ToInt32(label4.Text) >= 40)
            {
                if (label1.Text == "Estante Activo")
                {
                    return;
                }
                MessageBox.Show("Revisar el Peso de la caja ya que cuenta con mas de 40 carpetas en la misma", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=ANDRES-AMADO\\EXPRESS2014,1434; Initial Catalog=SERVIASEO; User ID=AndresStudio; Password=Bogota2018**";
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from CAJAS ORDER BY NUMERO DESC";
            comando.CommandTimeout = 160;
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(tabla);
            comboBox2.DataSource = tabla;
            comboBox2.DisplayMember = "CAJAS";
            comboBox2.ValueMember = "NUMERO";

            if (comboBox2.ValueMember == "NUMERO")
            {
                var ultimo = comboBox2.Items.Count - 1;
                comboBox2.SelectedIndex = ultimo;  //<-- con esto lo dejas seleccionado
                var valor = comboBox2.SelectedValue;
            }
            conexion.Close();
            label1.Text = comboBox2.Text;
            label4.Text = "0";
        }
    }
}
