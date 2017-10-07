namespace CMS
{
    partial class SearchDate
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
            this.rdbBetween = new System.Windows.Forms.RadioButton();
            this.rdbAfterOrEqual = new System.Windows.Forms.RadioButton();
            this.rdbBeforeOrEqual = new System.Windows.Forms.RadioButton();
            this.rdbAfter = new System.Windows.Forms.RadioButton();
            this.rdbBefore = new System.Windows.Forms.RadioButton();
            this.rdbExact = new System.Windows.Forms.RadioButton();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDay2 = new System.Windows.Forms.TextBox();
            this.txtYear2 = new System.Windows.Forms.TextBox();
            this.cmbMonth2 = new System.Windows.Forms.ComboBox();
            this.cmbColumn = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlOperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOperator
            // 
            this.pnlOperator.Controls.Add(this.rdbBetween);
            this.pnlOperator.Controls.Add(this.rdbAfterOrEqual);
            this.pnlOperator.Controls.Add(this.rdbBeforeOrEqual);
            this.pnlOperator.Controls.Add(this.rdbAfter);
            this.pnlOperator.Controls.Add(this.rdbBefore);
            this.pnlOperator.Controls.Add(this.rdbExact);
            this.pnlOperator.Location = new System.Drawing.Point(3, 3);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(100, 146);
            this.pnlOperator.TabIndex = 161;
            // 
            // rdbBetween
            // 
            this.rdbBetween.AutoSize = true;
            this.rdbBetween.Location = new System.Drawing.Point(4, 119);
            this.rdbBetween.Name = "rdbBetween";
            this.rdbBetween.Size = new System.Drawing.Size(67, 17);
            this.rdbBetween.TabIndex = 6;
            this.rdbBetween.Text = "Between";
            this.rdbBetween.UseVisualStyleBackColor = true;
            this.rdbBetween.CheckedChanged += new System.EventHandler(this.rdbBetween_CheckedChanged);
            // 
            // rdbAfterOrEqual
            // 
            this.rdbAfterOrEqual.AutoSize = true;
            this.rdbAfterOrEqual.Location = new System.Drawing.Point(4, 96);
            this.rdbAfterOrEqual.Name = "rdbAfterOrEqual";
            this.rdbAfterOrEqual.Size = new System.Drawing.Size(76, 17);
            this.rdbAfterOrEqual.TabIndex = 5;
            this.rdbAfterOrEqual.Text = "On or After";
            this.rdbAfterOrEqual.UseVisualStyleBackColor = true;
            // 
            // rdbBeforeOrEqual
            // 
            this.rdbBeforeOrEqual.AutoSize = true;
            this.rdbBeforeOrEqual.Location = new System.Drawing.Point(4, 73);
            this.rdbBeforeOrEqual.Name = "rdbBeforeOrEqual";
            this.rdbBeforeOrEqual.Size = new System.Drawing.Size(85, 17);
            this.rdbBeforeOrEqual.TabIndex = 4;
            this.rdbBeforeOrEqual.Text = "On or Before";
            this.rdbBeforeOrEqual.UseVisualStyleBackColor = true;
            // 
            // rdbAfter
            // 
            this.rdbAfter.AutoSize = true;
            this.rdbAfter.Location = new System.Drawing.Point(4, 50);
            this.rdbAfter.Name = "rdbAfter";
            this.rdbAfter.Size = new System.Drawing.Size(47, 17);
            this.rdbAfter.TabIndex = 2;
            this.rdbAfter.Text = "After";
            this.rdbAfter.UseVisualStyleBackColor = true;
            // 
            // rdbBefore
            // 
            this.rdbBefore.AutoSize = true;
            this.rdbBefore.Location = new System.Drawing.Point(4, 27);
            this.rdbBefore.Name = "rdbBefore";
            this.rdbBefore.Size = new System.Drawing.Size(56, 17);
            this.rdbBefore.TabIndex = 1;
            this.rdbBefore.Text = "Before";
            this.rdbBefore.UseVisualStyleBackColor = true;
            // 
            // rdbExact
            // 
            this.rdbExact.AutoSize = true;
            this.rdbExact.Checked = true;
            this.rdbExact.Location = new System.Drawing.Point(4, 4);
            this.rdbExact.Name = "rdbExact";
            this.rdbExact.Size = new System.Drawing.Size(78, 17);
            this.rdbExact.TabIndex = 0;
            this.rdbExact.TabStop = true;
            this.rdbExact.Text = "Exact Date";
            this.rdbExact.UseVisualStyleBackColor = true;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(176, 33);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 162;
            this.cmbMonth.Tag = "Month";
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(176, 7);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(121, 20);
            this.txtYear.TabIndex = 163;
            this.txtYear.Tag = "Year";
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(176, 60);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(121, 20);
            this.txtDay.TabIndex = 164;
            this.txtDay.Tag = "Day";
            this.txtDay.TextChanged += new System.EventHandler(this.txtDay_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 165;
            this.label3.Text = "Year:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 166;
            this.label1.Text = "Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 21);
            this.label2.TabIndex = 167;
            this.label2.Text = "Day:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(303, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 21);
            this.label4.TabIndex = 168;
            this.label4.Text = "and";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(361, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 21);
            this.label5.TabIndex = 174;
            this.label5.Text = "Day:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(342, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 173;
            this.label6.Text = "Month:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(358, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 172;
            this.label7.Text = "Year:";
            // 
            // txtDay2
            // 
            this.txtDay2.Enabled = false;
            this.txtDay2.Location = new System.Drawing.Point(411, 60);
            this.txtDay2.Name = "txtDay2";
            this.txtDay2.Size = new System.Drawing.Size(121, 20);
            this.txtDay2.TabIndex = 171;
            this.txtDay2.Tag = "Day";
            // 
            // txtYear2
            // 
            this.txtYear2.Enabled = false;
            this.txtYear2.Location = new System.Drawing.Point(411, 7);
            this.txtYear2.Name = "txtYear2";
            this.txtYear2.Size = new System.Drawing.Size(121, 20);
            this.txtYear2.TabIndex = 170;
            this.txtYear2.Tag = "Year";
            // 
            // cmbMonth2
            // 
            this.cmbMonth2.Enabled = false;
            this.cmbMonth2.FormattingEnabled = true;
            this.cmbMonth2.Location = new System.Drawing.Point(411, 33);
            this.cmbMonth2.Name = "cmbMonth2";
            this.cmbMonth2.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth2.TabIndex = 169;
            this.cmbMonth2.Tag = "Month";
            // 
            // cmbColumn
            // 
            this.cmbColumn.FormattingEnabled = true;
            this.cmbColumn.Location = new System.Drawing.Point(188, 109);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.Size = new System.Drawing.Size(121, 21);
            this.cmbColumn.TabIndex = 175;
            this.cmbColumn.SelectedIndexChanged += new System.EventHandler(this.cmbColumn_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(109, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 21);
            this.label8.TabIndex = 176;
            this.label8.Text = "Column:";
            // 
            // SearchDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbColumn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDay2);
            this.Controls.Add(this.txtYear2);
            this.Controls.Add(this.cmbMonth2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.pnlOperator);
            this.Name = "SearchDate";
            this.Size = new System.Drawing.Size(594, 224);
            this.pnlOperator.ResumeLayout(false);
            this.pnlOperator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel pnlOperator;
        public System.Windows.Forms.RadioButton rdbAfter;
        public System.Windows.Forms.RadioButton rdbBefore;
        public System.Windows.Forms.RadioButton rdbExact;
        public System.Windows.Forms.ComboBox cmbMonth;
        public System.Windows.Forms.TextBox txtYear;
        public System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtDay2;
        public System.Windows.Forms.TextBox txtYear2;
        public System.Windows.Forms.ComboBox cmbMonth2;
        public System.Windows.Forms.RadioButton rdbBetween;
        public System.Windows.Forms.RadioButton rdbAfterOrEqual;
        public System.Windows.Forms.RadioButton rdbBeforeOrEqual;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cmbColumn;
    }
}
