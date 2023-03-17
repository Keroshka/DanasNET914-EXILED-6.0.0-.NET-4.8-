﻿using Exiled.API.Features;
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
            if (ev.Item.Type == ItemType.Radio && ev.KnobSetting == Scp914.Scp914KnobSetting.Coarse && plugin.rng.Next(100) <= 50)
            {
                ev.IsAllowed = false;
                ev.Player.RemoveItem(ev.Item);
                ev.Player.AddItem(ItemType.SCP1576);
            }
        }

        public void OnPickupUpgrade(UpgradingPickupEventArgs ev)
        {
            if (ev.Pickup.Type == ItemType.Radio && ev.KnobSetting == Scp914.Scp914KnobSetting.Coarse && plugin.rng.Next(100) <= 50)
            {
                ev.IsAllowed = false;
                UpgradeItem(ev.Pickup, ItemType.SCP1576, ev.OutputPosition);
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
