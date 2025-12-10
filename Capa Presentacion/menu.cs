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
using Capa_Negocio.Habitacion.Servicios;
using Capa_Negocio.Reserva.Servicios;
using Capa_Negocio.Reserva;
using Capa_Negocio.Habitacion;

namespace Capa_Presentacion
{
    public partial class menu : MaterialForm
    {
        // Servicio de la capa negocio
        private readonly ClienteServicios _clienteServicios = new ClienteServicios();

        // Token para operaciones async
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        private readonly Capa_datos.ConexionBD _conexion = new Capa_datos.ConexionBD();
        private readonly HabitacionService _habitacionService;
        private readonly ReservaService _reservaService;



        public menu()
        {
            InitializeComponent();
            _habitacionService = new HabitacionService();
            _reservaService = new ReservaService(_habitacionService);
            
            dgvClientes.ReadOnly = true;                 // No permitir editar celdas
            dgvClientes.AllowUserToAddRows = false;      // No permitir agregar filas
            dgvClientes.AllowUserToDeleteRows = false;   // No permitir eliminar filas
            dgvClientes.AllowUserToResizeRows = false;   // No permitir cambiar tamaño de filas
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección por fila
            dgvClientes.MultiSelect = false;             // Solo una fila a la vez
            dgvClientes.RowHeadersVisible = false;       // Quitar columna extra de la izquierda
            dgvHabitaciones.ReadOnly = true;
            dgvHabitaciones.AllowUserToAddRows = false;
            dgvHabitaciones.AllowUserToDeleteRows = false;
            dgvHabitaciones.AllowUserToResizeRows = false;
            dgvHabitaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar toda la fila (necesario para eliminar con un solo clic)
            dgvHabitaciones.MultiSelect = false;
            dgvHabitaciones.RowHeadersVisible = false;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedula.DropDownStyle = ComboBoxStyle.DropDownList;
            txtNumeroHab.KeyPress += txtNumeroHab_KeyPress;
            cmbIDH.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoH.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPrecioN.KeyPress += txtPrecioN_KeyPress;
            









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

            btnRegistrarH.Click += btnRegistrarH_Click;
            BuscarH.Click += btnBuscarH_Click;
            btnLimpiarH.Click += BtnLimpiarH_Click;
            btnRegistrarR.Click += btnRegistrarR_Click;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            btnEliminarHab.Click += btnEliminarHab_Click;


        }

        private void BtnLimpiarH_Click(object? sender, EventArgs e)
        {
            // Restaurar combos
            cmbIDH.SelectedIndex = 0;     // "Todas"
            cmbEstadoH.SelectedIndex = -1; // Nada seleccionado (o añade "Todos" si quieres)

            // Recargar el DataGridView completo
            CargarHabitaciones();
        }

