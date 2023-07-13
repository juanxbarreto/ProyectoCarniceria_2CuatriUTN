namespace FormsCarniceria
{
    partial class HeladeraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeladeraForm));
            dgvProductos = new DataGridView();
            labelBuscar = new Label();
            textBoxBuscar = new TextBox();
            labelCliente = new Label();
            dgvClientes = new DataGridView();
            numericUpDownCantidad = new NumericUpDown();
            labelCantidad = new Label();
            btnVender = new Button();
            checkBoxCredito = new CheckBox();
            labelReloj = new Label();
            btnAdd = new Button();
            btnModify = new Button();
            btnDelete = new Button();
            btnDeserializar = new Button();
            btnSerializar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 52);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowTemplate.Height = 25;
            dgvProductos.Size = new Size(606, 150);
            dgvProductos.TabIndex = 0;
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelBuscar.Location = new Point(12, 24);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(54, 20);
            labelBuscar.TabIndex = 1;
            labelBuscar.Text = "Buscar";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(72, 21);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(396, 23);
            textBoxBuscar.TabIndex = 2;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCliente.Location = new Point(12, 229);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(56, 20);
            labelCliente.TabIndex = 3;
            labelCliente.Text = "Cliente";
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 252);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowTemplate.Height = 25;
            dgvClientes.Size = new Size(606, 150);
            dgvClientes.TabIndex = 4;
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.Location = new Point(545, 408);
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.Size = new Size(73, 23);
            numericUpDownCantidad.TabIndex = 5;
            // 
            // labelCantidad
            // 
            labelCantidad.AutoSize = true;
            labelCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            labelCantidad.Location = new Point(471, 411);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(68, 20);
            labelCantidad.TabIndex = 6;
            labelCantidad.Text = "Cantidad";
            // 
            // btnVender
            // 
            btnVender.Font = new Font("LEMON MILK Bold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnVender.Location = new Point(647, 508);
            btnVender.Name = "btnVender";
            btnVender.Size = new Size(141, 40);
            btnVender.TabIndex = 7;
            btnVender.Text = "VENDER";
            btnVender.UseVisualStyleBackColor = true;
            btnVender.Click += btnVender_Click;
            // 
            // checkBoxCredito
            // 
            checkBoxCredito.AutoSize = true;
            checkBoxCredito.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            checkBoxCredito.Location = new Point(647, 483);
            checkBoxCredito.Name = "checkBoxCredito";
            checkBoxCredito.Size = new Size(113, 19);
            checkBoxCredito.TabIndex = 8;
            checkBoxCredito.Text = "Paga con credito";
            checkBoxCredito.UseVisualStyleBackColor = true;
            // 
            // labelReloj
            // 
            labelReloj.AutoSize = true;
            labelReloj.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            labelReloj.Location = new Point(750, 9);
            labelReloj.Name = "labelReloj";
            labelReloj.Size = new Size(32, 15);
            labelReloj.TabIndex = 9;
            labelReloj.Text = "Reloj";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            btnAdd.Location = new Point(624, 52);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 26);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnModify
            // 
            btnModify.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            btnModify.Location = new Point(624, 84);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(84, 26);
            btnModify.TabIndex = 11;
            btnModify.Text = "Modificar";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += btnModify_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            btnDelete.Location = new Point(624, 116);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(84, 26);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnDeserializar
            // 
            btnDeserializar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            btnDeserializar.Location = new Point(12, 525);
            btnDeserializar.Name = "btnDeserializar";
            btnDeserializar.Size = new Size(135, 23);
            btnDeserializar.TabIndex = 13;
            btnDeserializar.Text = "Deserializar";
            btnDeserializar.UseVisualStyleBackColor = true;
            btnDeserializar.Click += btnDeserializar_Click;
            // 
            // btnSerializar
            // 
            btnSerializar.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            btnSerializar.Location = new Point(12, 496);
            btnSerializar.Name = "btnSerializar";
            btnSerializar.Size = new Size(135, 23);
            btnSerializar.TabIndex = 14;
            btnSerializar.Text = "Serializar";
            btnSerializar.UseVisualStyleBackColor = true;
            btnSerializar.Click += btnSerializar_Click;
            // 
            // HeladeraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 560);
            Controls.Add(btnSerializar);
            Controls.Add(btnDeserializar);
            Controls.Add(btnDelete);
            Controls.Add(btnModify);
            Controls.Add(btnAdd);
            Controls.Add(labelReloj);
            Controls.Add(checkBoxCredito);
            Controls.Add(btnVender);
            Controls.Add(labelCantidad);
            Controls.Add(numericUpDownCantidad);
            Controls.Add(dgvClientes);
            Controls.Add(labelCliente);
            Controls.Add(textBoxBuscar);
            Controls.Add(labelBuscar);
            Controls.Add(dgvProductos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HeladeraForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Heladera";
            FormClosing += HeladeraForm_FormClosing;
            FormClosed += HeladeraForm_FormClosed;
            Load += HeladeraForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Label labelBuscar;
        private TextBox textBoxBuscar;
        private Label labelCliente;
        private DataGridView dgvClientes;
        private NumericUpDown numericUpDownCantidad;
        private Label labelCantidad;
        private Button btnVender;
        private CheckBox checkBoxCredito;
        private Label labelReloj;
        private Button btnAdd;
        private Button btnModify;
        private Button btnDelete;
        private Button btnDeserializar;
        private Button btnSerializar;
    }
}