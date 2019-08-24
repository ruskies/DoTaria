using System.IO;
using DoTaria.Network;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DoTaria.Heroes.Abaddon.Abilities.MistCoil
{
    public class MistCoilFiredPacket : NetworkPacket
    {
        public override bool Receive(BinaryReader reader, int fromWho)
        {
            int whichPlayer = reader.ReadInt32();
            TargetType.TryParse(reader.ReadString(), out TargetType targetType);
            int projectileId = reader.ReadInt32();
            int entityId = reader.ReadInt32();
            int damageOnContact = reader.ReadInt32();

            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetworkPacketManager.Instance.MistCoilFired.SendPacketToAllClients(fromWho, whichPlayer, targetType.ToString(), entityId, damageOnContact);

            MistCoilProjectile mistCoil = Main.projectile[projectileId].modProjectile as MistCoilProjectile;

            if (targetType == TargetType.Player)
                mistCoil.HomeOntoPlayer = Main.player[entityId];
            else if (targetType == TargetType.NPC)
                mistCoil.HomeOntoNPC = Main.npc[entityId];

            mistCoil.DamageOnContact = damageOnContact;

            return true;
        }

        protected override void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args)
        {
            packet.Write((int) args[0]);
            packet.Write((string) args[1]);
            packet.Write((int) args[2]);
            packet.Write((int) args[3]);
            packet.Write((int) args[4]);

            packet.Send(toWho, fromWho);
        }

        public enum TargetType
        {
            Player,
            NPC
        }
    }
}