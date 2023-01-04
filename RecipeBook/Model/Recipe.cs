using RecipeBook.Settings;
using System;
using System.Collections.Generic;

namespace RecipeBook.Model
{
    public enum FoodGroup { Супы, Салаты, Гарниры}
    public class Recipe: ICloneable
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int CookTime { get; set; }
        public List<Ingridient> Ingridients { get; set; } 
        public FoodGroup Group { get; set; }
        public object Clone()
        {
            Recipe Recipe = (Recipe)MemberwiseClone();
            List<Ingridient> temp = new List<Ingridient>();
            Cloner<Ingridient>.CloneList(Ingridients, temp);
            Recipe.Ingridients = temp;
            return Recipe;
        }
        public override int GetHashCode()
        {
            int hash = (Name, Photo, Description, CookTime, Group).GetHashCode();
            if (Ingridients!=null) foreach (var ing in Ingridients) hash = hash * 31 + ing.GetHashCode();
            return hash;
        }
        public override bool Equals(object obj) => GetHashCode() == obj.GetHashCode();
    }
}
