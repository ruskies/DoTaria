using System.Collections.Generic;
using System.Collections.ObjectModel;
using DoTaria.Abilities;
using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;
using Main = Terraria.Main;

namespace DoTaria
{
	public sealed partial class DoTaria : Mod
	{
        public DoTaria()
		{
            Instance = this;
		}

        public override void Load()
        {
            if (!Main.dedServ)
            {
                LoadInterfaces();

                LoadHotKeys();
            }
        }

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                UnloadInterfaces();

                UnloadHotKeys();
            }

            Instance = null;
        }


        private void LoadHotKeys()
        {
            FirstAbility = RegisterHotKey("First Ability", Keys.Q.ToString());
            SecondAbility = RegisterHotKey("Second Ability", Keys.E.ToString());
            ThirdAbility = RegisterHotKey("Third Ability", Keys.E.ToString());
            UltimateAbility = RegisterHotKey("Ultimate Ability", Keys.R.ToString());

            AltFirstAbility = RegisterHotKey("Alternate First Ability", Keys.OemTilde.ToString());
            AltSecondAbility = RegisterHotKey("Alternate Second Ability", Keys.Tab.ToString());

            ModHotKeys = new ReadOnlyDictionary<ModHotKey, AbilitySlot>(new Dictionary<ModHotKey, AbilitySlot>()
            {
                { FirstAbility, AbilitySlot.First },
                { SecondAbility, AbilitySlot.Second },
                { ThirdAbility, AbilitySlot.Third },
                { UltimateAbility, AbilitySlot.Ultimate },
                { AltFirstAbility, AbilitySlot.Fourth },
                { AltSecondAbility, AbilitySlot.Fifth }
            });
        }

        private void UnloadHotKeys()
        {
            FirstAbility = null;
            SecondAbility = null;
            ThirdAbility = null;

            AltFirstAbility = null;
            AltSecondAbility = null;

            UltimateAbility = null;

            ModHotKeys = null;
        }


        public static DoTaria Instance { get; private set; }


        #region Hotkeys

        public ModHotKey FirstAbility { get; private set; }
        public ModHotKey SecondAbility { get; private set; }
        public ModHotKey ThirdAbility { get; private set; }

        public ModHotKey AltFirstAbility { get; private set; }
        public ModHotKey AltSecondAbility { get; private set; }

        public ModHotKey UltimateAbility { get; private set; }


        public IReadOnlyDictionary<ModHotKey, AbilitySlot> ModHotKeys { get; private set; }

        #endregion
    }
}