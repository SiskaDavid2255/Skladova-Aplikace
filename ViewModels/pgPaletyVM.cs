using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using PropertyChanged;

namespace Sklad.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class pgPaletyVM : BaseVM
    {

        public Paleta PaletaSelected { get; set; }

        public bool JeOznacenaPaleta => PaletaSelected != null;

    }


}
