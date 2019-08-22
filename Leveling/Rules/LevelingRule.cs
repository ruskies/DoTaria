using DoTaria.Commons;

namespace DoTaria.Leveling.Rules
{
    public abstract class LevelingRule : IHasUnlocalizedName
    {
        protected LevelingRule(string unlocalizedName)
        {
            UnlocalizedName = unlocalizedName;
        }


        public string UnlocalizedName { get; }
    }
}