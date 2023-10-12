using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWER.NETWORK;

namespace Packets
{
    public class S_LogInPacket : Packet
    {
        public override ushort ID => throw new NotImplementedException();

        public override void Deserialize(ArraySegment<byte> buffer)
        {
            throw new NotImplementedException();
        }

        public override ArraySegment<byte> Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
