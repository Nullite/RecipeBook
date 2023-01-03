﻿using RecipeBook.Model;
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
    internal class AddRecipeVM
    {
        private void GetFoodGroups()
        {
            foreach (var value in Enum.GetValues(typeof(FoodGroup)))
            {
                GroupToChoose.Add(new FoodGroupStruct((FoodGroup)value));
            }

        }
        public AddRecipeVM()
        {
            Recipes = RecipesDB.RecipesContext().Recipes;
            Recipe = new Recipe { Photo = "\\Resourses\\Images\\default.jpg" };
            GroupToChoose = new List<FoodGroupStruct>();
            GetFoodGroups();
        }
        private bool IsEmptyProps()
        {
            PropertyInfo[] properties = Recipe.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.Any(p => p.GetValue(Recipe, null) == null || (p.GetValue(Recipe, null)).ToString() == String.Empty);
        }
        public ObservableCollection<Recipe> Recipes { get; set; }
        public Recipe Recipe { get; set; }
        public struct FoodGroupStruct
        {
            public FoodGroupStruct(FoodGroup name) => NameGroup = name;
            public FoodGroup NameGroup { get; private set; }
        }
        public List<FoodGroupStruct> GroupToChoose { get; private set; }
        public void ChangeGroup (ComboBox changer) => Recipe.Group = ((FoodGroupStruct)changer.SelectedItem).NameGroup;
        public bool AddRecipe()
        {
            if (IsEmptyProps())
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            else
            {
                Recipes.Add(Recipe); 
                return true;
            }
        }
        public void AddIngridients()
        {
            IngridientsCRUDWindow ChangeIngridients = new IngridientsCRUDWindow(Recipe);
            ChangeIngridients.ShowDialog();
        }
    }
}
