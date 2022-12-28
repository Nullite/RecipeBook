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

        private void UpdateName(object sender, DataTransferEventArgs e)
        {
            _vm.Rec.Name = (sender as TextBox).Text;

        }
    }
}
