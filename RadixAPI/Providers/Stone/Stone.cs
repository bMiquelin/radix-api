using Microsoft.Extensions.Configuration;
using RadixAPI.Contract;
using RadixAPI.Exceptions;
using RadixAPI.Helper;
using RestSharp;
using System;
using System.Collections.ObjectModel;

namespace RadixAPI.Providers.Stone
{
    public class Stone : IProvider
    {
        private readonly RestClient client;
        private readonly string MerchantKey;

        public Stone(IConfiguration configuration)
        {
            var settings = configuration.GetSection($"Providers:{nameof(Stone)}");
            this.MerchantKey = settings[nameof(MerchantKey)];
            this.client = new RestClient(settings["API_URL"]);
        }

        private SaleRequestModel PrepareModel(Guid transactionId, TransactionRequest transactionRequest)
        {
            var expData = CreditCardHelper.GetExpMonthAndYear(transactionRequest.CreditCard.ExpirationDate);
            return new SaleRequestModel
            {
                CreditCardTransactionCollection = new Collection<CreditCardTransactionModel>
                {
                    new CreditCardTransactionModel
                    {                        
                        AmountInCents = transactionRequest.Amount,
                        CreditCard = new CreditCardModel{
                            CreditCardBrand = transactionRequest.CreditCard.Brand,
                            CreditCardNumber = transactionRequest.CreditCard.CardNumber,
                            ExpMonth = expData.Item1,
                            ExpYear = expData.Item2,
                            HolderName = transactionRequest.CreditCard.Holder,
                            SecurityCode = transactionRequest.CreditCard.SecurityCode
                        },
                        InstallmentCount = 1
                    }
                },
                Order = new OrderModel
                {
                    OrderReference = transactionId.ToString("N")
                }
            };
        }

        bool IProvider.MakeTransaction(Guid transactionId, TransactionRequest transactionRequest)
        {
            var model = PrepareModel(transactionId, transactionRequest);
            var response = Sale(model);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderException("Failed to finish transaction");

            return true;
        }

        private IRestResponse<SaleResponseModel> Sale(SaleRequestModel srm)
        {
            var request = new RestRequest("/Sale", Method.POST, DataFormat.Json);
            request.AddBody(srm);
            request.AddHeader(nameof(MerchantKey), MerchantKey);

            return client.Execute<SaleResponseModel>(request);
        }
    }
}
