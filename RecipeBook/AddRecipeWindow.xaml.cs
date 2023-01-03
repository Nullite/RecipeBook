using RecipeBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeBook
{
    /// <summary>
    /// Логика взаимодействия для AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        AddRecipeVM _vm;
        public AddRecipeWindow()
        {
            InitializeComponent();
            _vm= new AddRecipeVM();
            DataContext= _vm;
        }

        private void ChangeGroup(object sender, SelectionChangedEventArgs e) => _vm.ChangeGroup(sender as ComboBox);

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            if (_vm.AddRecipe()) Close();
        }

        private void AddIngridients(object sender, RoutedEventArgs e) => _vm.AddIngridients();
    }
}
