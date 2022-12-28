using RecipeBook.Model;
using RecipeBook.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.ViewModel
{
    internal class RecipeChangeVM : NotifyClass
    {
        private Recipe _rec;
        public Recipe Rec 
        {
            get => _rec;
            set
            { 
                _rec = value;
                OnPropertyChanged("Rec");
            }
        }
        public RecipeChangeVM(Recipe Rec) => this.Rec = Rec;
    }
}
