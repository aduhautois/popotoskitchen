using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class RecipeAccessor
    {
        public static List<Recipe> GetRecipeList()
        {
            var recipeList = new List<Recipe>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_recipe_list";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Recipe currentRecipe = new Recipe()
                        {
                            RecipeID = reader.GetString(0),
                        };

                        recipeList.Add(currentRecipe);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return recipeList;
        }

        public static Recipe GetRecipeStats(string recipeID)
        {
            var recipe = new Recipe();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_recipe_stats_by_id";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RecipeID", recipeID);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        recipe.RecipeID = rdr.GetString(0);
                        recipe.ItemLevel = rdr.GetInt32(1);
                        recipe.Mind = rdr.GetDecimal(2);
                        recipe.MindStack = rdr.GetInt32(3);
                        recipe.Acc = rdr.GetDecimal(4);
                        recipe.AccStack = rdr.GetInt32(5);
                        recipe.Crit = rdr.GetDecimal(6);
                        recipe.CritStack = rdr.GetInt32(7);
                        recipe.Det = rdr.GetDecimal(8);
                        recipe.DetStack = rdr.GetInt32(9);
                        recipe.Spell = rdr.GetDecimal(10);
                        recipe.SpellStack = rdr.GetInt32(11);
                        recipe.Vit = rdr.GetDecimal(12);
                        recipe.VitStack = rdr.GetInt32(13);
                        recipe.Piety = rdr.GetDecimal(14);
                        recipe.PietyStack = rdr.GetInt32(15);
                        recipe.Dex = rdr.GetDecimal(16);
                        recipe.DexStack = rdr.GetInt32(17);
                        recipe.Strength = rdr.GetDecimal(18);
                        recipe.StrengthStack = rdr.GetInt32(19);
                        recipe.Intel = rdr.GetDecimal(20);
                        recipe.IntelStack = rdr.GetInt32(21);
                        recipe.Parry = rdr.GetDecimal(22);
                        recipe.ParryStack = rdr.GetInt32(23);
                        recipe.Skill = rdr.GetDecimal(24);
                        recipe.SkillStack = rdr.GetInt32(25);
                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return recipe;
        }

        public static List<String> GetRecipeNames()
        {
            var recipeList = new List<String>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_recipe_list";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string recipeID = reader.GetString(0);

                        recipeList.Add(recipeID);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return recipeList;
        }

        public static List<String> GetRecipeNamesAndILVL()
        {
            var recipeList = new List<String>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_recipe_and_item_level";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string recipeID = reader.GetString(0);
                        int itemLevel = reader.GetInt32(1);

                        string formattedString = recipeID + " - " + itemLevel;
                        recipeList.Add(formattedString);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return recipeList;
        }

        public static List<RecipeCatalyst> GetRecipeCatalystListByID(string name)
        {
            var recipeList = new List<RecipeCatalyst>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_catalyst_by_recipe_id";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RecipeID", name);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RecipeCatalyst catalyst = new RecipeCatalyst()
                        {
                            Crystal = reader.GetString(0),
                            Quantity = reader.GetInt32(1)
                        };

                        recipeList.Add(catalyst);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return recipeList;
        }

        public static List<RecipeIngredient> GetRecipeIngredientListByID(string name)
        {
            var recipeList = new List<RecipeIngredient>();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_ingredients_by_recipe_id";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RecipeID", name);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RecipeIngredient ingredient = new RecipeIngredient()
                        {
                            IngredientID = reader.GetString(0),
                            Quantity = reader.GetInt32(1)
                        };

                        recipeList.Add(ingredient);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return recipeList;
        }

        public static Ingredient GetIngredientInfoByID(string ingredientID)
        {
            var i = new Ingredient();

            var conn = DBConnection.GetDBConnection();
            var query = @"sp_select_ingredient_details";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IngredientID", ingredientID);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        i.IngredientID = rdr.GetString(0);
                        i.ItemLevel = rdr.GetInt32(1);
                        i.Cooking = rdr.GetBoolean(2);
                        i.MobDrop = rdr.GetBoolean(3);
                        i.Fishing = rdr.GetBoolean(4);
                        i.Vendor = rdr.GetBoolean(5);
                        i.LocationName = rdr.GetString(6);
                        i.LocationLocale = rdr.GetString(7);
                        i.LocationLevel = rdr.GetInt32(8);
                        i.Coordinates = rdr.GetString(9);
                    }
                }

                return i;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
