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

        public MainWindow()
        {
            InitializeComponent();
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
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
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
            student.SurName = surNameTextBox.Text;
            student.LastName = lastNameTextBox.Text;
            student.Faculty = facultyTextBox.Text;
            student.Major = majorTextBox.Text;
            student.Degree = degreeTextBox.Text;
            student.Status = statusTextBox.Text;
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
            surNameTextBox.Text = student.SurName;
            lastNameTextBox.Text = student.LastName;
            facultyTextBox.Text = student.Faculty;
            majorTextBox.Text = student.Major;
            degreeTextBox.Text = student.Degree;
            statusTextBox.Text = student.Status;
            facultyNumberTextBox.Text = student.FacultyNumber;
            courseTextBox.Text = student.Course.ToString();
            flowTextBox.Text = student.Flow.ToString();
            groupTextBox.Text = student.Group.ToString();
        }

        private void DeactivateAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
            }
        }

        private void ActivateAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
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

    }
}
