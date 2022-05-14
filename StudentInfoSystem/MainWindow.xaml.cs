using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student _teststud;

        public Student TestStudent
        {
            get
            {
                return _teststud;
            }
            set
            {
                if (IsStudentValid(value))
                {
                    _teststud = value;
                }
            }
        }

        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            FillStudStatusChoices();
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
            if (TestUsersIfEmpty())
            {
                CopyTestUsers();
            }
        }

        private void ClearFormBbutton_Click(object sender, RoutedEventArgs e)
        {
            ClearAllControls();
        }

        private void GetStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentData.TestStudents.FirstOrDefault();
            SetStudentDataToControls(student);
        }

        private void DeactivateFormButton_Click(object sender, RoutedEventArgs e)
        {
            DeactivateAllControls();
        }

        private void ActivateFormButton_Click(object sender, RoutedEventArgs e)
        {
            ActivateAllControls();
        }

        private void ClearAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is GroupBox)
                {
                    if (((GroupBox)item).Content is Grid)
                    {
                        foreach (var innerItem in ((Grid)((GroupBox)item).Content).Children)
                        {
                            if (innerItem is TextBox)
                            {
                                ((TextBox)innerItem).Text = string.Empty;
                            }
                        }
                    }
                }
            }
        }

        private void SetStudentButton_Click(object sender, RoutedEventArgs e)
        {
            TestStudent = StudentData.TestStudents.FirstOrDefault();
        }

        private Student GetStudentDayaFromControls()
        {
            Student student = new Student();
            student.Name = nameTextBox.Text;
            student.Surname = surNameTextBox.Text;
            student.LastName = lastNameTextBox.Text;
            student.Faculty = facultyTextBox.Text;
            student.Major = majorTextBox.Text;
            student.Degree = degreeTextBox.Text;
            student.Status = statusListBox.SelectedItem.ToString();
            student.FacultyNumber = facultyNumberTextBox.Text;
            if (int.TryParse(courseTextBox.Text, out int course))
            {
                student.Course = course;
            }
            if (int.TryParse(courseTextBox.Text, out int flow))
            {
                student.Flow = flow;
            }
            if (int.TryParse(courseTextBox.Text, out int group))
            {
                student.Group = group;
            }
            return student;
        }

        private void SetStudentDataToControls(Student student)
        {
            nameTextBox.Text = student.Name;
            surNameTextBox.Text = student.Surname;
            lastNameTextBox.Text = student.LastName;
            facultyTextBox.Text = student.Faculty;
            majorTextBox.Text = student.Major;
            degreeTextBox.Text = student.Degree;
            statusListBox.SelectedItem = student.Status;
            facultyNumberTextBox.Text = student.FacultyNumber;
            courseTextBox.Text = student.Course.ToString();
            flowTextBox.Text = student.Flow.ToString();
            groupTextBox.Text = student.Group.ToString();
        }

        private void DeactivateAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is GroupBox)
                {
                    if (((GroupBox)item).Content is Grid)
                    {
                        foreach (var innerItem in ((Grid)((GroupBox)item).Content).Children)
                        {
                            if (innerItem is TextBox)
                            {
                                ((TextBox)innerItem).IsEnabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void ActivateAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is GroupBox)
                {
                    if (((GroupBox)item).Content is Grid)
                    {
                        foreach (var innerItem in ((Grid)((GroupBox)item).Content).Children)
                        {
                            if (innerItem is TextBox)
                            {
                                ((TextBox)innerItem).IsEnabled = true;
                            }
                        }
                    }
                }
            }
        }

        private bool IsStudentValid(Student student)
        {
            if (student != null && StudentData.IsStudentDataFilled(student))
            {
                ActivateAllControls();
                SetStudentDataToControls(student);
                return true;
            }
            else
            {
                ClearAllControls();
                DeactivateAllControls();
                return false;
            }
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
            {
                return true;
            }
            return false;
        }

        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);

            }
            context.SaveChanges();
        }

        public bool TestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            if (countUsers == 0)
            {
                return true;
            }
            return false;
        }

        public void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (User u in UserData.TestUsers)
            {
                context.Users.Add(u);

            }
            context.SaveChanges();
        }
    }
}
