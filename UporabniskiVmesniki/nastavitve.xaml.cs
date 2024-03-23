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
using System.ComponentModel.DataAnnotations;
using System.Windows.Threading;
using System.Data.Entity;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Reflection;
using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;


namespace UporabiskiVmesniki
{
    public class Žanr
    {
        [Key]
        public int ID { get; set; }
            public string imeŽanra { get; set; }
        

        public Žanr(string a)
            {
                imeŽanra = a;
            }
        public Žanr() { }
    }
    /// <summary>
    /// Interaction logic for nastavitve.xaml
    /// </summary>
    public partial class nastavitve : Window
    {
        public DispatcherTimer DT = new DispatcherTimer();
        public globalni zbirka = new globalni();
        public nastavitve()
        {
            InitializeComponent();
            InicializerajŽanre();

        }
        private void DT_Tick(object sender, EventArgs e) {
            Shrani();
        }
        public void Shrani()
        {
            List<Film> cc = new List<Film>(zbirka.GlobalniFilmi);
            string path = @"C:\Users\zan\source\repos\UporabiskiVmesniki\UporabiskiVmesniki\shrani\filmi.xml";
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Film>));
                xml.Serialize(stream, cc);
            }
        }
        public void InicializerajŽanre()
        {
            foreach (Žanr a in zbirka.globalniŽanri)
            {
                ListViewItem aa = new ListViewItem();
                aa.Content = a.imeŽanra;
                aa.Tag = a;
                Žanre.Items.Add(aa);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var a = Žanre.SelectedItems[0];
            var b = (ListViewItem)a;
            var cc = (Žanr)b.Tag;
            zbirka.globalniŽanri.Remove(cc);
            Žanre.Items.RemoveAt(Žanre.SelectedIndex);
            string abc = Spreminjanje.Text;
            Žanr kk = new Žanr(abc);
            ListViewItem av = new ListViewItem();
            av.Content = kk.imeŽanra;
            av.Tag = kk;
            Žanre.Items.Add(av);
            zbirka.globalniŽanri.Add(kk);
            zbirka.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string a = Dodajanje.Text;
            Žanr abc = new Žanr(a);

            ListViewItem av = new ListViewItem();
            av.Content = abc.imeŽanra;
            av.Tag = abc;
            Žanre.Items.Add(av);
            zbirka.globalniŽanri.Add(abc);
            zbirka.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var a = Žanre.SelectedItems[0];
            var b = (ListViewItem)a;
            var cc = (Žanr)b.Tag;

            if (Žanre.SelectedValue != null)
            {
                Žanre.Items.RemoveAt(Žanre.SelectedIndex);
                zbirka.globalniŽanri.Remove(cc);
                zbirka.SaveChanges();
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            DT.Interval = TimeSpan.FromSeconds(1);
            DT.Tick += DT_Tick;
            DT.Start();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            DT.Stop();
        }
    }
}
