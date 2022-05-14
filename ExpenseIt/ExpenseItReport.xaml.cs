using System;
using System.Collections.Generic;
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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItReport.xaml
    /// </summary>
    public partial class ExpenseItReport : Window
    {
        public ExpenseItReport()
        {
            InitializeComponent();
        }

        // Custom constructor to pass expense report data
        public ExpenseItReport(object data)
            : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
    }
}
