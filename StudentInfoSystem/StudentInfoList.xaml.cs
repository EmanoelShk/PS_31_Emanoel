using StudentInfoSystem.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for StudentInfoList.xaml
    /// </summary>
    public partial class StudentInfoList : Window
    {
        private StudentInfoContext context;

        public List<Student> Students { get; set; } = new List<Student>();

        public StudentInfoList()
        {
            InitializeComponent();
            context = new StudentInfoContext();
            DataContext = this;
            Students = GetActiveStudents();
        }

        private List<Student> GetActiveStudents()
        {
            return context.Students
                .ToList()
                .Where(s => s.Status == "Active")
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Course)
                .ThenBy(s => s.LastName)
                .Select(s => new Student()
                {
                    Name = s.Name,
                    Surname = s.Surname,
                    LastName = s.LastName,
                    Major = s.Major,
                    FacultyNumber = s.FacultyNumber,
                    Course = s.Course,
                    Status = s.Status
                })
                .ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
