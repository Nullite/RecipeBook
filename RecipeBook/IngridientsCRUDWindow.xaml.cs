using RecipeBook.Model;
using RecipeBook.ViewModel;
using System;
using System.Windows;

namespace RecipeBook
{
    /// <summary>
    /// Логика взаимодействия для IngridientsCRUDWindow.xaml
    /// </summary>
    public partial class IngridientsCRUDWindow : Window
    {
        IngidientsCRUD_VM _vm;
        public IngridientsCRUDWindow(Recipe Rec)
        {
            InitializeComponent();
            _vm = new IngidientsCRUD_VM(Rec);
            DataContext= _vm;
        }

        private void UpdateIngridientsString(object sender, EventArgs e)
        {
            _vm.UpdateIngridients();
        }

        private void SaveIngridients(object sender, RoutedEventArgs e)
        {
            _vm.SaveIngridients();
            Close();
        }
    }
}
