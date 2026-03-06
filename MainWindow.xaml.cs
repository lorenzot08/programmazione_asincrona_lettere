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

namespace Programmazione_Asincrona_Lettere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread t1 = new Thread(()=>StartGiro());
            t1.IsBackground = true;
            t1.Start();
        }
        string lettere = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private void StartGiro()
        {
            int i = 0;
            while (true)
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                        lblStampa.Content = lettere[i%26].ToString();//perche le lettere di una stringa trattati automaticamente come elementi di un array es: lettere[0]=a
                }));
                i++;
                Thread.Sleep(230);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblVisualizza.Content=lblVisualizza.Content.ToString()+lblStampa.Content.ToString();
        }
    }
}
