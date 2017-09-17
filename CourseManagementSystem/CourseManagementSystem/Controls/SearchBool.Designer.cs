namespace CMS
{
    partial class SearchBool
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOperator = new System.Windows.Forms.Panel();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOperator
            // 
            this.pnlOperator.Controls.Add(this.rdbNo);
            this.pnlOperator.Controls.Add(this.rdbYes);
            this.pnlOperator.Location = new System.Drawing.Point(25, 36);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(100, 54);
            this.pnlOperator.TabIndex = 162;
            this.pnlOperator.Tag = "Checked";
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Location = new System.Drawing.Point(4, 27);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(39, 17);
            this.rdbNo.TabIndex = 1;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdbYes
            // 
            this.rdbYes.AutoSize = true;
            this.rdbYes.Checked = true;
            this.rdbYes.Location = new System.Drawing.Point(4, 4);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(43, 17);
            this.rdbYes.TabIndex = 0;
            this.rdbYes.TabStop = true;
            this.rdbYes.Text = "Yes";
            this.rdbYes.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(21, 12);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 21);
            this.lblType.TabIndex = 168;
            this.lblType.Text = "Checked:";
            // 
            // SearchBool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pnlOperator);
            this.Name = "SearchBool";
            this.Size = new System.Drawing.Size(512, 166);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlOperator;
        public System.Windows.Forms.RadioButton rdbNo;
        public System.Windows.Forms.RadioButton rdbYes;
        public System.Windows.Forms.Label lblType;
    }
}
