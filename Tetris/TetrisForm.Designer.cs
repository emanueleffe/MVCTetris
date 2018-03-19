namespace Tetris.View
{
    partial class TetrisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TetrisForm));
            this.score = new System.Windows.Forms.Label();
            this.diff = new System.Windows.Forms.Label();
            this.pulsanti = new System.Windows.Forms.Label();
            this.bShowRanking = new System.Windows.Forms.Label();
            this.bPauseResume = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.Color.Transparent;
            this.score.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.ForeColor = System.Drawing.Color.White;
            this.score.Location = new System.Drawing.Point(270, 292);
            this.score.Name = "score";
            this.score.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.score.Size = new System.Drawing.Size(63, 15);
            this.score.TabIndex = 0;
            this.score.Text = "Score: 0";
            this.score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.diff.Size = new System.Drawing.Size(63, 15);
            this.diff.TabIndex = 3;
            this.diff.Text = "Level: 1";
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
            this.pulsanti.Text = "Buttons:\r\n↑, →, ↓, ←";
            this.pulsanti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bShowRanking
            // 
            this.bShowRanking.AutoSize = true;
            this.bShowRanking.ForeColor = System.Drawing.Color.White;
            this.bShowRanking.Location = new System.Drawing.Point(262, 347);
            this.bShowRanking.Name = "bShowRanking";
            this.bShowRanking.Size = new System.Drawing.Size(91, 13);
            this.bShowRanking.TabIndex = 7;
            this.bShowRanking.Text = "Show high scores";
            // 
            // bPauseResume
            // 
            this.bPauseResume.AutoSize = true;
            this.bPauseResume.ForeColor = System.Drawing.Color.White;
            this.bPauseResume.Location = new System.Drawing.Point(262, 370);
            this.bPauseResume.Name = "bPauseResume";
            this.bPauseResume.Size = new System.Drawing.Size(85, 13);
            this.bPauseResume.TabIndex = 8;
            this.bPauseResume.Text = "Pause - Resume";
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(374, 401);
            this.Controls.Add(this.bPauseResume);
            this.Controls.Add(this.bShowRanking);
            this.Controls.Add(this.pulsanti);
            this.Controls.Add(this.diff);
            this.Controls.Add(this.score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label diff;
        private System.Windows.Forms.Label pulsanti;
        public System.Windows.Forms.Label bShowRanking;
        public System.Windows.Forms.Label bPauseResume;
    }
}