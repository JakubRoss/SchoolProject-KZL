namespace School.DesktopUI
{
    partial class SchoolKZL
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPanel = new Panel();
            buttonExit = new Button();
            buttonStudent = new Button();
            buttonTeacher = new Button();
            buttonSchoolClass = new Button();
            buttonHome = new Button();
            panelHome = new Panel();
            textHome = new TextBox();
            panelSchool = new Panel();
            menuPanel.SuspendLayout();
            panelHome.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(buttonExit);
            menuPanel.Controls.Add(buttonStudent);
            menuPanel.Controls.Add(buttonTeacher);
            menuPanel.Controls.Add(buttonSchoolClass);
            menuPanel.Controls.Add(buttonHome);
            menuPanel.Location = new Point(12, 21);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(243, 591);
            menuPanel.TabIndex = 0;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.MistyRose;
            buttonExit.Location = new Point(20, 466);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(199, 72);
            buttonExit.TabIndex = 4;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonStudent
            // 
            buttonStudent.BackColor = Color.Azure;
            buttonStudent.Location = new Point(20, 347);
            buttonStudent.Name = "buttonStudent";
            buttonStudent.Size = new Size(199, 72);
            buttonStudent.TabIndex = 3;
            buttonStudent.Text = "Student";
            buttonStudent.UseVisualStyleBackColor = false;
            buttonStudent.Click += buttonStudent_Click;
            // 
            // buttonTeacher
            // 
            buttonTeacher.BackColor = Color.OldLace;
            buttonTeacher.Location = new Point(20, 235);
            buttonTeacher.Name = "buttonTeacher";
            buttonTeacher.Size = new Size(199, 72);
            buttonTeacher.TabIndex = 2;
            buttonTeacher.Text = "Teacher";
            buttonTeacher.UseVisualStyleBackColor = false;
            buttonTeacher.Click += buttonTeacher_Click;
            // 
            // buttonSchoolClass
            // 
            buttonSchoolClass.BackColor = Color.GhostWhite;
            buttonSchoolClass.Location = new Point(20, 131);
            buttonSchoolClass.Name = "buttonSchoolClass";
            buttonSchoolClass.Size = new Size(199, 72);
            buttonSchoolClass.TabIndex = 1;
            buttonSchoolClass.Text = "School Class";
            buttonSchoolClass.UseVisualStyleBackColor = false;
            buttonSchoolClass.Click += buttonSchoolClass_Click;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.Honeydew;
            buttonHome.Location = new Point(20, 26);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(199, 72);
            buttonHome.TabIndex = 0;
            buttonHome.Text = "Home";
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click;
            // 
            // panelHome
            // 
            panelHome.BackColor = Color.Honeydew;
            panelHome.Controls.Add(textHome);
            panelHome.Location = new Point(287, 21);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(754, 591);
            panelHome.TabIndex = 1;
            // 
            // textHome
            // 
            textHome.BackColor = Color.Honeydew;
            textHome.BorderStyle = BorderStyle.None;
            textHome.Enabled = false;
            textHome.Font = new Font("Clarendon BT", 18F, FontStyle.Bold, GraphicsUnit.Point);
            textHome.Location = new Point(80, 114);
            textHome.Multiline = true;
            textHome.Name = "textHome";
            textHome.Size = new Size(605, 360);
            textHome.TabIndex = 0;
            textHome.Text = "\r\n\r\n\r\n\r\nWelcome to simply school manager.\r\nSchool.KZL";
            textHome.TextAlign = HorizontalAlignment.Center;
            // 
            // panelSchool
            // 
            panelSchool.BackColor = Color.GhostWhite;
            panelSchool.Location = new Point(287, 21);
            panelSchool.Name = "panelSchool";
            panelSchool.Size = new Size(754, 591);
            panelSchool.TabIndex = 2;
            panelSchool.Visible = false;
            // 
            // SchoolKZL
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 634);
            Controls.Add(panelSchool);
            Controls.Add(panelHome);
            Controls.Add(menuPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SchoolKZL";
            Text = "School KZL";
            TopMost = true;
            menuPanel.ResumeLayout(false);
            panelHome.ResumeLayout(false);
            panelHome.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private Button buttonStudent;
        private Button buttonTeacher;
        private Button buttonSchoolClass;
        private Button buttonHome;
        private Panel panelHome;
        private TextBox textHome;
        private Button buttonExit;
        private Panel panelSchool;
    }
}
