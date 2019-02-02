namespace HotelManagementSystem
{
    partial class guestReport
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
            this.panel10 = new System.Windows.Forms.Panel();
            this.btngSearchR = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.gsearch = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(101)))));
            this.panel10.Controls.Add(this.btngSearchR);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.gsearch);
            this.panel10.Controls.Add(this.label29);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1351, 70);
            this.panel10.TabIndex = 2;
            this.panel10.Paint += new System.Windows.Forms.PaintEventHandler(this.panel10_Paint);
            // 
            // btngSearchR
            // 
            this.btngSearchR.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngSearchR.Location = new System.Drawing.Point(1173, 39);
            this.btngSearchR.Name = "btngSearchR";
            this.btngSearchR.Size = new System.Drawing.Size(79, 28);
            this.btngSearchR.TabIndex = 32;
            this.btngSearchR.Text = "Search";
            this.btngSearchR.UseVisualStyleBackColor = true;
            this.btngSearchR.Click += new System.EventHandler(this.btngSearchR_Click);
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Location = new System.Drawing.Point(3, 103);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(476, 523);
            this.panel11.TabIndex = 47;
            // 
            // gsearch
            // 
            this.gsearch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gsearch.Location = new System.Drawing.Point(917, 41);
            this.gsearch.Name = "gsearch";
            this.gsearch.Size = new System.Drawing.Size(239, 27);
            this.gsearch.TabIndex = 31;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(101)))));
            this.label29.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Transparent;
            this.label29.Location = new System.Drawing.Point(3, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(185, 43);
            this.label29.TabIndex = 45;
            this.label29.Text = "GuestReport";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 147);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1351, 587);
            this.crystalReportViewer1.TabIndex = 3;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // guestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1351, 734);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel10);
            this.Name = "guestReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "guestReport";
            this.Load += new System.EventHandler(this.guestReport_Load);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label29;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btngSearchR;
        private System.Windows.Forms.TextBox gsearch;
    }
}