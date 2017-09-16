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
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.pnlOperator = new System.Windows.Forms.Panel();
            this.rdbOrMore = new System.Windows.Forms.RadioButton();
            this.rdbOrLess = new System.Windows.Forms.RadioButton();
            this.rdbBetween = new System.Windows.Forms.RadioButton();
            this.rdbGreaterThan = new System.Windows.Forms.RadioButton();
            this.rdbLessThan = new System.Windows.Forms.RadioButton();
            this.rdbEqualTo = new System.Windows.Forms.RadioButton();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.pnlOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 175;
            this.label2.Text = "Cost:";
            // 
            // txtValue2
            // 
            this.txtValue2.Enabled = false;
            this.txtValue2.Location = new System.Drawing.Point(258, 29);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(100, 20);
            this.txtValue2.TabIndex = 174;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 21);
            this.label1.TabIndex = 173;
            this.label1.Text = "and";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(109, 7);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(50, 21);
            this.lblValue.TabIndex = 172;
            this.lblValue.Text = "Cost:";
            // 
            // pnlOperator
            // 
            this.pnlOperator.Controls.Add(this.rdbOrMore);
            this.pnlOperator.Controls.Add(this.rdbOrLess);
            this.pnlOperator.Controls.Add(this.rdbBetween);
            this.pnlOperator.Controls.Add(this.rdbGreaterThan);
            this.pnlOperator.Controls.Add(this.rdbLessThan);
            this.pnlOperator.Controls.Add(this.rdbEqualTo);
            this.pnlOperator.Location = new System.Drawing.Point(3, 3);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(100, 140);
            this.pnlOperator.TabIndex = 171;
            // 
            // rdbOrMore
            // 
            this.rdbOrMore.AutoSize = true;
            this.rdbOrMore.Location = new System.Drawing.Point(4, 96);
            this.rdbOrMore.Name = "rdbOrMore";
            this.rdbOrMore.Size = new System.Drawing.Size(63, 17);
            this.rdbOrMore.TabIndex = 5;
            this.rdbOrMore.Text = "Or More";
            this.rdbOrMore.UseVisualStyleBackColor = true;
            // 
            // rdbOrLess
            // 
            this.rdbOrLess.AutoSize = true;
            this.rdbOrLess.Location = new System.Drawing.Point(4, 73);
            this.rdbOrLess.Name = "rdbOrLess";
            this.rdbOrLess.Size = new System.Drawing.Size(61, 17);
            this.rdbOrLess.TabIndex = 4;
            this.rdbOrLess.Text = "Or Less";
            this.rdbOrLess.UseVisualStyleBackColor = true;
            // 
            // rdbBetween
            // 
            this.rdbBetween.AutoSize = true;
            this.rdbBetween.Location = new System.Drawing.Point(4, 119);
            this.rdbBetween.Name = "rdbBetween";
            this.rdbBetween.Size = new System.Drawing.Size(67, 17);
            this.rdbBetween.TabIndex = 3;
            this.rdbBetween.Text = "Between";
            this.rdbBetween.UseVisualStyleBackColor = true;
            this.rdbBetween.CheckedChanged += new System.EventHandler(this.rdbBetween_CheckedChanged);
            // 
            // rdbGreaterThan
            // 
            this.rdbGreaterThan.AutoSize = true;
            this.rdbGreaterThan.Location = new System.Drawing.Point(4, 50);
            this.rdbGreaterThan.Name = "rdbGreaterThan";
            this.rdbGreaterThan.Size = new System.Drawing.Size(88, 17);
            this.rdbGreaterThan.TabIndex = 2;
            this.rdbGreaterThan.Text = "Greater Than";
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
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(109, 29);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 170;
            // 
            // SearchCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.pnlOperator);
            this.Controls.Add(this.txtValue);
            this.Name = "SearchCost";
            this.Size = new System.Drawing.Size(654, 240);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValue;
        public System.Windows.Forms.Panel pnlOperator;
        public System.Windows.Forms.RadioButton rdbOrMore;
        public System.Windows.Forms.RadioButton rdbOrLess;
        public System.Windows.Forms.RadioButton rdbBetween;
        public System.Windows.Forms.RadioButton rdbGreaterThan;
        public System.Windows.Forms.RadioButton rdbLessThan;
        public System.Windows.Forms.RadioButton rdbEqualTo;
        public System.Windows.Forms.TextBox txtValue;
    }
}
