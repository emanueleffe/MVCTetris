namespace Tetris.View
{
    partial class FormClassifica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grigliaDati = new System.Windows.Forms.DataGridView();
            this.bSvuota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grigliaDati)).BeginInit();
            this.SuspendLayout();
            // 
            // grigliaDati
            // 
            this.grigliaDati.AllowUserToAddRows = false;
            this.grigliaDati.AllowUserToDeleteRows = false;
            this.grigliaDati.AllowUserToResizeColumns = false;
            this.grigliaDati.AllowUserToResizeRows = false;
            this.grigliaDati.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.grigliaDati.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grigliaDati.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grigliaDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grigliaDati.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grigliaDati.DefaultCellStyle = dataGridViewCellStyle1;
            this.grigliaDati.EnableHeadersVisualStyles = false;
            this.grigliaDati.GridColor = System.Drawing.Color.LightGray;
            this.grigliaDati.Location = new System.Drawing.Point(0, 0);
            this.grigliaDati.Name = "grigliaDati";
            this.grigliaDati.ReadOnly = true;
            this.grigliaDati.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grigliaDati.RowHeadersVisible = false;
            this.grigliaDati.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grigliaDati.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grigliaDati.Size = new System.Drawing.Size(201, 303);
            this.grigliaDati.TabIndex = 0;
            // 
            // bSvuota
            // 
            this.bSvuota.Location = new System.Drawing.Point(12, 309);
            this.bSvuota.Name = "bSvuota";
            this.bSvuota.Size = new System.Drawing.Size(177, 23);
            this.bSvuota.TabIndex = 1;
            this.bSvuota.Text = "Elimina punteggi migliori";
            this.bSvuota.UseVisualStyleBackColor = true;
            // 
            // FormClassifica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(201, 344);
            this.Controls.Add(this.bSvuota);
            this.Controls.Add(this.grigliaDati);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormClassifica";
            this.Text = "Migliori punteggi";
            ((System.ComponentModel.ISupportInitialize)(this.grigliaDati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button bSvuota;
        public System.Windows.Forms.DataGridView grigliaDati;
    }
}