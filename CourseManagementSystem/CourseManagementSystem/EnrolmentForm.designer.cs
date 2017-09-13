namespace CMS
{
    partial class EnrolmentForm
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
            this.dtpEnrolment = new System.Windows.Forms.DateTimePicker();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtEnrolmentId = new System.Windows.Forms.TextBox();
            this.dtpCompletion = new System.Windows.Forms.DateTimePicker();
            this.txtDiscountCost = new System.Windows.Forms.TextBox();
            this.txtEnrolmentCost = new System.Windows.Forms.TextBox();
            this.pnlSemester = new System.Windows.Forms.Panel();
            this.rdbSemesterOne = new System.Windows.Forms.RadioButton();
            this.rdbSemesterTwo = new System.Windows.Forms.RadioButton();
            this.pnlCourseResults = new System.Windows.Forms.Panel();
            this.rdbNotComplete = new System.Windows.Forms.RadioButton();
            this.rdbPass = new System.Windows.Forms.RadioButton();
            this.rdbFail = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.globalSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assessmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
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
            this.allocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlSemester.SuspendLayout();
            this.pnlCourseResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEnrolment
            // 
            this.dtpEnrolment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnrolment.Location = new System.Drawing.Point(207, 242);
            this.dtpEnrolment.Name = "dtpEnrolment";
            this.dtpEnrolment.Size = new System.Drawing.Size(295, 20);
            this.dtpEnrolment.TabIndex = 50;
            this.dtpEnrolment.Tag = "EnrolmentDate";
            this.ToolTips.SetToolTip(this.dtpEnrolment, "Insert the Current Date this Enrolment was completed on");
            // 
            // txtCourseId
            // 
            this.txtCourseId.Location = new System.Drawing.Point(209, 178);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.Size = new System.Drawing.Size(293, 20);
            this.txtCourseId.TabIndex = 49;
            this.txtCourseId.Tag = "CourseId";
            this.ToolTips.SetToolTip(this.txtCourseId, "Insert the Course ID here using Numeric Characters Only!");
            this.txtCourseId.Leave += new System.EventHandler(this.CourseId_LostFocus);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(209, 143);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(293, 20);
            this.txtId.TabIndex = 48;
            this.txtId.Tag = "StudentId";
            this.ToolTips.SetToolTip(this.txtId, "Insert the Student ID here using Numeric Characters Only!");
            // 
            // txtEnrolmentId
            // 
            this.txtEnrolmentId.Enabled = false;
            this.txtEnrolmentId.Location = new System.Drawing.Point(209, 110);
            this.txtEnrolmentId.Name = "txtEnrolmentId";
            this.txtEnrolmentId.Size = new System.Drawing.Size(293, 20);
            this.txtEnrolmentId.TabIndex = 47;
            this.txtEnrolmentId.Tag = "EnrolmentID";
            this.ToolTips.SetToolTip(this.txtEnrolmentId, "Insert a Numeric value for the Student ID, using 0-9 numbers Only");
            // 
            // dtpCompletion
            // 
            this.dtpCompletion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCompletion.Location = new System.Drawing.Point(207, 282);
            this.dtpCompletion.Name = "dtpCompletion";
            this.dtpCompletion.Size = new System.Drawing.Size(295, 20);
            this.dtpCompletion.TabIndex = 70;
            this.dtpCompletion.Tag = "CompletionDate";
            this.ToolTips.SetToolTip(this.dtpCompletion, "Insert the Course Completion Date Here");
            // 
            // txtDiscountCost
            // 
            this.txtDiscountCost.Enabled = false;
            this.txtDiscountCost.Location = new System.Drawing.Point(207, 360);
            this.txtDiscountCost.Name = "txtDiscountCost";
            this.txtDiscountCost.Size = new System.Drawing.Size(295, 20);
            this.txtDiscountCost.TabIndex = 76;
            this.txtDiscountCost.Tag = "DiscountCost";
            this.ToolTips.SetToolTip(this.txtDiscountCost, "This is the Final amount including discounts for the Enrolment");
            // 
            // txtEnrolmentCost
            // 
            this.txtEnrolmentCost.Enabled = false;
            this.txtEnrolmentCost.Location = new System.Drawing.Point(207, 325);
            this.txtEnrolmentCost.Name = "txtEnrolmentCost";
            this.txtEnrolmentCost.Size = new System.Drawing.Size(295, 20);
            this.txtEnrolmentCost.TabIndex = 75;
            this.txtEnrolmentCost.Tag = "EnrolmentCost";
            this.ToolTips.SetToolTip(this.txtEnrolmentCost, "This is the base cost for the Enrolment");
            // 
            // pnlSemester
            // 
            this.pnlSemester.Controls.Add(this.rdbSemesterOne);
            this.pnlSemester.Controls.Add(this.rdbSemesterTwo);
            this.pnlSemester.Location = new System.Drawing.Point(207, 426);
            this.pnlSemester.Name = "pnlSemester";
            this.pnlSemester.Size = new System.Drawing.Size(297, 25);
            this.pnlSemester.TabIndex = 81;
            this.pnlSemester.Tag = "Semester";
            this.ToolTips.SetToolTip(this.pnlSemester, "Select The Semester this course is being undertaken in");
            // 
            // rdbSemesterOne
            // 
            this.rdbSemesterOne.AutoSize = true;
            this.rdbSemesterOne.Location = new System.Drawing.Point(5, 5);
            this.rdbSemesterOne.Name = "rdbSemesterOne";
            this.rdbSemesterOne.Size = new System.Drawing.Size(45, 17);
            this.rdbSemesterOne.TabIndex = 72;
            this.rdbSemesterOne.TabStop = true;
            this.rdbSemesterOne.Tag = "SemesterOne";
            this.rdbSemesterOne.Text = "One";
            this.rdbSemesterOne.UseVisualStyleBackColor = true;
            // 
            // rdbSemesterTwo
            // 
            this.rdbSemesterTwo.AutoSize = true;
            this.rdbSemesterTwo.Location = new System.Drawing.Point(82, 5);
            this.rdbSemesterTwo.Name = "rdbSemesterTwo";
            this.rdbSemesterTwo.Size = new System.Drawing.Size(46, 17);
            this.rdbSemesterTwo.TabIndex = 73;
            this.rdbSemesterTwo.TabStop = true;
            this.rdbSemesterTwo.Tag = "SemesterTwo";
            this.rdbSemesterTwo.Text = "Two";
            this.rdbSemesterTwo.UseVisualStyleBackColor = true;
            // 
            // pnlCourseResults
            // 
            this.pnlCourseResults.Controls.Add(this.rdbNotComplete);
            this.pnlCourseResults.Controls.Add(this.rdbPass);
            this.pnlCourseResults.Controls.Add(this.rdbFail);
            this.pnlCourseResults.Location = new System.Drawing.Point(206, 460);
            this.pnlCourseResults.Name = "pnlCourseResults";
            this.pnlCourseResults.Size = new System.Drawing.Size(298, 25);
            this.pnlCourseResults.TabIndex = 82;
            this.pnlCourseResults.Tag = "CourseResult";
            this.ToolTips.SetToolTip(this.pnlCourseResults, "Select the State of the enrolment at the end of Completion Date (Select Not Compl" +
        "eted until results are recieved)");
            // 
            // rdbNotComplete
            // 
            this.rdbNotComplete.AutoSize = true;
            this.rdbNotComplete.Location = new System.Drawing.Point(153, 5);
            this.rdbNotComplete.Name = "rdbNotComplete";
            this.rdbNotComplete.Size = new System.Drawing.Size(95, 17);
            this.rdbNotComplete.TabIndex = 74;
            this.rdbNotComplete.TabStop = true;
            this.rdbNotComplete.Tag = "CourseNot";
            this.rdbNotComplete.Text = "Not Completed";
            this.rdbNotComplete.UseVisualStyleBackColor = true;
            // 
            // rdbPass
            // 
            this.rdbPass.AutoSize = true;
            this.rdbPass.Location = new System.Drawing.Point(5, 5);
            this.rdbPass.Name = "rdbPass";
            this.rdbPass.Size = new System.Drawing.Size(48, 17);
            this.rdbPass.TabIndex = 72;
            this.rdbPass.TabStop = true;
            this.rdbPass.Tag = "CoursePass";
            this.rdbPass.Text = "Pass";
            this.rdbPass.UseVisualStyleBackColor = true;
            // 
            // rdbFail
            // 
            this.rdbFail.AutoSize = true;
            this.rdbFail.Location = new System.Drawing.Point(82, 5);
            this.rdbFail.Name = "rdbFail";
            this.rdbFail.Size = new System.Drawing.Size(41, 17);
            this.rdbFail.TabIndex = 73;
            this.rdbFail.TabStop = true;
            this.rdbFail.Tag = "CourseFail";
            this.rdbFail.Text = "Fail";
            this.rdbFail.UseVisualStyleBackColor = true;
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.courseToolStripMenuItem.Text = "Course";
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // globalSearchToolStripMenuItem
            // 
            this.globalSearchToolStripMenuItem.Name = "globalSearchToolStripMenuItem";
            this.globalSearchToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.globalSearchToolStripMenuItem.Text = "Global Search";
            // 
            // skillsToolStripMenuItem
            // 
            this.skillsToolStripMenuItem.Name = "skillsToolStripMenuItem";
            this.skillsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.skillsToolStripMenuItem.Text = "Skills";
            // 
            // assessmentToolStripMenuItem
            // 
            this.assessmentToolStripMenuItem.Name = "assessmentToolStripMenuItem";
            this.assessmentToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.assessmentToolStripMenuItem.Text = "Assessment";
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
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.unitToolStripMenuItem.Text = "Unit";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enrolment Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Location = new System.Drawing.Point(612, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(132, 645);
            this.panel5.TabIndex = 59;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel8.Controls.Add(this.btnViewAll);
            this.panel8.Location = new System.Drawing.Point(4, 413);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(125, 50);
            this.panel8.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Location = new System.Drawing.Point(3, 350);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 50);
            this.panel4.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(3, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 50);
            this.panel3.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Location = new System.Drawing.Point(4, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 50);
            this.panel2.TabIndex = 21;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Location = new System.Drawing.Point(3, 214);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(125, 50);
            this.panel6.TabIndex = 19;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button5.Image = global::CMS.Properties.Resources.EnrolmentButton;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 100);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Location = new System.Drawing.Point(0, 27);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(685, 60);
            this.panel7.TabIndex = 55;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.formsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 60;
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
            this.courseToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.assessmentToolStripMenuItem,
            this.skillsToolStripMenuItem,
            this.allocationToolStripMenuItem,
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
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // teacherCoursesToolStripMenuItem
            // 
            this.teacherCoursesToolStripMenuItem.Name = "teacherCoursesToolStripMenuItem";
            this.teacherCoursesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.teacherCoursesToolStripMenuItem.Text = "Teacher";
            // 
            // allocationToolStripMenuItem
            // 
            this.allocationToolStripMenuItem.Name = "allocationToolStripMenuItem";
            this.allocationToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.allocationToolStripMenuItem.Text = "Allocation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 21);
            this.label6.TabIndex = 62;
            this.label6.Text = "Enrolment Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 61;
            this.label2.Text = "Enrolment ID:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(106, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 21);
            this.label13.TabIndex = 65;
            this.label13.Text = "Student ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(109, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 21);
            this.label12.TabIndex = 64;
            this.label12.Text = "Course ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 21);
            this.label8.TabIndex = 71;
            this.label8.Text = "Completion Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 74;
            this.label3.Text = "Semester:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 78;
            this.label4.Text = "Enrolment Cost:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 21);
            this.label5.TabIndex = 77;
            this.label5.Text = "Discounted Cost:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 21);
            this.label7.TabIndex = 79;
            this.label7.Text = "Course Results:";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(206, 393);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(295, 20);
            this.txtTotal.TabIndex = 83;
            this.txtTotal.Tag = "DiscountCost";
            this.ToolTips.SetToolTip(this.txtTotal, "This is the Final amount including discounts for the Enrolment");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(106, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 21);
            this.label9.TabIndex = 84;
            this.label9.Text = "Total Cost:";
            // 
            // EnrolmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(744, 507);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pnlCourseResults);
            this.Controls.Add(this.pnlSemester);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDiscountCost);
            this.Controls.Add(this.txtEnrolmentCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpCompletion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpEnrolment);
            this.Controls.Add(this.txtCourseId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtEnrolmentId);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Name = "EnrolmentForm";
            this.Text = "EnrolmentForm";
            this.pnlSemester.ResumeLayout(false);
            this.pnlSemester.PerformLayout();
            this.pnlCourseResults.ResumeLayout(false);
            this.pnlCourseResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.DateTimePicker dtpEnrolment;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtEnrolmentId;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.ToolStripMenuItem globalSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assessmentToolStripMenuItem;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel7;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpCompletion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdbSemesterOne;
        private System.Windows.Forms.RadioButton rdbSemesterTwo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountCost;
        private System.Windows.Forms.TextBox txtEnrolmentCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlSemester;
        private System.Windows.Forms.Panel pnlCourseResults;
        private System.Windows.Forms.RadioButton rdbNotComplete;
        private System.Windows.Forms.RadioButton rdbPass;
        private System.Windows.Forms.RadioButton rdbFail;
        private System.Windows.Forms.ToolStripMenuItem allocationToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
    }
}