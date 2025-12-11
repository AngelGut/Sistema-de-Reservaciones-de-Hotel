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
using Capa_Negocio.Factura;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Capa_Presentacion
{
    public partial class menu : MaterialForm
    {
        // Servicio de la capa negocio
        private readonly ClienteServicios _clienteServicios = new ClienteServicios();

        // Token para operaciones async
        

        private readonly Capa_datos.ConexionBD _conexion = new Capa_datos.ConexionBD();
        private readonly HabitacionService _habitacionService;
        private readonly ReservaService _reservaService;
        private readonly FacturaService _facturaService;


        public menu()
        {
            InitializeComponent();
            _habitacionService = new HabitacionService();
            _reservaService = new ReservaService(_habitacionService);
            _facturaService = new FacturaService(_reservaService);
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
            dgvReserva.ReadOnly = true; // No se puede editar
            dgvReserva.AllowUserToAddRows = false; // No permite agregar filas
            dgvReserva.AllowUserToDeleteRows = false; // No permite eliminar con Suprimir
            dgvReserva.AllowUserToResizeRows = false; // No permite redimensionar filas
            dgvReserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Esencial: Selecciona toda la fila con un clic
            dgvReserva.MultiSelect = false; // Solo una fila a la vez
            dgvReserva.RowHeadersVisible = false; // Quitar la columna izquierda
            dgvFactura.ReadOnly = true;
            dgvFactura.AllowUserToAddRows = false;
            dgvFactura.AllowUserToDeleteRows = false;
            dgvFactura.AllowUserToResizeRows = false;
            dgvFactura.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFactura.MultiSelect = false;
            dgvFactura.RowHeadersVisible = false;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedula.DropDownStyle = ComboBoxStyle.DropDownList;
            txtNumeroHab.KeyPress += txtNumeroHab_KeyPress;
            cmbIDH.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoH.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPrecioN.KeyPress += txtPrecioN_KeyPress;
            this.Text = $"Hotel Leche Alegre";









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
            btnReservada.Click += btnReservada_Click;
            btnCheckI.Click += btnCheckI_Click;
            btnCheckO.Click += btnCheckO_Click;
            btnCancelada.Click += btnCancelada_Click;
            btnBuscarR.Click += btnBuscarR_Click;
            dgvHabitaciones.CellFormatting += DgvHabitaciones_CellFormatting;
            btnBuscarF.Click += btnBuscarF_Click;
            btnFactura.Click += btnFactura_Click;
            BtnGenerarFactura.Click += BtnGenerarFactura_Click;
        }

        private void BtnLimpiarH_Click(object? sender, EventArgs e)
        {
            // Restaurar combos
            cmbIDH.SelectedIndex = 0;     // "Todas"
            cmbEstadoH.SelectedIndex = -1; // Nada seleccionado (o añade "Todos" si quieres)

            // Recargar el DataGridView completo
            CargarHabitaciones();
        }

        // Capa_Presentacion.menu.cs

        private async void menu_Load(object sender, EventArgs e)
        {
            ToggleLoading(true, progressBarC); // INICIO DE CARGA GLOBAL
            try
            {
                // Carga de Clientes
                await CargarClientesAsync();
                await CargarCedulas();
                await CargarIdsClientes();

                // Carga de Habitaciones
                CargarEstadosHabitacion();
                CargarTiposHabitacion();
                CargarIDs();
                CargarEstados();

                // Carga de Reservas y Facturas
                await CargarClientesReserva();
                await CargarHabitacionesReserva();
                await CargarIdsReservas();
                await CargarIdsClientesBusqueda();
                await CargarIdsFacturas();
                await CargarFacturasEnDGVAsync();

                // Carga final de DGV (que contiene el delay más largo)
                CargarHabitaciones();
                await CargarReservasEnDGVAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la carga inicial: {ex.Message}", "Error Crítico");
            }
            finally
            {
                ToggleLoading(false, progressBarC); // FIN DE CARGA GLOBAL
            }
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
            var lista = await _clienteServicios.ObtenerTodosAsync(CancellationToken.None);
            dgvClientes.DataSource = lista;
        }

        // ----------------------------------------------------------
        // EVENTO CLICK DEL BOTÓN REGISTRAR
        // ----------------------------------------------------------
        // Capa_Presentacion.menu.cs (Modificar btnRegistrar_Click)

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Usamos un timeout de 30 segundos para las operaciones de registro general
            using (var ctsLocal = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
            {
                ToggleLoading(true, progressBarC);
                try
                {
                    // ... (validaciones existentes) ...

                    var cliente = new Cliente { /* ... */ };

                    // Guardar, pasando el token temporal
                    await _clienteServicios.CrearClienteAsync(cliente, ctsLocal.Token); // Pasa el token

                    MessageBox.Show("Cliente registrado correctamente.");

                    LimpiarCampos();

                    // ... (Actualizaciones de UI existentes, deben usar _cts.Token si no tienen timeout)
                    await CargarClientesAsync();
                    await CargarCedulas();
                    await CargarIdsClientes();
                    await CargarClientesReserva();
                    await CargarIdsClientesBusqueda();
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("La operación de registro de cliente excedió el tiempo límite.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el cliente: " + ex.Message);
                }
                finally
                { 
                    ToggleLoading(false, progressBarC); 
                }
            }
        }

        private async Task CargarCedulas()
        {
            cmbCedula.Items.Clear();   // Muy importante
            cmbCedula.Items.Add("Todas");
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


        // Capa_Presentacion.menu.cs

        private async Task CargarIdsClientes()
        {
            // 1. Limpiar la lista (CRUCIAL)
            cmbID.Items.Clear();

            // 2. AÑADIR LA OPCIÓN "TODAS" MANUALMENTE
            cmbID.Items.Add("Todas");

            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();

                // Consulta que solo trae las IDs de la base de datos
                string query = "SELECT IdCliente FROM Cliente ORDER BY IdCliente";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    // 3. Agregar los IDs numéricos de la base de datos
                    while (await reader.ReadAsync())
                    {
                        cmbID.Items.Add(reader["IdCliente"].ToString());
                    }
                }
            }

            // 4. Seleccionar "Todas" (índice 0)
            // Esto solo funciona si cmbID.DropDownStyle está en DropDownList (que ya lo tienes configurado).
            cmbID.SelectedIndex = 0;
        }
        // Capa_Presentacion.menu.cs

        private async void btnBusqueda_Click(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados de los ComboBox
            string cedula = cmbCedula.SelectedItem?.ToString();
            string idCliente = cmbID.SelectedItem?.ToString();

            bool buscarTodo = (cedula == "Todas" || string.IsNullOrWhiteSpace(cedula)) &&
                              (idCliente == "Todas" || string.IsNullOrWhiteSpace(idCliente));

            // 1. CASO DE MOSTRAR TODO
            if (buscarTodo)
            {
                await CargarClientesAsync();
                MessageBox.Show("Mostrando todos los clientes registrados.", "Búsqueda Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. CASO DE FILTRO ESPECÍFICO
            using (var conn = _conexion.CrearConexion())
            {
                ToggleLoading(true, progressBarC);
                try
                   
                {
                    await conn.OpenAsync();

                    string query = "SELECT * FROM Cliente WHERE 1=1";
                    var parametros = new List<SqlParameter>();

                    if (!(cedula == "Todas" || string.IsNullOrWhiteSpace(cedula)))
                    {
                        query += " AND Documento = @Documento";
                        parametros.Add(new SqlParameter("@Documento", cedula));
                    }

                    if (!(idCliente == "Todas" || string.IsNullOrWhiteSpace(idCliente)))
                    {
                        query += " AND IdCliente = @IdCliente";
                        // Asumiendo que el ID es un INT, asegúrate de que el valor sea correcto
                        parametros.Add(new SqlParameter("@IdCliente", idCliente));
                    }

                    // Si el usuario seleccionó uno específico, la consulta se arma con el filtro.

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());

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

                            // También rellenar los TextBox con el primer resultado
                            DataRow row = tabla.Rows[0];
                            txtNombre.Text = row["Nombre"].ToString();
                            txtTelefono.Text = row["Telefono"].ToString();
                            txtCorreo.Text = row["Email"].ToString();
                            txtNacionalidad.Text = row["Nacionalidad"].ToString();

                            MessageBox.Show("Cliente encontrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún cliente con los criterios especificados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvClientes.DataSource = null;
                            LimpiarCampos(); // Limpiar también los TextBoxes
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el cliente: " + ex.Message);
                }
                finally
                {
                    ToggleLoading(false, progressBarC);
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
        // Capa_Presentacion.menu.cs (Añade este método a la clase menu)

        private void DgvHabitaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Aseguramos que solo trabajamos con la columna que muestra el estado de texto.
            // Usamos "EstadoTexto" que es la columna legible que creamos.
            if (dgvHabitaciones.Columns[e.ColumnIndex].Name == "EstadoTexto")
            {
                string estado = e.Value?.ToString();
                Color colorDeFondo = Color.White;
                Color colorDeFuente = Color.Black;

                switch (estado)
                {
                    case "Disponible":
                        colorDeFondo = Color.LightGreen;
                        break;
                    case "Ocupada":
                        colorDeFondo = Color.LightCoral; // Rojo claro
                        colorDeFuente = Color.White; // Para mejor contraste
                        break;
                    case "Mantenimiento":
                        colorDeFondo = Color.Yellow;
                        break;
                    default:
                        // Usar color por defecto si no coincide
                        break;
                }

                e.CellStyle.BackColor = colorDeFondo;
                e.CellStyle.ForeColor = colorDeFuente;

                // Esto indica que el valor ha sido formateado, por lo que el DGV debe usar estos estilos.
                e.FormattingApplied = true;
            }
        }




        private async void btnRegistrarH_Click(object sender, EventArgs e)
        {
            ToggleLoading(true, progressBarH);
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
                await _habitacionService.CrearHabitacionAsync(habitacion, CancellationToken.None);

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
            finally
            {
                ToggleLoading(false, progressBarH);
            }
        }


        private void txtPrecioN_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            string currentText = ((System.Windows.Forms.Control)sender).Text;

            // 1. Permitir dígitos, la tecla de control (borrar, etc.) y un solo separador decimal (punto o coma)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true; // Bloquea otros caracteres
            }

            // 2. Asegura que solo se puede ingresar un punto/coma decimal
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                // Si el texto actual ya contiene un punto O una coma, bloquea el nuevo ingreso.
                if (currentText.Contains(".") || currentText.Contains(","))
                {
                    e.Handled = true; // Bloquea si ya existe un separador decimal
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

       


        // Capa_Presentacion.menu.cs

        private async void btnRegistrarR_Click(object sender, EventArgs e)
        {
            ToggleLoading(true, progressBarR);
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
                await CargarIdsReservas();
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
            finally
            {
                ToggleLoading(false, progressBarR);
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

        

        private async void CbmElegirHR_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbmElegirHR.SelectedValue == null) return;

            // Obtenemos el IdHabitacion seleccionado
            if (int.TryParse(cbmElegirHR.SelectedValue.ToString(), out int idHabitacion))
            {
                try
                {
                    // Usamos el servicio para obtener los detalles de la habitación (incluyendo el precio)
                    var habitacion = await _habitacionService.ObtenerPorIdAsync(idHabitacion, CancellationToken.None);

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


        // Capa_Presentacion.menu.cs

        private async void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            // 1. Verificar selección
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona el cliente que deseas eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener el ID
            int idCliente = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["IdCliente"].Value);

            // 3. Confirmación
            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar el cliente con ID {idCliente}? Esta acción puede fallar si tiene reservas o facturas asociadas.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // === APLICACIÓN DEL CANCELLATION TOKEN CON TIMEOUT (30 SEGUNDOS) ===
                TimeSpan timeout = TimeSpan.FromSeconds(30);
                using (var ctsGeneral = new CancellationTokenSource(timeout))
                {
                    ToggleLoading(true, progressBarC);
                    try
                    {
                        // 4. Llamar al servicio de negocio para eliminar, pasando el token temporal
                        await _clienteServicios.EliminarClienteAsync(idCliente, ctsGeneral.Token);

                        MessageBox.Show($"Cliente ID {idCliente} eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 5. Actualizar la interfaz
                        await CargarClientesAsync();
                        await CargarCedulas();
                        await CargarIdsClientes();
                        await CargarClientesReserva();
                        await CargarIdsClientesBusqueda();
                        await CargarReservasEnDGVAsync();

                    }
                    catch (OperationCanceledException)
                    {
                        // Captura si la eliminación superó los 30 segundos
                        MessageBox.Show("La operación de eliminación excedió el tiempo límite de 30 segundos y fue cancelada.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    finally 
                    { 
                        ToggleLoading(false, progressBarC);
                    }
                } // El using garantiza que ctsGeneral.Dispose() se llama al final
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
                ToggleLoading(true,progressBarH);
                try
                {
                    // 4. Llamar al servicio de negocio para eliminar
                    // Usamos _habitacionService que contiene el método EliminarHabitacionAsync
                    await _habitacionService.EliminarHabitacionAsync(idHabitacion, CancellationToken.None);

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
                finally
                {
                    ToggleLoading(false,progressBarH);
                }
            }
        }

        

        /// <summary>
        /// Obtiene el IdReserva de la fila seleccionada, o lanza una excepción si no hay selección.
        /// </summary>
        private int GetSelectedReservaId()
        {
            if (dgvReserva.SelectedRows.Count == 0)
            {
                throw new InvalidOperationException("Debes seleccionar una reserva primero.");
            }
            // Asumimos que la columna 'IdReserva' existe y es donde se toma el valor.
            return Convert.ToInt32(dgvReserva.SelectedRows[0].Cells["IdReserva"].Value);
        }

        /// <summary>
        /// Método genérico para ejecutar acciones en el servicio de reserva y actualizar la UI.
        /// </summary>
        // Capa_Presentacion.menu.cs (Reemplazar ExecuteReservaActionAsync)

        private async Task ExecuteReservaActionAsync(Func<int, CancellationToken, Task> action, string successMessage)
        {
            // Definimos el límite de 5 minutos (300 segundos) para esta operación.
            TimeSpan timeout = TimeSpan.FromMinutes(5);

            // Usamos un CTS local que se cancelará automáticamente después del timeout.
            using (var ctsTiempoLimite = new CancellationTokenSource(timeout))
            {
                ToggleLoading(true, progressBarR);
                try
                {
                    int idReserva = GetSelectedReservaId();

                    // Ejecuta la función del servicio, pasando el token con timeout.
                    await action(idReserva, ctsTiempoLimite.Token);

                    MessageBox.Show(successMessage, "Éxito");

                    // Actualizar UI
                    await CargarReservasEnDGVAsync();
                    CargarHabitaciones();
                }
                catch (OperationCanceledException)
                {
                    // Captura si la cancelación fue forzada por el timeout.
                    MessageBox.Show("La operación excedió el tiempo límite de 5 minutos y fue cancelada.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (ReservacionNoEncontradaException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error durante la operación: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ToggleLoading(false, progressBarR);
                }
            }
        }
        // Capa_Presentacion.menu.cs

        private async void btnCheckI_Click(object? sender, EventArgs e)
        {
            await ExecuteReservaActionAsync(_reservaService.CheckInAsync, "Check-In realizado con éxito. La habitación está ahora Ocupada.");
        }

        private async void btnCheckO_Click(object? sender, EventArgs e)
        {
            await ExecuteReservaActionAsync(_reservaService.CheckOutAsync, "Check-Out realizado con éxito. La habitación está ahora Disponible.");
        }

        private async void btnCancelada_Click(object? sender, EventArgs e)
        {
            await ExecuteReservaActionAsync(_reservaService.CancelarReservaAsync, "Reserva cancelada con éxito. La habitación ha sido liberada.");
        }

        private async void btnReservada_Click(object? sender, EventArgs e)
        {
            // Usamos el método de Reversión que creamos en ReservaService (paso 1.1)
            await ExecuteReservaActionAsync(_reservaService.RevertirAReservadaAsync, "Reserva revertida a estado 'Reservada' con éxito.");
        }

        // Capa_Presentacion.menu.cs

        private async Task CargarIdsReservas()
        {
            cbmBuscarIDR.Items.Clear();
            cbmBuscarIDR.Items.Add("Todas");

            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();
                string query = "SELECT IdReserva FROM Reserva ORDER BY IdReserva DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cbmBuscarIDR.Items.Add(reader["IdReserva"].ToString());
                    }
                }
            }
            cbmBuscarIDR.SelectedIndex = 0; // Selecciona "Todas" por defecto
        }

        private async Task CargarIdsClientesBusqueda()
        {
            cbmBuscarIDC.Items.Clear();
            cbmBuscarIDC.Items.Add("Todos");

            using (var conn = _conexion.CrearConexion())
            {
                await conn.OpenAsync();
                string query = "SELECT IdCliente FROM Cliente ORDER BY IdCliente";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cbmBuscarIDC.Items.Add(reader["IdCliente"].ToString());
                    }
                }
            }
            cbmBuscarIDC.SelectedIndex = 0; // Selecciona "Todos" por defecto
        }
        // Capa_Presentacion.menu.cs

        // Capa_Presentacion.menu.cs

        // Capa_Presentacion.menu.cs (Reemplazar btnBuscarR_Click)

        private async void btnBuscarR_Click(object sender, EventArgs e)
        {
            string idReservaStr = cbmBuscarIDR.SelectedItem?.ToString();
            string idClienteStr = cbmBuscarIDC.SelectedItem?.ToString();

            bool buscarTodasReservas = (idReservaStr == "Todas" || string.IsNullOrEmpty(idReservaStr));
            bool buscarTodosClientes = (idClienteStr == "Todos" || string.IsNullOrEmpty(idClienteStr));

            // 1. Caso de limpieza/mostrar todo:
            if (buscarTodasReservas && buscarTodosClientes)
            {
                await CargarReservasEnDGVAsync();
                MessageBox.Show("Mostrando todas las reservas activas.", "Búsqueda Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Caso de FILTRO específico
            try
            {
                using (var conn = _conexion.CrearConexion())
                {
                    await conn.OpenAsync();

                    string baseQuery = @"
                SELECT R.IdReserva, H.Numero AS HabitacionNumero, C.Nombre AS ClienteNombre,
                       R.FechaEntrada, R.FechaSalida, R.EstadoReserva, R.FechaCreacion, 
                       R.PrecioPorNoche, R.Notas
                FROM Reserva R
                INNER JOIN Habitacion H ON R.IdHabitacion = H.IdHabitacion
                INNER JOIN Cliente C ON R.IdCliente = C.IdCliente
                WHERE 1=1";

                    var parametros = new List<SqlParameter>();

                    if (!buscarTodasReservas)
                    {
                        baseQuery += " AND R.IdReserva = @IdReserva";
                        parametros.Add(new SqlParameter("@IdReserva", idReservaStr));
                    }

                    if (!buscarTodosClientes)
                    {
                        baseQuery += " AND R.IdCliente = @IdCliente";
                        parametros.Add(new SqlParameter("@IdCliente", idClienteStr));
                    }

                    baseQuery += " ORDER BY R.IdReserva DESC";

                    using (SqlCommand cmd = new SqlCommand(baseQuery, conn))
                    {
                        cmd.Parameters.AddRange(parametros.ToArray());

                        DataTable tabla = new DataTable();
                        new SqlDataAdapter(cmd).Fill(tabla);

                        // --- 3. CREAR COLUMNAS CALCULADAS Y DE TEXTO (FUERA DEL BUCLE) ---
                        tabla.Columns.Add("Dias", typeof(int));
                        tabla.Columns.Add("Subtotal", typeof(string));
                        tabla.Columns.Add("ITBIS", typeof(string));
                        tabla.Columns.Add("Total", typeof(string));
                        tabla.Columns.Add("EstadoTexto", typeof(string)); // Columna de estado legible


                        // --- 4. LLENAR DATOS CALCULADOS Y CONVERTIDOS DENTRO DEL BUCLE ---
                        foreach (DataRow row in tabla.Rows)
                        {
                            // Conversión y Cálculo
                            int estado = Convert.ToInt32(row["EstadoReserva"]);
                            decimal precio = Convert.ToDecimal(row["PrecioPorNoche"]);
                            DateTime fechaE = Convert.ToDateTime(row["FechaEntrada"]);
                            DateTime fechaS = Convert.ToDateTime(row["FechaSalida"]);
                            int dias = (fechaS.Date - fechaE.Date).Days;
                            decimal subtotal = precio * dias;
                            decimal itbis = subtotal * 0.18m;
                            decimal total = subtotal + itbis;


                            // Asignación de valores
                            row["Dias"] = dias;
                            row["Subtotal"] = subtotal.ToString("N2");
                            row["ITBIS"] = itbis.ToString("N2");
                            row["Total"] = total.ToString("N2");

                            // Asignación de Estado Legible
                            row["EstadoTexto"] = estado switch
                            {
                                0 => "Reservada",
                                1 => "CheckIn",
                                2 => "CheckOut",
                                3 => "Cancelada",
                                _ => "Desconocido"
                            };
                        }

                        dgvReserva.DataSource = tabla;
                        FormatearDgvReservasBusqueda(dgvReserva);

                        if (tabla.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron reservas con los criterios seleccionados.", "Búsqueda vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar reservas: {ex.Message}", "Error");
            }
        }

        

        private async void btnLimpiarR_Click(object sender, EventArgs e)
        {
            // 1. Limpiar filtros
            cbmBuscarIDR.SelectedIndex = 0; // "Todas"
            cbmBuscarIDC.SelectedIndex = 0; // "Todos"

            // 2. Recargar el DGV con todas las reservas activas (vista por defecto)
            await CargarReservasEnDGVAsync();
        }
        // Capa_Presentacion.menu.cs

        private void FormatearDgvReservasBusqueda(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            // --- Renombrar Columnas Principales ---
            if (dgv.Columns.Contains("IdReserva")) dgv.Columns["IdReserva"].HeaderText = "ID Reserva";
            if (dgv.Columns.Contains("HabitacionNumero")) dgv.Columns["HabitacionNumero"].HeaderText = "Habitación";
            if (dgv.Columns.Contains("ClienteNombre")) dgv.Columns["ClienteNombre"].HeaderText = "Cliente";

            // --- Fechas ---
            if (dgv.Columns.Contains("FechaEntrada")) dgv.Columns["FechaEntrada"].HeaderText = "Entrada";
            if (dgv.Columns.Contains("FechaSalida")) dgv.Columns["FechaSalida"].HeaderText = "Salida";
            if (dgv.Columns.Contains("FechaCreacion")) dgv.Columns["FechaCreacion"].HeaderText = "Creación";

            // --- Estado (Texto Legible) ---
            if (dgv.Columns.Contains("EstadoTexto"))
            {
                dgv.Columns["EstadoTexto"].HeaderText = "Estado";
                dgv.Columns["EstadoTexto"].Visible = true; // Aseguramos que se vea el texto
            }

            // --- Valores Financieros y Calculados (Añadido para las columnas creadas en btnBuscarR) ---
            if (dgv.Columns.Contains("PrecioPorNoche")) dgv.Columns["PrecioPorNoche"].HeaderText = "Precio/Noche";
            if (dgv.Columns.Contains("Dias")) dgv.Columns["Dias"].HeaderText = "Días";
            if (dgv.Columns.Contains("Subtotal")) dgv.Columns["Subtotal"].HeaderText = "Subtotal";
            if (dgv.Columns.Contains("ITBIS")) dgv.Columns["ITBIS"].HeaderText = "ITBIS (18%)";
            if (dgv.Columns.Contains("Total")) dgv.Columns["Total"].HeaderText = "TOTAL";

            // --- Ocultar Columnas Numéricas/Redundantes ---
            if (dgv.Columns.Contains("IdHabitacion")) dgv.Columns["IdHabitacion"].Visible = false;
            if (dgv.Columns.Contains("IdCliente")) dgv.Columns["IdCliente"].Visible = false;

            // Ocultar el estado numérico original y las notas
            if (dgv.Columns.Contains("EstadoReserva")) dgv.Columns["EstadoReserva"].Visible = false;
            if (dgv.Columns.Contains("Notas")) dgv.Columns["Notas"].Visible = false;

            // --- Ajuste Final ---
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async Task CargarIdsFacturas()
        {
            cbmFactura.Items.Clear();
            cbmFactura.Items.Add("Todas");

            try
            {
                // No hay un método para solo IDs, así que cargamos todas las facturas
                var lista = await _facturaService.ObtenerTodasAsync(CancellationToken.None);

                foreach (var factura in lista.OrderByDescending(f => f.IdFactura))
                {
                    cbmFactura.Items.Add(factura.IdFactura.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar IDs de facturas: {ex.Message}");
            }

            cbmFactura.SelectedIndex = 0; // Selecciona "Todas"
        }

        /// <summary>
        /// Carga todas las facturas en el DGV. Usado para la carga inicial y el botón de búsqueda "Todas".
        /// </summary>
        private async Task CargarFacturasEnDGVAsync()
        {
            try
            {
                var lista = await _facturaService.ObtenerTodasAsync(CancellationToken.None);

                dgvFactura.DataSource = lista.Select(f => new
                {
                    f.IdFactura,
                    f.IdReserva,
                    FechaEmision = f.FechaEmision.ToString("dd/MM/yyyy HH:mm"), // Formato legible
                    Subtotal = f.Subtotal.ToString("N2"),
                    Itbis = f.Itbis.ToString("N2"),
                    Total = f.Total.ToString("N2")
                }).ToList();

                FormatearDgvFactura();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el DGV de facturas: {ex.Message}");
            }
        }

        /// <summary>
        /// Aplica el formato y encabezados al dgvFactura.
        /// </summary>
        private void FormatearDgvFactura()
        {
            if (dgvFactura.Columns.Count == 0) return;

            if (dgvFactura.Columns.Contains("IdFactura")) dgvFactura.Columns["IdFactura"].HeaderText = "ID Factura";
            if (dgvFactura.Columns.Contains("IdReserva")) dgvFactura.Columns["IdReserva"].HeaderText = "ID Reserva";
            if (dgvFactura.Columns.Contains("FechaEmision")) dgvFactura.Columns["FechaEmision"].HeaderText = "Emisión";
            if (dgvFactura.Columns.Contains("Subtotal")) dgvFactura.Columns["Subtotal"].HeaderText = "Subtotal";
            if (dgvFactura.Columns.Contains("Itbis")) dgvFactura.Columns["Itbis"].HeaderText = "ITBIS";
            if (dgvFactura.Columns.Contains("Total")) dgvFactura.Columns["Total"].HeaderText = "TOTAL";

            dgvFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Capa_Presentacion.menu.cs

        private async void btnBuscarF_Click(object sender, EventArgs e)
        {
            string idFacturaStr = cbmFactura.SelectedItem?.ToString();

            if (idFacturaStr == "Todas" || string.IsNullOrEmpty(idFacturaStr))
            {
                // Si selecciona "Todas" o está vacío, muestra todas las facturas.
                await CargarFacturasEnDGVAsync();
                return;
            }

            if (!int.TryParse(idFacturaStr, out int idFactura))
            {
                MessageBox.Show("ID de factura inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ToggleLoading(true, progressBarF);
            try
            {
                // 1. Obtener la factura específica
                var factura = await _facturaService.ObtenerPorIdAsync(idFactura, CancellationToken.None);

                if (factura != null)
                {
                    // 2. Mostrar SOLO la factura encontrada
                    var lista = new List<object> { new {
                factura.IdFactura,
                factura.IdReserva,
                FechaEmision = factura.FechaEmision.ToString("dd/MM/yyyy HH:mm"),
                Subtotal = factura.Subtotal.ToString("N2"),
                Itbis = factura.Itbis.ToString("N2"),
                Total = factura.Total.ToString("N2")
            }};

                    dgvFactura.DataSource = lista;
                    FormatearDgvFactura();
                    MessageBox.Show($"Factura ID {idFactura} encontrada.", "Éxito");
                }
                else
                {
                    MessageBox.Show($"Factura ID {idFactura} no encontrada.", "Sin resultados");
                    dgvFactura.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar factura: {ex.Message}", "Error");
            }
            finally
            {
                ToggleLoading(false, progressBarF);
            }
        }
        // Capa_Presentacion.menu.cs

        private async void btnFactura_Click(object sender, EventArgs e)
        {
            // 1. Verificar selección
            if (dgvFactura.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila para ver el detalle de la factura.", "Advertencia");
                return;
            }

            // 2. Obtener los valores directamente del DGV (ya están formateados)
            DataGridViewRow row = dgvFactura.SelectedRows[0];

            string idFactura = row.Cells["IdFactura"].Value.ToString();
            string idReserva = row.Cells["IdReserva"].Value.ToString();
            string fechaEmision = row.Cells["FechaEmision"].Value.ToString();
            string subtotal = row.Cells["Subtotal"].Value.ToString();
            string itbis = row.Cells["Itbis"].Value.ToString();
            string total = row.Cells["Total"].Value.ToString();

            // 3. Crear el mensaje detallado (incluyendo los detalles de la RESERVA para contexto)
            string mensaje = $"--- DETALLE DE FACTURA ---\n\n" +
                             $"ID Factura: {idFactura}\n" +
                             $"ID Reserva: {idReserva}\n" +
                             $"Fecha Emisión: {fechaEmision}\n" +
                             $"---------------------------\n" +
                             $"Subtotal: {subtotal}\n" +
                             $"ITBIS (18%): {itbis}\n" +
                             $"TOTAL: {total}\n" +
                             $"---------------------------\n\n" +
                             $"Nota: Esta factura está basada en la Reserva {idReserva}.";

            // 4. Mostrar la ventana emergente
            MessageBox.Show(mensaje, $"Factura No. {idFactura} - Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Capa_Presentacion.menu.cs (Reemplaza tu método BtnGenerarFactura_Click)

        private async void BtnGenerarFactura_Click(object sender, EventArgs e)
        {
            ToggleLoading(true, progressBarF);
            try
            {
                // 1. Obtener el ID de la reserva seleccionada
                int idReserva = GetSelectedReservaId();

                // 2. Obtener la reserva para validar
                var reserva = await _reservaService.ObtenerPorIdAsync(idReserva, CancellationToken.None);

                if (reserva == null)
                {
                    MessageBox.Show("La reserva no fue encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validación CLAVE: Verificar si ya existe una factura
                var facturaExistente = await _facturaService.ObtenerPorIdReservaAsync(idReserva, CancellationToken.None);
                if (facturaExistente != null)
                {
                    MessageBox.Show($"Esta reserva ya tiene una factura registrada (No. {facturaExistente.IdFactura}). No se permite duplicar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Regla de negocio: Solo generar factura si está en estado RESERVADA
                if (reserva.EstadoReserva != EstadoReserva.Reservada)
                {
                    MessageBox.Show($"La factura solo debe generarse cuando la reserva está en estado 'Reservada'. El estado actual es: {reserva.EstadoReserva}.", "Advertencia de Facturación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Generar la factura
                Factura nuevaFactura = await _facturaService.GenerarFacturaAsync(idReserva, CancellationToken.None);

                MessageBox.Show(
                    $"Factura No. {nuevaFactura.IdFactura} generada para la reserva {idReserva}. Los montos son inmutables.",
                    "Factura Generada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // 4. Actualizar la interfaz
                await CargarReservasEnDGVAsync();
                await CargarFacturasEnDGVAsync();
                await CargarIdsFacturas();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleLoading(false, progressBarF);
            }
        }

        // Capa_Presentacion.menu.cs (Añadir a la clase menu)

        // Capa_Presentacion.menu.cs (Añadir a la clase menu)

        private void ToggleLoading(bool isLoading, System.Windows.Forms.ProgressBar targetBar)
        {
            // Deshabilitar/Habilitar los DataGridViews principales
            // (Opcional: Si los DGV están en diferentes TabPages, puedes deshabilitar solo los controles del TabPage activo)
            dgvClientes.Enabled = !isLoading;
            dgvHabitaciones.Enabled = !isLoading;
            dgvReserva.Enabled = !isLoading;
            dgvFactura.Enabled = !isLoading;

            if (isLoading)
            {
                targetBar.Style = ProgressBarStyle.Marquee;
                targetBar.Visible = true;
            }
            else
            {
                targetBar.Visible = false;
                targetBar.Style = ProgressBarStyle.Blocks;
            }
        }













    }
}
