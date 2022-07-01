namespace Connect4
{
    partial class ventanaMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ventanaMenu));
            this.JvsCOM = new System.Windows.Forms.Button();
            this.JvJ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // JvsCOM
            // 
            this.JvsCOM.Location = new System.Drawing.Point(51, 36);
            this.JvsCOM.Name = "JvsCOM";
            this.JvsCOM.Size = new System.Drawing.Size(165, 23);
            this.JvsCOM.TabIndex = 0;
            this.JvsCOM.Text = "Jugador vs COM";
            this.JvsCOM.UseVisualStyleBackColor = true;
            this.JvsCOM.Click += new System.EventHandler(this.JvsCOM_Click);
            // 
            // JvJ
            // 
            this.JvJ.Location = new System.Drawing.Point(51, 65);
            this.JvJ.Name = "JvJ";
            this.JvJ.Size = new System.Drawing.Size(165, 23);
            this.JvJ.TabIndex = 1;
            this.JvJ.Text = "Jugador vs Jugador";
            this.JvJ.UseVisualStyleBackColor = true;
            this.JvJ.Click += new System.EventHandler(this.JvJ_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elija modo de juego:";
            // 
            // ventanaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(257, 100);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JvJ);
            this.Controls.Add(this.JvsCOM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ventanaMenu";
            this.Text = "4 en linea";
            this.Load += new System.EventHandler(this.ventanaMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button JvsCOM;
        private System.Windows.Forms.Button JvJ;
        private System.Windows.Forms.Label label1;
    }
}