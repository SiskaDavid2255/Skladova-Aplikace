using DataEntity;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Sklad.ViewModels
{

    [AddINotifyPropertyChangedInterface] //automatické obnovení grafiky po změně kódu
    public class pgPrehMatVM: BaseVM
    {
        private ObservableCollection<Material> _materialyCol; // vytvoření uzavřené vlastnosti
        public ObservableCollection<Material> MaterialyCol

        { //vytvoření kolekce materiálu
            get //vytvoření vlastního get set
            {
                if (_materialyCol == null)//pokud _materialyCol je prázdná (== porovnává hodnoty)
                    _materialyCol = new ObservableCollection<Material>(Globals._context.Materialy); // naplní _materialcol novou kolekcí z databáze(= nastavuje hodnotu)
                return _materialyCol;
            }
            set
            {
                _materialyCol = value;
            }
        }

        public pgPrehMatVM()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(MaterialyCol);
            	
            view.Filter = UserFilter;

        }

        private bool UserFilter (object item)
        {
            if (String.IsNullOrEmpty(FiltrMaterialNazev))
                return true;
            else
                return ((item as Material).NazevMat.IndexOf(FiltrMaterialNazev, StringComparison.OrdinalIgnoreCase) >= 0);

        }

  
        private string _filtrMaterialNazev;
        public string FiltrMaterialNazev
        {
            get
            {
                return _filtrMaterialNazev;
            }
            set
            {
                _filtrMaterialNazev = value;
                CollectionViewSource.GetDefaultView(MaterialyCol).Refresh();
            }

        }

        public Material MaterialSelected { get; set; } //vrácení vybraného materiálu4

        public bool JeOznacenMaterial
        {
            get
            {
                return MaterialSelected != null;
            }
        }

        public enum Rezimy { Prohlizeni, Pridavani, Editace }

        private Rezimy _aktualniRezim = Rezimy.Prohlizeni;
        public Rezimy AktualniRezim
        {
            get
            {
                return _aktualniRezim;
            }
            set
            {
                _aktualniRezim = value;
                //následující řádka - příprava na to, aby nebylo možno používat menu při editaci
                //Globals._parentvm.LzePouzivatMenu = _aktualniRezim == Rezimy.Prohlizeni; 
            }


        }

        public string AktualniRezimString
        {
            get
            {
                switch (AktualniRezim)
                {
                    case Rezimy.Pridavani: return "Přidávání";
                    case Rezimy.Editace: return "Editace";
                }
                return "Prohlížení";
            }
        }


        public bool RezimPridavaniNeboEditace
        {
            get
            {
                return AktualniRezim != Rezimy.Prohlizeni;
            }
        }


    }
}

