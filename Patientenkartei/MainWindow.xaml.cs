using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Patientenkartei
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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = TextBoxContent.Text;
            string filename = TextBoxFileName.Text;

            using(FileStream fs = File.Create(filename + ".txt"))
            {
                byte[] contentConvertedToBytes = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvertedToBytes, 0, contentConvertedToBytes.Length);
            }

            MessageBox.Show("Datei wurde Angelegt.");
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string filename = TextBoxFileName.Text;

            using (FileStream fs = File.OpenRead(filename + ".txt"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    TextBoxContent.Text = content;
                }

            }
        }
    }
}