        private async void menu_Load(object sender, EventArgs e)
        {
            // Cargar clientes en el DataGrid al abrir el formulario
            await CargarClientesAsync();
            await CargarCedulas();
            await CargarIdsClientes();
            CargarEstadosHabitacion();
            CargarTiposHabitacion();
            CargarIDs();
            CargarEstados();
            await CargarClientesReserva();
            await CargarHabitacionesReserva();
            CargarOpcionesCheckInOut();

            




            // Cargar habitaciones desde la BD
            CargarHabitaciones();
            await CargarReservasEnDGVAsync();
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
                await CargarClientesReserva();
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
        private void CargarEstadosHabitacion()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Ocupada");
            cmbEstado.Items.Add("Mantenimiento");

            cmbEstado.SelectedIndex = -1;
        }
        private void CargarTiposHabitacion()
        {
            cmbTipo.Items.Clear();

            cmbTipo.Items.Add("Simple");
            cmbTipo.Items.Add("Doble");
            cmbTipo.Items.Add("Suite");
            cmbTipo.Items.Add("Presidencial");

            cmbTipo.SelectedIndex = -1;
        }
        private void CargarHabitaciones()
        {
            try // Añadimos try-catch por si la conexión falla.
            {
                using (var conn = _conexion.CrearConexion())
                {
                    conn.Open();

                    // Incluimos PrecioPorNoche como acordamos
                    string query = "SELECT IdHabitacion, Numero, Nombre, Tipo, PrecioPorNoche, Estado FROM Habitacion";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);

                        // --------------------------------------------
                        // Convertir NUMEROS → TEXTO (Tipo y Estado)
                        // --------------------------------------------
                        tabla.Columns.Add("TipoTexto", typeof(string));
                        tabla.Columns.Add("EstadoTexto", typeof(string));

                        foreach (DataRow row in tabla.Rows)
                        {
                            // Tipo: 1-4
                            int tipo = Convert.ToInt32(row["Tipo"]);
                            row["TipoTexto"] = tipo switch
                            {
                                1 => "Simple",
                                2 => "Doble",
                                3 => "Suite",
                                4 => "Presidencial",
                                _ => "Desconocido"
                            };

                            // Estado: 0-2
                            int estado = Convert.ToInt32(row["Estado"]);
                            row["EstadoTexto"] = estado switch
                            {
                                0 => "Disponible",
                                1 => "Ocupada",
                                2 => "Mantenimiento",
                                _ => "Desconocido"
                            };
                        }

                        // Mostrar en el DGV
                        dgvHabitaciones.DataSource = tabla;

                        // --------------------------------------------
                        // RENOMBRAR Y OCULTAR COLUMNAS (Añadir comprobación)
                        // --------------------------------------------

                        // dgvHabitaciones.Columns.Contains("NombreDeColumna") es la clave

                        if (dgvHabitaciones.Columns.Contains("IdHabitacion"))
                            dgvHabitaciones.Columns["IdHabitacion"].HeaderText = "ID";

                        if (dgvHabitaciones.Columns.Contains("Numero"))
                            dgvHabitaciones.Columns["Numero"].HeaderText = "Número";

                        if (dgvHabitaciones.Columns.Contains("Nombre"))
                            dgvHabitaciones.Columns["Nombre"].HeaderText = "Nombre";

                        // Las columnas que causaron el error:
                        if (dgvHabitaciones.Columns.Contains("TipoTexto"))
                            dgvHabitaciones.Columns["TipoTexto"].HeaderText = "Tipo";

                        if (dgvHabitaciones.Columns.Contains("EstadoTexto"))
                            dgvHabitaciones.Columns["EstadoTexto"].HeaderText = "Estado";

                        if (dgvHabitaciones.Columns.Contains("PrecioPorNoche"))
                            dgvHabitaciones.Columns["PrecioPorNoche"].HeaderText = "Precio/Noche";


                        // Ocultar columnas numéricas (si existen)
                        if (dgvHabitaciones.Columns.Contains("Tipo"))
                            dgvHabitaciones.Columns["Tipo"].Visible = false;

                        if (dgvHabitaciones.Columns.Contains("Estado"))
                            dgvHabitaciones.Columns["Estado"].Visible = false;

                        // Ocultamos la descripción (si no queremos verla)
                        if (dgvHabitaciones.Columns.Contains("Descripcion"))
                            dgvHabitaciones.Columns["Descripcion"].Visible = false;

                        // Asegurar que el DGV se ajuste al contenido
                        dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las habitaciones: {ex.Message}", "Error de Base de Datos/UI");
            }
        }


        // Capa_Presentacion.menu.cs

        // Capa_Presentacion.menu.cs

