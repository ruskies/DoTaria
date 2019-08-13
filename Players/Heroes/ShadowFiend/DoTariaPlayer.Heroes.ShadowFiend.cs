using DoTaria.Abilities;
using DoTaria.Heroes.ShadowFiend;
using DoTaria.Heroes.ShadowFiend.Abilities;
using DoTaria.Heroes.ShadowFiend.Abilities.Necromastery;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private int _souls;


        private void SaveShadowFiend(TagCompound tag)
        {
            tag.Add(nameof(Souls), Souls);
        }

        private void LoadShadowFiend(TagCompound tag)
        {
            Souls = tag.GetAsInt(nameof(Souls));
        }

        public int Souls
        {
            get => _souls;
            set
            {
                NecromasteryAbility necromastery = AbilityDefinitionManager.Instance.Necromastery;

                if (!(Hero is ShadowFiendHero sf) || !HasAbility(necromastery))
                {
                    _souls = 0;
                    return;
                }

                int maxSouls = necromastery.GetMaxSouls(this);

                if (_souls > maxSouls || value == _souls || _souls == maxSouls)
                    return;

                if (value > maxSouls)
                    value = maxSouls;

                _souls = value;
            }
        }
    }
}
