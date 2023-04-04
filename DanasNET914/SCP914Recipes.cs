using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanasNET914
{
    public class SCP914Recipes
    {
        public static List<SCP914Recipe> Recipes { get; set; } = new List<SCP914Recipe>
        {
            new SCP914Recipe(Scp914.Scp914KnobSetting.Coarse, 100, ItemType.Radio, new Dictionary<ItemType, int>()
            {
                {ItemType.SCP1576, 1},
                {ItemType.None, 1}
            }),
            new SCP914Recipe(Scp914.Scp914KnobSetting.Fine, 100, ItemType.Coin, new Dictionary<ItemType, int>()
            {
                {ItemType.GrenadeFlash, 1},
                {ItemType.GrenadeHE, 1},
                {ItemType.Adrenaline, 1},
                {ItemType.Radio, 1},
                {ItemType.GunCOM15, 1},
                {ItemType.Medkit, 1}
            }),
            new SCP914Recipe(Scp914.Scp914KnobSetting.VeryFine, 100, ItemType.Coin, new Dictionary<ItemType, int>()
            {
                {ItemType.Jailbird, 1},
                {ItemType.GunCom45, 1},
                {ItemType.SCP018, 1},
                {ItemType.SCP207, 1},
                {ItemType.SCP244a, 1},
                {ItemType.SCP268, 1},
                {ItemType.SCP500, 1},
                {ItemType.SCP1576, 1},
                {ItemType.SCP1853, 1},
                {ItemType.SCP2176, 1},
                {ItemType.None, 10}
            })
        };

        public static SCP914Recipe GetItemPool(Scp914.Scp914KnobSetting setting, ItemType oldItem)
        {
            foreach (SCP914Recipe recipe in Recipes)
            {
                if (recipe.OldItem == oldItem && recipe.KnobSetting == setting) return recipe;
            }
            return null;
        }
    }
}
