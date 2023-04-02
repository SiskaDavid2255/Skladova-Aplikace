using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Sklad.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class winHlavniVM
    {

        public bool LzeUkladat { get; set; } = false;

        public bool LzePouzivatMenu { get; set; } = true;

    }


}
