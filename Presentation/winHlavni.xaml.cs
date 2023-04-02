using DataEntity;
using MahApps.Metro.Controls;
using Sklad.ViewModels;
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

namespace Sklad.Presentation
{
    /// <summary>
    /// Interaction logic for winHlavni.xaml
    /// </summary>
    public partial class winHlavni : MetroWindow
    {
        public winHlavni()
        {
            Globals._context = new SkladContext();
            Globals._parent = this;

            InitializeComponent();
            frame.Navigate(new pgPrehMat());
        }

        private void MiPrehMat_Click(object sender, RoutedEventArgs e)
        {
            if (!TestNaValiditu()) return;
            if (!(frame.Content is pgPrehMat))
            {
                frame.Navigate(new pgPrehMat());
            }
        }
        private void miPalety_Click(object sender, RoutedEventArgs e)
        {
            if (!TestNaValiditu()) return;
            if (!(frame.Content is pgPalety))
            {
                frame.Navigate(new pgPalety());
            }

        }
        public void PisNaStatusBar(string co)
        {
            DateTime ted = DateTime.Now;
            tbStatusBar.Text = ted.ToLongTimeString() + "> " + co;
        }

        /*private void miPalety_Click(object sender, RoutedEventArgs e)
        {

            if (!(frame.Content is pgPalety))
            {
                frame.Navigate(new pgPalety());
            }
        }*/

        private SkladContext _context = Globals._context;
        private winHlavniVM _datacontext;

        private void VstupniNastaveni()
        {
            Globals._context = new SkladContext();
            Globals._parent = this;

            _datacontext = new winHlavniVM();
            Globals._parentvm = _datacontext;
            this.DataContext = _datacontext;

            _context = Globals._context;

        }

        private bool TestNaValiditu()
        {
            if (frame.Content is pgPalety)
            {

                Page pg = (Page)frame.Content;


                if (!Globals.IsValid(pg))
                {
                    MessageBox.Show("Data nejsou validní. Před pokračováním je opravte.", "UPOZORNĚNÍ", MessageBoxButton.OK, MessageBoxImage.Warning);

                    return false;
                }

                if (Globals.HasUnsavedChanges())
                {
                    if (MessageBox.Show("Chcete uložit provedené změny?", "OTÁZKA", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Globals.UlozitData();
                    }
                    else
                    {
                        Globals.RollBack();
                    }
                }

            }
            return true;

        }

        private void miUloz_Click(object sender, RoutedEventArgs e)
        {
            if (isAllValid()) Globals.UlozitData();
        }
        public bool isAllValid(bool silent = false)
        {

            if (!Globals.IsValid(this))
            {
                if (!silent) MessageBox.Show
               ("Data obsahují chyby, před tím než bude možno pokračovat, je potřeba je opravit.", "CHYBA OVĚŘENÍ", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            return true;
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            frame.NavigationService.RemoveBackEntry();
        }


    }
}
