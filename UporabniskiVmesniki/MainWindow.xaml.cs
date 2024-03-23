using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Schema;
using System.Data.Entity;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel.DataAnnotations;


namespace UporabiskiVmesniki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// DataAnnotations;

    public class Film : INotifyPropertyChanged
    {


        [Key]
        public int ID { get; set; }
        public string naslovFilma { get; set; }       
        public string opisFilma { get; set; }
        public string igralci { get;  set; }
        public string direktorji { get; set; }
        public string pomagači { get; set; }
        public string potDoSlike { get; set; }
        public int ID_žanra { get; set; }
        public List<string> igralciFilma { get; set; }
        public List<Žanr> žanriFilma { get; set; }
        public int ocenaFilma { get; set; }

        public Film(int id, string a)
        {
            ID = id;
            naslovFilma = a;
        }

        public void NastaviOceno(int value)
        {
                ocenaFilma = value; OnPropertyChanged("OcenaFilma"); 

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return naslovFilma;
        }

        public Film() { }

        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                
            }
        }
    }
    public class globalni : DbContext
    {
        public virtual DbSet<Film> GlobalniFilmi { get; set; }
        public virtual DbSet<Žanr> globalniŽanri  { get; set; }
    }
    public partial class MainWindow : Window
    {
        public globalni zbirka = new globalni();

        public ObservableCollection<Film> filmiZbirke = new ObservableCollection<Film> {};
        public bool abc=true;
        public MainWindow()
        {
            InitializeComponent();
            DodajNalistView();
            
            listView.DataContext = filmiZbirke;
            //DodajFilme();    //AvtomatskiFilmi();
            //DodajNalistView();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            abc = false;
            //odstrani
            if (listView.SelectedValue != null)
            {
                var aa = listView.SelectedItem;
                //var bb = (ListViewItem)aa;
                var cc = (Film)aa;
                listView.Items.RemoveAt(listView.SelectedIndex);
                
                zbirka.GlobalniFilmi.Remove(cc);
                zbirka.SaveChanges();
                abc = true;
            }
            else
            {
                MessageBox.Show("Ni izbranega elementa");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SpreminjanjeFilmov a = new SpreminjanjeFilmov(DodajNalistView);
            a.ShowDialog();
            //ListViewItem aa = new ListViewItem();
            //Film b = new Film(13, "Forrest gump");
            //b.direktorji = " ";
            //b.igralci = " ";
            //b.opisFilma = " ";
            //b.pomagači = " ";
            //b.potDoSlike = @"Ikone\forrest.jpg";
            //b.ID_žanra = 2;
            //zbirka.GlobalniFilmi.Add(b);
            //aa.Content = b.naslovFilma;
            //aa.Tag = b;
            //this.listView.Items.Add(aa);
        }

        public void DodajFilme()
        {
            Žanr prvi = new Žanr("komedija");
            Žanr drugi = new Žanr("drama");
            zbirka.globalniŽanri.Add(prvi);
            zbirka.globalniŽanri.Add(drugi);
            zbirka.SaveChanges();

            Film b = new Film(1, "Pineapple express");
            b.direktorji = "Seth rogan";
            b.igralci = " Seth Rogen, James Franco, Gary Cole";
            b.opisFilma = "A process server and his marijuana dealer wind up on the run from hitmen and a corrupt police officer after he witnesses his dealer's boss murder a competitor while trying to serve papers on him. ";
            b.pomagači = "krneki";
            b.ID_žanra = 1;
            b.potDoSlike = @"Ikone\express.jpg";
            b.ocenaFilma = 4;
            zbirka.GlobalniFilmi.Add(b);
            zbirka.SaveChanges();

            Film c = new Film(2, "Parasite");
            c.opisFilma = "Greed and class discrimination threaten the newly formed symbiotic relationship between the wealthy Park family and the destitute Kim clan. ";
            c.direktorji = " Bong Joon Ho";
            c.igralci = " Kang-ho Song, Sun-kyun Lee, Yeo-jeong Jo";
            c.pomagači = "kreni";
            c.ID_žanra = 2;
            c.potDoSlike = @"Ikone\parasite.jpg";
            c.ocenaFilma = 3;
            zbirka.GlobalniFilmi.Add(c);
            zbirka.SaveChanges();
            listView.DataContext = filmiZbirke;




        }


        public void DodajNalistView()
        {
            abc = false;
            filmiZbirke.Clear();
            zbirka.GlobalniFilmi.ToList().ForEach(x => filmiZbirke.Add(x));
            listView.DataContext = filmiZbirke;
            abc = true;
            //listView.Items.Clear();
            //List<Film> novList = zbirka.GlobalniFilmi.ToList();
            //listView.ItemsSource = novList;

            //foreach (Film abb in zbirka.GlobalniFilmi)
            //{
            //    ListViewItem aa = new ListViewItem();
            //    aa.Content = abb.naslovFilma;
            //    aa.Tag = abb;
            //    listView.Items.Add(aa);
            //}


        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!abc)
            {
                return;
            }

            var a = listView.SelectedItems[0];
            //var b = (ListViewItem)a;
            var cc =  (Film)a;
            labelFilmNaslov.Content = cc.naslovFilma;
            direktorFilma.Content = cc.direktorji;
            igralciFilma.Content = cc.igralci;
            pomagačiFilma.Content = cc.pomagači;
            OpisFilma.Text = cc.opisFilma;
            ocena.Content = $"{cc.ocenaFilma}/5";
            Uri uri = new Uri(@cc.potDoSlike, UriKind.RelativeOrAbsolute);
            ImageSource imgSource = new BitmapImage(uri);
            imageFIlm.Source = imgSource;
            listView.DataContext = filmiZbirke;
            abc = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            nastavitve a = new nastavitve();

            a.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SpreminjanjeFilmov a = new SpreminjanjeFilmov(DodajNalistView);
            DodajNalistView();
            a.ShowDialog();

        }

        //private void Button_Click_5(object sender, RoutedEventArgs e)
        //{
        //    abc = false;
        //    var a = listView.SelectedItem;
        //    //var b = (ListViewItem)a;
        //    var cc = (Film)a;
        //    string naslov = cc.naslovFilma;
        //    string igralci = cc.igralci;
        //    string direktorji = cc.direktorji;
        //    int žanr = cc.ID_žanra;
        //    string pomagači = cc.pomagači;
            
        //    zbirka.GlobalniFilmi.Remove(cc);
        //    filmiZbirke.Remove(cc);
        //    Film abcd = new Film(3, naslov);
        //    abcd.direktorji = direktorji;
        //    abcd.igralci = igralci;
        //    abcd.pomagači = pomagači;
        //    if (zbirka.globalniŽanri.Any(x => x.ID == žanr))
        //    {
        //        abcd.ID_žanra = zbirka.globalniŽanri.Where(x => x.ID == žanr).FirstOrDefault().ID;
        //    }
        //    abcd.potDoSlike = cc.potDoSlike;
        //    abcd.opisFilma = cc.opisFilma;
        //    var teksta = (ComboBoxItem)cbox.SelectedItem;
        //    string tekst = teksta.Content.ToString();
        //    string enstring = tekst[0].ToString();
        //    int ocenaA = Int32.Parse(enstring);
        //    abcd.NastaviOceno(ocenaA);
        //    filmiZbirke.Add(abcd);
        //    zbirka.GlobalniFilmi.Add(abcd);
        //    zbirka.SaveChanges();
        //    //ListViewItem item = new ListViewItem();
        //    //item.Content = abcd.naslovFilma;
        //    //item.Tag = abcd;
        //    //listView.Items.Add(item);
        //    //DodajNalistView();
        //    CollectionViewSource.GetDefaultView(filmiZbirke).Refresh();
        //    abc = true;
        //}

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            abc = false;
            var a = listView.SelectedItem;
            //var b = (ListViewItem)a;
            var cc = (Film)a;
            var path = "";
            SaveFileDialog odpri = new SaveFileDialog();
            odpri.Filter = "XML Files(*.xml)|*.xml";
            if (odpri.ShowDialog() == true)
            {
                path = odpri.FileName;
            }
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Film));
                xml.Serialize(stream, cc);
            }
            abc = true;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog odpri = new OpenFileDialog();
            odpri.Filter = "XML Files(*.xml)|*.xml";
            if (odpri.ShowDialog() == true)
            {
                path = odpri.FileName;
            }
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Film));
                Film mm = (Film)xml.Deserialize(stream);
                zbirka.GlobalniFilmi.Add(mm);
                zbirka.SaveChanges();
            }
        }
        public void AvtomatskiFilmi()
        {
            
            string path = @"C:\Users\zan\source\repos\UporabiskiVmesniki\UporabiskiVmesniki\xmlDat\NekFilm.xml";
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Film>));
                List<Film> mm = (List<Film>)xml.Deserialize(stream);
                foreach (Film kk in mm)
                {
                    zbirka.GlobalniFilmi.Add(kk);
                    zbirka.SaveChanges();
                } 
                
            }
        }

        private void listView_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            DodajNalistView();
        }



        private void UserControl1_Loaded_1(object sender, RoutedEventArgs e)
        {

        }


        private void UserControlContainer_MouseLeave(object sender, MouseEventArgs e)
        {
            DodajNalistView();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var a =  (Film)listView.SelectedItem;
            datoteka aa = new datoteka(a);
            aa.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SpreminjanjeFilmov aa = new SpreminjanjeFilmov(DodajNalistView);
            aa.ShowDialog();
        }
    }
}
