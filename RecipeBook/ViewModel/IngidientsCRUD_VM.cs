using RecipeBook.Model;
using RecipeBook.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeBook.ViewModel
{
    internal class IngidientsCRUD_VM : NotifyClass
    {
        private List<Ingridient> _ingridients;
        public string Photo { get; private set; }
        public Recipe Rec { get; private set; }
        public IngidientsCRUD_VM(Recipe rec)
        {
            Rec = rec;
            Ingridients = new List<Ingridient>();
            Cloner<Ingridient>.CloneList(rec.Ingridients, Ingridients);
            Photo = rec.Photo;
        }
        private bool isIngridientsChanged()
        {
            for (int i = 0; i < Ingridients.Count; ++i) 
            {
                if (!(Ingridients[i].Equals(Rec.Ingridients[i]))) return true;
            }
            return false;
        }
        public List<Ingridient> Ingridients
        {
            get => _ingridients;
            set
            {
                _ingridients = value;
                OnPropertyChanged(nameof(IngridientsString));
            }
        }
        public string IngridientsString
        {
            get
            {
                string ingridients = "";
                Ingridients?.ForEach(i =>
                {
                    ingridients += $"{i.Name} {i.Quantity} {i.Units}\n";
                });
                return ingridients;
            }
        }
        public void UpdateIngridients()
        {
            OnPropertyChanged(nameof(IngridientsString));
        }
        public void SaveIngridients()
        {
            if (isIngridientsChanged())
            {
                if (MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Rec.Ingridients = Ingridients.Count > 0 ? Ingridients : null;
                }
            }            
        }
    }
}
