namespace Vista
{
    partial class ventana
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventana));
            this.btnjugar = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.txtminas = new System.Windows.Forms.TextBox();
            this.txttamano = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paneltablero = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnjugar
            // 
            this.btnjugar.Location = new System.Drawing.Point(130, 23);
            this.btnjugar.Name = "btnjugar";
            this.btnjugar.Size = new System.Drawing.Size(105, 23);
            this.btnjugar.TabIndex = 0;
            this.btnjugar.Text = "Jugar";
            this.btnjugar.UseVisualStyleBackColor = true;
            this.btnjugar.Click += new System.EventHandler(this.btnjugar_Click);
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel.Controls.Add(this.txtminas);
            this.panel.Controls.Add(this.btnjugar);
            this.panel.Controls.Add(this.txttamano);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Location = new System.Drawing.Point(6, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(238, 70);
            this.panel.TabIndex = 1;
            // 
            // txtminas
            // 
            this.txtminas.Location = new System.Drawing.Point(56, 39);
            this.txtminas.Name = "txtminas";
            this.txtminas.Size = new System.Drawing.Size(65, 20);
            this.txtminas.TabIndex = 4;
            // 
            // txttamano
            // 
            this.txttamano.Location = new System.Drawing.Point(56, 7);
            this.txttamano.Name = "txttamano";
            this.txttamano.Size = new System.Drawing.Size(65, 20);
            this.txttamano.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "tamaño";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No.minas";
            // 
            // paneltablero
            // 
            this.paneltablero.AutoSize = true;
            this.paneltablero.BackColor = System.Drawing.SystemColors.HotTrack;
            this.paneltablero.Location = new System.Drawing.Point(6, 88);
            this.paneltablero.Name = "paneltablero";
            this.paneltablero.Size = new System.Drawing.Size(50, 10);
            this.paneltablero.TabIndex = 2;
            this.paneltablero.Visible = false;
            // 
            // ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(246, 86);
            this.Controls.Add(this.paneltablero);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ventana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscaminas";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnjugar;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox txtminas;
        private System.Windows.Forms.TextBox txttamano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel paneltablero;
    }
}

