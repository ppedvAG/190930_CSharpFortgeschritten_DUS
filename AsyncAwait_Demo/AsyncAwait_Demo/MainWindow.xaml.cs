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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Start");

            // await Task.Run(FülleProgressbar);

            #region await mit Resultat:
            //string uhrzeit = await Task<string>.Run(() =>
            //{
            //    Thread.Sleep(5000);
            //    return DateTime.Now.ToLongTimeString();
            //});
            //MessageBox.Show("Uhrzeit:" + uhrzeit); 
            #endregion

            // Warten selbst:
            // Thread.Sleep(5000);      // blockiert den UI-Thread
            // await Task.Delay(5000);  // blockiert NICHT !

            #region ConfigureAwait
            //textBoxInhalt.Text = "Vor dem Task";

            //await Task.Run(FülleProgressbar).ConfigureAwait(false);
            //// Normalfall: nach dem await wird zurück in den UI-Thread gewechselt
            //// ConfigureAwait(false): nach dem await wird mit dem Thread vom Task weitergemacht (= performance da der Thread nicht "gewechselt" werden muss)

            //textBoxInhalt.Text = "Nach dem Task"; 
            #endregion

            //MessageBox.Show("Ende");

            ProgressWindow w = new ProgressWindow();
            w.ShowDialog();
        }

        public void FülleProgressbar()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                Dispatcher.Invoke(() => progressBarWert.Value = i); // "Oberflächenthread -> Bitte mach das für mich
            }
            Close();
        }
    }
}
