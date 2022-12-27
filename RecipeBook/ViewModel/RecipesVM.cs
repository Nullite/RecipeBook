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
    public class RecipesVM : NotifyClass
    {
        
        public RecipesVM()
        {
            RecipesDB context = RecipesDB.RecipesContext();
            Recipes = context.Recipes;
        }
        public ObservableCollection<Recipe> Recipes { get; set; }
    }
}
