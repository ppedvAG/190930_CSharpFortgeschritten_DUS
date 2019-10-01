using System;
using System.Collections.Generic;
using System.IO;
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

namespace Dateisystem_Demo
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

        private void menuItemSpeichern_Click(object sender, RoutedEventArgs e)
        {
            #region Variante 1: Binär mit FileStream
            //FileStream stream = new FileStream("demo.txt", FileMode.Create);
            //byte[] textData = Encoding.Default.GetBytes(textBoxInhalt.Text);
            //stream.Write(textData, 0, textData.Length);
            //stream.Close(); 
            #endregion

            #region Variante 2: Text mit StreamReader/Writer

            StreamWriter sw = new StreamWriter("demo.txt");
            sw.Write(textBoxInhalt.Text);
            sw.Close();
            #endregion

            // Variante 3: File
            File.WriteAllText("demo.txt", textBoxInhalt.Text);

        }

        private void menuItemÖffnen_Click(object sender, RoutedEventArgs e)
        {
            #region Variante 1: Binär mit FileStream
            //FileStream stream = new FileStream("demo.txt", FileMode.Open);
            //byte[] textdata = new byte[stream.Length]; 
            //for (int i = 0; i < stream.Length; i++)
            //{
            //    textdata[i] = (byte)stream.ReadByte(); // byte für byte einlesen
            //} 
            //stream.Close();

            //MessageBox.Show("Datei erfolgreich eingelesen");
            //textBoxInhalt.Text = Encoding.Default.GetString(textdata); 
            #endregion

            #region Variante 2: Text mit StreamReader/Writer
            //StreamReader sr = new StreamReader("demo.txt");
            //textBoxInhalt.Text = sr.ReadToEnd();
            //sr.Close(); 
            #endregion

            textBoxInhalt.Text = File.ReadAllText("demo.txt");
        }

        private void menuItemBeenden_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
