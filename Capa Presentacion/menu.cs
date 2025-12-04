using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;
using Capa_Negocio.Cliente;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Capa_Presentacion
{
    public partial class menu : MaterialForm
    {
        // Servicio de la capa negocio
        private readonly ClienteServicios _clienteServicios = new ClienteServicios();

        // Token para operaciones async
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        private readonly Capa_datos.ConexionBD _conexion = new Capa_datos.ConexionBD();


        public menu()
        {
            InitializeComponent();
            dgvClientes.ReadOnly = true;                 // No permitir editar celdas
            dgvClientes.AllowUserToAddRows = false;      // No permitir agregar filas
            dgvClientes.AllowUserToDeleteRows = false;   // No permitir eliminar filas
            dgvClientes.AllowUserToResizeRows = false;   // No permitir cambiar tamaño de filas
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección por fila
            dgvClientes.MultiSelect = false;             // Solo una fila a la vez
            dgvClientes.RowHeadersVisible = false;       // Quitar columna extra de la izquierda



            // Configuración MaterialSkin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600,
                Primary.Blue900,
                Primary.Blue100,
                Accent.LightBlue200,
                TextShade.WHITE
            );

            lblNombreC.ForeColor = Color.White;

            //Evento del botón registrar
            btnRegistrar.Click += btnRegistrar_Click;
            btnBusqueda.Click += btnBusqueda_Click;
            
            dgvClientes.KeyDown += dgvClientes_KeyDown;
            dgvClientes.CellDoubleClick += dgvClientes_CellDoubleClick;
            dgvClientes.CellEndEdit += dgvClientes_CellEndEdit;



        }

        private async void menu_Load(object sender, EventArgs e)
        {
            // Cargar clientes en el DataGrid al abrir el formulario
            await CargarClientesAsync();
            await CargarCedulas();
            await CargarIdsClientes();
        }

        // ----------------------------------------------------------
        // MÉTODO PARA LIMPIAR LOS TEXTBOX
        // ----------------------------------------------------------
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtNacionalidad.Text = "";

            txtNombre.Focus();
        }

        // ----------------------------------------------------------
        // MÉTODO PARA CARGAR EL DGV
        // ----------------------------------------------------------
        private async Task CargarClientesAsync()
        {
            var lista = await _clienteServicios.ObtenerTodosAsync(_cts.Token);
            dgvClientes.DataSource = lista;
        }

        // ----------------------------------------------------------
        // EVENTO CLICK DEL BOTÓN REGISTRAR
        // ----------------------------------------------------------
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El nombre no puede estar vacío.");
                    return;
                }

                var cliente = new Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Documento = txtCedula.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    Nacionalidad = txtNacionalidad.Text.Trim()
                };

                // Guardar
                await _clienteServicios.CrearClienteAsync(cliente, _cts.Token);

                MessageBox.Show("Cliente registrado correctamente.");

                LimpiarCampos();

                await CargarClientesAsync();
                await CargarCedulas();     // <<========= ComboBox se actualiza
                await CargarIdsClientes(); // <<========= ComboBox se actualiza
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente: " + ex.Message);
            }
        }

        private async Task CargarCedulas()
        {
            cmbCedula.Items.Clear();   // Muy importante

            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();

                string query = "SELECT Documento FROM Cliente ORDER BY Documento";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        cmbCedula.Items.Add(dr["Documento"].ToString());
                    }
                }
            }

            // ✔ Evita que quede mostrando un valor viejo
            cmbCedula.SelectedIndex = -1;
            cmbCedula.Text = "";
        }


        private async Task CargarIdsClientes()
        {
            using (var conn = _conexion.CrearConexion())

            {
                await conn.OpenAsync();

                string query = "SELECT IdCliente FROM Cliente";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    cmbID.Items.Clear();

                    while (await reader.ReadAsync())
                    {
                        cmbID.Items.Add(reader["IdCliente"].ToString());
                    }
                }
            }
        }
        private async void btnBusqueda_Click(object sender, EventArgs e)
        {
            string cedula = cmbCedula.SelectedItem?.ToString();
            string idCliente = cmbID.SelectedItem?.ToString();

            // Validación
            if (cedula == null && idCliente == null)
            {
                MessageBox.Show("Debes seleccionar una cédula o un ID.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();

                string query = "SELECT * FROM Cliente WHERE 1=1";

                if (cedula != null)
                    query += " AND Documento = @Documento";

                if (idCliente != null)
                    query += " AND IdCliente = @IdCliente";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (cedula != null)
                        cmd.Parameters.AddWithValue("@Documento", cedula);

                    if (idCliente != null)
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    // FILTRAR Y MOSTRAR EN EL DGV
                    DataTable tabla = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }

                    if (tabla.Rows.Count > 0)
                    {
                        // Muestra solo el resultado filtrado
                        dgvClientes.DataSource = tabla;

                        // También rellenar los TextBox
                        DataRow row = tabla.Rows[0];
                        txtNombre.Text = row["Nombre"].ToString();
                        txtTelefono.Text = row["Telefono"].ToString();
                        txtCorreo.Text = row["Email"].ToString();
                        txtNacionalidad.Text = row["Nacionalidad"].ToString();

                        MessageBox.Show("Cliente encontrado.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente.",
                                        "Sin resultados",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Limpia el DGV si no hay nada
                        dgvClientes.DataSource = null;
                    }
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea
            }
        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (!EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("El correo no es válido. Ejemplo: usuario@dominio.com",
                                "Correo inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtCorreo.Focus(); // Volver al textbox
            }
        }
        private bool EsCorreoValido(string correo)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(correo);
                return mail.Address == correo;
            }
            catch
            {
                return false;
            }
        }
        private void BloquearControles(bool bloquear)
        {
            // Usamos BloquearRecursivo, que ya tiene la lógica para NO bloquear 
            // el panel que contiene al DataGridView
            BloquearRecursivo(this, bloquear);

            // Aseguramos explícitamente el DGV y el botón
            dgvClientes.Enabled = true;

            // El botón Editar se deshabilita si estamos bloqueando (modo edición)
            
        }

        /*private void HabilitarControlesRecursivo(Control contenedor, bool estadoHabilitado)
        {
            foreach (Control c in contenedor.Controls)
            {
                // No tocamos el DataGridView aquí, se maneja en el método padre
                if (c != dgvClientes)
                {
                    c.Enabled = estadoHabilitado;
                }

                // Si el control contiene otros controles
                if (c.HasChildren)
                    HabilitarControlesRecursivo(c, estadoHabilitado);
            }
        }*/



        private void BloquearRecursivo(Control parent, bool bloquear)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // NO bloquear el DGV
                if (ctrl == dgvClientes)
                    continue;

                // NO bloquear el contenedor que lo contiene
                if (ContieneControl(ctrl, dgvClientes))
                    continue;

                ctrl.Enabled = !bloquear;

                // Recursividad para llegar a TODOS los controles
                if (ctrl.HasChildren)
                    BloquearRecursivo(ctrl, bloquear);
            }
        }

        private bool ContieneControl(Control parent, Control child)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl == child)
                    return true;

                if (ctrl.HasChildren && ContieneControl(ctrl, child))
                    return true;
            }
            return false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // 1. Validar selección
            if (dgvClientes.SelectedRows.Count == 0 && dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente primero.");
                return;
            }

            // 2. Bloquear interfaz (Esto ahora usará la lógica corregida del Paso 1)
            BloquearControles(true);

            // 3. Configurar DGV para edición
            dgvClientes.ReadOnly = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvClientes.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            // 4. Configurar columnas (bloquear ID)
            foreach (DataGridViewColumn col in dgvClientes.Columns)
            {
                if (col.Name == "IdCliente") col.ReadOnly = true;
                else col.ReadOnly = false;
            }

            // 5. PONER EL FOCO Y ABRIR EDICIÓN AUTOMÁTICAMENTE
            dgvClientes.Focus();

            // Identificamos la columna 'Nombre' (o la columna 1) para empezar a editar ahí
            if (dgvClientes.CurrentRow != null)
            {
                // Nos aseguramos de ir a la celda de Nombre
                dgvClientes.CurrentCell = dgvClientes.CurrentRow.Cells["Nombre"];

                // Esta línea es mágica: Fuerza al DGV a mostrar el cursor de texto
                dgvClientes.BeginEdit(true);
            }

            // Mensaje opcional (a veces es mejor quitarlo para que el usuario escriba directo)
            // MessageBox.Show("Modo edición activado..."); 
        }



        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !dgvClientes.ReadOnly)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                dgvClientes.EndEdit(); // <-- dispara CellEndEdit
            }
        }


        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita doble clic en headers

            // 1. Habilitar edición SOLO en el DGV
            dgvClientes.ReadOnly = false;
            dgvClientes.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 2. Bloquear TODOS los controles excepto el DGV
            BloquearControles(true);
            

            // 3. Activar edición inmediatamente
            dgvClientes.CurrentCell = dgvClientes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dgvClientes.BeginEdit(true);
        }
        private async void dgvClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.ReadOnly) return;

            if (dgvClientes.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);

            string nombre = dgvClientes.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "";
            string documento = dgvClientes.CurrentRow.Cells["Documento"].Value?.ToString() ?? "";
            string telefono = dgvClientes.CurrentRow.Cells["Telefono"].Value?.ToString() ?? "";
            string correo = dgvClientes.CurrentRow.Cells["Email"].Value?.ToString() ?? "";
            string nacionalidad = dgvClientes.CurrentRow.Cells["Nacionalidad"].Value?.ToString() ?? "";

            try
            {
                using (var conn = _conexion.CrearConexion())
                {
                    await conn.OpenAsync();

                    string query = @"UPDATE Cliente SET 
                                Nombre=@Nombre,
                                Documento=@Documento,
                                Telefono=@Telefono,
                                Email=@Email,
                                Nacionalidad=@Nacionalidad
                             WHERE IdCliente=@IdCliente";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", id);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Documento", documento);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Email", correo);
                        cmd.Parameters.AddWithValue("@Nacionalidad", nacionalidad);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                // Refrescar UI
                await CargarClientesAsync();
                await CargarCedulas();
                await CargarIdsClientes();

                dgvClientes.ReadOnly = true;
                dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvClientes.EditMode = DataGridViewEditMode.EditProgrammatically;

                BloquearControles(false);
               

                MessageBox.Show("Cambios guardados correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }







    }
}
