using DoTaria.Abilities;
using DoTaria.Heroes;
using DoTaria.UserInterfaces.HeroSelection;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DoTaria.Players
{
    public sealed partial class DoTariaPlayer : ModPlayer
    {
        private void SaveHeroes(TagCompound tag)
        {
            HeroDefinition hero = HeroSelectionUIState.SelectedHero;

            if (!HeroSelected && hero != null)
            {
                Hero = hero;

                HeroSelectionUIState.SelectedHero = null;
                HeroSelected = true;
            }

            tag.Add(nameof(Hero), Hero.UnlocalizedName);
            tag.Add(nameof(HeroSelected), HeroSelected);

            SaveShadowFiend(tag);
        }

        private void LoadHeroes(TagCompound tag)
        {
            if (tag.ContainsKey(nameof(Hero)))
                Hero = HeroDefinitionManager.Instance[tag.GetString(nameof(Hero))];

            HeroSelected = tag.GetBool(nameof(HeroSelected));

            LoadShadowFiend(tag);
        }
    }
}
