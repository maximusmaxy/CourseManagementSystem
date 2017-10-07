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
            this.txtString = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.rdbExclude = new System.Windows.Forms.RadioButton();
            this.pnlOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOperator
            // 
            this.pnlOperator.Controls.Add(this.rdbExclude);
            this.pnlOperator.Controls.Add(this.rdbPartialMatch);
            this.pnlOperator.Controls.Add(this.rdbExactMatch);
            this.pnlOperator.Location = new System.Drawing.Point(3, 3);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(100, 76);
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
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(109, 31);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(100, 20);
            this.txtString.TabIndex = 163;
            this.txtString.Tag = "Word";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(109, 7);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(56, 21);
            this.lblValue.TabIndex = 167;
            this.lblValue.Text = "Word:";
            // 
            // rdbExclude
            // 
            this.rdbExclude.AutoSize = true;
            this.rdbExclude.Location = new System.Drawing.Point(4, 50);
            this.rdbExclude.Name = "rdbExclude";
            this.rdbExclude.Size = new System.Drawing.Size(63, 17);
            this.rdbExclude.TabIndex = 2;
            this.rdbExclude.Text = "Exclude";
            this.rdbExclude.UseVisualStyleBackColor = true;
            // 
            // SearchString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.pnlOperator);
            this.Name = "SearchString";
            this.Size = new System.Drawing.Size(532, 222);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlOperator;
        public System.Windows.Forms.RadioButton rdbPartialMatch;
        public System.Windows.Forms.RadioButton rdbExactMatch;
        public System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Label lblValue;
        public System.Windows.Forms.RadioButton rdbExclude;
    }
}
