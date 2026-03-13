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
        int numeroLettereScelto = 0;
        public MainWindow()
        {
            InitializeComponent();
            Thread t1 = new Thread(()=>StartGiro());
            t1.IsBackground = true;
            t1.Start();
        }
        string lettere = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public async Task StartGiro()
        {
            int i = 0;
            await Task.Run(() =>
            {
                while (true)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblStampa.Content = lettere[i % 26].ToString();//perche le lettere di una stringa trattati automaticamente come elementi di un array es: lettere[0]=a
                    }));
                    i++;
                    Thread.Sleep(230);
                }
            });
         }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NumLettere.Text, out int numeroLettereScelto) || numeroLettereScelto<=0)
            {
                MessageBox.Show("Inserire un numero valido (maggiore di zero).");
            }
            else
            {
                lblVisualizza.Content = lblVisualizza.Content.ToString() + lblStampa.Content.ToString();
                if (lblVisualizza.Content.ToString().Length >= numeroLettereScelto)
                {
                    lista.Items.Add(lblVisualizza.Content.ToString());
                    lblVisualizza.Content = "";
                }
            }
        }

    }
}
