using RecipeBook.Model;
using RecipeBook.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Ingridients = rec.Ingridients != null 
                ? new List<Ingridient>(rec.Ingridients) 
                : new List<Ingridient>();
            Photo = rec.Photo;
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
        public void SaveIngridients() => Rec.Ingridients = Ingridients.Count > 0 ? Ingridients : null;
    }
}
