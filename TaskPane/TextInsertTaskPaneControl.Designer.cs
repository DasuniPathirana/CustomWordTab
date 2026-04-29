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
            this.lblInstruction = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstruction.Location = new System.Drawing.Point(8, 8);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblInstruction.Size = new System.Drawing.Size(155, 18);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Enter text to insert (plain text):";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(8, 32);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(260, 150);
            this.txtInput.TabIndex = 1;
            // 
            // btnInsert
            // 
            //this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left
            //| System.Windows.Forms.AnchorStyles.Right)));
            //this.btnInsert.Location = new System.Drawing.Point(8, 192);
            //this.btnInsert.Name = "btnInsert";
            //this.btnInsert.Size = new System.Drawing.Size(260, 30);
            //this.btnInsert.TabIndex = 2;
            //this.btnInsert.Text = "Insert Text";
            //this.btnInsert.UseVisualStyleBackColor = true;
            //this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(8, 192);
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
            this.Name = "TextInsertTaskPaneControl";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(280, 235);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInsert;
    }
}
