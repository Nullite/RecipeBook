using RecipeBook.Model;
using RecipeBook.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            return properties.Any(p => p.GetValue(СhangeRec, null) == null
            || (p.GetValue(СhangeRec, null)).ToString() == String.Empty
            || (p.GetValue(СhangeRec) is List<Ingridient>) && (p.GetValue(СhangeRec) as List<Ingridient>).Count == 0);
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
            СhangeRec = (Recipe)Rec.Clone();
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
                if (MessageBox.Show("Сохранить изменения?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) RecipesDB.RecipesContext().ChangeRecipe(Rec, СhangeRec);
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
