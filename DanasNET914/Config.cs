using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanasNET914
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        //[Description("List of 914 recipes")]
        //public Dictionary<Scp914.Scp914KnobSetting, List<SCP914Recipe>> RecipeList { get; set; } = new Dictionary<Scp914.Scp914KnobSetting, List<SCP914Recipe>>
        //{
        //    { Scp914.Scp914KnobSetting.Coarse, new List<SCP914Recipe>
        //        {
        //            new SCP914Recipe(ItemType.Radio, ItemType.SCP1576, 50)
        //        }
        //    },
        //    {
        //        Scp914.Scp914KnobSetting.Fine, new List<SCP914Recipe>
        //        {
        //            new SCP914Recipe(ItemType.Coin, ItemType.GrenadeFlash, 20),
        //            new SCP914Recipe(ItemType.Coin, ItemType.GrenadeHE, 20),
        //            new SCP914Recipe(ItemType.Coin, ItemType.Adrenaline, 20),
        //            new SCP914Recipe(ItemType.Coin, ItemType.Radio, 20),
        //            new SCP914Recipe(ItemType.Coin, ItemType.GunCOM15, 20),
        //            new SCP914Recipe(ItemType.Coin, ItemType.Medkit, 100)
        //        }
        //    },
        //    {
        //        Scp914.Scp914KnobSetting.VeryFine, new List<SCP914Recipe>
        //        {
        //            new SCP914Recipe(ItemType.Coin, ItemType.Jailbird, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.GunCom45, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP018, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP207, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP244a, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP268, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP500, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP1576, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP1853, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.SCP2176, 5),
        //            new SCP914Recipe(ItemType.Coin, ItemType.None, 100)
        //        }
        //    }
        //};
    }
}