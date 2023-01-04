using RecipeBook.Model;
using RecipeBook.Settings;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace RecipeBook.ViewModel
{
    public class RecipesVM : NotifyClass
    {
        private RecipesDB context;
        public RecipesVM()
        {
            context = RecipesDB.RecipesContext();
            Recipes = new ObservableCollection<Recipe>(context.Recipes);
        }
        public string SearchText { get; set; }
        public ObservableCollection<Recipe> Recipes { get; set; }
        public List<Recipe> SelectedRecipes { get; set; }
        public void Delete()
        {
            foreach (var o in SelectedRecipes)
            {
                context.Recipes.Remove(o);
            }
            Recipes = context.Recipes;
            SelectedRecipes.Clear();
            OnPropertyChanged("Recipes");
        }
        public void Find()
        {
            Recipes.Clear();
            foreach (var r in context.Recipes)
            {
                if (SearchText == null 
                    || r.Name.ToLower().Contains(SearchText.ToLower()) 
                    || r.Group.ToString().ToLower().Contains(SearchText.ToLower()))
                Recipes.Add(r);
            }
            OnPropertyChanged("Recipes");
        }
        public Recipe FindRecipe(string Name) => Recipes.FirstOrDefault(x => x.Name == Name);

        public void Change(ListView RecipesLV)
        {
            SelectedRecipes = RecipesLV.SelectedItems.Cast<Recipe>().ToList();
            Recipe Rec = SelectedRecipes.FirstOrDefault();
            if (Rec != null)
            {
                ChangeRecipeWindow change = new ChangeRecipeWindow(Rec);
                change.ShowDialog();
            }
            Recipes = new ObservableCollection<Recipe>(context.Recipes);
            OnPropertyChanged("Recipes");
        }
        public void Add()
        {
            AddRecipeWindow add = new AddRecipeWindow();
            add.ShowDialog();
            Recipes = new ObservableCollection<Recipe>(context.Recipes);
            OnPropertyChanged("Recipes");
        }
    }
}
