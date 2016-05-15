using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace BusinessObjects
{
    public class RecipeIngredient
    {
        //public string RecipeID { get; set; }
        public string IngredientID { get; set; }
        public int Quantity { get; set; }

        /*public RecipeIngredient(string recipeID,
                                string ingredientID,
                                int quantity)
        {
            RecipeID = recipeID;
            IngredientID = ingredientID;
            Quantity = quantity;
        }*/

        public RecipeIngredient() { }

        public RecipeIngredient(string ingredientID,
                                int quantity)
        {
            IngredientID = ingredientID;
            Quantity = quantity;
        }
    }
}
