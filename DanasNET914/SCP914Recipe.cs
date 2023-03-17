using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanasNET914
{
    public class SCP914Recipe
    {
        public ItemType OldItem { get; set; }
        public ItemType NewItem { get; set; }
        public int Chance { get; set; }

        public SCP914Recipe(ItemType oldItem, ItemType newItem, int chance)  
        {
            OldItem = oldItem;
            NewItem = newItem;
            Chance = chance;
        }
    }
}
