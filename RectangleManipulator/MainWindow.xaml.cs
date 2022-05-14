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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RectangleManipulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDataErrorInfo
    {
        public string Degrees { get; set; }

        public string Size { get; set; }

        public string Message { get; set; }

        public ObservableCollection<Input> inputs = new ObservableCollection<Input>();

        public ObservableCollection<Input> Inputs
        {
            get
            {
                return inputs;
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string PropertyName]
        {
            get
            {
                string result = null;

                switch (PropertyName)
                {
                    case "Degrees":
                        if (!int.TryParse(Degrees, out int degrees))
                            result = "Degrees must be a number.";
                        break;
                    case "Size":
                        if (!double.TryParse(Size, out double size))
                            result = "Size must be a number.";
                        break;
                }
                return result;
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Degrees, out int degreesResult) && double.TryParse(Size, out double sizeResult))
            {
                messageTextBox.Text = "Valid data!";
                messageTextBox.Foreground = Brushes.Green;

                TransformGroup transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform(sizeResult, sizeResult, rectangle.Width / 2, rectangle.Height / 2));
                transformGroup.Children.Add(new RotateTransform(degreesResult, rectangle.Width / 2, rectangle.Height / 2));

                Inputs.Add(new Input() { Size = sizeResult.ToString(), Degrees = degreesResult.ToString()});
                rectangle.RenderTransform = transformGroup;
            }
            else
            {
                messageTextBox.Text = "Invalid data!";
                messageTextBox.Foreground = Brushes.Red;
            }
        }

        public class Input
        {
            public string Degrees { get; set; }

            public string Size { get; set; }
        }


    }
}
