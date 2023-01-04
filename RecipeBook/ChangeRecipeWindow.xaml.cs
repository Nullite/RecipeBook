using RecipeBook.Model;
using RecipeBook.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace RecipeBook
{
    /// <summary>
    /// Логика взаимодействия для ChangeRecipeWindow.xaml
    /// </summary>
    public partial class ChangeRecipeWindow : Window
    {
        RecipeChangeVM _vm;
        public ChangeRecipeWindow(Recipe Rec)
        {
            InitializeComponent();
            _vm = new RecipeChangeVM(Rec);
            DataContext = _vm;
        }

        private void UpdateRecipe(object sender, RoutedEventArgs e)
        {
            if (_vm.ChangeRecipe()) Close();
        }
        private void ChangeFoodGroup(object sender, SelectionChangedEventArgs e) => _vm.ChooseFoodGroup(sender as ComboBox);

        private void ChangeIngridients(object sender, RoutedEventArgs e)
        {
            _vm.ChangeIngridients();
        }
    }
}
