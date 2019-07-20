using DoTaria.Heroes;
using System;

namespace DoTaria.Skins
{
    public abstract class SkinSet
    {
        protected SkinSet(HeroDefinition heroLock, Type headSkin, Type bodySkin, Type legsSkin)
        {
            HeroLock = heroLock;

            HeadSkin = headSkin;
            BodySkin = bodySkin;
            LegsSkin = legsSkin;
        }

        public HeroDefinition HeroLock { get; }

        public Type HeadSkin { get; }
        public Type BodySkin { get; }
        public Type LegsSkin { get; }
    }
}
