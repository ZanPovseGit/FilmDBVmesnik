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
using System.Windows.Media.Animation;


namespace UporabiskiVmesniki
{
    /// <summary>
    /// Interaction logic for datoteka.xaml
    /// </summary>
    public partial class datoteka : Window
    {
        public Film nek;
        public datoteka(Film a)
        {
            InitializeComponent();
            nek = a;
            IzpisFilma();
        }
        public void IzpisFilma()
        {
            naslov.Content = nek.naslovFilma;
            Uri uri = new Uri(@nek.potDoSlike, UriKind.RelativeOrAbsolute);
            ImageSource imgSource = new BitmapImage(uri);
            aa.Source = imgSource;
            ocena.Content = $"Ocena: {nek.ocenaFilma}";
            igral.Content = nek.igralci;
            dir.Content = nek.direktorji;
        }

    }
}
