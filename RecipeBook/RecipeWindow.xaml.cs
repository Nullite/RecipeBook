using RecipeBook.Model;
using RecipeBook.ViewModel;
using System.Windows;


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
