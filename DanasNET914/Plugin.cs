using Exiled.API.Features;
using Exiled.Loader;
using InventorySystem.Disarming;
using System;

namespace DanasNET914
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Keroshka";
        public override string Name { get; } = "DanasDotNET914";
        public override Version Version { get; } = new Version(1,0,0);

        public override Version RequiredExiledVersion { get; } = new Version(6,0,0);

        public static Plugin Instance = new Plugin();

        public EventHandlers EventHandler { get; private set; }

        public Random rng = new Random();

        public override void OnEnabled()
        {
            EventHandler = new EventHandlers(Instance);

            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem += EventHandler.OnItemUpgrade;
            Exiled.Events.Handlers.Scp914.UpgradingPickup += EventHandler.OnPickupUpgrade;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem -= EventHandler.OnItemUpgrade;
            Exiled.Events.Handlers.Scp914.UpgradingPickup -= EventHandler.OnPickupUpgrade;

            EventHandler = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}