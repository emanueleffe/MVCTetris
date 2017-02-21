namespace Tetris.View
{
    partial class Tetris_Form
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
            this.punti = new System.Windows.Forms.Label();
            this.diff = new System.Windows.Forms.Label();
            this.pulsanti = new System.Windows.Forms.Label();
            this.bMostraClassifica = new System.Windows.Forms.Label();
            this.bPausaRiprendi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // punti
            // 
            this.punti.AutoSize = true;
            this.punti.BackColor = System.Drawing.Color.Transparent;
            this.punti.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.punti.ForeColor = System.Drawing.Color.White;
            this.punti.Location = new System.Drawing.Point(256, 292);
            this.punti.Name = "punti";
            this.punti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.punti.Size = new System.Drawing.Size(91, 15);
            this.punti.TabIndex = 0;
            this.punti.Text = "Punteggio: 0";
            this.punti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // diff
            // 
            this.diff.AutoSize = true;
            this.diff.BackColor = System.Drawing.Color.Transparent;
            this.diff.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diff.ForeColor = System.Drawing.Color.White;
            this.diff.Location = new System.Drawing.Point(270, 277);
            this.diff.Name = "diff";
            this.diff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.diff.Size = new System.Drawing.Size(77, 15);
            this.diff.TabIndex = 3;
            this.diff.Text = "Livello: 1";
            this.diff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pulsanti
            // 
            this.pulsanti.AutoSize = true;
            this.pulsanti.BackColor = System.Drawing.Color.Transparent;
            this.pulsanti.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulsanti.ForeColor = System.Drawing.Color.White;
            this.pulsanti.Location = new System.Drawing.Point(270, 219);
            this.pulsanti.Name = "pulsanti";
            this.pulsanti.Size = new System.Drawing.Size(77, 28);
            this.pulsanti.TabIndex = 4;
            this.pulsanti.Text = "Pulsanti:\r\n↑, →, ↓, ←";
            this.pulsanti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bMostraClassifica
            // 
            this.bMostraClassifica.AutoSize = true;
            this.bMostraClassifica.ForeColor = System.Drawing.Color.White;
            this.bMostraClassifica.Location = new System.Drawing.Point(262, 347);
            this.bMostraClassifica.Name = "bMostraClassifica";
            this.bMostraClassifica.Size = new System.Drawing.Size(85, 13);
            this.bMostraClassifica.TabIndex = 7;
            this.bMostraClassifica.Text = "Mostra classifica";
            // 
            // bPausaRiprendi
            // 
            this.bPausaRiprendi.AutoSize = true;
            this.bPausaRiprendi.ForeColor = System.Drawing.Color.White;
            this.bPausaRiprendi.Location = new System.Drawing.Point(262, 369);
            this.bPausaRiprendi.Name = "bPausaRiprendi";
            this.bPausaRiprendi.Size = new System.Drawing.Size(81, 13);
            this.bPausaRiprendi.TabIndex = 8;
            this.bPausaRiprendi.Text = "Pausa/Riprendi";
            // 
            // Tetris_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(374, 401);
            this.Controls.Add(this.bPausaRiprendi);
            this.Controls.Add(this.bMostraClassifica);
            this.Controls.Add(this.pulsanti);
            this.Controls.Add(this.diff);
            this.Controls.Add(this.punti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tetris_Form";
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label punti;
        private System.Windows.Forms.Label diff;
        private System.Windows.Forms.Label pulsanti;
        public System.Windows.Forms.Label bMostraClassifica;
        public System.Windows.Forms.Label bPausaRiprendi;
    }
}