namespace CMS
{
    partial class SearchCost
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.pnlOperator = new System.Windows.Forms.Panel();
            this.rdbBetween = new System.Windows.Forms.RadioButton();
            this.rdbGreaterThan = new System.Windows.Forms.RadioButton();
            this.rdbLessThan = new System.Windows.Forms.RadioButton();
            this.rdbEqualTo = new System.Windows.Forms.RadioButton();
            this.pnlOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(133, 39);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 160;
            // 
            // pnlOperator
            // 
            this.pnlOperator.Controls.Add(this.rdbBetween);
            this.pnlOperator.Controls.Add(this.rdbGreaterThan);
            this.pnlOperator.Controls.Add(this.rdbLessThan);
            this.pnlOperator.Controls.Add(this.rdbEqualTo);
            this.pnlOperator.Location = new System.Drawing.Point(3, 3);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(100, 98);
            this.pnlOperator.TabIndex = 161;
            // 
            // rdbBetween
            // 
            this.rdbBetween.AutoSize = true;
            this.rdbBetween.Location = new System.Drawing.Point(4, 73);
            this.rdbBetween.Name = "rdbBetween";
            this.rdbBetween.Size = new System.Drawing.Size(67, 17);
            this.rdbBetween.TabIndex = 3;
            this.rdbBetween.Text = "Between";
            this.rdbBetween.UseVisualStyleBackColor = true;
            // 
            // rdbGreaterThan
            // 
            this.rdbGreaterThan.AutoSize = true;
            this.rdbGreaterThan.Location = new System.Drawing.Point(4, 50);
            this.rdbGreaterThan.Name = "rdbGreaterThan";
            this.rdbGreaterThan.Size = new System.Drawing.Size(84, 17);
            this.rdbGreaterThan.TabIndex = 2;
            this.rdbGreaterThan.Text = "Greater than";
            this.rdbGreaterThan.UseVisualStyleBackColor = true;
            // 
            // rdbLessThan
            // 
            this.rdbLessThan.AutoSize = true;
            this.rdbLessThan.Location = new System.Drawing.Point(4, 27);
            this.rdbLessThan.Name = "rdbLessThan";
            this.rdbLessThan.Size = new System.Drawing.Size(75, 17);
            this.rdbLessThan.TabIndex = 1;
            this.rdbLessThan.Text = "Less Than";
            this.rdbLessThan.UseVisualStyleBackColor = true;
            // 
            // rdbEqualTo
            // 
            this.rdbEqualTo.AutoSize = true;
            this.rdbEqualTo.Checked = true;
            this.rdbEqualTo.Location = new System.Drawing.Point(4, 4);
            this.rdbEqualTo.Name = "rdbEqualTo";
            this.rdbEqualTo.Size = new System.Drawing.Size(68, 17);
            this.rdbEqualTo.TabIndex = 0;
            this.rdbEqualTo.TabStop = true;
            this.rdbEqualTo.Text = "Equal To";
            this.rdbEqualTo.UseVisualStyleBackColor = true;
            // 
            // SearchInt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOperator);
            this.Controls.Add(this.txtValue);
            this.Name = "SearchInt";
            this.Size = new System.Drawing.Size(654, 240);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtValue;
        public System.Windows.Forms.RadioButton rdbBetween;
        public System.Windows.Forms.RadioButton rdbGreaterThan;
        public System.Windows.Forms.RadioButton rdbLessThan;
        public System.Windows.Forms.RadioButton rdbEqualTo;
        public System.Windows.Forms.Panel pnlOperator;
    }
}
