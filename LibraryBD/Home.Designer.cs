
namespace LibraryBD
{
    partial class Home
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
            this.consultar = new System.Windows.Forms.Button();
            this.reservar = new System.Windows.Forms.Button();
            this.entregar = new System.Windows.Forms.Button();
            this.atividades = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // consultar
            // 
            this.consultar.BackColor = System.Drawing.Color.PeachPuff;
            this.consultar.FlatAppearance.BorderColor = System.Drawing.Color.PeachPuff;
            this.consultar.FlatAppearance.BorderSize = 0;
            this.consultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.consultar.Location = new System.Drawing.Point(318, 118);
            this.consultar.Name = "consultar";
            this.consultar.Size = new System.Drawing.Size(177, 49);
            this.consultar.TabIndex = 0;
            this.consultar.Text = "Consultar";
            this.consultar.UseVisualStyleBackColor = false;
            this.consultar.Click += new System.EventHandler(this.button1_Click);
            // 
            // reservar
            // 
            this.reservar.BackColor = System.Drawing.Color.PeachPuff;
            this.reservar.FlatAppearance.BorderSize = 0;
            this.reservar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reservar.Location = new System.Drawing.Point(318, 191);
            this.reservar.Name = "reservar";
            this.reservar.Size = new System.Drawing.Size(177, 50);
            this.reservar.TabIndex = 1;
            this.reservar.Text = "Reservar";
            this.reservar.UseVisualStyleBackColor = false;
            this.reservar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // entregar
            // 
            this.entregar.BackColor = System.Drawing.Color.PeachPuff;
            this.entregar.FlatAppearance.BorderSize = 0;
            this.entregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.entregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.entregar.Location = new System.Drawing.Point(318, 265);
            this.entregar.Name = "entregar";
            this.entregar.Size = new System.Drawing.Size(177, 49);
            this.entregar.TabIndex = 2;
            this.entregar.Text = "Entregar";
            this.entregar.UseVisualStyleBackColor = false;
            this.entregar.Click += new System.EventHandler(this.entregar_Click);
            // 
            // atividades
            // 
            this.atividades.BackColor = System.Drawing.Color.PeachPuff;
            this.atividades.FlatAppearance.BorderSize = 0;
            this.atividades.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.atividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.atividades.Location = new System.Drawing.Point(318, 336);
            this.atividades.Name = "atividades";
            this.atividades.Size = new System.Drawing.Size(177, 49);
            this.atividades.TabIndex = 3;
            this.atividades.Text = "Atividades";
            this.atividades.UseVisualStyleBackColor = false;
            this.atividades.Click += new System.EventHandler(this.atividades_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.PeachPuff;
            this.label1.Location = new System.Drawing.Point(126, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bem-vindo à Biblioteca Municipal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryBD.Properties.Resources.pic;
            this.pictureBox1.Location = new System.Drawing.Point(800, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 359);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::LibraryBD.Properties.Resources.pic;
            this.pictureBox2.Location = new System.Drawing.Point(12, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(242, 359);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = global::LibraryBD.Properties.Resources.pic2;
            this.pictureBox3.Location = new System.Drawing.Point(546, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(242, 359);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Sienna;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Sienna;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Sienna;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Sienna;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(660, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 76);
            this.button1.TabIndex = 9;
            this.button1.Text = "🛈 ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atividades);
            this.Controls.Add(this.entregar);
            this.Controls.Add(this.reservar);
            this.Controls.Add(this.consultar);
            this.Name = "Home";
            this.Text = "Início";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button consultar;
        private System.Windows.Forms.Button reservar;
        private System.Windows.Forms.Button entregar;
        private System.Windows.Forms.Button atividades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button1;
    }
}

