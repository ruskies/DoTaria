using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using DoTaria.Abilities;
using DoTaria.Heroes;
using DoTaria.Heroes.Invoker.Abilities.InvokableAbilities;
using DoTaria.Leveling.Rules.NPCs;
using DoTaria.Network;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria
{
	public sealed partial class DoTariaMod : Mod
	{
        public DoTariaMod()
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

            InvokableAbilities.Load();
        }

        public override void Unload()
        {
            if (!Main.dedServ)
            {
                UnloadInterfaces();

                UnloadHotKeys();
            }

            Instance = null;

            HeroDefinitionManager.Instance.Unload();
            AbilityDefinitionManager.Instance.Unload();
            NetworkPacketManager.Instance.Unload();
            NPCLevelingRulesManager.Instance.Unload();

            InvokableAbilities.Unload();
        }


        private void LoadHotKeys()
        {
            FirstAbility = RegisterHotKey("First Ability", Keys.Q.ToString());
            SecondAbility = RegisterHotKey("Second Ability", Keys.W.ToString());
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


        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            NetworkPacketManager.Instance.HandlePacket(reader, whoAmI);
        }


        public static DoTariaMod Instance { get; private set; }


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