using RecipeBook.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace RecipeBook.Model
{
    public class RecipesDB
    {
        private static ObservableCollection<Recipe> _recipes;
        private static RecipesDB _instance;
        private RecipesDB()
        {
            Recipes = new ObservableCollection<Recipe>()
            {
                new Recipe() {Name = "Суп Харчо", Group = FoodGroup.Супы, Photo = "\\Resourses\\Images\\harcho.jpg"},
                new Recipe() {Name = "Крем-Суп", Group = FoodGroup.Супы, Photo = "\\Resourses\\Images\\cream-soup.jpg"},
                new Recipe() {Name = "Салат Греческий", Group = FoodGroup.Салаты, Photo = "\\Resourses\\Images\\salat_Grecheskiy.jpg"},
                new Recipe() {Name = "Салат цезарь с курицей", Group = FoodGroup.Салаты, Photo = "\\Resourses\\Images\\cesar_s_kuricey.jpg"},
                new Recipe() {Name = "Шашлык из карбонада на кости", Group = FoodGroup.Гарниры, Photo = "\\Resourses\\Images\\shashlik.jpg"},
                new Recipe() {Name = "Курица запеченая в духовке", Group = FoodGroup.Гарниры, Photo = "\\Resourses\\Images\\kurica.jpeg"},
            };
        }
        public ObservableCollection<Recipe> Recipes { get => _recipes; private set => _recipes = value; }
        public static RecipesDB RecipesContext()
        {
            if (_instance == null) _instance = new RecipesDB();
            return _instance;
        }
    }
}
