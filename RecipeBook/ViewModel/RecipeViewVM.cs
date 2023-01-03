using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.ViewModel
{
    
    internal class RecipeViewVM
    {
        public Recipe Rec { get; set; }
        public string Ingridients
        {
            get
            {
                string ingridients = "";
                Rec.Ingridients?.ForEach(i =>
                {
                    ingridients += $"{i.Name} {i.Quantity} {i.Units}\n";
                });
                return ingridients;
            }
        }
    }
}
