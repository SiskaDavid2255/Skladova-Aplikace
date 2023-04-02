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
using DataEntity;
using Sklad.ViewModels;

namespace Sklad.Presentation
{
    /// <summary>
    /// Interaction logic for pgPalety.xaml
    /// </summary>
    public partial class pgPalety : Page
    {

        private pgPaletyVM _datacontext;
        public pgPalety()
        {
            InitializeComponent();

            _datacontext = new pgPaletyVM();
            this.DataContext = _datacontext;
            // Globals._parentvm.LzeUkladat = true;
        }

        private void btnAddPal_Click(object sender, RoutedEventArgs e)
        {
            Paleta pal = new Paleta();

            if (_datacontext.PaletaTypCol.Count > 1) pal.PaletaStav = _datacontext.PaletaStavyCol[1]; //vychozi vyskladnena
            if (_datacontext.PaletaTypCol.Count > 0) pal.PaletaTyp = _datacontext.PaletaTypCol[0];


            Globals._context.Palety.Add(pal);
            _datacontext.PaletyCol.Add(pal);
            _datacontext.PaletaSelected = pal;
            dgPalety.ScrollIntoView(_datacontext.PaletaSelected);

            var column = dgPalety.Columns[3];
            var cellToEdit = new DataGridCellInfo(pal, column);

            dgPalety.CurrentCell = cellToEdit;

            dgPalety.BeginEdit();

        }

        private void btnDelPal_Click(object sender, RoutedEventArgs e)
        {
            Paleta pal = _datacontext.PaletaSelected;



            if (MessageBox.Show("Opravdu chcete vymazat paletu " + pal.PaletaId + "?", "UPOZORNĚNÍ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _datacontext.PaletyCol.Remove(pal);
                Globals._context.Palety.Remove(pal);
            }


        }

        private void DgPalety_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
