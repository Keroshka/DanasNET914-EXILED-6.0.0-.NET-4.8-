using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanasNET914
{
    public class SCP914Recipe
    {
        private Dictionary<ItemType, int> RecipeList { get; set; }
        public ItemType OldItem { get; set; }
        public int InitialChance { get; set; } = 100;
        public Scp914.Scp914KnobSetting KnobSetting { get; set; }
        public SCP914Recipe(Scp914.Scp914KnobSetting setting, int initialChance, ItemType oldItem, Dictionary<ItemType, int> recipes)
        {
            InitialChance = initialChance;
            OldItem = oldItem;
            KnobSetting = setting;
            RecipeList = recipes;
        }

        public ItemType ChooseOutcome(Random rng)
        {
            int chanceSum = 0;
            Dictionary<ItemType, int> chance = new Dictionary<ItemType, int>();
            foreach (var item in RecipeList)
            {
                chanceSum += item.Value;
                chance.Add(item.Key, chanceSum);
            }

            int roll = rng.Next(chanceSum) + 1;

            foreach (var item in chance)
            {
                if (roll <= item.Value) return item.Key;
            }
            return ItemType.None;
        }
    }
}
