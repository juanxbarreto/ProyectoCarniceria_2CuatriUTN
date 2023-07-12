namespace FormsCarniceria
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            labelBienvenida = new Label();
            labelMail = new Label();
            labelPass = new Label();
            labelTipo = new Label();
            textBoxMail = new TextBox();
            textBoxPass = new TextBox();
            comboBoxTipo = new ComboBox();
            btnIngresar = new Button();
            btnAutocompletar = new Button();
            SuspendLayout();
            // 
            // labelBienvenida
            // 
            labelBienvenida.AutoSize = true;
            labelBienvenida.Font = new Font("LEMON MILK Bold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelBienvenida.Location = new Point(43, 25);
            labelBienvenida.Name = "labelBienvenida";
            labelBienvenida.Size = new Size(334, 21);
            labelBienvenida.TabIndex = 0;
            labelBienvenida.Text = "Bienvenido a Carniceria Don Julio";
            // 
            // labelMail
            // 
            labelMail.AutoSize = true;
            labelMail.Font = new Font("Georgia", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelMail.Location = new Point(12, 143);
            labelMail.Name = "labelMail";
            labelMail.Size = new Size(137, 18);
            labelMail.TabIndex = 1;
            labelMail.Text = "Correo Electronico:";
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Font = new Font("Georgia", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelPass.Location = new Point(12, 201);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(89, 18);
            labelPass.TabIndex = 2;
            labelPass.Text = "Contraseña:";
            // 
            // labelTipo
            // 
            labelTipo.AutoSize = true;
            labelTipo.Font = new Font("Georgia", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelTipo.Location = new Point(12, 271);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(115, 18);
            labelTipo.TabIndex = 3;
            labelTipo.Text = "Tipo de usuario:";
            // 
            // textBoxMail
            // 
            textBoxMail.Location = new Point(12, 164);
            textBoxMail.Name = "textBoxMail";
            textBoxMail.Size = new Size(397, 23);
            textBoxMail.TabIndex = 4;
            // 
            // textBoxPass
            // 
            textBoxPass.Location = new Point(12, 222);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.Size = new Size(397, 23);
            textBoxPass.TabIndex = 5;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(12, 292);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(156, 23);
            comboBoxTipo.TabIndex = 6;
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("LEMON MILK Bold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.Location = new Point(12, 357);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(397, 46);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnAutocompletar
            // 
            btnAutocompletar.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            btnAutocompletar.Location = new Point(12, 495);
            btnAutocompletar.Name = "btnAutocompletar";
            btnAutocompletar.Size = new Size(137, 23);
            btnAutocompletar.TabIndex = 8;
            btnAutocompletar.Text = "Autocompletar";
            btnAutocompletar.UseVisualStyleBackColor = true;
            btnAutocompletar.Click += btnAutocompletar_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(421, 530);
            Controls.Add(btnAutocompletar);
            Controls.Add(btnIngresar);
            Controls.Add(comboBoxTipo);
            Controls.Add(textBoxPass);
            Controls.Add(textBoxMail);
            Controls.Add(labelTipo);
            Controls.Add(labelPass);
            Controls.Add(labelMail);
            Controls.Add(labelBienvenida);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBienvenida;
        private Label labelMail;
        private Label labelPass;
        private Label labelTipo;
        private TextBox textBoxMail;
        private TextBox textBoxPass;
        private ComboBox comboBoxTipo;
        private Button btnIngresar;
        private Button btnAutocompletar;
    }
}