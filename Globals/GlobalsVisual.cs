using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class GlobalsVisual
    {

        public MetroDialogSettings metrodialogsettingsAnoNe { get; set; }
        public MetroDialogSettings metrodialogsettingsOKStorno { get; set; }
        public MetroDialogSettings metrodialogsettingsInfoBlack { get; set; }

        public GlobalsVisual()
        {
            metrodialogsettingsAnoNe = new MetroDialogSettings();
            metrodialogsettingsAnoNe.NegativeButtonText = "Ne";
            metrodialogsettingsAnoNe.AffirmativeButtonText = "Ano";

            metrodialogsettingsOKStorno = new MetroDialogSettings();
            metrodialogsettingsOKStorno.NegativeButtonText = "Storno";
            metrodialogsettingsOKStorno.AffirmativeButtonText = "OK";

            metrodialogsettingsInfoBlack = new MetroDialogSettings();

            metrodialogsettingsInfoBlack.ColorScheme = MetroDialogColorScheme.Inverted;
            metrodialogsettingsInfoBlack.AffirmativeButtonText = "OK";

        }

    }
}
