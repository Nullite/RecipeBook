using RecipeBook.Model;
using RecipeBook.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RecipeBook.ViewModel
{
    public class RecipesVM : NotifyClass
    {
        private RecipesDB context;
        public RecipesVM()
        {
            context = RecipesDB.RecipesContext();
            Recipes = context.Recipes.ToList();
        }
        public string SearchText { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Recipe> SelectedRecipes { get; set; }
        public void Delete()
        {
            foreach (var o in SelectedRecipes)
            {
                context.Recipes.Remove(o);
            }
            Recipes = context.Recipes.ToList();
            SelectedRecipes.Clear();
            OnPropertyChanged("Recipes");
        }
        public void Find()
        {
            Recipes = context.Recipes.Where(r => SearchText == null 
            || r.Name.ToLower().Contains(SearchText.ToLower())
            || r.Group.ToString().ToLower().Contains(SearchText.ToLower())).ToList();
            OnPropertyChanged("Recipes");
        }
        public Recipe FindRecipe(string Name)
        {
            return Recipes.FirstOrDefault(x => x.Name == Name);
        }
    }
}
