using System;

namespace RecipeBook.Model
{
    public class Ingridient : ICloneable
    {
        public string Name { get; set; }
        public string Units { get; set; }
        public float Quantity { get; set; }
        public object Clone() => MemberwiseClone();
        public override int GetHashCode() => (Name, Units, Quantity).GetHashCode();
        public override bool Equals(object obj) => GetHashCode() == obj.GetHashCode();
    }
}
