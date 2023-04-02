using DataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using Sklad.Presentation;
using System.Data.Entity;
using Sklad.ViewModels;

namespace Sklad
{
    public static class Globals
    {

        public static SkladContext _context { get; set; }

        public static winHlavni _parent { get; set; }
        //public static GlobalsVisual _visual { get; set; } = new GlobalsVisual();

        //public static winHlavniVM _parentvm { get; set; }

        public static void Vratit()
        {

            foreach (var entity in _context.ChangeTracker.Entries())
            {
                if (entity.State == EntityState.Modified) entity.Reload();
                if (entity.State == EntityState.Added) entity.State = EntityState.Detached;
            }

        }


        public static void RollBack()
        {
       
            var changedEntries = _context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }

        }

        internal static winHlavniVM _parentvm;

        public static bool IsValid(DependencyObject parent)
        {
            if (System.Windows.Controls.Validation.GetHasError(parent))
                return false;

            // Validate all the bindings on the children
            for (int i = 0; i != VisualTreeHelper.GetChildrenCount(parent); ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (!IsValid(child)) { return false; }
            }

            return true;
        }

        public static bool HasUnsavedChanges()
        {
            return Globals._context.ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                      || e.State == EntityState.Modified
                                                      || e.State == EntityState.Deleted);
        }

        public static void UlozitData()
        {

            try
            {
                _context.SaveChanges();
                _parent.PisNaStatusBar("Saved.");
            }

            catch (DbEntityValidationException e)
            {

                String text = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    text = text + "Entita typu " + eve.Entry.Entity.GetType().Name + " ve stavu " + eve.Entry.State + " obsahuje tyto chyby ověření:" + Environment.NewLine;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        text = text + "- Vlastnost: " + ve.PropertyName + ", Chyba: " + ve.ErrorMessage + Environment.NewLine;
                    }
                }

                MessageBox.Show(text, "CHYBA", MessageBoxButton.OK, MessageBoxImage.Error);

                throw;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Nastala chyba při ukládání.\n" + ex.ToString(), "CHYBA", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }


        }


    }
}
