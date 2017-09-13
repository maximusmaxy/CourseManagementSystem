namespace CMS
{
    partial class SearchString
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
            this.rdbPartialMatch = new System.Windows.Forms.RadioButton();
            this.rdbExactMatch = new System.Windows.Forms.RadioButton();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.pnlOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOperator
            // 
            this.pnlOperator.Controls.Add(this.rdbPartialMatch);
            this.pnlOperator.Controls.Add(this.rdbExactMatch);
            this.pnlOperator.Location = new System.Drawing.Point(3, 3);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(100, 56);
            this.pnlOperator.TabIndex = 162;
            // 
            // rdbPartialMatch
            // 
            this.rdbPartialMatch.AutoSize = true;
            this.rdbPartialMatch.Location = new System.Drawing.Point(4, 27);
            this.rdbPartialMatch.Name = "rdbPartialMatch";
            this.rdbPartialMatch.Size = new System.Drawing.Size(87, 17);
            this.rdbPartialMatch.TabIndex = 1;
            this.rdbPartialMatch.Text = "Partial Match";
            this.rdbPartialMatch.UseVisualStyleBackColor = true;
            // 
            // rdbExactMatch
            // 
            this.rdbExactMatch.AutoSize = true;
            this.rdbExactMatch.Checked = true;
            this.rdbExactMatch.Location = new System.Drawing.Point(4, 4);
            this.rdbExactMatch.Name = "rdbExactMatch";
            this.rdbExactMatch.Size = new System.Drawing.Size(85, 17);
            this.rdbExactMatch.TabIndex = 0;
            this.rdbExactMatch.TabStop = true;
            this.rdbExactMatch.Text = "Exact Match";
            this.rdbExactMatch.UseVisualStyleBackColor = true;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(109, 7);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 163;
            // 
            // SearchString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.pnlOperator);
            this.Name = "SearchString";
            this.Size = new System.Drawing.Size(514, 206);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlOperator;
        public System.Windows.Forms.RadioButton rdbPartialMatch;
        public System.Windows.Forms.RadioButton rdbExactMatch;
        public System.Windows.Forms.TextBox txtValue;
    }
}
