using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace UporabiskiVmesniki
{
    /// <summary>
    /// Interaction logic for SpreminjanjeFilmov.xaml
    /// </summary>
    /// 
    public static class ListViewEL
    {
        public static Action ena;
    }
    public partial class SpreminjanjeFilmov : Window
    {
        public globalni zbirka = new globalni();
        public SpreminjanjeFilmov(Action abc)
        {
            InitializeComponent();
            ustvariListView();
            ustvariGlobSprem(abc);
        }
        public SpreminjanjeFilmov()
        {
            InitializeComponent();
            ustvariListView();
        }
        public void ustvariGlobSprem(Action aa)
        {
            ListViewEL.ena = aa;
        }

        public void ustvariListView()
        {
            foreach (Film a in zbirka.GlobalniFilmi)
            {
                ListViewItem aa = new ListViewItem();
                aa.Content = a.naslovFilma;
                aa.Tag = a;
                filmiVIEW.Items.Add(aa);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = filmiVIEW.SelectedItems[0];
            var b = (ListViewItem)a;
            var cc = (Film)b.Tag;
            igralciFilma.Content = cc.igralci;
            Žanr ime = zbirka.globalniŽanri.Where(x => x.ID == cc.ID_žanra).FirstOrDefault();
            žanrFilma.Content = ime.imeŽanra;
            direktorjiFilma.Content = cc.direktorji;
            pomagačiFilma.Content = cc.pomagači;
            Uri uri = new Uri(@cc.potDoSlike,UriKind.RelativeOrAbsolute);
            ImageSource imgSource = new BitmapImage(uri);
            slikaFilma.Source = imgSource;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var aaa = filmiVIEW.SelectedItem;
            var b = (ListViewItem)aaa;
            var cc = (Film)b.Tag;
            string naslov = naslovFilmaVpis.Text;
            string igralci = igralciFilmaVpis.Text;
            string direktorji = direktorjiFilmaVpis.Text;
            string žanr = žanrFilmaVpis.Text;
            string pomagači = pomagačiFilmaVpis.Text;
            filmiVIEW.Items.RemoveAt(filmiVIEW.SelectedIndex);
            zbirka.GlobalniFilmi.Remove(cc);
            Film abc = new Film(3, naslov);
            abc.direktorji = direktorji;
            abc.igralci = igralci;
            abc.pomagači = pomagači;
            if (zbirka.globalniŽanri.Any(x => x.imeŽanra == žanr))
            {
                abc.ID_žanra = zbirka.globalniŽanri.Where(x => x.imeŽanra == žanr).FirstOrDefault().ID;
            }
            else
            {
                zbirka.globalniŽanri.Add(new Žanr(žanr));
                zbirka.SaveChanges();
                abc.ID_žanra = zbirka.globalniŽanri.Max(x => x.ID);
            }
            abc.potDoSlike = cc.potDoSlike;
            abc.opisFilma = cc.opisFilma;
            zbirka.GlobalniFilmi.Add(abc);
            zbirka.SaveChanges();
            ListViewItem item = new ListViewItem();
            item.Content = abc.naslovFilma;
            item.Tag = abc;
            filmiVIEW.Items.Add(item);
        }

        private void slikaFilma_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog odpri = new OpenFileDialog();
            odpri.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (odpri.ShowDialog()==true)
            {
                slikaFilma.Source = new BitmapImage(new Uri(@odpri.FileName, UriKind.RelativeOrAbsolute));                
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string path = " ";
            string naslov = naslovFilmaVpis.Text;
            string igralci = igralciFilmaVpis.Text;
            string direktorji = direktorjiFilmaVpis.Text;
            string žanr = žanrFilmaVpis.Text;
            string pomagači = pomagačiFilmaVpis.Text;
            OpenFileDialog odpri = new OpenFileDialog();
            odpri.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (odpri.ShowDialog() == true)
            {
                path = odpri.FileName;
            }
            Film abc = new Film(4,naslov);
            abc.igralci = igralci;
            abc.opisFilma = " ";
            abc.pomagači = pomagači;
            abc.potDoSlike = path;
            abc.ocenaFilma = 1;
            abc.direktorji = direktorji;
            zbirka.globalniŽanri.Add(new Žanr(žanr));
            zbirka.SaveChanges();
            int zadnji = zbirka.globalniŽanri.Max(x => x.ID);
            abc.ID_žanra = zadnji;
            zbirka.GlobalniFilmi.Add(abc);
            zbirka.SaveChanges();
            filmiVIEW.Items.Clear();
            ustvariListView();
            ListViewEL.ena();
        }

        private void filmiVIEW_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = filmiVIEW.SelectedItems[0];
            var b = (ListViewItem)a;
            var cc = (Film)b.Tag;
            ListViewEL.ena();
        }

        private void ocena_Click(object sender, RoutedEventArgs e)
        {
            Oceni aa = new Oceni();
            aa.ShowDialog();
        }

        private void ColorPicker_Closed(object sender, RoutedEventArgs e)
        {
            var s = barva.SelectedColor.Value;
            Brush barvaa = new SolidColorBrush(s);
            
            this.Background = barvaa;
        }
    }
}
