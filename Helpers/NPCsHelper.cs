using Terraria;

namespace DoTaria.Helpers
{
    public static class NPCsHelper
    {
        public static int GetNPCIdFromNPC(NPC npc)
        {
            for (int i = 0; i < Main.npc.Length; i++)
                if (Main.npc[i] == npc)
                    return i;

            return 0;
        }

        public static NPC GetNPCFromNetId(int npcNetId)
        {
            for (int i = 0; i < Main.npc.Length; i++)
                if (Main.npc[i].netID == npcNetId)
                    return Main.npc[i];

            return null;
        }
    }
}