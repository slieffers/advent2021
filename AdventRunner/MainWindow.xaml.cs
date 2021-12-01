using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace AdventRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _daySelection = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_daySelection) || _daySelection == "Select Advent Day")
            {
                return;
            }

            var assembly = Assembly.GetExecutingAssembly();
            Type dayType = assembly.GetTypes().First(t => t.Name == _daySelection);
            MethodInfo method = dayType.GetMethod("Run", BindingFlags.Public | BindingFlags.Static);
            if (method != null)
            {
                method.Invoke(this, null);
            }
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _daySelection = ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content?.ToString()?.Replace(" ", "") ?? "";
        }
    }
}