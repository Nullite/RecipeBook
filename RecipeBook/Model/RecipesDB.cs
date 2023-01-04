using RecipeBook.Settings;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
                new Recipe()
                {
                    Name = "Суп Харчо",
                    Group = FoodGroup.Супы,
                    Photo = "\\Resourses\\Images\\harcho.jpg",
                    CookTime = 40,
                    Description = "Суп харчо готовится исключительно из говядины, попробуйте этот простой рецепт.",
                    Ingridients = new List<Ingridient>()
                    {
                        new Ingridient {Name = "Говядина", Quantity = 1, Units = "кг."},
                        new Ingridient {Name = "Рис", Quantity = 1, Units = "ст."},
                        new Ingridient {Name = "Томатная Паста", Quantity = 1, Units = "ст. л."},
                        new Ingridient {Name = "Лук", Quantity = 3, Units = "шт."},
                        new Ingridient {Name = "Соль", Quantity = 0.5f, Units = "ч.л"},
                    }
                },
                new Recipe() 
                {
                    Name = "Крем-Суп", 
                    Group = FoodGroup.Супы, 
                    Photo = "\\Resourses\\Images\\cream-soup.jpg",
                    CookTime = 45,
                    Description = "Если одним из ваших любимых продуктов является сыр, " +
                    "то одним из самых любимых блюд обязательно станет этот сырный суп " +
                    "с овощами и зеленью. Готовим сырный крем-суп из плавленых сырков.",
                    Ingridients= new List<Ingridient>()
                    {
                        new Ingridient {Name = "Сыр Плавленый", Quantity = 90, Units = "г."},
                        new Ingridient {Name = "Картофель", Quantity = 250, Units = "г."},
                        new Ingridient {Name = "Лук", Quantity = 70, Units = "г."},
                        new Ingridient {Name = "Морковь", Quantity = 100, Units = "г."},
                        new Ingridient {Name = "Сливки", Quantity = 120, Units = "мл."},
                        new Ingridient {Name = "Масло сливочное", Quantity = 30, Units = "г."},
                        new Ingridient {Name = "Укроп", Quantity = 30, Units = "г."},
                        new Ingridient {Name = "Вода", Quantity = 200, Units = "мл."},
                    }
                },
                new Recipe() 
                {
                    Name = "Салат Греческий", 
                    Group = FoodGroup.Салаты, 
                    Photo = "\\Resourses\\Images\\salat_Grecheskiy.jpg",
                    CookTime = 30,
                    Description = "Рецепт классического греческого салата, отличающегося своим великолепным вкусом и пользой!",
                    Ingridients = new List<Ingridient>()
                    {
                        new Ingridient {Name = "Помидор", Quantity = 2, Units = "шт."},
                        new Ingridient {Name = "Огурец", Quantity = 2, Units = "шт."},
                        new Ingridient {Name = "Лук", Quantity = 1, Units = "шт."},
                        new Ingridient {Name = "Перец Болгарский", Quantity = 2, Units = "шт."},
                        new Ingridient {Name = "Сыр Фета", Quantity = 200, Units = "г."},
                        new Ingridient {Name = "Оливки", Quantity = 100, Units = "г."},
                        new Ingridient {Name = "Лимон", Quantity = 0.5f, Units = "шт."},
                        new Ingridient {Name = "Соль", Quantity = 1, Units = "ч.л."},
                    }
                },
                new Recipe() 
                {
                    Name = "Салат цезарь с курицей", 
                    Group = FoodGroup.Салаты,
                    Photo = "\\Resourses\\Images\\cesar_s_kuricey.jpg",
                    CookTime = 60,
                    Description = "Один из рецептов салата Цезарь - с курицей, помидорами и яйцами - не для заправки, " +
                    "а просто отварными. Ярче и сытнее. Но обязательно салат с сухариками." +
                    " И масляная заправка для салата Цезарь с чесноком и лимонным соком.",
                    Ingridients = new List<Ingridient>()
                    {
                        new Ingridient {Name = "Грудка куриная", Quantity = 250, Units = "г."},
                        new Ingridient {Name = "сыр твёрдый", Quantity = 70, Units = "г."},
                        new Ingridient {Name = "батон белый", Quantity = 100, Units = "г."},
                        new Ingridient {Name = "салат зеленый", Quantity = 100, Units = "г."},
                        new Ingridient {Name = "Помидоры Черри", Quantity = 10, Units = "шт."},
                        new Ingridient {Name = "Соус Цезарь", Quantity = 150, Units = "г."},
                    }
                },
                new Recipe() 
                {
                    Name = "Шашлык из карбонада на кости",
                    Group = FoodGroup.Гарниры,
                    Photo = "\\Resourses\\Images\\shashlik.jpg",
                    CookTime = 80,
                    Description = "Очень вкусное, сочное и ароматное мясо, " +
                    "запечённое в углях на мангале. Автор назвал это блюдо \"Охотничий привал\". " +
                    "Как говорит одна моя знакомая: \"Ничего вкуснее в жизни не пробовала!\".",
                    Ingridients = new List<Ingridient>()
                    {
                        new Ingridient {Name = "Карбонад на кости", Quantity = 1, Units = "кг."},
                        new Ingridient {Name = "Соус соевый", Quantity = 70, Units = "г."},
                        new Ingridient {Name = "Соль", Quantity = 1, Units = " Ст.л."},
                        new Ingridient {Name = "Лук", Quantity = 200, Units = "г."},
                    }
                },
                new Recipe() 
                {
                    Name = "Курица запеченая в духовке",
                    Group = FoodGroup.Гарниры, 
                    Photo = "\\Resourses\\Images\\kurica.jpeg",
                    CookTime = 80,
                    Description = "Курица, запеченная целиком, очень эффектное горячее блюдо, при этом не требующее больших усилий в приготовлении.",
                    Ingridients = new List<Ingridient>()
                    {
                        new Ingridient {Name = "Курица тушка", Quantity = 1, Units = "кг."},
                        new Ingridient {Name = "Соус соевый", Quantity = 70, Units = "г."},
                        new Ingridient {Name = "Соль", Quantity = 1, Units = " Ст.л."},
                        new Ingridient {Name = "Лук", Quantity = 200, Units = "г."},
                        new Ingridient {Name = "Перец", Quantity = 50, Units = "г."},
                    }
                },
            };
        }
        public ObservableCollection<Recipe> Recipes 
        { 
            get
            {
                Sorter.Sort(ref _recipes);
                return _recipes;
            }
            private set => _recipes = value; }
        public static RecipesDB RecipesContext()
        {
            if (_instance == null) _instance = new RecipesDB();
            return _instance;
        }
        public void ChangeRecipe(Recipe oldRec, Recipe newRec)
        {
            Recipes.Add(newRec);
            Recipes.Remove(oldRec);           
        }
    }
}
