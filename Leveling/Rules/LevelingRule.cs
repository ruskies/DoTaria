using DoTaria.Commons;

namespace DoTaria.Leveling.Rules
{
    public abstract class LevelingRule : IHasUnlocalizedName
    {
        protected LevelingRule(string unlocalizedName, int levels)
        {
            UnlocalizedName = unlocalizedName;
            Levels = levels;
        }


        public string UnlocalizedName { get; }

        public int Levels { get; }
    }
}