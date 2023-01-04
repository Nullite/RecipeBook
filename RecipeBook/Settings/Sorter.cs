using RecipeBook.Model;
using System.Collections.ObjectModel;
using System.Linq;
namespace RecipeBook.Settings
{
    public static class Sorter
    {
        public static void Sort(ref ObservableCollection<Recipe> recipes)
        {
            var sorted = from recipe in recipes
                    orderby recipe.Group.ToString(), recipe.Name
                    select recipe;
            recipes = new ObservableCollection<Recipe>(sorted);
        }
    }
}
