using DataEntity;
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
using System.Data.Entity;

namespace Sklad.Presentation
{
    /// <summary>
    /// Interaction logic for pgPrehMat.xaml
    /// </summary>
    public partial class pgPrehMat : Page
    {
        public pgPrehMatVM _datacontext;
        private SkladContext _context = Globals._context;

        public pgPrehMat()
        {
            InitializeComponent();
            _datacontext = new pgPrehMatVM();
            this.DataContext = _datacontext;

        }

        private void DgMaterialy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEditMat_Click(object sender, RoutedEventArgs e)
        {
            _datacontext.AktualniRezim = pgPrehMatVM.Rezimy.Editace;
        }

        private void PotvrditCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Globals.IsValid(gbLeva);
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // _context.SaveChanges();
            Globals.UlozitData();
            _datacontext.AktualniRezim = pgPrehMatVM.Rezimy.Prohlizeni;
        }


        private void btnAddMat_Click(object sender, RoutedEventArgs e)
        {
            //nová instance materiálu
            Material material = new Material();

            //výchozí datum je dnešní
            material.Datum = DateTime.Today;

            //přidat tuto instaci do kontextu (databáze)
            _context.Materialy.Add(material);

            //přidat ji i do kolekce
            _datacontext.MaterialyCol.Add(material);

            //nový materiál je vybraným materiálem
            _datacontext.MaterialSelected = material;
            //nastavení režimu
            _datacontext.AktualniRezim = pgPrehMatVM.Rezimy.Pridavani;
            //fokus komponenty na vybraný materiál
            dgMaterialy.ScrollIntoView(_datacontext.MaterialSelected);

        }

        private void btnStrono_Click(object sender, RoutedEventArgs e)
        {
            if (_datacontext.AktualniRezim == pgPrehMatVM.Rezimy.Pridavani)
            {
                _context.Entry(_datacontext.MaterialSelected).State = EntityState.Detached;
                _datacontext.MaterialyCol.Remove(_datacontext.MaterialSelected);
                _datacontext.MaterialSelected = null;
            }

            if (_datacontext.AktualniRezim == pgPrehMatVM.Rezimy.Editace)
            {
                Globals.RollBack();
            }


            _datacontext.AktualniRezim = pgPrehMatVM.Rezimy.Prohlizeni;

        }

    }
}
