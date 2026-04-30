namespace CustomWordTab.TaskPane
{
    partial class TextInsertTaskPaneControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader — Icon + Title row at the top
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 48;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.picIcon);
            // 
            // picIcon — Task pane icon (matches Insert Heading ribbon button)
            // 
            this.picIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picIcon.Size = new System.Drawing.Size(32, 32);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            // 
            // lblTitle — Task pane title next to icon
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "  Text Insert";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSeparator — Thin line between header and content
            // 
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator.Height = 1;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstruction.Location = new System.Drawing.Point(8, 57);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Padding = new System.Windows.Forms.Padding(0, 8, 0, 5);
            this.lblInstruction.Size = new System.Drawing.Size(155, 26);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInstruction.Text = "Enter text to insert (plain text):";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(8, 86);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(260, 110);
            this.txtInput.TabIndex = 1;
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(8, 204);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(260, 30);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert Text";
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(0, 120, 212);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // TextInsertTaskPaneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.pnlHeader);
            this.Name = "TextInsertTaskPaneControl";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(280, 245);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInsert;
    }
}