        private async void btnRegistrarH_Click(object sender, EventArgs e)
        {
            try
            {
                // Usamos una variable local para el Nombre, que usaremos si el control existe:
                // Si el control está declarado, esto funcionará. 
                string nombreHabitacion = txtNombreH.Text.Trim(); // Si txtNombreH existe, obtiene su valor.

                if (string.IsNullOrWhiteSpace(txtNumeroHab.Text) ||
                    cmbEstado.SelectedIndex == -1 ||
                    cmbTipo.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtPrecioN.Text) ||
                    string.IsNullOrWhiteSpace(nombreHabitacion)) // <<--- Validación con la variable local
                {
                    MessageBox.Show("Completa todos los campos obligatorios (Número, Tipo, Estado, Nombre y Precio por Noche).");
                    return;
                }

                // Validación de precio (se mantiene)
                if (!decimal.TryParse(txtPrecioN.Text.Trim(), out decimal precio))
                {
                    MessageBox.Show("El precio por noche debe ser un valor numérico válido.");
                    return;
                }
                if (precio <= 0)
                {
                    MessageBox.Show("El precio por noche debe ser mayor a cero.");
                    return;
                }

                // 1. Obtener valores y mapear al objeto de negocio
                int numero = int.Parse(txtNumeroHab.Text);
                int tipoInt = cmbTipo.SelectedIndex + 1;
                int estadoInt = cmbEstado.SelectedIndex;

                var tipoEnum = (TipoHabitacion)tipoInt;
                HabitacionBase habitacion;

                // Crear la instancia de la subclase correcta (se mantiene)
                switch (tipoEnum)
                {
                    case TipoHabitacion.Simple:
                        habitacion = new Simple(); break;
                    case TipoHabitacion.Doble:
                        habitacion = new Doble(); break;
                    case TipoHabitacion.Suite:
                        habitacion = new Suite(); break;
                    case TipoHabitacion.Presidencial:
                        habitacion = new Presidencial(); break;
                    default:
                        throw new Exception("Tipo de habitación no válido.");
                }

                habitacion.Numero = numero;
                // ASIGNACIÓN CLAVE: Usamos el nombre local
                habitacion.Nombre = nombreHabitacion;

                habitacion.Estado = (EstadoHabitacion)estadoInt;
                habitacion.Descripcion = nombreHabitacion; // Usamos Nombre como descripción
                habitacion.PrecioPorNoche = precio;

                // 2. Llamar al servicio de negocio (se mantiene)
                await _habitacionService.CrearHabitacionAsync(habitacion, _cts.Token);

                MessageBox.Show("Habitación registrada correctamente.");

                // 3. Limpiar campos y recargar DGV
                txtNumeroHab.Text = "";
                cmbEstado.SelectedIndex = -1;
                cmbTipo.SelectedIndex = -1;
                txtPrecioN.Text = "";
                txtNombreH.Text = ""; // <--- Esta línea requiere que txtNombreH exista

                // Recargar DGV
                CargarHabitaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la habitación: " + ex.Message);
            }
        }
        

