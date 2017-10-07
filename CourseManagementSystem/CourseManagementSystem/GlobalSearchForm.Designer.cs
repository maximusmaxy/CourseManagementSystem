namespace CMS
{
    partial class GlobalSearchForm
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
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddSearch = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNewSearch = new System.Windows.Forms.Button();
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
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.dgvTotals = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.cmbColumns2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTables2 = new System.Windows.Forms.ComboBox();
            this.cmbColumns3 = new System.Windows.Forms.ComboBox();
            this.cmbTables3 = new System.Windows.Forms.ComboBox();
            this.cmbColumns4 = new System.Windows.Forms.ComboBox();
            this.cmbTables4 = new System.Windows.Forms.ComboBox();
            this.searchInt = new CMS.SearchInt();
            this.cmbGroupBy2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbGroupBy3 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbGroupBy4 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbCount = new System.Windows.Forms.ComboBox();
            this.cmbCount2 = new System.Windows.Forms.ComboBox();
            this.cmbCount3 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCount4 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotals)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(852, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 508);
            this.panel5.TabIndex = 151;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Controls.Add(this.btnClearForm);
            this.panel2.Location = new System.Drawing.Point(4, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 50);
            this.panel2.TabIndex = 160;
            // 
            // btnClearForm
            // 
            this.btnClearForm.BackColor = System.Drawing.Color.White;
            this.btnClearForm.Image = global::CMS.Properties.Resources.ClearFormButton;
            this.btnClearForm.Location = new System.Drawing.Point(3, 3);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(120, 45);
            this.btnClearForm.TabIndex = 18;
            this.btnClearForm.Tag = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = false;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Crimson;
            this.panel8.Controls.Add(this.btnViewAll);
            this.panel8.Location = new System.Drawing.Point(4, 223);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(125, 50);
            this.panel8.TabIndex = 159;
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.Color.White;
            this.btnViewAll.Image = global::CMS.Properties.Resources.ViewAllButton;
            this.btnViewAll.Location = new System.Drawing.Point(3, 3);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(120, 45);
            this.btnViewAll.TabIndex = 9;
            this.btnViewAll.UseVisualStyleBackColor = false;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.btnAddSearch);
            this.panel1.Location = new System.Drawing.Point(3, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 58);
            this.panel1.TabIndex = 158;
            // 
            // btnAddSearch
            // 
            this.btnAddSearch.BackColor = System.Drawing.Color.White;
            this.btnAddSearch.Image = global::CMS.Properties.Resources.SearchButton;
            this.btnAddSearch.Location = new System.Drawing.Point(3, 3);
            this.btnAddSearch.Name = "btnAddSearch";
            this.btnAddSearch.Size = new System.Drawing.Size(144, 52);
            this.btnAddSearch.TabIndex = 18;
            this.btnAddSearch.UseVisualStyleBackColor = false;
            this.btnAddSearch.Click += new System.EventHandler(this.btnAddSearch_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Crimson;
            this.button5.Image = global::CMS.Properties.Resources.GlobalSearchButton;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 124);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Crimson;
            this.panel6.Controls.Add(this.btnNewSearch);
            this.panel6.Location = new System.Drawing.Point(3, 130);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 58);
            this.panel6.TabIndex = 19;
            // 
            // btnNewSearch
            // 
            this.btnNewSearch.BackColor = System.Drawing.Color.White;
            this.btnNewSearch.Image = global::CMS.Properties.Resources.SearchButton;
            this.btnNewSearch.Location = new System.Drawing.Point(3, 3);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(144, 52);
            this.btnNewSearch.TabIndex = 18;
            this.btnNewSearch.UseVisualStyleBackColor = false;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            // 
            // assessmentToolStripMenuItem
            // 
            this.assessmentToolStripMenuItem.Name = "assessmentToolStripMenuItem";
            this.assessmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.panel7.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(801, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Global Search Form";
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
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 152;
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
            this.allocationToolStripMenuItem});
            this.formsToolStripMenuItem.Name = "formsToolStripMenuItem";
            this.formsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.formsToolStripMenuItem.Text = "Forms";
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.studentToolStripMenuItem.Text = "Student";
            this.studentToolStripMenuItem.Click += new System.EventHandler(this.studentToolStripMenuItem_Click);
            // 
            // teacherCoursesToolStripMenuItem
            // 
            this.teacherCoursesToolStripMenuItem.Name = "teacherCoursesToolStripMenuItem";
            this.teacherCoursesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.teacherCoursesToolStripMenuItem.Text = "Teacher";
            this.teacherCoursesToolStripMenuItem.Click += new System.EventHandler(this.teacherCoursesToolStripMenuItem_Click);
            // 
            // enrolmentToolStripMenuItem
            // 
            this.enrolmentToolStripMenuItem.Name = "enrolmentToolStripMenuItem";
            this.enrolmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.enrolmentToolStripMenuItem.Text = "Enrolment";
            this.enrolmentToolStripMenuItem.Click += new System.EventHandler(this.enrolmentToolStripMenuItem_Click);
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.courseToolStripMenuItem.Text = "Course";
            this.courseToolStripMenuItem.Click += new System.EventHandler(this.courseToolStripMenuItem_Click);
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unitToolStripMenuItem.Text = "Unit";
            this.unitToolStripMenuItem.Click += new System.EventHandler(this.unitToolStripMenuItem_Click);
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.skillsToolStripMenuItem.Text = "Skills";
            this.skillsToolStripMenuItem.Click += new System.EventHandler(this.skillsToolStripMenuItem_Click);
            // 
            // cmbTables
            // 
            this.cmbTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(73, 109);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(236, 28);
            this.cmbTables.TabIndex = 154;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 155;
            this.label2.Text = "Selection:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(203, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 157;
            this.label3.Text = "Filter:";
            // 
            // cmbColumns
            // 
            this.cmbColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(282, 109);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(236, 28);
            this.cmbColumns.TabIndex = 156;
            this.cmbColumns.SelectedIndexChanged += new System.EventHandler(this.cmbColumns_SelectedIndexChanged);
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(200, 352);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(834, 151);
            this.dgvSearch.TabIndex = 158;
            this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellDoubleClick);
            // 
            // dgvTotals
            // 
            this.dgvTotals.AllowUserToAddRows = false;
            this.dgvTotals.AllowUserToDeleteRows = false;
            this.dgvTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotals.Location = new System.Drawing.Point(12, 583);
            this.dgvTotals.Name = "dgvTotals";
            this.dgvTotals.ReadOnly = true;
            this.dgvTotals.Size = new System.Drawing.Size(834, 66);
            this.dgvTotals.TabIndex = 159;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(409, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 23);
            this.label4.TabIndex = 160;
            this.label4.Text = "Group by:";
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Location = new System.Drawing.Point(502, 109);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(368, 28);
            this.cmbGroupBy.TabIndex = 161;
            this.cmbGroupBy.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 165;
            this.label5.Text = "Column:";
            // 
            // cmbColumns2
            // 
            this.cmbColumns2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColumns2.FormattingEnabled = true;
            this.cmbColumns2.Location = new System.Drawing.Point(282, 138);
            this.cmbColumns2.Name = "cmbColumns2";
            this.cmbColumns2.Size = new System.Drawing.Size(236, 28);
            this.cmbColumns2.TabIndex = 164;
            this.cmbColumns2.SelectedIndexChanged += new System.EventHandler(this.cmbColumns2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
            this.label6.TabIndex = 163;
            // 
            // cmbTables2
            // 
            this.cmbTables2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables2.FormattingEnabled = true;
            this.cmbTables2.Location = new System.Drawing.Point(73, 138);
            this.cmbTables2.Name = "cmbTables2";
            this.cmbTables2.Size = new System.Drawing.Size(236, 28);
            this.cmbTables2.TabIndex = 162;
            this.cmbTables2.SelectedIndexChanged += new System.EventHandler(this.cmbTables2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(203, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 169;
            this.label7.Text = "Column:";
            // 
            // cmbColumns3
            // 
            this.cmbColumns3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColumns3.FormattingEnabled = true;
            this.cmbColumns3.Location = new System.Drawing.Point(282, 167);
            this.cmbColumns3.Name = "cmbColumns3";
            this.cmbColumns3.Size = new System.Drawing.Size(236, 28);
            this.cmbColumns3.TabIndex = 168;
            this.cmbColumns3.SelectedIndexChanged += new System.EventHandler(this.cmbColumns3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 21);
            this.label8.TabIndex = 167;
            this.label8.Text = "Table:";
            // 
            // cmbTables3
            // 
            this.cmbTables3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables3.FormattingEnabled = true;
            this.cmbTables3.Location = new System.Drawing.Point(73, 167);
            this.cmbTables3.Name = "cmbTables3";
            this.cmbTables3.Size = new System.Drawing.Size(236, 28);
            this.cmbTables3.TabIndex = 166;
            this.cmbTables3.SelectedIndexChanged += new System.EventHandler(this.cmbTables3_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(203, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 21);
            this.label9.TabIndex = 173;
            this.label9.Text = "Column:";
            // 
            // cmbColumns4
            // 
            this.cmbColumns4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColumns4.FormattingEnabled = true;
            this.cmbColumns4.Location = new System.Drawing.Point(282, 194);
            this.cmbColumns4.Name = "cmbColumns4";
            this.cmbColumns4.Size = new System.Drawing.Size(236, 28);
            this.cmbColumns4.TabIndex = 172;
            this.cmbColumns4.SelectedIndexChanged += new System.EventHandler(this.cmbColumns4_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 21);
            this.label10.TabIndex = 171;
            this.label10.Text = "Table:";
            // 
            // cmbTables4
            // 
            this.cmbTables4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables4.FormattingEnabled = true;
            this.cmbTables4.Location = new System.Drawing.Point(73, 194);
            this.cmbTables4.Name = "cmbTables4";
            this.cmbTables4.Size = new System.Drawing.Size(236, 28);
            this.cmbTables4.TabIndex = 170;
            this.cmbTables4.SelectedIndexChanged += new System.EventHandler(this.cmbTables4_SelectedIndexChanged);
            // 
            // searchInt
            // 
            this.searchInt.Location = new System.Drawing.Point(157, 232);
            this.searchInt.Name = "searchInt";
            this.searchInt.Size = new System.Drawing.Size(558, 188);
            this.searchInt.TabIndex = 153;
            // 
            // cmbGroupBy2
            // 
            this.cmbGroupBy2.FormattingEnabled = true;
            this.cmbGroupBy2.Location = new System.Drawing.Point(502, 140);
            this.cmbGroupBy2.Name = "cmbGroupBy2";
            this.cmbGroupBy2.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupBy2.TabIndex = 175;
            this.cmbGroupBy2.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy2_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(409, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 21);
            this.label11.TabIndex = 174;
            this.label11.Text = "Group by:";
            // 
            // cmbGroupBy3
            // 
            this.cmbGroupBy3.FormattingEnabled = true;
            this.cmbGroupBy3.Location = new System.Drawing.Point(502, 167);
            this.cmbGroupBy3.Name = "cmbGroupBy3";
            this.cmbGroupBy3.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupBy3.TabIndex = 177;
            this.cmbGroupBy3.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy3_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(409, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 21);
            this.label12.TabIndex = 176;
            this.label12.Text = "Group by:";
            // 
            // cmbGroupBy4
            // 
            this.cmbGroupBy4.FormattingEnabled = true;
            this.cmbGroupBy4.Location = new System.Drawing.Point(502, 194);
            this.cmbGroupBy4.Name = "cmbGroupBy4";
            this.cmbGroupBy4.Size = new System.Drawing.Size(121, 21);
            this.cmbGroupBy4.TabIndex = 179;
            this.cmbGroupBy4.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy4_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(409, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 21);
            this.label13.TabIndex = 178;
            this.label13.Text = "Group by:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(629, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 21);
            this.label14.TabIndex = 181;
            this.label14.Text = "Count:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(629, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 21);
            this.label15.TabIndex = 182;
            this.label15.Text = "Count:";
            // 
            // cmbCount
            // 
            this.cmbCount.FormattingEnabled = true;
            this.cmbCount.Location = new System.Drawing.Point(695, 109);
            this.cmbCount.Name = "cmbCount";
            this.cmbCount.Size = new System.Drawing.Size(121, 21);
            this.cmbCount.TabIndex = 183;
            this.cmbCount.SelectedIndexChanged += new System.EventHandler(this.cmbCount_SelectedIndexChanged);
            // 
            // cmbCount2
            // 
            this.cmbCount2.FormattingEnabled = true;
            this.cmbCount2.Location = new System.Drawing.Point(695, 140);
            this.cmbCount2.Name = "cmbCount2";
            this.cmbCount2.Size = new System.Drawing.Size(121, 21);
            this.cmbCount2.TabIndex = 184;
            this.cmbCount2.SelectedIndexChanged += new System.EventHandler(this.cmbCount2_SelectedIndexChanged);
            // 
            // cmbCount3
            // 
            this.cmbCount3.FormattingEnabled = true;
            this.cmbCount3.Location = new System.Drawing.Point(695, 167);
            this.cmbCount3.Name = "cmbCount3";
            this.cmbCount3.Size = new System.Drawing.Size(121, 21);
            this.cmbCount3.TabIndex = 186;
            this.cmbCount3.SelectedIndexChanged += new System.EventHandler(this.cmbCount3_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(629, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 21);
            this.label16.TabIndex = 185;
            this.label16.Text = "Count:";
            // 
            // cmbCount4
            // 
            this.cmbCount4.FormattingEnabled = true;
            this.cmbCount4.Location = new System.Drawing.Point(695, 194);
            this.cmbCount4.Name = "cmbCount4";
            this.cmbCount4.Size = new System.Drawing.Size(121, 21);
            this.cmbCount4.TabIndex = 188;
            this.cmbCount4.SelectedIndexChanged += new System.EventHandler(this.cmbCount4_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(629, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 21);
            this.label17.TabIndex = 187;
            this.label17.Text = "Count:";
            // 
            // GlobalSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.cmbCount4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbCount3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbCount2);
            this.Controls.Add(this.cmbCount);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbGroupBy4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbGroupBy3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbGroupBy2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbColumns4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbTables4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbColumns3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTables3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbColumns2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTables2);
            this.Controls.Add(this.cmbGroupBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvTotals);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "GlobalSearchForm";
            this.Text = "GlobalSearchForm";
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotals)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.Button btnNewSearch;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel6;
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
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSearch;
        private System.Windows.Forms.DataGridView dgvSearch;
        private SearchInt searchInt;
        private System.Windows.Forms.DataGridView dgvTotals;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.ComboBox cmbColumns2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTables2;
        private System.Windows.Forms.ComboBox cmbColumns3;
        private System.Windows.Forms.ComboBox cmbTables3;
        private System.Windows.Forms.ComboBox cmbColumns4;
        private System.Windows.Forms.ComboBox cmbTables4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.ComboBox cmbGroupBy2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbGroupBy3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbGroupBy4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.ComboBox cmbCount2;
        private System.Windows.Forms.ComboBox cmbCount3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCount4;
        private System.Windows.Forms.Label label17;
    }
}