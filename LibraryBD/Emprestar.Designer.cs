
namespace LibraryBD
{
    partial class Emprestar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lista = new System.Windows.Forms.ListBox();
            this.adicionar = new System.Windows.Forms.Button();
            this.criar = new System.Windows.Forms.Button();
            this.idf = new System.Windows.Forms.TextBox();
            this.idm = new System.Windows.Forms.TextBox();
            this.idi = new System.Windows.Forms.TextBox();
            this.itens = new System.Windows.Forms.GroupBox();
            this.itens.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID funcionario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID membro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID item";
            // 
            // lista
            // 
            this.lista.FormattingEnabled = true;
            this.lista.ItemHeight = 20;
            this.lista.Location = new System.Drawing.Point(24, 37);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(392, 164);
            this.lista.TabIndex = 3;
            // 
            // adicionar
            // 
            this.adicionar.Location = new System.Drawing.Point(322, 223);
            this.adicionar.Name = "adicionar";
            this.adicionar.Size = new System.Drawing.Size(94, 29);
            this.adicionar.TabIndex = 5;
            this.adicionar.Text = "Adicionar";
            this.adicionar.UseVisualStyleBackColor = true;
            this.adicionar.Click += new System.EventHandler(this.adicionar_Click);
            // 
            // criar
            // 
            this.criar.Location = new System.Drawing.Point(162, 128);
            this.criar.Name = "criar";
            this.criar.Size = new System.Drawing.Size(133, 29);
            this.criar.TabIndex = 6;
            this.criar.Text = "Criar emprestimo";
            this.criar.UseVisualStyleBackColor = true;
            this.criar.Click += new System.EventHandler(this.criar_Click);
            // 
            // idf
            // 
            this.idf.Location = new System.Drawing.Point(125, 24);
            this.idf.Name = "idf";
            this.idf.Size = new System.Drawing.Size(289, 27);
            this.idf.TabIndex = 7;
            this.idf.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // idm
            // 
            this.idm.Location = new System.Drawing.Point(125, 79);
            this.idm.Name = "idm";
            this.idm.Size = new System.Drawing.Size(289, 27);
            this.idm.TabIndex = 8;
            // 
            // idi
            // 
            this.idi.Location = new System.Drawing.Point(76, 223);
            this.idi.Name = "idi";
            this.idi.Size = new System.Drawing.Size(236, 27);
            this.idi.TabIndex = 9;
            // 
            // itens
            // 
            this.itens.Controls.Add(this.lista);
            this.itens.Controls.Add(this.label3);
            this.itens.Controls.Add(this.idi);
            this.itens.Controls.Add(this.adicionar);
            this.itens.Enabled = false;
            this.itens.Location = new System.Drawing.Point(22, 163);
            this.itens.Name = "itens";
            this.itens.Size = new System.Drawing.Size(444, 265);
            this.itens.TabIndex = 11;
            this.itens.TabStop = false;
            this.itens.Text = "Itens no Emprestimo";
            this.itens.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Emprestar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 440);
            this.Controls.Add(this.itens);
            this.Controls.Add(this.idm);
            this.Controls.Add(this.idf);
            this.Controls.Add(this.criar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Emprestar";
            this.Text = "Emprestar";
            this.itens.ResumeLayout(false);
            this.itens.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lista;
        private System.Windows.Forms.Button adicionar;
        private System.Windows.Forms.Button criar;
        private System.Windows.Forms.TextBox idf;
        private System.Windows.Forms.TextBox idm;
        private System.Windows.Forms.TextBox idi;
        private System.Windows.Forms.GroupBox itens;
    }
}