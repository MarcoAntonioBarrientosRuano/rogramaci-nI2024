using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MantenimientoDeProductos
{
    public partial class Form1 : Form
    {
        private List<Producto>
            productos = new List<Producto>
                ();
        private string connectionString = "tu_cadena_de_conexion_aqui"; // Coloca aquí tu cadena de conexión a la base de datos
        private readonly object dataGridView1;

        public Form1()
        {
            InitializeComponent();
            CargarUsuarios();
            ActualizarGrid();
        }

        private void CargarUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Usuario, Nombre FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbUsuarios.Items.Add(new Usuario
                    {
                        UsuarioID = reader["Usuario"].ToString(),
                        Nombre = reader["Nombre"].ToString()
                    });
                }
                conn.Close();
            }
            cmbUsuarios.DisplayMember = "Nombre";
            cmbUsuarios.ValueMember = "UsuarioID";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Existencia = int.Parse(txtExistencia.Text),
                UsuarioID = ((Usuario)cmbUsuarios.SelectedItem).UsuarioID
            };

            productos.Add(producto);
            ActualizarGrid();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto != null)
                {
                    producto.Nombre = txtNombre.Text;
                    producto.Precio = decimal.Parse(txtPrecio.Text);
                    producto.Existencia = int.Parse(txtExistencia.Text);
                    producto.UsuarioID = ((Usuario)cmbUsuarios.SelectedItem).UsuarioID;
                    Actualizargrid();
                    Limpiarcampos(): 
		}
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto != null)
                {
                    productos.Remove(producto);
                    ActualizarGrid();
                    LimpiarCampos();
                }
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto != null)
                {
                    txtCodigo.Text = producto.Codigo;
                    txtNombre.Text = producto.Nombre;
                    txtPrecio.Text = producto.Precio.ToString();
                    txtExistencia.Text = producto.Existencia.ToString();
                    cmbUsuarios.SelectedValue = producto.UsuarioID;
                }
            }
        }

        private void ActualizarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productos;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            cmbUsuarios.SelectedIndex = -1;
        }
    }

    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public string UsuarioID { get; set; }

        public string Usuario => $"{UsuarioID} - {Nombre}";
    }

    public class Usuario
    {
        public string UsuarioID { get; set; }
        public string Nombre { get; set; }
    }
}

		using System;
		using System.Collections.Generic;
		using System.Data.SqlClient;
		using System.Windows.Forms;

		namespace MantenimientoDeProductos
{
    public partial class Form1 : Form
    {
        private List<Producto>
            productos = new List<Producto>();
        private string connectionString = "tu_cadena_de_conexion_aqui"; // Coloca aquí tu cadena de conexión a la base de datos

        public Form1()
        {
            InitializeComponent();
            CargarUsuarios();
            ActualizarGrid();
        }

        private void CargarUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Usuario, Nombre FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbUsuarios.Items.Add(new Usuario
                    {
                        UsuarioID = reader["Usuario"].ToString(),
                        Nombre = reader["Nombre"].ToString()
                    });
                }
                conn.Close();
            }
            cmbUsuarios.DisplayMember = "Nombre";
            cmbUsuarios.ValueMember = "UsuarioID";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Existencia = int.Parse(txtExistencia.Text),
                UsuarioID = ((Usuario)cmbUsuarios.SelectedItem).UsuarioID
            };

            productos.Add(producto);
            ActualizarGrid();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto != null)
                {
                    producto.Nombre = txtNombre.Text;
                    producto.Precio = decimal.Parse(txtPrecio.Text);
                    producto.Existencia = int.Parse(txtExistencia.Text);
                    producto.UsuarioID = ((Usuario)cmbUsuarios.SelectedItem).UsuarioID;
                    ActualizarGrid();
                    LimpiarCampos();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto != null)
                {
                    productos.Remove(producto);
                    ActualizarGrid();
                    LimpiarCampos();
                }
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var codigo = dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString();
                var producto = productos.Find(p => p.Codigo == codigo);
                if (producto != null)
                {
                    txtCodigo.Text = producto.Codigo;
                    txtNombre.Text = producto.Nombre;
                    txtPrecio.Text = producto.Precio.ToString();
                    txtExistencia.Text = producto.Existencia.ToString();
                    cmbUsuarios.SelectedValue = producto.UsuarioID;
                }
            }
        }

        private void ActualizarGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productos;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            cmbUsuarios.SelectedIndex = -1;
        }
    }

    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public string UsuarioID { get; set; }

        public string Usuario => $"{UsuarioID} - {Nombre}";
    }

    public class Usuario
    {
        public string UsuarioID { get; set; }
        public string Nombre { get; set; }
    }
}