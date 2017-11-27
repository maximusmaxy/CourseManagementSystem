namespace CMS
{
    partial class AllocationForm
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
            this.components = new System.ComponentModel.Container();
            this.assessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrolmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button5 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.cmbAreaOfStudy = new System.Windows.Forms.ComboBox();
            this.lstOption2 = new System.Windows.Forms.ListBox();
            this.cmbSel1 = new System.Windows.Forms.ComboBox();
            this.cmbSel2 = new System.Windows.Forms.ComboBox();
            this.lstOption1 = new System.Windows.Forms.ListBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllocations = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocations)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // assessmentToolStripMenuItem
            // 
            this.assessmentToolStripMenuItem.Name = "assessmentToolStripMenuItem";
            this.assessmentToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.assessmentToolStripMenuItem.Text = "Assessment";
            this.assessmentToolStripMenuItem.Click += new System.EventHandler(this.assessmentToolStripMenuItem_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(0, 27);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(825, 60);
            this.panel7.TabIndex = 140;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allocations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(988, 24);
            this.menuStrip1.TabIndex = 142;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.viewAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.updateToolStripMenuItem.Text = "&Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.viewAllToolStripMenuItem.Text = "&View All";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.viewAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.logOutToolStripMenuItem.Text = "&Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // formsToolStripMenuItem
            // 
            this.formsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.teacherCoursesToolStripMenuItem,
            this.enrolmentToolStripMenuItem,
            this.courseToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.assessmentToolStripMenuItem,
            this.skillsToolStripMenuItem,
            this.globalSearchToolStripMenuItem});
            this.formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            this.formsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.formsToolStripMenuItem.Text = "Forms";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.studentToolStripMenuItem.Text = "Student";
            this.studentToolStripMenuItem.Click += new System.EventHandler(this.studentToolStripMenuItem_Click);
            // 
            // teacherCoursesToolStripMenuItem
            // 
            this.teacherCoursesToolStripMenuItem.Name = "teacherCoursesToolStripMenuItem";
            this.teacherCoursesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.teacherCoursesToolStripMenuItem.Text = "Teacher";
            this.teacherCoursesToolStripMenuItem.Click += new System.EventHandler(this.teacherCoursesToolStripMenuItem_Click);
            // 
            // enrolmentToolStripMenuItem
            // 
            this.enrolmentToolStripMenuItem.Name = "enrolmentToolStripMenuItem";
            this.enrolmentToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.enrolmentToolStripMenuItem.Text = "Enrolment";
            this.enrolmentToolStripMenuItem.Click += new System.EventHandler(this.enrolmentToolStripMenuItem_Click);
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.courseToolStripMenuItem.Text = "Course";
            this.courseToolStripMenuItem.Click += new System.EventHandler(this.courseToolStripMenuItem_Click);
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.unitToolStripMenuItem.Text = "Unit";
            this.unitToolStripMenuItem.Click += new System.EventHandler(this.unitToolStripMenuItem_Click);
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.skillsToolStripMenuItem.Text = "Skills";
            this.skillsToolStripMenuItem.Click += new System.EventHandler(this.skillsToolStripMenuItem_Click);
            // 
            // globalSearchToolStripMenuItem
            // 
            this.globalSearchToolStripMenuItem.Name = "globalSearchToolStripMenuItem";
            this.globalSearchToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.globalSearchToolStripMenuItem.Text = "Global Search";
            this.globalSearchToolStripMenuItem.Click += new System.EventHandler(this.globalSearchToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gainsboro;
            this.button5.Image = global::CMS.Properties.Resources.AllocationButton;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 124);
            this.button5.TabIndex = 0;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Controls.Add(this.btnViewAll);
            this.panel8.Location = new System.Drawing.Point(3, 193);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(150, 58);
            this.panel8.TabIndex = 1;
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.Color.White;
            this.btnViewAll.Image = global::CMS.Properties.Resources.ViewAllButton;
            this.btnViewAll.Location = new System.Drawing.Point(3, 3);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(144, 52);
            this.btnViewAll.TabIndex = 0;
            this.btnViewAll.UseVisualStyleBackColor = false;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 21);
            this.label5.TabIndex = 147;
            this.label5.Text = "Area Of Study:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(3, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 58);
            this.panel3.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Image = global::CMS.Properties.Resources.UpdateButton;
            this.btnUpdate.Location = new System.Drawing.Point(3, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(144, 52);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbAreaOfStudy
            // 
            this.cmbAreaOfStudy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAreaOfStudy.FormattingEnabled = true;
            this.cmbAreaOfStudy.Location = new System.Drawing.Point(250, 10);
            this.cmbAreaOfStudy.Name = "cmbAreaOfStudy";
            this.cmbAreaOfStudy.Size = new System.Drawing.Size(236, 28);
            this.cmbAreaOfStudy.TabIndex = 0;
            this.cmbAreaOfStudy.Tag = "Area of Study";
            this.ToolTips.SetToolTip(this.cmbAreaOfStudy, "Select from the list the Appropriate Area of Study");
            this.cmbAreaOfStudy.SelectedIndexChanged += new System.EventHandler(this.cmbAreaOfStudy_SelectedIndexChanged);
            // 
            // lstOption2
            // 
            this.lstOption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOption2.FormattingEnabled = true;
            this.lstOption2.ItemHeight = 20;
            this.lstOption2.Location = new System.Drawing.Point(513, 118);
            this.lstOption2.Name = "lstOption2";
            this.lstOption2.ScrollAlwaysVisible = true;
            this.lstOption2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOption2.Size = new System.Drawing.Size(236, 64);
            this.lstOption2.TabIndex = 4;
            this.lstOption2.Tag = "Option 2";
            this.ToolTips.SetToolTip(this.lstOption2, "Please select an option. You may select multiple options as required.");
            // 
            // cmbSel1
            // 
            this.cmbSel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSel1.FormattingEnabled = true;
            this.cmbSel1.Location = new System.Drawing.Point(250, 46);
            this.cmbSel1.Name = "cmbSel1";
            this.cmbSel1.Size = new System.Drawing.Size(236, 28);
            this.cmbSel1.TabIndex = 1;
            this.cmbSel1.Tag = "Selection 1";
            this.ToolTips.SetToolTip(this.cmbSel1, "Please select an option.");
            this.cmbSel1.SelectedIndexChanged += new System.EventHandler(this.cmbSel1_SelectedIndexChanged);
            // 
            // cmbSel2
            // 
            this.cmbSel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSel2.FormattingEnabled = true;
            this.cmbSel2.Location = new System.Drawing.Point(250, 118);
            this.cmbSel2.Name = "cmbSel2";
            this.cmbSel2.Size = new System.Drawing.Size(236, 28);
            this.cmbSel2.TabIndex = 2;
            this.cmbSel2.Tag = "Selection 2";
            this.ToolTips.SetToolTip(this.cmbSel2, "Please select an option.");
            this.cmbSel2.SelectedIndexChanged += new System.EventHandler(this.cmbSel2_SelectedIndexChanged);
            // 
            // lstOption1
            // 
            this.lstOption1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOption1.FormattingEnabled = true;
            this.lstOption1.ItemHeight = 20;
            this.lstOption1.Location = new System.Drawing.Point(513, 46);
            this.lstOption1.Name = "lstOption1";
            this.lstOption1.ScrollAlwaysVisible = true;
            this.lstOption1.Size = new System.Drawing.Size(236, 64);
            this.lstOption1.TabIndex = 3;
            this.lstOption1.Tag = "Option 1";
            this.ToolTips.SetToolTip(this.lstOption1, "Please select an option.");
            this.lstOption1.SelectedIndexChanged += new System.EventHandler(this.lstOption1_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(828, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 508);
            this.panel5.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Allocation";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(148, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 21);
            this.label12.TabIndex = 144;
            this.label12.Text = "Selection 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 144;
            this.label2.Text = "Selection 2:";
            // 
            // dgvAllocations
            // 
            this.dgvAllocations.AllowUserToAddRows = false;
            this.dgvAllocations.AllowUserToDeleteRows = false;
            this.dgvAllocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllocations.Location = new System.Drawing.Point(250, 190);
            this.dgvAllocations.Name = "dgvAllocations";
            this.dgvAllocations.ReadOnly = true;
            this.dgvAllocations.Size = new System.Drawing.Size(499, 236);
            this.dgvAllocations.TabIndex = 151;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lstOption1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbSel2);
            this.panel1.Controls.Add(this.lstOption2);
            this.panel1.Controls.Add(this.dgvAllocations);
            this.panel1.Controls.Add(this.cmbSel1);
            this.panel1.Controls.Add(this.cmbAreaOfStudy);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(1, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 442);
            this.panel1.TabIndex = 152;
            // 
            // AllocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(988, 539);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AllocationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AllocationForm";
            this.panel7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocations)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem assessmentToolStripMenuItem;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teacherCoursesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enrolmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalSearchToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.ComboBox cmbAreaOfStudy;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstOption2;
        private System.Windows.Forms.ComboBox cmbSel1;
        private System.Windows.Forms.ComboBox cmbSel2;
        private System.Windows.Forms.DataGridView dgvAllocations;
        private System.Windows.Forms.ListBox lstOption1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}