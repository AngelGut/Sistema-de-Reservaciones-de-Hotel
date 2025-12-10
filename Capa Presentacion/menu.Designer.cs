
namespace Capa_Presentacion
{
    partial class menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage3 = new TabPage();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            btnLimpiarH = new MaterialSkin.Controls.MaterialButton();
            cmbIDH = new MaterialSkin.Controls.MaterialComboBox();
            BuscarH = new MaterialSkin.Controls.MaterialButton();
            cmbEstadoH = new MaterialSkin.Controls.MaterialComboBox();
            dgvHabitaciones = new DataGridView();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            txtNombreH = new MaterialSkin.Controls.MaterialMaskedTextBox();
            cmbTipo = new MaterialSkin.Controls.MaterialComboBox();
            cmbEstado = new MaterialSkin.Controls.MaterialComboBox();
            btnRegistrarH = new MaterialSkin.Controls.MaterialButton();
            lblTpo = new MaterialSkin.Controls.MaterialLabel();
            lblEstado = new MaterialSkin.Controls.MaterialLabel();
            txtNumeroHab = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblNumeroHab = new MaterialSkin.Controls.MaterialLabel();
            tabPage2 = new TabPage();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            cmbCedula = new MaterialSkin.Controls.MaterialComboBox();
            cmbID = new MaterialSkin.Controls.MaterialComboBox();
            btnBusqueda = new MaterialSkin.Controls.MaterialButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnRegistrar = new MaterialSkin.Controls.MaterialButton();
            txtNombre = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblNombreC = new MaterialSkin.Controls.MaterialLabel();
            txtTelefono = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblTelefono = new MaterialSkin.Controls.MaterialLabel();
            lblCedula = new MaterialSkin.Controls.MaterialLabel();
            txtCorreo = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txtCedula = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblCorreo = new MaterialSkin.Controls.MaterialLabel();
            lblNacionalidad = new MaterialSkin.Controls.MaterialLabel();
            txtNacionalidad = new MaterialSkin.Controls.MaterialMaskedTextBox();
            dgvClientes = new DataGridView();
            tabPage1 = new TabPage();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage4 = new TabPage();
            fileSystemWatcher1 = new FileSystemWatcher();
            dgvReserva = new DataGridView();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            cbmElegirHR = new MaterialSkin.Controls.MaterialComboBox();
            cbmElegirCliente = new MaterialSkin.Controls.MaterialComboBox();
            btnLimpiarR = new MaterialSkin.Controls.MaterialButton();
            btnBuscarR = new MaterialSkin.Controls.MaterialButton();
            cbmBuscarIDR = new MaterialSkin.Controls.MaterialComboBox();
            materialCard5 = new MaterialSkin.Controls.MaterialCard();
            cbmBuscarIDC = new MaterialSkin.Controls.MaterialComboBox();
            cbmCiO = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            dateTimePicker1 = new DateTimePicker();
            btnRegistrarR = new MaterialSkin.Controls.MaterialButton();
            tabPage3.SuspendLayout();
            materialCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHabitaciones).BeginInit();
            materialCard2.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            materialTabControl1.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReserva).BeginInit();
            materialCard4.SuspendLayout();
            materialCard5.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(materialCard3);
            tabPage3.Controls.Add(dgvHabitaciones);
            tabPage3.Controls.Add(materialCard2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1616, 857);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Habitaciones";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(btnLimpiarH);
            materialCard3.Controls.Add(cmbIDH);
            materialCard3.Controls.Add(BuscarH);
            materialCard3.Controls.Add(cmbEstadoH);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(446, 611);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(420, 171);
            materialCard3.TabIndex = 5;
            // 
            // btnLimpiarH
            // 
            btnLimpiarH.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpiarH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLimpiarH.Depth = 0;
            btnLimpiarH.HighEmphasis = true;
            btnLimpiarH.Icon = null;
            btnLimpiarH.Location = new Point(43, 112);
            btnLimpiarH.Margin = new Padding(4, 6, 4, 6);
            btnLimpiarH.MouseState = MaterialSkin.MouseState.HOVER;
            btnLimpiarH.Name = "btnLimpiarH";
            btnLimpiarH.NoAccentTextColor = Color.Empty;
            btnLimpiarH.Size = new Size(158, 36);
            btnLimpiarH.TabIndex = 5;
            btnLimpiarH.Text = "LIMPIAR BUSQUEDA";
            btnLimpiarH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLimpiarH.UseAccentColor = false;
            btnLimpiarH.UseVisualStyleBackColor = true;
            // 
            // cmbIDH
            // 
            cmbIDH.AutoResize = false;
            cmbIDH.BackColor = Color.FromArgb(255, 255, 255);
            cmbIDH.Depth = 0;
            cmbIDH.DrawMode = DrawMode.OwnerDrawVariable;
            cmbIDH.DropDownHeight = 174;
            cmbIDH.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIDH.DropDownWidth = 121;
            cmbIDH.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbIDH.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbIDH.FormattingEnabled = true;
            cmbIDH.IntegralHeight = false;
            cmbIDH.ItemHeight = 43;
            cmbIDH.Location = new Point(43, 26);
            cmbIDH.MaxDropDownItems = 4;
            cmbIDH.MouseState = MaterialSkin.MouseState.OUT;
            cmbIDH.Name = "cmbIDH";
            cmbIDH.Size = new Size(121, 49);
            cmbIDH.StartIndex = 0;
            cmbIDH.TabIndex = 2;
            // 
            // BuscarH
            // 
            BuscarH.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BuscarH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            BuscarH.Depth = 0;
            BuscarH.HighEmphasis = true;
            BuscarH.Icon = null;
            BuscarH.Location = new Point(294, 112);
            BuscarH.Margin = new Padding(4, 6, 4, 6);
            BuscarH.MouseState = MaterialSkin.MouseState.HOVER;
            BuscarH.Name = "BuscarH";
            BuscarH.NoAccentTextColor = Color.Empty;
            BuscarH.Size = new Size(77, 36);
            BuscarH.TabIndex = 4;
            BuscarH.Text = "BUSCAR";
            BuscarH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            BuscarH.UseAccentColor = false;
            BuscarH.UseVisualStyleBackColor = true;
            // 
            // cmbEstadoH
            // 
            cmbEstadoH.AutoResize = false;
            cmbEstadoH.BackColor = Color.FromArgb(255, 255, 255);
            cmbEstadoH.Depth = 0;
            cmbEstadoH.DrawMode = DrawMode.OwnerDrawVariable;
            cmbEstadoH.DropDownHeight = 174;
            cmbEstadoH.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoH.DropDownWidth = 121;
            cmbEstadoH.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbEstadoH.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbEstadoH.FormattingEnabled = true;
            cmbEstadoH.IntegralHeight = false;
            cmbEstadoH.ItemHeight = 43;
            cmbEstadoH.Location = new Point(250, 26);
            cmbEstadoH.MaxDropDownItems = 4;
            cmbEstadoH.MouseState = MaterialSkin.MouseState.OUT;
            cmbEstadoH.Name = "cmbEstadoH";
            cmbEstadoH.Size = new Size(121, 49);
            cmbEstadoH.StartIndex = 0;
            cmbEstadoH.TabIndex = 3;
            // 
            // dgvHabitaciones
            // 
            dgvHabitaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHabitaciones.Location = new Point(413, 20);
            dgvHabitaciones.Name = "dgvHabitaciones";
            dgvHabitaciones.Size = new Size(968, 445);
            dgvHabitaciones.TabIndex = 1;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(materialLabel3);
            materialCard2.Controls.Add(txtNombreH);
            materialCard2.Controls.Add(cmbTipo);
            materialCard2.Controls.Add(cmbEstado);
            materialCard2.Controls.Add(btnRegistrarH);
            materialCard2.Controls.Add(lblTpo);
            materialCard2.Controls.Add(lblEstado);
            materialCard2.Controls.Add(txtNumeroHab);
            materialCard2.Controls.Add(lblNumeroHab);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(-4, 0);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(364, 857);
            materialCard2.TabIndex = 0;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(17, 74);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(138, 19);
            materialLabel3.TabIndex = 10;
            materialLabel3.Text = "Nombre Habitacion";
            // 
            // txtNombreH
            // 
            txtNombreH.AllowPromptAsInput = true;
            txtNombreH.AnimateReadOnly = false;
            txtNombreH.AsciiOnly = false;
            txtNombreH.BackgroundImageLayout = ImageLayout.None;
            txtNombreH.BeepOnError = false;
            txtNombreH.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtNombreH.Depth = 0;
            txtNombreH.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombreH.HidePromptOnLeave = false;
            txtNombreH.HideSelection = true;
            txtNombreH.InsertKeyMode = InsertKeyMode.Default;
            txtNombreH.LeadingIcon = null;
            txtNombreH.Location = new Point(17, 112);
            txtNombreH.Mask = "";
            txtNombreH.MaxLength = 32767;
            txtNombreH.MouseState = MaterialSkin.MouseState.OUT;
            txtNombreH.Name = "txtNombreH";
            txtNombreH.PasswordChar = '\0';
            txtNombreH.PrefixSuffixText = null;
            txtNombreH.PromptChar = '_';
            txtNombreH.ReadOnly = false;
            txtNombreH.RejectInputOnFirstFailure = false;
            txtNombreH.ResetOnPrompt = true;
            txtNombreH.ResetOnSpace = true;
            txtNombreH.RightToLeft = RightToLeft.No;
            txtNombreH.SelectedText = "";
            txtNombreH.SelectionLength = 0;
            txtNombreH.SelectionStart = 0;
            txtNombreH.ShortcutsEnabled = true;
            txtNombreH.Size = new Size(250, 48);
            txtNombreH.SkipLiterals = true;
            txtNombreH.TabIndex = 9;
            txtNombreH.TabStop = false;
            txtNombreH.TextAlign = HorizontalAlignment.Left;
            txtNombreH.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtNombreH.TrailingIcon = null;
            txtNombreH.UseSystemPasswordChar = false;
            txtNombreH.ValidatingType = null;
            // 
            // cmbTipo
            // 
            cmbTipo.AutoResize = false;
            cmbTipo.BackColor = Color.FromArgb(255, 255, 255);
            cmbTipo.Depth = 0;
            cmbTipo.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTipo.DropDownHeight = 174;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.DropDownWidth = 121;
            cmbTipo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbTipo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.IntegralHeight = false;
            cmbTipo.ItemHeight = 43;
            cmbTipo.Location = new Point(17, 550);
            cmbTipo.MaxDropDownItems = 4;
            cmbTipo.MouseState = MaterialSkin.MouseState.OUT;
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(121, 49);
            cmbTipo.StartIndex = 0;
            cmbTipo.TabIndex = 8;
            // 
            // cmbEstado
            // 
            cmbEstado.AutoResize = false;
            cmbEstado.BackColor = Color.FromArgb(255, 255, 255);
            cmbEstado.Depth = 0;
            cmbEstado.DrawMode = DrawMode.OwnerDrawVariable;
            cmbEstado.DropDownHeight = 174;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.DropDownWidth = 121;
            cmbEstado.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbEstado.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.IntegralHeight = false;
            cmbEstado.ItemHeight = 43;
            cmbEstado.Location = new Point(17, 397);
            cmbEstado.MaxDropDownItems = 4;
            cmbEstado.MouseState = MaterialSkin.MouseState.OUT;
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 49);
            cmbEstado.StartIndex = 0;
            cmbEstado.TabIndex = 7;
            // 
            // btnRegistrarH
            // 
            btnRegistrarH.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegistrarH.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegistrarH.Depth = 0;
            btnRegistrarH.HighEmphasis = true;
            btnRegistrarH.Icon = null;
            btnRegistrarH.Location = new Point(11, 723);
            btnRegistrarH.Margin = new Padding(4, 6, 4, 6);
            btnRegistrarH.MouseState = MaterialSkin.MouseState.HOVER;
            btnRegistrarH.Name = "btnRegistrarH";
            btnRegistrarH.NoAccentTextColor = Color.Empty;
            btnRegistrarH.Size = new Size(99, 36);
            btnRegistrarH.TabIndex = 6;
            btnRegistrarH.Text = "REGISTRAR";
            btnRegistrarH.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegistrarH.UseAccentColor = false;
            btnRegistrarH.UseVisualStyleBackColor = true;
            // 
            // lblTpo
            // 
            lblTpo.AutoSize = true;
            lblTpo.Depth = 0;
            lblTpo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTpo.Location = new Point(17, 514);
            lblTpo.MouseState = MaterialSkin.MouseState.HOVER;
            lblTpo.Name = "lblTpo";
            lblTpo.Size = new Size(33, 19);
            lblTpo.TabIndex = 4;
            lblTpo.Text = "Tipo";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Depth = 0;
            lblEstado.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEstado.Location = new Point(17, 356);
            lblEstado.MouseState = MaterialSkin.MouseState.HOVER;
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(50, 19);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Estado";
            // 
            // txtNumeroHab
            // 
            txtNumeroHab.AllowPromptAsInput = true;
            txtNumeroHab.AnimateReadOnly = false;
            txtNumeroHab.AsciiOnly = false;
            txtNumeroHab.BackgroundImageLayout = ImageLayout.None;
            txtNumeroHab.BeepOnError = false;
            txtNumeroHab.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtNumeroHab.Depth = 0;
            txtNumeroHab.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNumeroHab.HidePromptOnLeave = false;
            txtNumeroHab.HideSelection = true;
            txtNumeroHab.InsertKeyMode = InsertKeyMode.Default;
            txtNumeroHab.LeadingIcon = null;
            txtNumeroHab.Location = new Point(17, 241);
            txtNumeroHab.Mask = "";
            txtNumeroHab.MaxLength = 32767;
            txtNumeroHab.MouseState = MaterialSkin.MouseState.OUT;
            txtNumeroHab.Name = "txtNumeroHab";
            txtNumeroHab.PasswordChar = '\0';
            txtNumeroHab.PrefixSuffixText = null;
            txtNumeroHab.PromptChar = '_';
            txtNumeroHab.ReadOnly = false;
            txtNumeroHab.RejectInputOnFirstFailure = false;
            txtNumeroHab.ResetOnPrompt = true;
            txtNumeroHab.ResetOnSpace = true;
            txtNumeroHab.RightToLeft = RightToLeft.No;
            txtNumeroHab.SelectedText = "";
            txtNumeroHab.SelectionLength = 0;
            txtNumeroHab.SelectionStart = 0;
            txtNumeroHab.ShortcutsEnabled = true;
            txtNumeroHab.Size = new Size(250, 48);
            txtNumeroHab.SkipLiterals = true;
            txtNumeroHab.TabIndex = 1;
            txtNumeroHab.TabStop = false;
            txtNumeroHab.TextAlign = HorizontalAlignment.Left;
            txtNumeroHab.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtNumeroHab.TrailingIcon = null;
            txtNumeroHab.UseSystemPasswordChar = false;
            txtNumeroHab.ValidatingType = null;
            // 
            // lblNumeroHab
            // 
            lblNumeroHab.AutoSize = true;
            lblNumeroHab.Depth = 0;
            lblNumeroHab.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNumeroHab.Location = new Point(17, 205);
            lblNumeroHab.MouseState = MaterialSkin.MouseState.HOVER;
            lblNumeroHab.Name = "lblNumeroHab";
            lblNumeroHab.Size = new Size(159, 19);
            lblNumeroHab.TabIndex = 0;
            lblNumeroHab.Text = "Numero de Habitacion";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialLabel2);
            tabPage2.Controls.Add(materialLabel1);
            tabPage2.Controls.Add(cmbCedula);
            tabPage2.Controls.Add(cmbID);
            tabPage2.Controls.Add(btnBusqueda);
            tabPage2.Controls.Add(materialCard1);
            tabPage2.Controls.Add(dgvClientes);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1616, 857);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clientes";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(565, 550);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(83, 19);
            materialLabel2.TabIndex = 19;
            materialLabel2.Text = "Documento";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(367, 550);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(62, 19);
            materialLabel1.TabIndex = 18;
            materialLabel1.Text = "IdCliente";
            // 
            // cmbCedula
            // 
            cmbCedula.AutoResize = false;
            cmbCedula.BackColor = Color.FromArgb(255, 255, 255);
            cmbCedula.Depth = 0;
            cmbCedula.DrawMode = DrawMode.OwnerDrawVariable;
            cmbCedula.DropDownHeight = 174;
            cmbCedula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCedula.DropDownWidth = 121;
            cmbCedula.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbCedula.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbCedula.FormattingEnabled = true;
            cmbCedula.IntegralHeight = false;
            cmbCedula.ItemHeight = 43;
            cmbCedula.Location = new Point(565, 593);
            cmbCedula.MaxDropDownItems = 4;
            cmbCedula.MouseState = MaterialSkin.MouseState.OUT;
            cmbCedula.Name = "cmbCedula";
            cmbCedula.Size = new Size(121, 49);
            cmbCedula.StartIndex = 0;
            cmbCedula.TabIndex = 17;
            // 
            // cmbID
            // 
            cmbID.AutoResize = false;
            cmbID.BackColor = Color.FromArgb(255, 255, 255);
            cmbID.Depth = 0;
            cmbID.DrawMode = DrawMode.OwnerDrawVariable;
            cmbID.DropDownHeight = 174;
            cmbID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbID.DropDownWidth = 121;
            cmbID.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbID.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbID.FormattingEnabled = true;
            cmbID.IntegralHeight = false;
            cmbID.ItemHeight = 43;
            cmbID.Location = new Point(367, 593);
            cmbID.MaxDropDownItems = 4;
            cmbID.MouseState = MaterialSkin.MouseState.OUT;
            cmbID.Name = "cmbID";
            cmbID.Size = new Size(121, 49);
            cmbID.StartIndex = 0;
            cmbID.TabIndex = 16;
            // 
            // btnBusqueda
            // 
            btnBusqueda.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBusqueda.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBusqueda.Depth = 0;
            btnBusqueda.HighEmphasis = true;
            btnBusqueda.Icon = null;
            btnBusqueda.Location = new Point(367, 702);
            btnBusqueda.Margin = new Padding(4, 6, 4, 6);
            btnBusqueda.MouseState = MaterialSkin.MouseState.HOVER;
            btnBusqueda.Name = "btnBusqueda";
            btnBusqueda.NoAccentTextColor = Color.Empty;
            btnBusqueda.Size = new Size(77, 36);
            btnBusqueda.TabIndex = 15;
            btnBusqueda.Text = "BUSCAR";
            btnBusqueda.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBusqueda.UseAccentColor = false;
            btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnRegistrar);
            materialCard1.Controls.Add(txtNombre);
            materialCard1.Controls.Add(lblNombreC);
            materialCard1.Controls.Add(txtTelefono);
            materialCard1.Controls.Add(lblTelefono);
            materialCard1.Controls.Add(lblCedula);
            materialCard1.Controls.Add(txtCorreo);
            materialCard1.Controls.Add(txtCedula);
            materialCard1.Controls.Add(lblCorreo);
            materialCard1.Controls.Add(lblNacionalidad);
            materialCard1.Controls.Add(txtNacionalidad);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(313, 861);
            materialCard1.TabIndex = 14;
            // 
            // btnRegistrar
            // 
            btnRegistrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegistrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegistrar.Depth = 0;
            btnRegistrar.HighEmphasis = true;
            btnRegistrar.Icon = null;
            btnRegistrar.Location = new Point(10, 618);
            btnRegistrar.Margin = new Padding(4, 6, 4, 6);
            btnRegistrar.MouseState = MaterialSkin.MouseState.HOVER;
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.NoAccentTextColor = Color.Empty;
            btnRegistrar.Size = new Size(99, 36);
            btnRegistrar.TabIndex = 13;
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegistrar.UseAccentColor = false;
            btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.AllowPromptAsInput = true;
            txtNombre.AnimateReadOnly = false;
            txtNombre.AsciiOnly = false;
            txtNombre.BackgroundImageLayout = ImageLayout.None;
            txtNombre.BeepOnError = false;
            txtNombre.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtNombre.Depth = 0;
            txtNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombre.HidePromptOnLeave = false;
            txtNombre.HideSelection = true;
            txtNombre.InsertKeyMode = InsertKeyMode.Default;
            txtNombre.LeadingIcon = null;
            txtNombre.Location = new Point(10, 47);
            txtNombre.Mask = "";
            txtNombre.MaxLength = 32767;
            txtNombre.MouseState = MaterialSkin.MouseState.OUT;
            txtNombre.Name = "txtNombre";
            txtNombre.PasswordChar = '\0';
            txtNombre.PrefixSuffixText = null;
            txtNombre.PromptChar = '_';
            txtNombre.ReadOnly = false;
            txtNombre.RejectInputOnFirstFailure = false;
            txtNombre.ResetOnPrompt = true;
            txtNombre.ResetOnSpace = true;
            txtNombre.RightToLeft = RightToLeft.No;
            txtNombre.SelectedText = "";
            txtNombre.SelectionLength = 0;
            txtNombre.SelectionStart = 0;
            txtNombre.ShortcutsEnabled = true;
            txtNombre.Size = new Size(250, 48);
            txtNombre.SkipLiterals = true;
            txtNombre.TabIndex = 12;
            txtNombre.TabStop = false;
            txtNombre.TextAlign = HorizontalAlignment.Left;
            txtNombre.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtNombre.TrailingIcon = null;
            txtNombre.UseSystemPasswordChar = false;
            txtNombre.ValidatingType = null;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // lblNombreC
            // 
            lblNombreC.AutoSize = true;
            lblNombreC.Depth = 0;
            lblNombreC.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNombreC.Location = new Point(6, 14);
            lblNombreC.MouseState = MaterialSkin.MouseState.HOVER;
            lblNombreC.Name = "lblNombreC";
            lblNombreC.RightToLeft = RightToLeft.Yes;
            lblNombreC.Size = new Size(57, 19);
            lblNombreC.TabIndex = 11;
            lblNombreC.Text = "Nombre";
            // 
            // txtTelefono
            // 
            txtTelefono.AllowPromptAsInput = true;
            txtTelefono.AnimateReadOnly = false;
            txtTelefono.AsciiOnly = false;
            txtTelefono.BackgroundImageLayout = ImageLayout.None;
            txtTelefono.BeepOnError = false;
            txtTelefono.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtTelefono.Depth = 0;
            txtTelefono.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefono.HidePromptOnLeave = false;
            txtTelefono.HideSelection = true;
            txtTelefono.InsertKeyMode = InsertKeyMode.Default;
            txtTelefono.LeadingIcon = null;
            txtTelefono.Location = new Point(7, 536);
            txtTelefono.Mask = "";
            txtTelefono.MaxLength = 32767;
            txtTelefono.MouseState = MaterialSkin.MouseState.OUT;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PasswordChar = '\0';
            txtTelefono.PrefixSuffixText = null;
            txtTelefono.PromptChar = '_';
            txtTelefono.ReadOnly = false;
            txtTelefono.RejectInputOnFirstFailure = false;
            txtTelefono.ResetOnPrompt = true;
            txtTelefono.ResetOnSpace = true;
            txtTelefono.RightToLeft = RightToLeft.No;
            txtTelefono.SelectedText = "";
            txtTelefono.SelectionLength = 0;
            txtTelefono.SelectionStart = 0;
            txtTelefono.ShortcutsEnabled = true;
            txtTelefono.Size = new Size(250, 48);
            txtTelefono.SkipLiterals = true;
            txtTelefono.TabIndex = 10;
            txtTelefono.TabStop = false;
            txtTelefono.TextAlign = HorizontalAlignment.Left;
            txtTelefono.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtTelefono.TrailingIcon = null;
            txtTelefono.UseSystemPasswordChar = false;
            txtTelefono.ValidatingType = null;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Depth = 0;
            lblTelefono.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTelefono.Location = new Point(17, 482);
            lblTelefono.MouseState = MaterialSkin.MouseState.HOVER;
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(64, 19);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Telefono";
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Depth = 0;
            lblCedula.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCedula.Location = new Point(7, 117);
            lblCedula.MouseState = MaterialSkin.MouseState.HOVER;
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(129, 19);
            lblCedula.TabIndex = 3;
            lblCedula.Text = "Cedula/Pasaporte";
            // 
            // txtCorreo
            // 
            txtCorreo.AllowPromptAsInput = true;
            txtCorreo.AnimateReadOnly = false;
            txtCorreo.AsciiOnly = false;
            txtCorreo.BackgroundImageLayout = ImageLayout.None;
            txtCorreo.BeepOnError = false;
            txtCorreo.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtCorreo.Depth = 0;
            txtCorreo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCorreo.HidePromptOnLeave = false;
            txtCorreo.HideSelection = true;
            txtCorreo.InsertKeyMode = InsertKeyMode.Default;
            txtCorreo.LeadingIcon = null;
            txtCorreo.Location = new Point(10, 390);
            txtCorreo.Mask = "";
            txtCorreo.MaxLength = 32767;
            txtCorreo.MouseState = MaterialSkin.MouseState.OUT;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PasswordChar = '\0';
            txtCorreo.PrefixSuffixText = null;
            txtCorreo.PromptChar = '_';
            txtCorreo.ReadOnly = false;
            txtCorreo.RejectInputOnFirstFailure = false;
            txtCorreo.ResetOnPrompt = true;
            txtCorreo.ResetOnSpace = true;
            txtCorreo.RightToLeft = RightToLeft.No;
            txtCorreo.SelectedText = "";
            txtCorreo.SelectionLength = 0;
            txtCorreo.SelectionStart = 0;
            txtCorreo.ShortcutsEnabled = true;
            txtCorreo.Size = new Size(250, 48);
            txtCorreo.SkipLiterals = true;
            txtCorreo.TabIndex = 8;
            txtCorreo.TabStop = false;
            txtCorreo.TextAlign = HorizontalAlignment.Left;
            txtCorreo.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtCorreo.TrailingIcon = null;
            txtCorreo.UseSystemPasswordChar = false;
            txtCorreo.ValidatingType = null;
            txtCorreo.Leave += txtCorreo_Leave;
            // 
            // txtCedula
            // 
            txtCedula.AllowPromptAsInput = true;
            txtCedula.AnimateReadOnly = false;
            txtCedula.AsciiOnly = false;
            txtCedula.BackgroundImageLayout = ImageLayout.None;
            txtCedula.BeepOnError = false;
            txtCedula.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtCedula.Depth = 0;
            txtCedula.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCedula.HidePromptOnLeave = false;
            txtCedula.HideSelection = true;
            txtCedula.InsertKeyMode = InsertKeyMode.Default;
            txtCedula.LeadingIcon = null;
            txtCedula.Location = new Point(10, 151);
            txtCedula.Mask = "";
            txtCedula.MaxLength = 32767;
            txtCedula.MouseState = MaterialSkin.MouseState.OUT;
            txtCedula.Name = "txtCedula";
            txtCedula.PasswordChar = '\0';
            txtCedula.PrefixSuffixText = null;
            txtCedula.PromptChar = '_';
            txtCedula.ReadOnly = false;
            txtCedula.RejectInputOnFirstFailure = false;
            txtCedula.ResetOnPrompt = true;
            txtCedula.ResetOnSpace = true;
            txtCedula.RightToLeft = RightToLeft.No;
            txtCedula.SelectedText = "";
            txtCedula.SelectionLength = 0;
            txtCedula.SelectionStart = 0;
            txtCedula.ShortcutsEnabled = true;
            txtCedula.Size = new Size(250, 48);
            txtCedula.SkipLiterals = true;
            txtCedula.TabIndex = 4;
            txtCedula.TabStop = false;
            txtCedula.TextAlign = HorizontalAlignment.Left;
            txtCedula.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtCedula.TrailingIcon = null;
            txtCedula.UseSystemPasswordChar = false;
            txtCedula.ValidatingType = null;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Depth = 0;
            lblCorreo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCorreo.Location = new Point(20, 343);
            lblCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(47, 19);
            lblCorreo.TabIndex = 7;
            lblCorreo.Text = "Correo";
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Depth = 0;
            lblNacionalidad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNacionalidad.Location = new Point(17, 225);
            lblNacionalidad.MouseState = MaterialSkin.MouseState.HOVER;
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(95, 19);
            lblNacionalidad.TabIndex = 5;
            lblNacionalidad.Text = "Nacionalidad";
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.AllowPromptAsInput = true;
            txtNacionalidad.AnimateReadOnly = false;
            txtNacionalidad.AsciiOnly = false;
            txtNacionalidad.BackgroundImageLayout = ImageLayout.None;
            txtNacionalidad.BeepOnError = false;
            txtNacionalidad.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtNacionalidad.Depth = 0;
            txtNacionalidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNacionalidad.HidePromptOnLeave = false;
            txtNacionalidad.HideSelection = true;
            txtNacionalidad.InsertKeyMode = InsertKeyMode.Default;
            txtNacionalidad.LeadingIcon = null;
            txtNacionalidad.Location = new Point(10, 263);
            txtNacionalidad.Mask = "";
            txtNacionalidad.MaxLength = 32767;
            txtNacionalidad.MouseState = MaterialSkin.MouseState.OUT;
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.PasswordChar = '\0';
            txtNacionalidad.PrefixSuffixText = null;
            txtNacionalidad.PromptChar = '_';
            txtNacionalidad.ReadOnly = false;
            txtNacionalidad.RejectInputOnFirstFailure = false;
            txtNacionalidad.ResetOnPrompt = true;
            txtNacionalidad.ResetOnSpace = true;
            txtNacionalidad.RightToLeft = RightToLeft.No;
            txtNacionalidad.SelectedText = "";
            txtNacionalidad.SelectionLength = 0;
            txtNacionalidad.SelectionStart = 0;
            txtNacionalidad.ShortcutsEnabled = true;
            txtNacionalidad.Size = new Size(250, 48);
            txtNacionalidad.SkipLiterals = true;
            txtNacionalidad.TabIndex = 6;
            txtNacionalidad.TabStop = false;
            txtNacionalidad.TextAlign = HorizontalAlignment.Left;
            txtNacionalidad.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtNacionalidad.TrailingIcon = null;
            txtNacionalidad.UseSystemPasswordChar = false;
            txtNacionalidad.ValidatingType = null;
            txtNacionalidad.KeyPress += txtNacionalidad_KeyPress;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(340, 14);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(620, 432);
            dgvClientes.TabIndex = 12;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1616, 857);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Menu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1624, 885);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(materialCard5);
            tabPage4.Controls.Add(materialCard4);
            tabPage4.Controls.Add(dgvReserva);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1616, 857);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Reservacion";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // dgvReserva
            // 
            dgvReserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReserva.Location = new Point(405, 84);
            dgvReserva.Name = "dgvReserva";
            dgvReserva.Size = new Size(738, 412);
            dgvReserva.TabIndex = 0;
            dgvReserva.CellContentClick += dataGridView1_CellContentClick;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(btnRegistrarR);
            materialCard4.Controls.Add(materialLabel6);
            materialCard4.Controls.Add(materialLabel5);
            materialCard4.Controls.Add(materialLabel4);
            materialCard4.Controls.Add(cbmCiO);
            materialCard4.Controls.Add(cbmElegirCliente);
            materialCard4.Controls.Add(cbmElegirHR);
            materialCard4.Depth = 0;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(0, 0);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(339, 897);
            materialCard4.TabIndex = 1;
            // 
            // cbmElegirHR
            // 
            cbmElegirHR.AutoResize = false;
            cbmElegirHR.BackColor = Color.FromArgb(255, 255, 255);
            cbmElegirHR.Depth = 0;
            cbmElegirHR.DrawMode = DrawMode.OwnerDrawVariable;
            cbmElegirHR.DropDownHeight = 174;
            cbmElegirHR.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmElegirHR.DropDownWidth = 121;
            cbmElegirHR.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbmElegirHR.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbmElegirHR.FormattingEnabled = true;
            cbmElegirHR.IntegralHeight = false;
            cbmElegirHR.ItemHeight = 43;
            cbmElegirHR.Location = new Point(17, 219);
            cbmElegirHR.MaxDropDownItems = 4;
            cbmElegirHR.MouseState = MaterialSkin.MouseState.OUT;
            cbmElegirHR.Name = "cbmElegirHR";
            cbmElegirHR.Size = new Size(121, 49);
            cbmElegirHR.StartIndex = 0;
            cbmElegirHR.TabIndex = 0;
            // 
            // cbmElegirCliente
            // 
            cbmElegirCliente.AutoResize = false;
            cbmElegirCliente.BackColor = Color.FromArgb(255, 255, 255);
            cbmElegirCliente.Depth = 0;
            cbmElegirCliente.DrawMode = DrawMode.OwnerDrawVariable;
            cbmElegirCliente.DropDownHeight = 174;
            cbmElegirCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmElegirCliente.DropDownWidth = 121;
            cbmElegirCliente.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbmElegirCliente.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbmElegirCliente.FormattingEnabled = true;
            cbmElegirCliente.IntegralHeight = false;
            cbmElegirCliente.ItemHeight = 43;
            cbmElegirCliente.Location = new Point(17, 84);
            cbmElegirCliente.MaxDropDownItems = 4;
            cbmElegirCliente.MouseState = MaterialSkin.MouseState.OUT;
            cbmElegirCliente.Name = "cbmElegirCliente";
            cbmElegirCliente.Size = new Size(121, 49);
            cbmElegirCliente.StartIndex = 0;
            cbmElegirCliente.TabIndex = 1;
            // 
            // btnLimpiarR
            // 
            btnLimpiarR.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpiarR.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLimpiarR.Depth = 0;
            btnLimpiarR.HighEmphasis = true;
            btnLimpiarR.Icon = null;
            btnLimpiarR.Location = new Point(202, 134);
            btnLimpiarR.Margin = new Padding(4, 6, 4, 6);
            btnLimpiarR.MouseState = MaterialSkin.MouseState.HOVER;
            btnLimpiarR.Name = "btnLimpiarR";
            btnLimpiarR.NoAccentTextColor = Color.Empty;
            btnLimpiarR.Size = new Size(158, 36);
            btnLimpiarR.TabIndex = 2;
            btnLimpiarR.Text = "LIMPIAR BUSQUEDA";
            btnLimpiarR.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLimpiarR.UseAccentColor = false;
            btnLimpiarR.UseVisualStyleBackColor = true;
            // 
            // btnBuscarR
            // 
            btnBuscarR.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscarR.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscarR.Depth = 0;
            btnBuscarR.HighEmphasis = true;
            btnBuscarR.Icon = null;
            btnBuscarR.Location = new Point(45, 134);
            btnBuscarR.Margin = new Padding(4, 6, 4, 6);
            btnBuscarR.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscarR.Name = "btnBuscarR";
            btnBuscarR.NoAccentTextColor = Color.Empty;
            btnBuscarR.Size = new Size(77, 36);
            btnBuscarR.TabIndex = 3;
            btnBuscarR.Text = "BUSCAR";
            btnBuscarR.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscarR.UseAccentColor = false;
            btnBuscarR.UseVisualStyleBackColor = true;
            // 
            // cbmBuscarIDR
            // 
            cbmBuscarIDR.AutoResize = false;
            cbmBuscarIDR.BackColor = Color.FromArgb(255, 255, 255);
            cbmBuscarIDR.Depth = 0;
            cbmBuscarIDR.DrawMode = DrawMode.OwnerDrawVariable;
            cbmBuscarIDR.DropDownHeight = 174;
            cbmBuscarIDR.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmBuscarIDR.DropDownWidth = 121;
            cbmBuscarIDR.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbmBuscarIDR.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbmBuscarIDR.FormattingEnabled = true;
            cbmBuscarIDR.IntegralHeight = false;
            cbmBuscarIDR.ItemHeight = 43;
            cbmBuscarIDR.Location = new Point(27, 17);
            cbmBuscarIDR.MaxDropDownItems = 4;
            cbmBuscarIDR.MouseState = MaterialSkin.MouseState.OUT;
            cbmBuscarIDR.Name = "cbmBuscarIDR";
            cbmBuscarIDR.Size = new Size(121, 49);
            cbmBuscarIDR.StartIndex = 0;
            cbmBuscarIDR.TabIndex = 4;
            // 
            // materialCard5
            // 
            materialCard5.BackColor = Color.FromArgb(255, 255, 255);
            materialCard5.Controls.Add(dateTimePicker1);
            materialCard5.Controls.Add(cbmBuscarIDC);
            materialCard5.Controls.Add(btnBuscarR);
            materialCard5.Controls.Add(cbmBuscarIDR);
            materialCard5.Controls.Add(btnLimpiarR);
            materialCard5.Depth = 0;
            materialCard5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard5.Location = new Point(429, 578);
            materialCard5.Margin = new Padding(14);
            materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard5.Name = "materialCard5";
            materialCard5.Padding = new Padding(14);
            materialCard5.Size = new Size(764, 190);
            materialCard5.TabIndex = 5;
            // 
            // cbmBuscarIDC
            // 
            cbmBuscarIDC.AutoResize = false;
            cbmBuscarIDC.BackColor = Color.FromArgb(255, 255, 255);
            cbmBuscarIDC.Depth = 0;
            cbmBuscarIDC.DrawMode = DrawMode.OwnerDrawVariable;
            cbmBuscarIDC.DropDownHeight = 174;
            cbmBuscarIDC.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmBuscarIDC.DropDownWidth = 121;
            cbmBuscarIDC.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbmBuscarIDC.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbmBuscarIDC.FormattingEnabled = true;
            cbmBuscarIDC.IntegralHeight = false;
            cbmBuscarIDC.ItemHeight = 43;
            cbmBuscarIDC.Location = new Point(228, 17);
            cbmBuscarIDC.MaxDropDownItems = 4;
            cbmBuscarIDC.MouseState = MaterialSkin.MouseState.OUT;
            cbmBuscarIDC.Name = "cbmBuscarIDC";
            cbmBuscarIDC.Size = new Size(121, 49);
            cbmBuscarIDC.StartIndex = 0;
            cbmBuscarIDC.TabIndex = 5;
            // 
            // cbmCiO
            // 
            cbmCiO.AutoResize = false;
            cbmCiO.BackColor = Color.FromArgb(255, 255, 255);
            cbmCiO.Depth = 0;
            cbmCiO.DrawMode = DrawMode.OwnerDrawVariable;
            cbmCiO.DropDownHeight = 174;
            cbmCiO.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmCiO.DropDownWidth = 121;
            cbmCiO.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbmCiO.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbmCiO.FormattingEnabled = true;
            cbmCiO.IntegralHeight = false;
            cbmCiO.ItemHeight = 43;
            cbmCiO.Location = new Point(17, 351);
            cbmCiO.MaxDropDownItems = 4;
            cbmCiO.MouseState = MaterialSkin.MouseState.OUT;
            cbmCiO.Name = "cbmCiO";
            cbmCiO.Size = new Size(121, 49);
            cbmCiO.StartIndex = 0;
            cbmCiO.TabIndex = 2;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(17, 164);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(121, 19);
            materialLabel4.TabIndex = 3;
            materialLabel4.Text = "Elegir Habitacion";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(17, 33);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(92, 19);
            materialLabel5.TabIndex = 4;
            materialLabel5.Text = "Elegir Cliente";
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(17, 300);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(144, 19);
            materialLabel6.TabIndex = 5;
            materialLabel6.Text = "Check In/ Check Out";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(439, 17);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // btnRegistrarR
            // 
            btnRegistrarR.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegistrarR.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegistrarR.Depth = 0;
            btnRegistrarR.HighEmphasis = true;
            btnRegistrarR.Icon = null;
            btnRegistrarR.Location = new Point(17, 475);
            btnRegistrarR.Margin = new Padding(4, 6, 4, 6);
            btnRegistrarR.MouseState = MaterialSkin.MouseState.HOVER;
            btnRegistrarR.Name = "btnRegistrarR";
            btnRegistrarR.NoAccentTextColor = Color.Empty;
            btnRegistrarR.Size = new Size(158, 36);
            btnRegistrarR.TabIndex = 6;
            btnRegistrarR.Text = "REGISTRAR";
            btnRegistrarR.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegistrarR.UseAccentColor = false;
            btnRegistrarR.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1630, 952);
            Controls.Add(materialTabControl1);
            DrawerTabControl = materialTabControl1;
            Name = "menu";
            Text = "Form1";
            Load += menu_Load;
            tabPage3.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHabitaciones).EndInit();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            materialTabControl1.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReserva).EndInit();
            materialCard4.ResumeLayout(false);
            materialCard4.PerformLayout();
            materialCard5.ResumeLayout(false);
            materialCard5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage3;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNombre;
        private MaterialSkin.Controls.MaterialLabel lblNombreC;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtTelefono;
        private MaterialSkin.Controls.MaterialLabel lblTelefono;
        private MaterialSkin.Controls.MaterialLabel lblCedula;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtCorreo;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtCedula;
        private MaterialSkin.Controls.MaterialLabel lblCorreo;
        private MaterialSkin.Controls.MaterialLabel lblNacionalidad;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNacionalidad;
        private DataGridView dgvClientes;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private FileSystemWatcher fileSystemWatcher1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialLabel lblTpo;
        private MaterialSkin.Controls.MaterialLabel lblEstado;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNumeroHab;
        private MaterialSkin.Controls.MaterialLabel lblNumeroHab;
        private DataGridView dgvHabitaciones;
        private MaterialSkin.Controls.MaterialButton btnRegistrar;
        private MaterialSkin.Controls.MaterialButton btnBusqueda;
        private MaterialSkin.Controls.MaterialComboBox cmbCedula;
        private MaterialSkin.Controls.MaterialComboBox cmbID;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnRegistrarH;
        private TabPage tabPage4;
        private MaterialSkin.Controls.MaterialComboBox cmbTipo;
        private MaterialSkin.Controls.MaterialComboBox cmbEstado;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNombreH;
        private MaterialSkin.Controls.MaterialButton BuscarH;
        private MaterialSkin.Controls.MaterialComboBox cmbEstadoH;
        private MaterialSkin.Controls.MaterialComboBox cmbIDH;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialButton btnLimpiarH;
        private DataGridView dgvReserva;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialButton btnBuscarR;
        private MaterialSkin.Controls.MaterialButton btnLimpiarR;
        private MaterialSkin.Controls.MaterialComboBox cbmElegirCliente;
        private MaterialSkin.Controls.MaterialComboBox cbmElegirHR;
        private MaterialSkin.Controls.MaterialCard materialCard5;
        private MaterialSkin.Controls.MaterialComboBox cbmBuscarIDC;
        private MaterialSkin.Controls.MaterialComboBox cbmBuscarIDR;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialComboBox cbmCiO;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialButton btnRegistrarR;
    }
}
