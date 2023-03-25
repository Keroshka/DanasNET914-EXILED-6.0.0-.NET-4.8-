using Exiled.API.Features;
using Exiled.Events.Handlers;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Scp914;
using MapGeneration.Distributors;
using InventorySystem.Items.Pickups;
using Exiled.API.Features.Items;
using UnityEngine;
using Exiled.API.Features.Pickups;
using Item = Exiled.API.Features.Items.Item;

namespace DanasNET914
{
    public class EventHandlers
    {
        private Plugin plugin;

        public EventHandlers(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnItemUpgrade(UpgradingInventoryItemEventArgs ev)
        {
            //if (ev.Item.Type == ItemType.Radio && ev.KnobSetting == Scp914.Scp914KnobSetting.Coarse && plugin.rng.Next(100) <= 50)
            //{
            //    ev.IsAllowed = false;
            //    ev.Player.RemoveItem(ev.Item);
            //    ev.Player.AddItem(ItemType.SCP1576);
            //}

            if (Recipes914.RecipeList != null && Recipes914.RecipeList.ContainsKey(ev.KnobSetting))
            {
                foreach (var sourceItem in Recipes914.RecipeList[ev.KnobSetting])
                {
                    if (sourceItem.OldItem != ev.Item.Type) continue;

                    if (plugin.rng.Next(100) <= sourceItem.Chance)
                    {
                        ev.IsAllowed = false;
                        ev.Player.RemoveItem(ev.Item);
                        if (sourceItem.NewItem != ItemType.None) ev.Player.AddItem(sourceItem.NewItem);
                        break;
                    }
                }
            }
        }

        public void OnItemUpgradeNew(UpgradingInventoryItemEventArgs ev)
        {
            SCP914RecipeNew recipe = Recipes914New.GetItemPool(ev.KnobSetting, ev.Item.Type);
            if (Recipes914New.Recipes != null && recipe != null)
            {
                if (plugin.rng.Next(100) <= recipe.InitialChance)
                {
                    ev.IsAllowed = false;
                    ev.Player.RemoveItem(ev.Item);
                    ItemType itemToAdd = recipe.ChooseOutcome(plugin.rng);
                    if (itemToAdd != ItemType.None) ev.Player.AddItem(itemToAdd);
                }
            }
        }

        public void OnPickupUpgrade(UpgradingPickupEventArgs ev)
        {
            //if (ev.Pickup.Type == ItemType.Radio && ev.KnobSetting == Scp914.Scp914KnobSetting.Coarse && plugin.rng.Next(100) <= 50)
            //{
            //    ev.IsAllowed = false;
            //    UpgradeItem(ev.Pickup, ItemType.SCP1576, ev.OutputPosition);
            //}

            if (Recipes914.RecipeList != null && Recipes914.RecipeList.ContainsKey(ev.KnobSetting))
            {
                foreach (var sourceItem in Recipes914.RecipeList[ev.KnobSetting])
                {
                    if (sourceItem.OldItem != ev.Pickup.Type) continue;

                    if (plugin.rng.Next(100) <= sourceItem.Chance)
                    {
                        ev.IsAllowed = false;
                        UpgradeItem(ev.Pickup, sourceItem.NewItem, ev.OutputPosition);
                        break;
                    }
                }
            }
        }

        public void OnPickupUpgradeNew(UpgradingPickupEventArgs ev)
        {
            SCP914RecipeNew recipe = Recipes914New.GetItemPool(ev.KnobSetting, ev.Pickup.Type);
            if (Recipes914New.Recipes != null && recipe != null)
            {
                if (plugin.rng.Next(100) <= recipe.InitialChance)
                {
                    ev.IsAllowed = false;
                    ItemType itemToAdd = recipe.ChooseOutcome(plugin.rng);
                    UpgradeItem(ev.Pickup, itemToAdd, ev.OutputPosition);
                }
            }
        }

        internal void UpgradeItem(Pickup oldItem, ItemType newItem, Vector3 pos)
        {
            if (newItem != ItemType.None)
            {
                Item item = Item.Create(newItem);
                if (oldItem is FirearmPickup oldFirearm && item is Firearm firearm)
                    firearm.Ammo = oldFirearm.Ammo <= firearm.MaxAmmo ? oldFirearm.Ammo : firearm.MaxAmmo;

                item.CreatePickup(pos);
            }
            oldItem.Destroy();
        }
    }
}
