using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Recipe
    {
        public string RecipeID { get; set; }
        public int ItemLevel { get; set; }
        public string ImagePath { get; set; }
        public decimal Mind { get; set; }
        public int MindStack { get; set; }
        public decimal Acc { get; set; }
        public int AccStack { get; set; }
        public decimal Crit { get; set; }
        public int CritStack { get; set; }
        public decimal Det { get; set; }
        public int DetStack { get; set; }
        public decimal Spell { get; set; }
        public int SpellStack { get; set; }
        public decimal Vit { get; set; }
        public int VitStack { get; set; }
        public decimal Piety { get; set; }
        public int PietyStack { get; set; }
        public decimal Dex { get; set; }
        public int DexStack { get; set; }
        public decimal Strength { get; set; }
        public int StrengthStack { get; set; }
        public decimal Intel { get; set; }
        public int IntelStack { get; set; }
        public decimal Parry { get; set; }
        public int ParryStack { get; set; }
        public decimal Skill { get; set; }
        public int SkillStack { get; set; }

        public Recipe() { }

        public Recipe(string recipeID)
        {
            RecipeID = recipeID;
        }

        public Recipe(string recipeID,
                      int itemLevel)
        {
            RecipeID = recipeID;
            ItemLevel = itemLevel;
        }

        public Recipe(  string recipeID,
                        int itemLevel,
                        string imagePath,
                        decimal mind,
                        int mindStack,
                        decimal acc,
                        int accStack,
                        decimal crit,
                        int critStack,
                        decimal det,
                        int detStack,
                        decimal spell,
                        int spellStack,
                        decimal vit,
                        int vitStack,
                        decimal piety,
                        int pietyStack,
                        decimal dex,
                        int dexStack,
                        decimal strength,
                        int strengthStack,
                        decimal intel,
                        int intelStack,
                        decimal parry,
                        int parryStack,
                        decimal skill,
                        int skillStack)
        {
            RecipeID = recipeID;
            ItemLevel = itemLevel;
            ImagePath = ImagePath;
            Mind = mind;
            MindStack = mindStack;
            Acc = acc;
            AccStack = accStack;
            Crit = crit;
            CritStack = critStack;
            Det = det;
            DetStack = detStack;
            Spell = spell;
            SpellStack = spellStack;
            Vit = vit;
            VitStack = vitStack;
            Piety = piety;
            PietyStack = pietyStack;
            Dex = dex;
            DexStack = dexStack;
            Strength = strength;
            StrengthStack = strengthStack;
            Intel = intel;
            IntelStack = intelStack;
            Parry = parry;
            ParryStack = parryStack;
            Skill = skill;
            SkillStack = skillStack;
        }
    }
}
