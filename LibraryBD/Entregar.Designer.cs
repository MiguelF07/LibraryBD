
namespace LibraryBD
{
    partial class Entregar
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
            this.ent1 = new System.Windows.Forms.Button();
            this.enttodos = new System.Windows.Forms.Button();
            this.estender = new System.Windows.Forms.Button();
            this.itens = new System.Windows.Forms.ListBox();
            this.emprestimos = new System.Windows.Forms.ListBox();
            this.idm = new System.Windows.Forms.TextBox();
            this.procurar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emprestimos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID Membro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Itens";
            // 
            // ent1
            // 
            this.ent1.Location = new System.Drawing.Point(386, 373);
            this.ent1.Name = "ent1";
            this.ent1.Size = new System.Drawing.Size(129, 29);
            this.ent1.TabIndex = 3;
            this.ent1.Text = "Entregar";
            this.ent1.UseVisualStyleBackColor = true;
            // 
            // enttodos
            // 
            this.enttodos.Location = new System.Drawing.Point(521, 373);
            this.enttodos.Name = "enttodos";
            this.enttodos.Size = new System.Drawing.Size(126, 29);
            this.enttodos.TabIndex = 4;
            this.enttodos.Text = "Entregar Tudo";
            this.enttodos.UseVisualStyleBackColor = true;
            // 
            // estender
            // 
            this.estender.Location = new System.Drawing.Point(386, 409);
            this.estender.Name = "estender";
            this.estender.Size = new System.Drawing.Size(261, 29);
            this.estender.TabIndex = 5;
            this.estender.Text = "Estender Emprestimo";
            this.estender.UseVisualStyleBackColor = true;
            this.estender.Click += new System.EventHandler(this.button3_Click);
            // 
            // itens
            // 
            this.itens.FormattingEnabled = true;
            this.itens.ItemHeight = 20;
            this.itens.Location = new System.Drawing.Point(386, 102);
            this.itens.Name = "itens";
            this.itens.Size = new System.Drawing.Size(260, 244);
            this.itens.TabIndex = 6;
            // 
            // emprestimos
            // 
            this.emprestimos.FormattingEnabled = true;
            this.emprestimos.ItemHeight = 20;
            this.emprestimos.Location = new System.Drawing.Point(22, 50);
            this.emprestimos.Name = "emprestimos";
            this.emprestimos.Size = new System.Drawing.Size(329, 384);
            this.emprestimos.TabIndex = 7;
            this.emprestimos.SelectedIndexChanged += new System.EventHandler(this.emprestimos_SelectedIndexChanged);
            // 
            // idm
            // 
            this.idm.Location = new System.Drawing.Point(478, 37);
            this.idm.Name = "idm";
            this.idm.Size = new System.Drawing.Size(125, 27);
            this.idm.TabIndex = 8;
            // 
            // procurar
            // 
            this.procurar.Location = new System.Drawing.Point(609, 37);
            this.procurar.Name = "procurar";
            this.procurar.Size = new System.Drawing.Size(37, 29);
            this.procurar.TabIndex = 9;
            this.procurar.Text = "🔎";
            this.procurar.UseVisualStyleBackColor = true;
            this.procurar.Click += new System.EventHandler(this.procurar_Click);
            // 
            // Entregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 450);
            this.Controls.Add(this.procurar);
            this.Controls.Add(this.idm);
            this.Controls.Add(this.emprestimos);
            this.Controls.Add(this.itens);
            this.Controls.Add(this.estender);
            this.Controls.Add(this.enttodos);
            this.Controls.Add(this.ent1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Entregar";
            this.Text = "Entregar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ent1;
        private System.Windows.Forms.Button enttodos;
        private System.Windows.Forms.Button estender;
        private System.Windows.Forms.ListBox itens;
        private System.Windows.Forms.ListBox emprestimos;
        private System.Windows.Forms.TextBox idm;
        private System.Windows.Forms.Button procurar;
    }
}