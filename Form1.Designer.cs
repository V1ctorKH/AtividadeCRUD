namespace AtividadeCRUD
{
    partial class Form1
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
            bntConsultar = new Button();
            bntEditar = new Button();
            bntRegistrar = new Button();
            bntExcluir = new Button();
            Lançamentos = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            cmbModalidade = new ComboBox();
            txtValor = new TextBox();
            txtDesc = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblSaldo = new Label();
            label3 = new Label();
            txtConsulta = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            txtSaldo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Lançamentos).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // bntConsultar
            // 
            bntConsultar.Location = new Point(22, 38);
            bntConsultar.Name = "bntConsultar";
            bntConsultar.Size = new Size(119, 23);
            bntConsultar.TabIndex = 0;
            bntConsultar.Text = "Consultar";
            bntConsultar.UseVisualStyleBackColor = true;
            bntConsultar.Click += bntConsultar_Click;
            // 
            // bntEditar
            // 
            bntEditar.Location = new Point(96, 67);
            bntEditar.Name = "bntEditar";
            bntEditar.Size = new Size(119, 23);
            bntEditar.TabIndex = 1;
            bntEditar.Text = "Editar";
            bntEditar.UseVisualStyleBackColor = true;
            bntEditar.Click += bntEditar_Click;
            // 
            // bntRegistrar
            // 
            bntRegistrar.Location = new Point(565, 268);
            bntRegistrar.Name = "bntRegistrar";
            bntRegistrar.Size = new Size(172, 23);
            bntRegistrar.TabIndex = 2;
            bntRegistrar.Text = "Registrar";
            bntRegistrar.UseVisualStyleBackColor = true;
            bntRegistrar.Click += bntRegistrar_Click;
            // 
            // bntExcluir
            // 
            bntExcluir.Location = new Point(161, 38);
            bntExcluir.Name = "bntExcluir";
            bntExcluir.Size = new Size(119, 23);
            bntExcluir.TabIndex = 3;
            bntExcluir.Text = "Excluir";
            bntExcluir.UseVisualStyleBackColor = true;
            bntExcluir.Click += bntExcluir_Click;
            // 
            // Lançamentos
            // 
            Lançamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Lançamentos.Location = new Point(53, 86);
            Lançamentos.Name = "Lançamentos";
            Lançamentos.Size = new Size(438, 345);
            Lançamentos.TabIndex = 4;
            Lançamentos.CellContentClick += Lançamentos_CellContentClick;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(519, 157);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(258, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // cmbModalidade
            // 
            cmbModalidade.FormattingEnabled = true;
            cmbModalidade.Location = new Point(519, 230);
            cmbModalidade.Name = "cmbModalidade";
            cmbModalidade.Size = new Size(258, 23);
            cmbModalidade.TabIndex = 6;
            cmbModalidade.SelectedIndexChanged += cmbModalidade_SelectedIndexChanged;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(519, 201);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(258, 23);
            txtValor.TabIndex = 7;
            txtValor.TextChanged += txtValor_TextChanged;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(519, 113);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(258, 23);
            txtDesc.TabIndex = 8;
            txtDesc.TextChanged += txtDesc_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(519, 183);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 9;
            label1.Text = "Valor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(519, 95);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 10;
            label2.Text = "Descrição";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(0, 7);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(36, 15);
            lblSaldo.TabIndex = 11;
            lblSaldo.Text = "Saldo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(521, 139);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 12;
            label3.Text = "Data";
            // 
            // txtConsulta
            // 
            txtConsulta.Location = new Point(22, 9);
            txtConsulta.Name = "txtConsulta";
            txtConsulta.Size = new Size(258, 23);
            txtConsulta.TabIndex = 13;
            txtConsulta.TextChanged += txtConsulta_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(497, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 224);
            panel1.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtConsulta);
            panel2.Controls.Add(bntConsultar);
            panel2.Controls.Add(bntEditar);
            panel2.Controls.Add(bntExcluir);
            panel2.Location = new Point(497, 329);
            panel2.Name = "panel2";
            panel2.Size = new Size(302, 102);
            panel2.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtSaldo);
            panel3.Controls.Add(lblSaldo);
            panel3.Location = new Point(53, 47);
            panel3.Name = "panel3";
            panel3.Size = new Size(438, 36);
            panel3.TabIndex = 16;
            // 
            // txtSaldo
            // 
            txtSaldo.BackColor = SystemColors.Info;
            txtSaldo.Location = new Point(42, 4);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Size = new Size(391, 23);
            txtSaldo.TabIndex = 12;
            txtSaldo.TextChanged += txtSaldo_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 486);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDesc);
            Controls.Add(txtValor);
            Controls.Add(cmbModalidade);
            Controls.Add(dateTimePicker1);
            Controls.Add(Lançamentos);
            Controls.Add(bntRegistrar);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Lançamentos).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bntConsultar;
        private Button bntEditar;
        private Button bntRegistrar;
        private Button bntExcluir;
        private DataGridView Lançamentos;
        private DateTimePicker dateTimePicker1;
        private ComboBox cmbModalidade;
        private TextBox txtValor;
        private TextBox txtDesc;
        private Label label1;
        private Label label2;
        private Label lblSaldo;
        private Label label3;
        private TextBox txtConsulta;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtSaldo;
    }
}
