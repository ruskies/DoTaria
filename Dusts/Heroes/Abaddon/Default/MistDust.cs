using Terraria;

namespace DoTaria.Dusts.Heroes.Abaddon.Default
{
    public sealed class MistDust : DoTariaDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;

            base.OnSpawn(dust);
        }
    }
}