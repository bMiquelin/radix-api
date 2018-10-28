using Microsoft.Extensions.Configuration;
using System;

namespace RadixAPI.Providers
{
    public class ProviderIterator
    {
        private readonly IConfiguration configuration;
        public ProviderIterator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IProvider CreateProviderInstance(ProviderEnum providerEnum)
        {
            switch(providerEnum)
            {
                case ProviderEnum.Cielo:
                    return new Cielo.Cielo(configuration);
                case ProviderEnum.Stone:
                    return new Stone.Stone(configuration);
                default:
                    throw new ArgumentOutOfRangeException(nameof(providerEnum));
            }
        }
    }
}
