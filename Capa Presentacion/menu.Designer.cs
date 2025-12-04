
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
            dataGridView2 = new DataGridView();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            txtTipo = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblTpo = new MaterialSkin.Controls.MaterialLabel();
            txtEstado = new MaterialSkin.Controls.MaterialMaskedTextBox();
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
            fileSystemWatcher1 = new FileSystemWatcher();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            materialCard2.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            materialTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView2);
            tabPage3.Controls.Add(materialCard2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1616, 857);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Habitaciones";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(604, 56);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(861, 461);
            dataGridView2.TabIndex = 1;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(txtTipo);
            materialCard2.Controls.Add(lblTpo);
            materialCard2.Controls.Add(txtEstado);
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
            // txtTipo
            // 
            txtTipo.AllowPromptAsInput = true;
            txtTipo.AnimateReadOnly = false;
            txtTipo.AsciiOnly = false;
            txtTipo.BackgroundImageLayout = ImageLayout.None;
            txtTipo.BeepOnError = false;
            txtTipo.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtTipo.Depth = 0;
            txtTipo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTipo.HidePromptOnLeave = false;
            txtTipo.HideSelection = true;
            txtTipo.InsertKeyMode = InsertKeyMode.Default;
            txtTipo.LeadingIcon = null;
            txtTipo.Location = new Point(17, 410);
            txtTipo.Mask = "";
            txtTipo.MaxLength = 32767;
            txtTipo.MouseState = MaterialSkin.MouseState.OUT;
            txtTipo.Name = "txtTipo";
            txtTipo.PasswordChar = '\0';
            txtTipo.PrefixSuffixText = null;
            txtTipo.PromptChar = '_';
            txtTipo.ReadOnly = false;
            txtTipo.RejectInputOnFirstFailure = false;
            txtTipo.ResetOnPrompt = true;
            txtTipo.ResetOnSpace = true;
            txtTipo.RightToLeft = RightToLeft.No;
            txtTipo.SelectedText = "";
            txtTipo.SelectionLength = 0;
            txtTipo.SelectionStart = 0;
            txtTipo.ShortcutsEnabled = true;
            txtTipo.Size = new Size(250, 48);
            txtTipo.SkipLiterals = true;
            txtTipo.TabIndex = 5;
            txtTipo.TabStop = false;
            txtTipo.TextAlign = HorizontalAlignment.Left;
            txtTipo.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtTipo.TrailingIcon = null;
            txtTipo.UseSystemPasswordChar = false;
            txtTipo.ValidatingType = null;
            // 
            // lblTpo
            // 
            lblTpo.AutoSize = true;
            lblTpo.Depth = 0;
            lblTpo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTpo.Location = new Point(17, 367);
            lblTpo.MouseState = MaterialSkin.MouseState.HOVER;
            lblTpo.Name = "lblTpo";
            lblTpo.Size = new Size(33, 19);
            lblTpo.TabIndex = 4;
            lblTpo.Text = "Tipo";
            // 
            // txtEstado
            // 
            txtEstado.AllowPromptAsInput = true;
            txtEstado.AnimateReadOnly = false;
            txtEstado.AsciiOnly = false;
            txtEstado.BackgroundImageLayout = ImageLayout.None;
            txtEstado.BeepOnError = false;
            txtEstado.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtEstado.Depth = 0;
            txtEstado.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEstado.HidePromptOnLeave = false;
            txtEstado.HideSelection = true;
            txtEstado.InsertKeyMode = InsertKeyMode.Default;
            txtEstado.LeadingIcon = null;
            txtEstado.Location = new Point(10, 259);
            txtEstado.Mask = "";
            txtEstado.MaxLength = 32767;
            txtEstado.MouseState = MaterialSkin.MouseState.OUT;
            txtEstado.Name = "txtEstado";
            txtEstado.PasswordChar = '\0';
            txtEstado.PrefixSuffixText = null;
            txtEstado.PromptChar = '_';
            txtEstado.ReadOnly = false;
            txtEstado.RejectInputOnFirstFailure = false;
            txtEstado.ResetOnPrompt = true;
            txtEstado.ResetOnSpace = true;
            txtEstado.RightToLeft = RightToLeft.No;
            txtEstado.SelectedText = "";
            txtEstado.SelectionLength = 0;
            txtEstado.SelectionStart = 0;
            txtEstado.ShortcutsEnabled = true;
            txtEstado.Size = new Size(250, 48);
            txtEstado.SkipLiterals = true;
            txtEstado.TabIndex = 3;
            txtEstado.TabStop = false;
            txtEstado.TextAlign = HorizontalAlignment.Left;
            txtEstado.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtEstado.TrailingIcon = null;
            txtEstado.UseSystemPasswordChar = false;
            txtEstado.ValidatingType = null;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Depth = 0;
            lblEstado.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEstado.Location = new Point(10, 205);
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
            txtNumeroHab.Location = new Point(10, 98);
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
            lblNumeroHab.Location = new Point(10, 56);
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
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
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
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            materialTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
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
        private MaterialSkin.Controls.MaterialMaskedTextBox txtEstado;
        private MaterialSkin.Controls.MaterialLabel lblEstado;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtNumeroHab;
        private MaterialSkin.Controls.MaterialLabel lblNumeroHab;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtTipo;
        private DataGridView dataGridView2;
        private MaterialSkin.Controls.MaterialButton btnRegistrar;
        private MaterialSkin.Controls.MaterialButton btnBusqueda;
        private MaterialSkin.Controls.MaterialComboBox cmbCedula;
        private MaterialSkin.Controls.MaterialComboBox cmbID;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
