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
using System.Collections.ObjectModel;

namespace UporabiskiVmesniki
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public globalni zbirka = new globalni();
        public ObservableCollection<Film> FilmiZbirke = new ObservableCollection<Film> { };
        public UserControl1()
        {
            InitializeComponent();
            
            nafilajList();
        }
        public void nafilajList()
        {
            FilmiZbirke.Clear();
            zbirka.GlobalniFilmi.ToList().ForEach(x => FilmiZbirke.Add(x));
            lista.DataContext = FilmiZbirke;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = lista.SelectedItem;
            //var b = (ListViewItem)a;
            var cc = (Film)a;
            string naslov = cc.naslovFilma;
            string igralci = cc.igralci;
            string direktorji = cc.direktorji;
            int žanr = cc.ID_žanra;
            string pomagači = cc.pomagači;

            zbirka.GlobalniFilmi.Remove(cc);
            Film abcd = new Film(3, naslov);
            abcd.direktorji = direktorji;
            abcd.igralci = igralci;
            abcd.pomagači = pomagači;
            if (zbirka.globalniŽanri.Any(x => x.ID == žanr))
            {
                abcd.ID_žanra = zbirka.globalniŽanri.Where(x => x.ID == žanr).FirstOrDefault().ID;
            }
            abcd.potDoSlike = cc.potDoSlike;
            abcd.opisFilma = cc.opisFilma;
            var teksta = (ComboBoxItem)cbox.SelectedItem;
            string tekst = teksta.Content.ToString();
            string enstring = tekst[0].ToString();
            int ocenaA = Int32.Parse(enstring);
            abcd.NastaviOceno(ocenaA);

            zbirka.GlobalniFilmi.Add(abcd);
            zbirka.SaveChanges();
            nafilajList();
            //ListViewItem item = new ListViewItem();
            //item.Content = abcd.naslovFilma;
            //item.Tag = abcd;
            //listView.Items.Add(item);
            //DodajNalistView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var a = lista.SelectedItem;
            //var b = (ListViewItem)a;
            var cc = (Film)a;
            ocena.Content = $"Ocena filma: {cc.ocenaFilma}/5";
            nafilajList();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            ocena.Content = "";
        }
    }
}
