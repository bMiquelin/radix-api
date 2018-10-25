using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways
{
    public class GatewayIterator
    {
        public static IGateway GetGateway(GatewayEnum gatewayEnum)
        {
            switch(gatewayEnum)
            {
                case GatewayEnum.Cielo:
                    return new Cielo.CieloGateway();
                case GatewayEnum.Stone:
                    return new Stone.StoneGateway();
                default:
                    throw new ArgumentOutOfRangeException(nameof(gatewayEnum));
            }
        }
    }
}
