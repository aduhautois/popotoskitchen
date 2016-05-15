using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Ingredient
    {
        public string IngredientID { get; set; }
        public int LocationID { get; set; }
        public int ItemLevel { get; set; }
        public bool Cooking { get; set; }
        public bool MobDrop { get; set; }
        public bool Fishing { get; set; }
        public bool Vendor { get; set; }
        public string LocationName { get; set; }
        public string LocationLocale { get; set; }
        public int LocationLevel { get; set; }
        public string Coordinates { get; set; }

        public Ingredient() { }

        public Ingredient(string ingredientID,
                          int locationID,
                          int itemLevel,
                          bool cooking,
                          bool mobdrop,
                          bool fishing,
                          bool vendor,
                          string locationName,
                          string locationLocale,
                          int locationLevel,
                          string coordinates)
        {
            IngredientID = ingredientID;
            LocationID = locationID;
            ItemLevel = itemLevel;
            Cooking = cooking;
            MobDrop = mobdrop;
            Fishing = fishing;
            Vendor = vendor;
            LocationName = locationName;
            LocationLocale = locationLocale;
            LocationLevel = locationLevel;
            Coordinates = coordinates;
        }
    }
}
