﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace DoTaria.Network
{
    public abstract class NetworkPacket
    {
        protected NetworkPacket()
        {
        }

        public abstract bool Receive(BinaryReader reader, int fromWho);

        public void SendPacket(int toWho, int fromWho, params object[] args) => SendPacket(MakePacket(), toWho, fromWho, args);

        protected abstract void SendPacket(ModPacket packet, int toWho, int fromWho, params object[] args);

        public void SendPacketToAllClients(int fromWho, params object[] args) => SendPacket(-1, fromWho, args);
        public void SendPacketToServer(int fromWho, params object[] args) => SendPacket(256, fromWho, args);


        protected ModPacket MakePacket()
        {
            ModPacket packet = DoTariaMod.Instance.GetPacket();
            packet.Write(PacketType);

            return packet;
        }

        public byte PacketType { get; internal set; }
    }
}
