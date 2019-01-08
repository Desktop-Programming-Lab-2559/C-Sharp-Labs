using ConsoleCalculatorApp;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string expression = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            Expression.Text = string.Empty;
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            Parser parser = new Parser();
            double result = parser.Evaluate(Expression.Text);
            Expression.Text = Convert.ToString(result);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Expression.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Expression.Text += (sender as Button).Content;
        }
    }
}
