namespace School.DesktopUI
{
    public partial class SchoolKZL : Form
    {

        public SchoolKZL()
        {
            InitializeComponent();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            panelSchool.Visible = false;
            panelHome.Visible = true;
        }

        private void buttonSchoolClass_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            //panelStudent.Visible = false;
            //panelTeacher.Visible = false;
            panelSchool.Visible = true;
        }

        private void buttonTeacher_Click(object sender, EventArgs e)
        {
            //panelSchool.Visible = false;
            //panelStudent.Visible = false;
            //panelTeacher.Visible = true;
        }

        private void buttonStudent_Click(object sender, EventArgs e)
        {
            //panelSchool.Visible = false;
            //panelTeacher.Visible = false;
            //panelStudent.Visible = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}