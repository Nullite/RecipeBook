﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Model
{
    public enum FoodGroup { Супы, Салаты, Гарниры}
    public class Recipe
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public FoodGroup Group { get; set; }
    }
}