        private void txtPrecioN_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos, la tecla de control (borrar, etc.) y un solo separador decimal (punto o coma)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true; // Bloquea otros caracteres
            }

            // Asegura que solo se puede ingresar un punto/coma decimal
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                if (((TextBox)sender).Text.Contains(".") || ((TextBox)sender).Text.Contains(","))
                {
                    e.Handled = true; // Bloquea si ya hay un separador decimal
                }
            }
        }
        private void txtNumeroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y tecla de borrar
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void CargarIDs()
        {
            cmbIDH.Items.Clear();
            cmbIDH.Items.Add("Todas");

            using (SqlConnection cn = _conexion.CrearConexion())
            {
                string query = "SELECT IdHabitacion FROM Habitacion";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbIDH.Items.Add(dr["IdHabitacion"].ToString());
                }
            }
            cmbIDH.SelectedIndex = 0;

            cmbIDH.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private int EstadoTextoAInt(string estado)
        {
            return estado switch
            {
                "Disponible" => 0,
                "Ocupada" => 1,
                "Mantenimiento" => 2,
                _ => -1
            };
        }
        



        private void CargarEstados()
        {
            cmbEstadoH.Items.Clear();

            cmbEstadoH.Items.Add("Disponible");     // 0
            cmbEstadoH.Items.Add("Ocupada");        // 1
            cmbEstadoH.Items.Add("Mantenimiento");  // 2

            cmbEstadoH.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbIDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIDH.SelectedIndex == -1) return;

            using (SqlConnection cn = _conexion.CrearConexion())
            {
                string query = "SELECT * FROM Habitacion WHERE IdHabitacion = @id";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@id", cmbIDH.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvHabitaciones.DataSource = dt;
                FormatearDgvHabitaciones();
            }
        }

        private void cmbEstadoH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstadoH.SelectedIndex == -1) return;

            int estadoInt = EstadoTextoAInt(cmbEstadoH.Text);

            using (SqlConnection cn = _conexion.CrearConexion())
            {
                string query = "SELECT * FROM Habitacion WHERE Estado = @estado";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.SelectCommand.Parameters.AddWithValue("@estado", estadoInt);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvHabitaciones.DataSource = dt;
                FormatearDgvHabitaciones();
            }
        }

        // ...
        // Capa_Presentacion.menu.cs

        private void btnBuscarH_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = _conexion.CrearConexion())
            {
                try
                {
                    cn.Open();

                    // 1. Construir la consulta base (incluyendo PrecioPorNoche)
                    string query = "SELECT IdHabitacion, Numero, Nombre, Tipo, PrecioPorNoche, Estado, Descripcion FROM Habitacion WHERE 1=1";

                    // 2. Aplicar filtros (ID y Estado)
                    if (!string.IsNullOrWhiteSpace(cmbIDH.Text) && cmbIDH.Text != "Todas")
                        query += " AND IdHabitacion = @Id";

                    if (!string.IsNullOrWhiteSpace(cmbEstadoH.Text))
                        query += " AND Estado = @Estado";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        // 3. Asignar parámetros
                        if (!string.IsNullOrWhiteSpace(cmbIDH.Text) && cmbIDH.Text != "Todas")
                            cmd.Parameters.AddWithValue("@Id", cmbIDH.Text);

                        if (!string.IsNullOrWhiteSpace(cmbEstadoH.Text))
                            // IMPORTANTE: cmbEstadoH.SelectedIndex devuelve 0, 1, 2 que coinciden con los valores de la BD.
                            cmd.Parameters.AddWithValue("@Estado", cmbEstadoH.SelectedIndex);

                        // 4. Llenar el DataTable
                        DataTable tabla = new DataTable();
                        new SqlDataAdapter(cmd).Fill(tabla);

                        // 5. CONVERTIR NÚMEROS A TEXTO (Lógica copiada de CargarHabitaciones)
                        tabla.Columns.Add("TipoTexto", typeof(string));
                        tabla.Columns.Add("EstadoTexto", typeof(string));

                        foreach (DataRow row in tabla.Rows)
                        {
                            int tipo = Convert.ToInt32(row["Tipo"]);
                            row["TipoTexto"] = tipo switch
                            {
                                1 => "Simple",
                                2 => "Doble",
                                3 => "Suite",
                                4 => "Presidencial",
                                _ => "Desconocido"
                            };

                            int estado = Convert.ToInt32(row["Estado"]);
                            row["EstadoTexto"] = estado switch
                            {
                                0 => "Disponible",
                                1 => "Ocupada",
                                2 => "Mantenimiento",
                                _ => "Desconocido"
                            };
                        }

                        // 6. Asignar y Formatear DGV
                        dgvHabitaciones.DataSource = tabla;

                        // Aplicar formato de columnas:
                        if (dgvHabitaciones.Columns.Contains("IdHabitacion"))
                            dgvHabitaciones.Columns["IdHabitacion"].HeaderText = "ID";

                        if (dgvHabitaciones.Columns.Contains("Numero"))
                            dgvHabitaciones.Columns["Numero"].HeaderText = "Número";

                        if (dgvHabitaciones.Columns.Contains("Nombre"))
                            dgvHabitaciones.Columns["Nombre"].HeaderText = "Nombre";

                        // Columnas de texto (visible y con header)
                        if (dgvHabitaciones.Columns.Contains("TipoTexto"))
                            dgvHabitaciones.Columns["TipoTexto"].HeaderText = "Tipo";

                        if (dgvHabitaciones.Columns.Contains("EstadoTexto"))
                            dgvHabitaciones.Columns["EstadoTexto"].HeaderText = "Estado";

                        if (dgvHabitaciones.Columns.Contains("PrecioPorNoche"))
                            dgvHabitaciones.Columns["PrecioPorNoche"].HeaderText = "Precio/Noche";

                        // Ocultar las columnas originales y Descripción
                        if (dgvHabitaciones.Columns.Contains("Tipo"))
                            dgvHabitaciones.Columns["Tipo"].Visible = false;

                        if (dgvHabitaciones.Columns.Contains("Estado"))
                            dgvHabitaciones.Columns["Estado"].Visible = false;

                        if (dgvHabitaciones.Columns.Contains("Descripcion"))
                            dgvHabitaciones.Columns["Descripcion"].Visible = false;

                        dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en la búsqueda de habitaciones: {ex.Message}", "Error de Búsqueda");
                }
            }
        }



        private void FormatearDgvHabitaciones()
        {
            if (dgvHabitaciones.Columns.Count == 0) return;

            // Si se cargó con SELECT *, puede que no existan las columnas de texto, 
            // pero sí la columna de la BD. 

            // Ocultar columnas que NO quieres (si existen)
            if (dgvHabitaciones.Columns.Contains("Descripcion"))
                dgvHabitaciones.Columns["Descripcion"].Visible = false;

            if (dgvHabitaciones.Columns.Contains("IdHabitacion"))
                dgvHabitaciones.Columns["IdHabitacion"].HeaderText = "ID";

            if (dgvHabitaciones.Columns.Contains("Numero"))
                dgvHabitaciones.Columns["Numero"].HeaderText = "Número";

            if (dgvHabitaciones.Columns.Contains("Tipo"))
                dgvHabitaciones.Columns["Tipo"].HeaderText = "Tipo";

            if (dgvHabitaciones.Columns.Contains("Nombre"))
                dgvHabitaciones.Columns["Nombre"].HeaderText = "Nombre";

            if (dgvHabitaciones.Columns.Contains("PrecioPorNoche"))
                dgvHabitaciones.Columns["PrecioPorNoche"].HeaderText = "Precio por noche";

            if (dgvHabitaciones.Columns.Contains("Estado"))
                dgvHabitaciones.Columns["Estado"].HeaderText = "Estado";

            // Ajustar tamaño automático
            dgvHabitaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task CargarClientesReserva()
        {
            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();

                string query = "SELECT IdCliente, Nombre FROM Cliente";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    cbmElegirCliente.DataSource = tabla;
                    cbmElegirCliente.DisplayMember = "Nombre";      // Lo que se muestra
                    cbmElegirCliente.ValueMember = "IdCliente";      // Lo que se usa internamente
                    cbmElegirCliente.SelectedIndex = -1;             // Ninguno seleccionado
                }
            }
        }


        private async Task CargarHabitacionesReserva()
        {
            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();

                string sql = "SELECT IdHabitacion, Numero FROM Habitacion ORDER BY Numero";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);

                    cbmElegirHR.DataSource = tabla;
                    cbmElegirHR.DisplayMember = "Numero";
                    cbmElegirHR.ValueMember = "IdHabitacion";
                }
            }

            cbmElegirHR.SelectedIndex = -1;
        }

        private void CargarOpcionesCheckInOut()
        {
            cbmCiO.Items.Clear();
            cbmCiO.Items.Add("Check-In");
            cbmCiO.Items.Add("Check-Out");
            cbmCiO.SelectedIndex = -1;
        }


        // Capa_Presentacion.menu.cs

        private async void btnRegistrarR_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones
                if (cbmElegirCliente.SelectedValue == null || cbmElegirHR.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un Cliente y una Habitación.");
                    return;
                }

                // Asumiendo que DateEntrada y DateSalida existen:
                DateTime fechaEntrada = dateEntrada.Value.Date; // Solo la fecha
                DateTime fechaSalida = dateSalida.Value.Date;   // Solo la fecha

                if (fechaSalida <= fechaEntrada)
                {
                    MessageBox.Show("La fecha de salida debe ser posterior a la fecha de entrada.");
                    return;
                }

                // El ComboBox cbmCiO (Check In/Out) no se usa para la creación inicial, 
                // ya que la reserva siempre se crea como 'Reservada' (0) por el Servicio.

                // 2. Mapeo del objeto Reserva
                var reserva = new Reserva
                {
                    IdCliente = Convert.ToInt32(cbmElegirCliente.SelectedValue),
                    IdHabitacion = Convert.ToInt32(cbmElegirHR.SelectedValue),
                    FechaEntrada = fechaEntrada,
                    FechaSalida = fechaSalida,

                    // Enviamos 0.0m. El ReservaService se encarga de buscar el precio 
                    // de la habitación en la BD antes de guardar (ver lógica en el servicio).
                    PrecioPorNoche = 0m,

                    // El campo FechaCreacion es manejado automáticamente por la BD o por el constructor de Reserva.
                    // El EstadoReserva se establece en 0 (Reservada) en la Capa de Negocio.

                    // Si tienes un TextBox para notas (ej: txtNotasR):
                    // Notas = txtNotasR.Text.Trim()
                    Notas = "" // O usa un TextBox si existe
                };

                // 3. Registrar
                await _reservaService.CrearReservaAsync(reserva, CancellationToken.None);

                MessageBox.Show($"Reserva #{reserva.IdReserva} creada con éxito para la Habitación {reserva.IdHabitacion}.");

                // Limpiar Controles de Reserva
                cbmElegirCliente.SelectedIndex = -1;
                cbmElegirHR.SelectedIndex = -1;
                // Asumiendo que DateEntrada/Salida se reinician o mantienen la fecha actual

                // 4. Recargar DGV
                await CargarReservasEnDGVAsync();

                // 5. Opcional: Recargar habitaciones para ver el estado 'Ocupada'
                CargarHabitaciones();
            }
            catch (HabitacionNoDisponibleException ex)
            {
                MessageBox.Show("Error de Disponibilidad: " + ex.Message, "Error");
            }
            catch (FechaInvalidaException ex)
            {
                MessageBox.Show("Error de Fechas: " + ex.Message, "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la reserva: {ex.Message}", "Error General");
            }
        }





        private async Task CargarReservasEnDGVAsync()
        {
            try
            {
                var cts = new CancellationTokenSource();
                var reservas = await _reservaService.ObtenerReservasActivasAsync(cts.Token);

                dgvReserva.DataSource = reservas;

                dgvReserva.Columns["IdReserva"].HeaderText = "Reserva";
                dgvReserva.Columns["IdHabitacion"].HeaderText = "Habitación";
                dgvReserva.Columns["IdCliente"].HeaderText = "Cliente";
                dgvReserva.Columns["FechaEntrada"].HeaderText = "Entrada";
                dgvReserva.Columns["FechaSalida"].HeaderText = "Salida";
                dgvReserva.Columns["EstadoReserva"].HeaderText = "Estado";
                dgvReserva.Columns["PrecioPorNoche"].HeaderText = "Precio/Noche";
                dgvReserva.Columns["FechaCreacion"].HeaderText = "Creación";
                dgvReserva.Columns["Notas"].HeaderText = "Notas";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reservas: " + ex.Message);
            }
        }

        // Capa_Presentacion.menu.cs

        private async void CbmElegirHR_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbmElegirHR.SelectedValue == null) return;

            // Obtenemos el IdHabitacion seleccionado
            if (int.TryParse(cbmElegirHR.SelectedValue.ToString(), out int idHabitacion))
            {
                try
                {
                    // Usamos el servicio para obtener los detalles de la habitación (incluyendo el precio)
                    var habitacion = await _habitacionService.ObtenerPorIdAsync(idHabitacion, _cts.Token);

                    if (habitacion != null)
                    {
                        
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores de conexión o servicio
                    MessageBox.Show($"Error al cargar el precio de la habitación: {ex.Message}", "Error");
                }
            }
        }
       

        private async void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            // 1. Verificar selección
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona el cliente que deseas eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el ID
            // Se asume que la columna 'IdCliente' existe y es donde se extrae el valor.
            int idCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["IdCliente"].Value);

            // 3. Confirmación
            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar el cliente con ID {idCliente}? Esto puede fallar si tiene reservas o facturas asociadas.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 4. Llamar al servicio de negocio para eliminar
                    // Usamos _clienteServicios que contiene el método EliminarClienteAsync
                    await _clienteServicios.EliminarClienteAsync(idCliente, _cts.Token);

                    MessageBox.Show($"Cliente ID {idCliente} eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Actualizar la interfaz (DGV y todos los ComboBoxes de cliente/reserva)
                    await CargarClientesAsync();
                    await CargarCedulas();
                    await CargarIdsClientes();
                    await CargarClientesReserva(); // Actualiza el ComboBox de reserva (cbmElegirCliente)

                    // Recargar reservas, ya que las reservas sin cliente pueden causar problemas, 
                    // pero la BD debería haberlo bloqueado (Foreign Key Constraint).
                    await CargarReservasEnDGVAsync();

                }
                catch (Microsoft.Data.SqlClient.SqlException sqlEx)
                {
                    // Manejar error de llave foránea (Error 547)
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("No se puede eliminar el cliente porque tiene reservas o facturas activas/asociadas.", "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Error de SQL al eliminar: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private async void btnEliminarHab_Click(object sender, EventArgs e)
        {
            // 1. Verificar selección
            if (dgvHabitaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona la habitación que deseas eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el ID (y el Número para el mensaje)
            int idHabitacion = Convert.ToInt32(dgvHabitaciones.SelectedRows[0].Cells["IdHabitacion"].Value);
            // Usamos 'Numero' para el mensaje, asumiendo que es una columna visible:
            string numeroHab = dgvHabitaciones.SelectedRows[0].Cells["Numero"].Value.ToString();


            // 3. Confirmación
            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar la habitación {numeroHab} (ID: {idHabitacion})? Esto puede fallar si tiene reservas o facturas asociadas.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 4. Llamar al servicio de negocio para eliminar
                    // Usamos _habitacionService que contiene el método EliminarHabitacionAsync
                    await _habitacionService.EliminarHabitacionAsync(idHabitacion, _cts.Token);

                    MessageBox.Show($"Habitación {numeroHab} eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Actualizar la interfaz (DGV, ComboBoxes de habitaciones y reserva)
                    CargarHabitaciones();          // Recargar el DGV de Habitaciones
                    CargarIDs();                   // Recargar los ComboBoxes de búsqueda (cmbIDH)
                    await CargarHabitacionesReserva(); // Recargar el ComboBox de reserva (cbmElegirHR)
                    await CargarReservasEnDGVAsync(); // Recargar las reservas para actualizar la vista

                }
                catch (Microsoft.Data.SqlClient.SqlException sqlEx)
                {
                    // Manejar error de llave foránea (Error 547)
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("No se puede eliminar la habitación porque está asociada a reservas o facturas. Elimine primero las dependencias.", "Error de Integridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Error de SQL al eliminar: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado al eliminar la habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }













    }
}
