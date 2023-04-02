using DataEntity;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sklad.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class BaseVM : BaseModel
    {


        private ObservableCollection<MernaJednotka> _merneJednotkyCol;
        public ObservableCollection<MernaJednotka> MerneJednotkyCol
        {
            get
            {
                if (_merneJednotkyCol == null)
                    _merneJednotkyCol = new ObservableCollection<MernaJednotka>(Globals._context.MerneJednotky);
                return _merneJednotkyCol;
            }
            set
            {
                _merneJednotkyCol = value;

            }

         
        }

        private ObservableCollection<Material> _materialyCol;
        public ObservableCollection<Material> MaterialyCol

        { 
            get
            {
                if (_materialyCol == null)
                    _materialyCol = new ObservableCollection<Material>(Globals._context.Materialy);
                return _materialyCol;
            }
            set
            {
                _materialyCol = value;
            }
        }

        private ObservableCollection<PaletaTyp> _paletaTypCol;
        public ObservableCollection<PaletaTyp> PaletaTypCol

        {
            get
            {
                if (_paletaTypCol == null)
                    _paletaTypCol = new ObservableCollection<PaletaTyp>(Globals._context.PaletyTypy);
                return _paletaTypCol;
            }
            set
            {
                _paletaTypCol = value;
            }
        }

        private ObservableCollection<PaletaStav> _paletaStavyCol;
        public ObservableCollection<PaletaStav> PaletaStavyCol

        {
            get
            {
                if (_paletaStavyCol == null)
                    _paletaStavyCol = new ObservableCollection<PaletaStav>(Globals._context.PaletyStavy);
                return _paletaStavyCol;
            }
            set
            {
                _paletaStavyCol = value;
            }
        }

        private ObservableCollection<Paleta> _paletyCol;
        public ObservableCollection<Paleta> PaletyCol
        {
            get
            {

                if (_paletyCol == null)
                    _paletyCol = new ObservableCollection<Paleta>(Globals._context.Palety);
                return _paletyCol;
            }
            set
            {
                _paletyCol = value;

            }
        }

    }
}
