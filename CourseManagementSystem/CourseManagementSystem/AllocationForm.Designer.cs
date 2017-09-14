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
            this.btnDelete = new System.Windows.Forms.Button();
            this.assessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrolmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button5 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.cmbAreaOfStudy = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstOption2 = new System.Windows.Forms.ListBox();
            this.cmbSel1 = new System.Windows.Forms.ComboBox();
            this.cmbSel2 = new System.Windows.Forms.ComboBox();
            this.dgvAllocations = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lstOption1 = new System.Windows.Forms.ListBox();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::CMS.Properties.Resources.DeleteButton;
            this.btnDelete.Location = new System.Drawing.Point(3, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 44);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.UseVisualStyleBackColor = false;
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
            this.panel7.Size = new System.Drawing.Size(685, 60);
            this.panel7.TabIndex = 140;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Allocation Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 142;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.viewAllToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addToolStripMenuItem.Text = "&Add";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.updateToolStripMenuItem.Text = "&Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.viewAllToolStripMenuItem.Text = "&View All";
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
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Gainsboro;
            this.button5.Image = global::CMS.Properties.Resources.AllocationButton;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 100);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gainsboro;
            this.panel8.Controls.Add(this.btnViewAll);
            this.panel8.Location = new System.Drawing.Point(4, 413);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(125, 50);
            this.panel8.TabIndex = 22;
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.Color.White;
            this.btnViewAll.Image = global::CMS.Properties.Resources.ViewAllButton;
            this.btnViewAll.Location = new System.Drawing.Point(3, 3);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(120, 45);
            this.btnViewAll.TabIndex = 21;
            this.btnViewAll.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 21);
            this.label5.TabIndex = 147;
            this.label5.Text = "Area Of Study:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Location = new System.Drawing.Point(3, 350);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 50);
            this.panel4.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(3, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 50);
            this.panel3.TabIndex = 21;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Image = global::CMS.Properties.Resources.UpdateButton;
            this.btnUpdate.Location = new System.Drawing.Point(3, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 45);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbAreaOfStudy
            // 
            this.cmbAreaOfStudy.FormattingEnabled = true;
            this.cmbAreaOfStudy.Location = new System.Drawing.Point(234, 124);
            this.cmbAreaOfStudy.Name = "cmbAreaOfStudy";
            this.cmbAreaOfStudy.Size = new System.Drawing.Size(334, 21);
            this.cmbAreaOfStudy.TabIndex = 148;
            this.cmbAreaOfStudy.Tag = "Area of Study";
            this.ToolTips.SetToolTip(this.cmbAreaOfStudy, "Select from the list the Appropriate Area of Study for this Course");
            this.cmbAreaOfStudy.SelectedIndexChanged += new System.EventHandler(this.cmbAreaOfStudy_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Location = new System.Drawing.Point(4, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 50);
            this.panel2.TabIndex = 21;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::CMS.Properties.Resources.AddButton;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 45);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Location = new System.Drawing.Point(3, 214);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(125, 50);
            this.panel6.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::CMS.Properties.Resources.SearchButton;
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 45);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(678, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(132, 524);
            this.panel5.TabIndex = 141;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(31, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 21);
            this.label12.TabIndex = 144;
            this.label12.Text = "Selection 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(355, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 144;
            this.label2.Text = "Selection 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(355, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 144;
            this.label4.Text = "Option 2:";
            // 
            // lstOption2
            // 
            this.lstOption2.FormattingEnabled = true;
            this.lstOption2.Location = new System.Drawing.Point(359, 291);
            this.lstOption2.Name = "lstOption2";
            this.lstOption2.ScrollAlwaysVisible = true;
            this.lstOption2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstOption2.Size = new System.Drawing.Size(287, 56);
            this.lstOption2.TabIndex = 149;
            this.lstOption2.Tag = "Option 2";
            // 
            // cmbSel1
            // 
            this.cmbSel1.FormattingEnabled = true;
            this.cmbSel1.Location = new System.Drawing.Point(35, 216);
            this.cmbSel1.Name = "cmbSel1";
            this.cmbSel1.Size = new System.Drawing.Size(287, 21);
            this.cmbSel1.TabIndex = 150;
            this.cmbSel1.Tag = "Selection 1";
            this.cmbSel1.SelectedIndexChanged += new System.EventHandler(this.cmbSel1_SelectedIndexChanged);
            // 
            // cmbSel2
            // 
            this.cmbSel2.FormattingEnabled = true;
            this.cmbSel2.Location = new System.Drawing.Point(359, 216);
            this.cmbSel2.Name = "cmbSel2";
            this.cmbSel2.Size = new System.Drawing.Size(287, 21);
            this.cmbSel2.TabIndex = 150;
            this.cmbSel2.Tag = "Selection 2";
            this.cmbSel2.SelectedIndexChanged += new System.EventHandler(this.cmbSel2_SelectedIndexChanged);
            // 
            // dgvAllocations
            // 
            this.dgvAllocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllocations.Location = new System.Drawing.Point(35, 380);
            this.dgvAllocations.Name = "dgvAllocations";
            this.dgvAllocations.Size = new System.Drawing.Size(617, 161);
            this.dgvAllocations.TabIndex = 151;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 21);
            this.label6.TabIndex = 144;
            this.label6.Text = "Option 1:";
            // 
            // lstOption1
            // 
            this.lstOption1.FormattingEnabled = true;
            this.lstOption1.Location = new System.Drawing.Point(35, 291);
            this.lstOption1.Name = "lstOption1";
            this.lstOption1.ScrollAlwaysVisible = true;
            this.lstOption1.Size = new System.Drawing.Size(287, 56);
            this.lstOption1.TabIndex = 149;
            this.lstOption1.Tag = "Option 1";
            this.lstOption1.SelectedIndexChanged += new System.EventHandler(this.lstOption1_SelectedIndexChanged);
            // 
            // AllocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(813, 553);
            this.Controls.Add(this.dgvAllocations);
            this.Controls.Add(this.cmbSel2);
            this.Controls.Add(this.cmbSel1);
            this.Controls.Add(this.lstOption1);
            this.Controls.Add(this.lstOption2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAreaOfStudy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Name = "AllocationForm";
            this.Text = "AllocationForm";
            this.panel7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem assessmentToolStripMenuItem;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.ComboBox cmbAreaOfStudy;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstOption2;
        private System.Windows.Forms.ComboBox cmbSel1;
        private System.Windows.Forms.ComboBox cmbSel2;
        private System.Windows.Forms.DataGridView dgvAllocations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstOption1;
    }
}