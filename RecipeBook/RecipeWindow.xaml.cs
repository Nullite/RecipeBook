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
    /// Логика взаимодействия для RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        private RecipeViewVM _vm;
        public RecipeWindow(Recipe Rec)
        {
            InitializeComponent();
            _vm = new RecipeViewVM { Rec = Rec };
            DataContext = _vm;
        }
    }
}
