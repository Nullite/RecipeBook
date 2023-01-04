using RecipeBook.Model;
using RecipeBook.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace RecipeBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecipesVM _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new RecipesVM();
            DataContext= _vm;
        }
        private void DeleteRecipe(object sender, RoutedEventArgs e)
        {
            _vm.SelectedRecipes = RecipesLV.SelectedItems.Cast<Recipe>().ToList();
            _vm.Delete();
        }
        private void OpenRecipe(object sender, MouseButtonEventArgs e)
        {
            object source = e.OriginalSource;
            if ((source is TextBlock))
            {
                Recipe Rec = _vm.FindRecipe((source as TextBlock).Text);
                RecipeWindow recipe = new RecipeWindow(Rec);
                recipe.ShowDialog();
            }
            else return;            
        }
        private void FindOrders(object sender, RoutedEventArgs e) => _vm.Find();

        private void ChangeRecipe(object sender, RoutedEventArgs e)
        {
            _vm.Change(RecipesLV);           
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            _vm.Add();
        }
    }
}
