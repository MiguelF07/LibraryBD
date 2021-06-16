
namespace LibraryBD
{
    partial class Infobibl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.telefone = new System.Windows.Forms.TextBox();
            this.morada = new System.Windows.Forms.TextBox();
            this.nome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::LibraryBD.Properties.Resources.imageedit_1_9739736254;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.telefone);
            this.groupBox1.Controls.Add(this.morada);
            this.groupBox1.Controls.Add(this.nome);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // telefone
            // 
            this.telefone.Location = new System.Drawing.Point(100, 155);
            this.telefone.Name = "telefone";
            this.telefone.Size = new System.Drawing.Size(260, 27);
            this.telefone.TabIndex = 6;
            // 
            // morada
            // 
            this.morada.Location = new System.Drawing.Point(100, 98);
            this.morada.Name = "morada";
            this.morada.Size = new System.Drawing.Size(260, 27);
            this.morada.TabIndex = 5;
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(100, 39);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(260, 27);
            this.nome.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Morada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // Infobibl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 226);
            this.Controls.Add(this.groupBox1);
            this.Name = "Infobibl";
            this.Text = "Informação da Biblioteca";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox telefone;
        private System.Windows.Forms.TextBox morada;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}