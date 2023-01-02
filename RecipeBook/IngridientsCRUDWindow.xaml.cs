using RecipeBook.Model;
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
