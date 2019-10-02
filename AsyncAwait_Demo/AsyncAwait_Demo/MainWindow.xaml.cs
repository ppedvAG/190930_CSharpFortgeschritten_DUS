using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncAwait_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start");

            Task t1 = Task.Run(FülleProgressbar);

            MessageBox.Show("Ende");
        }

        public void FülleProgressbar()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                Dispatcher.Invoke(() => progressBarWert.Value = i); // "Oberflächenthread -> Bitte mach das für mich
            }
        }
    }
}
