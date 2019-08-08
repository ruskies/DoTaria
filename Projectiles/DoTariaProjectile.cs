using DoTaria.Players;
using Terraria;
using Terraria.ModLoader;

namespace DoTaria.Projectiles
{
    public abstract class DoTariaProjectile : ModProjectile
    {
        private readonly string _displayName;
        private readonly int _width, _height;

        protected DoTariaProjectile(string displayName, int width, int height, bool cloneNewInstances = true)
        {
            _displayName = displayName;

            _width = width;
            _height = height;

            CloneNewInstances = cloneNewInstances;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault(_displayName);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            projectile.width = _width;
            projectile.height = _height;
        }


        public override bool PreAI()
        {
            if (Owner == null)
                Owner = DoTariaPlayer.Get(Main.player[projectile.owner]);

            projectile.netUpdate = true;

            return base.PreAI();
        }


        public DoTariaPlayer Owner { get; protected set; }

        public override bool CloneNewInstances { get; }
    }
}
