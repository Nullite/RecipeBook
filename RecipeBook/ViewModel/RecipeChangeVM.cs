using RecipeBook.Model;
using RecipeBook.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RecipeBook.ViewModel
{
    internal class RecipeChangeVM : NotifyClass
    {
        private int _index;
        private bool IsEmptyProps()
        {
            PropertyInfo[] properties = СhangeRec.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.Any(p => p.GetValue(СhangeRec, null) == null || (p.GetValue(СhangeRec, null)).ToString() == String.Empty);
        }
        public Recipe Rec { get; set; }
        public Recipe СhangeRec { get; set; }
        public struct FoodGroupStruct
        {
            public FoodGroupStruct(FoodGroup name) => NameGroup = name;
            public FoodGroup NameGroup { get; private set; }
        }
        public List<FoodGroupStruct> GroupToChoose { get; private set; }
        public RecipeChangeVM(Recipe Rec)
        {
            this.Rec = Rec;
            СhangeRec = new Recipe();
            СhangeRec.Ingridients = new List<Ingridient>(Rec.Ingridients);
            СhangeRec.Name = Rec.Name;
            СhangeRec.Description = Rec.Description;
            СhangeRec.Photo = Rec.Photo;
            СhangeRec.CookTime = Rec.CookTime;
            СhangeRec.Group = Rec.Group;
            GroupToChoose = new List<FoodGroupStruct>();
            GetFoodGroups();
        }

        public bool ChangeRecipe()
        {
            if (IsEmptyProps())
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            else
            {
                Rec.Name = СhangeRec.Name;
                Rec.Description = СhangeRec.Description;
                Rec.CookTime = СhangeRec.CookTime;
                Rec.Group = СhangeRec.Group;
                Rec.Ingridients = СhangeRec.Ingridients;
                return true;
            }
            
        }
        private void GetFoodGroups()
        {
            foreach(var value in Enum.GetValues(typeof(FoodGroup)))
            {
                GroupToChoose.Add(new FoodGroupStruct((FoodGroup)value));
            }
            
        }
        public int SelectedIndex
        {
            get => _index = GroupToChoose.FindIndex(i => i.NameGroup == Rec.Group);
            set => _index = value;
        }
        public string Ingridients
        {
            get
            {
                string ingridients = "";
                Rec.Ingridients.ForEach(i =>
                {
                    ingridients += $"{i.Name} {i.Quantity} {i.Units}\n";
                });
                return ingridients;
            }
        }
        public void ChooseFoodGroup(ComboBox changer) => СhangeRec.Group = ((FoodGroupStruct)changer.SelectedItem).NameGroup;
        public void ChangeIngridients()
        {
            IngridientsCRUDWindow ChangeIngridients = new IngridientsCRUDWindow(СhangeRec);
            ChangeIngridients.ShowDialog();
        }
    }
}
