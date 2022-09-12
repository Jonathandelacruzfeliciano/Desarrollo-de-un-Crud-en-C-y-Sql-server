using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JCFprueba
{
    public partial class FrmMantenimiento : Form
    {
        public FrmMantenimiento()
        {
            InitializeComponent();
        }
        SqlConnection conecion = new SqlConnection("server=LAPTOP-KQH2TR9E\\SQLEXPRESS; database=JonathanPrueba; integrated security=true");

        public void actualizar()

        {
            string consulta = "Select * from persona";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conecion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;

         }

        public void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtFecha.Clear();

    }
         private void button2_Click(object sender, EventArgs e)
        {
           
            conecion.Open();

            string consulta = " delete from persona where id=" +txtId.Text+"";
            SqlCommand ejecutar = new SqlCommand(consulta,conecion);
            ejecutar.ExecuteNonQuery();
            MessageBox.Show("Registro Eliminado");
            actualizar();
             limpiar ();
           

            conecion.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            string consulta = "Select * from persona";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta,conecion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            bntGuardar.Enabled = false;
        }
        private void validarCampo()
        {
            var var = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtFecha.Text);
                
                bntGuardar.Enabled = var;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            conecion.Open();
            string consulta = "Insert into persona values ( '"+txtNombre.Text+"', '"+txtFecha.Text+"')";
            SqlCommand ejecutar = new SqlCommand(consulta, conecion);
            ejecutar.ExecuteNonQuery();
            
   
            MessageBox.Show("Registro agregado");
            limpiar();
            actualizar(); 

            conecion.Close();
            
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtId.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txtNombre.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtFecha.Text = dataGridView1.SelectedCells[2].Value.ToString();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
