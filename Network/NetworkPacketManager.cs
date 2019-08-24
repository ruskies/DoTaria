using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoTaria.Heroes.Abaddon.Abilities.MistCoil;
using DoTaria.Managers;
using DoTaria.Network.Abilities;
using DoTaria.Network.NPCs;
using DoTaria.Network.Players;

namespace DoTaria.Network
{
    public sealed class NetworkPacketManager
    {
        private static NetworkPacketManager _instance;

        private byte _latestPacketTypeId = 1;
        private readonly Dictionary<byte, NetworkPacket> _networkPacketsById = new Dictionary<byte, NetworkPacket>();
        private readonly Dictionary<Type, NetworkPacket> _networkPacketsByType = new Dictionary<Type, NetworkPacket>();

        internal void DefaultInitialize()
        {
            AbilityCasted = Add(new AbilityCastedPacket()) as AbilityCastedPacket;

            PlayerJoiningSynchronization = Add(new PlayerJoiningSynchronizationPacket()) as PlayerJoiningSynchronizationPacket;
            PlayerKilledNPC = Add(new PlayerKilledNPCPacket()) as PlayerKilledNPCPacket;
            PlayerLeveledUp = Add(new PlayerLeveledUpPacket()) as PlayerLeveledUpPacket;

            PlayerAbilityLeveledUp = Add(new PlayerAbilityLeveledUpPacket()) as PlayerAbilityLeveledUpPacket;

            MistCoilFired = Add(new MistCoilFiredPacket()) as MistCoilFiredPacket;

            Initialized = true;
        }


        public AbilityCastedPacket AbilityCasted { get; private set; }

        public PlayerJoiningSynchronizationPacket PlayerJoiningSynchronization { get; private set; }
        public PlayerKilledNPCPacket PlayerKilledNPC { get; private set; }
        public PlayerLeveledUpPacket PlayerLeveledUp { get; private set; }

        public PlayerAbilityLeveledUpPacket PlayerAbilityLeveledUp { get; private set; }


        public MistCoilFiredPacket MistCoilFired { get; private set; }


        public NetworkPacket Add(NetworkPacket networkPacket)
        {
            if (_networkPacketsById.ContainsValue(networkPacket))
                return _networkPacketsByType[networkPacket.GetType()];

            _networkPacketsById.Add(_latestPacketTypeId, networkPacket);
            _networkPacketsByType.Add(networkPacket.GetType(), networkPacket);

            networkPacket.PacketType = _latestPacketTypeId;
            _latestPacketTypeId++;

            return networkPacket;
        }

        public void HandlePacket(BinaryReader reader, int fromWho)
        {
            byte packetType = reader.ReadByte();

            _networkPacketsById[packetType].Receive(reader, fromWho);
        }


        internal void Unload()
        {
            _networkPacketsById.Clear();
            _networkPacketsByType.Clear();

            _instance = null;
        }


        public bool Initialized { get; private set; }

        public NetworkPacket this[byte packetType] => _networkPacketsById[packetType];


        public static NetworkPacketManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NetworkPacketManager();

                if (!_instance.Initialized)
                    _instance.DefaultInitialize();

                return _instance;
            }
        }
    }
}
