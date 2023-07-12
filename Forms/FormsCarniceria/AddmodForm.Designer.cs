namespace FormsCarniceria
{
    partial class AddmodForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddmodForm));
            btnConfirmar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxNombre = new TextBox();
            textBoxDetalle = new TextBox();
            numericUpDownCantidad = new NumericUpDown();
            numericUpDownPrecio = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecio).BeginInit();
            SuspendLayout();
            // 
            // btnConfirmar
            // 
            btnConfirmar.Font = new Font("LEMON MILK Bold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirmar.Location = new Point(12, 343);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(370, 35);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(12, 118);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 2;
            label2.Text = "Precio por kilo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(12, 183);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 3;
            label3.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(12, 249);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 4;
            label4.Text = "Detalle";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(12, 75);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(370, 23);
            textBoxNombre.TabIndex = 5;
            // 
            // textBoxDetalle
            // 
            textBoxDetalle.Location = new Point(12, 272);
            textBoxDetalle.Name = "textBoxDetalle";
            textBoxDetalle.Size = new Size(370, 23);
            textBoxDetalle.TabIndex = 6;
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.Location = new Point(12, 206);
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.Size = new Size(68, 23);
            numericUpDownCantidad.TabIndex = 7;
            // 
            // numericUpDownPrecio
            // 
            numericUpDownPrecio.DecimalPlaces = 2;
            numericUpDownPrecio.Location = new Point(12, 141);
            numericUpDownPrecio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownPrecio.Name = "numericUpDownPrecio";
            numericUpDownPrecio.Size = new Size(101, 23);
            numericUpDownPrecio.TabIndex = 8;
            // 
            // AddmodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(394, 405);
            Controls.Add(numericUpDownPrecio);
            Controls.Add(numericUpDownCantidad);
            Controls.Add(textBoxDetalle);
            Controls.Add(textBoxNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddmodForm";
            Text = "Agregar Modificar producto";
            Load += AddmodForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirmar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxNombre;
        private TextBox textBoxDetalle;
        private NumericUpDown numericUpDownCantidad;
        private NumericUpDown numericUpDownPrecio;
    }
}