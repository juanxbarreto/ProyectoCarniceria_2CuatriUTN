namespace FormsCarniceria
{
    partial class VentasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasForm));
            dgvProductos = new DataGridView();
            btnComprar = new Button();
            checkBoxCredito = new CheckBox();
            numericUpDownCantidad = new NumericUpDown();
            labelCantidad = new Label();
            labelCliente = new Label();
            labelBuscar = new Label();
            textBoxBuscar = new TextBox();
            labelReloj = new Label();
            btnSerializar = new Button();
            btnDeserializar = new Button();
            numericUpDownSaldo = new NumericUpDown();
            btnSaldo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaldo).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 64);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowTemplate.Height = 25;
            dgvProductos.Size = new Size(603, 289);
            dgvProductos.TabIndex = 0;
            // 
            // btnComprar
            // 
            btnComprar.Font = new Font("LEMON MILK Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnComprar.Location = new Point(668, 459);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(116, 35);
            btnComprar.TabIndex = 1;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // checkBoxCredito
            // 
            checkBoxCredito.AutoSize = true;
            checkBoxCredito.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            checkBoxCredito.Location = new Point(668, 434);
            checkBoxCredito.Name = "checkBoxCredito";
            checkBoxCredito.Size = new Size(112, 19);
            checkBoxCredito.TabIndex = 2;
            checkBoxCredito.Text = "Pago con credito";
            checkBoxCredito.UseVisualStyleBackColor = true;
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.Location = new Point(557, 362);
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.Size = new Size(58, 23);
            numericUpDownCantidad.TabIndex = 3;
            // 
            // labelCantidad
            // 
            labelCantidad.AutoSize = true;
            labelCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCantidad.Location = new Point(482, 365);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(69, 20);
            labelCantidad.TabIndex = 4;
            labelCantidad.Text = "Cantidad";
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            labelCliente.Location = new Point(12, 368);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(77, 17);
            labelCliente.TabIndex = 5;
            labelCliente.Text = "DatosCliente";
            // 
            // labelBuscar
            // 
            labelBuscar.AutoSize = true;
            labelBuscar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelBuscar.Location = new Point(12, 34);
            labelBuscar.Name = "labelBuscar";
            labelBuscar.Size = new Size(54, 20);
            labelBuscar.TabIndex = 6;
            labelBuscar.Text = "Buscar";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(72, 35);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(417, 23);
            textBoxBuscar.TabIndex = 7;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // labelReloj
            // 
            labelReloj.AutoSize = true;
            labelReloj.Location = new Point(730, 9);
            labelReloj.Name = "labelReloj";
            labelReloj.Size = new Size(58, 15);
            labelReloj.TabIndex = 8;
            labelReloj.Text = "labelReloj";
            // 
            // btnSerializar
            // 
            btnSerializar.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            btnSerializar.Location = new Point(621, 64);
            btnSerializar.Name = "btnSerializar";
            btnSerializar.Size = new Size(124, 23);
            btnSerializar.TabIndex = 9;
            btnSerializar.Text = "Serializar";
            btnSerializar.UseVisualStyleBackColor = true;
            btnSerializar.Click += btnSerializar_Click;
            // 
            // btnDeserializar
            // 
            btnDeserializar.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            btnDeserializar.Location = new Point(621, 93);
            btnDeserializar.Name = "btnDeserializar";
            btnDeserializar.Size = new Size(124, 23);
            btnDeserializar.TabIndex = 10;
            btnDeserializar.Text = "Deserializar";
            btnDeserializar.UseVisualStyleBackColor = true;
            btnDeserializar.Click += btnDeserializar_Click;
            // 
            // numericUpDownSaldo
            // 
            numericUpDownSaldo.DecimalPlaces = 2;
            numericUpDownSaldo.Location = new Point(149, 471);
            numericUpDownSaldo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSaldo.Name = "numericUpDownSaldo";
            numericUpDownSaldo.Size = new Size(86, 23);
            numericUpDownSaldo.TabIndex = 11;
            // 
            // btnSaldo
            // 
            btnSaldo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnSaldo.Location = new Point(12, 471);
            btnSaldo.Name = "btnSaldo";
            btnSaldo.Size = new Size(131, 23);
            btnSaldo.TabIndex = 12;
            btnSaldo.Text = "Actualizar saldo";
            btnSaldo.UseVisualStyleBackColor = true;
            btnSaldo.Click += btnSaldo_Click;
            // 
            // VentasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkKhaki;
            ClientSize = new Size(800, 506);
            Controls.Add(btnSaldo);
            Controls.Add(numericUpDownSaldo);
            Controls.Add(btnDeserializar);
            Controls.Add(btnSerializar);
            Controls.Add(labelReloj);
            Controls.Add(textBoxBuscar);
            Controls.Add(labelBuscar);
            Controls.Add(labelCliente);
            Controls.Add(labelCantidad);
            Controls.Add(numericUpDownCantidad);
            Controls.Add(checkBoxCredito);
            Controls.Add(btnComprar);
            Controls.Add(dgvProductos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VentasForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            FormClosing += VentasForm_FormClosing;
            FormClosed += VentasForm_FormClosed;
            Load += VentasForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSaldo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnComprar;
        private CheckBox checkBoxCredito;
        private NumericUpDown numericUpDownCantidad;
        private Label labelCantidad;
        private Label labelCliente;
        private Label labelBuscar;
        private TextBox textBoxBuscar;
        private Label labelReloj;
        private Button btnSerializar;
        private Button btnDeserializar;
        private NumericUpDown numericUpDownSaldo;
        private Button btnSaldo;
    }
}