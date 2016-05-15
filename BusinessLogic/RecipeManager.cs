using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessObjects;
using DataAccess;

namespace BusinessLogic
{
    public class RecipeManager
    {
        public List<Recipe> GetRecipeList()
        {

            try
            {
                var recipeList = RecipeAccessor.GetRecipeList();

                if (recipeList.Count > 0)
                {
                    return recipeList;
                }
                else
                {
                    throw new ApplicationException("No recipes found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Recipe GetRecipeStats(string recipeID)
        {
            try
            {
                var recipe = RecipeAccessor.GetRecipeStats(recipeID);

                if (recipe.RecipeID != null)
                {
                    return recipe;
                }
                else
                {
                    throw new ApplicationException("No recipes found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<String> GetRecipeNames()
        {

            try
            {
                List<String> recipeList = RecipeAccessor.GetRecipeNames();

                if (recipeList.Count > 0)
                {
                    return recipeList;
                }
                else
                {
                    throw new ApplicationException("No recipes found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<String> GetRecipeNamesAndILVL()
        {

            try
            {
                List<String> recipeList = RecipeAccessor.GetRecipeNamesAndILVL();

                if (recipeList.Count > 0)
                {
                    return recipeList;
                }
                else
                {
                    throw new ApplicationException("No recipes found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RecipeCatalyst> GetRecipeCatalystListByID(string name)
        {
            try
            {
                var catalystList = RecipeAccessor.GetRecipeCatalystListByID(name);

                if (catalystList.Count > 0)
                {
                    return catalystList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RecipeIngredient> GetRecipeIngredientListByID(string name)
        {
            try
            {
                var ingredientList = RecipeAccessor.GetRecipeIngredientListByID(name);

                if (ingredientList.Count > 0)
                {
                    return ingredientList;
                }
                else
                {
                    throw new ApplicationException("No records found.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Ingredient GetIngredientInfoByID(string ingredientID)
        {
            try
            {
                var ingredient = RecipeAccessor.GetIngredientInfoByID(ingredientID);

                if (ingredient.IngredientID != null)
                {
                    return ingredient;
                }
                else
                {
                    throw new ApplicationException("Could not retrieve ingredient information.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
