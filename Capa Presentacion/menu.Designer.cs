
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
            tabPage2 = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
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
            dataGridView1 = new DataGridView();
            tabPage1 = new TabPage();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            fileSystemWatcher1 = new FileSystemWatcher();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            lblNumeroHab = new MaterialSkin.Controls.MaterialLabel();
            txtNumeroHab = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblEstado = new MaterialSkin.Controls.MaterialLabel();
            txtEstado = new MaterialSkin.Controls.MaterialMaskedTextBox();
            lblTpo = new MaterialSkin.Controls.MaterialLabel();
            txtTipo = new MaterialSkin.Controls.MaterialMaskedTextBox();
            dataGridView2 = new DataGridView();
            tabPage3.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            materialTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            // tabPage2
            // 
            tabPage2.Controls.Add(materialCard1);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1616, 857);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clientes";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
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
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(484, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(981, 653);
            dataGridView1.TabIndex = 12;
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
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(604, 56);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(861, 461);
            dataGridView2.TabIndex = 1;
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
            tabPage2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            materialTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private DataGridView dataGridView1;
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
    }
}
