using System;

namespace RadixAPI.Providers
{
    public class ProviderIterator
    {
        public static IProvider CreateProviderInstance(ProviderEnum providerEnum)
        {
            switch(providerEnum)
            {
                case ProviderEnum.Cielo:
                    return new Cielo.Cielo();
                case ProviderEnum.Stone:
                    return new Stone.Stone();
                default:
                    throw new ArgumentOutOfRangeException(nameof(providerEnum));
            }
        }
    }
}
