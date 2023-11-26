using School.Domain.Entities;
using System.Text;

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

        private async void buttonSchoolClass_Click(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            //panelStudent.Visible = false;
            //panelTeacher.Visible = false;
            panelSchool.Visible = true;

            SchoolService schoolService = new SchoolService();
            var list = await schoolService.SendGetRequest();

            // Ustaw źródło danych dla ListBox
            listBoxSchoolClasses.DataSource = list;

            // Ustaw właściwość do wyświetlania
            listBoxSchoolClasses.DisplayMember = "ClassName";
            
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