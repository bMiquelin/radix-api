using Microsoft.Extensions.Configuration;
using RadixAPI.Contract;
using RadixAPI.Exceptions;
using RestSharp;
using System;

namespace RadixAPI.Providers.Cielo
{
    public class Cielo : IProvider
    {
        const string DEFAULT_INTEREST = "ByIssuer";
        const string DEFAULT_IDENTITYTYPE = "CPF";
        const string DEFAULT_STATUS = "NEW";

        private readonly RestClient client;
        private readonly string MERCHANT_ID;
        private readonly string MERCHANT_KEY;

        public Cielo(IConfiguration configuration)
        {
            var settings = configuration.GetSection($"Providers:{nameof(Cielo)}");
            this.MERCHANT_KEY = settings[nameof(this.MERCHANT_KEY)];
            this.MERCHANT_ID = settings[nameof(this.MERCHANT_ID)];

            this.client = new RestClient(settings["API_URL"]);
        }

        private SalesRequestModel PrepareModel(Guid transactionId, TransactionRequest transactionRequest)
        {
            return new SalesRequestModel
            {
                CreditCard = new CreditCardModel {
                    Brand = transactionRequest.CreditCard.Brand,
                    CardNumber = transactionRequest.CreditCard.CardNumber,
                    ExpirationDate = transactionRequest.CreditCard.ExpirationDate,
                    Holder = transactionRequest.CreditCard.Holder,
                    SaveCard = false,
                    SecurityCode = transactionRequest.CreditCard.SecurityCode.ToString()
                },
                Customer = new CustomerModel {
                    Address = new CustomerAddressModel
                    {
                        City = null,
                        Complement = null,
                        Country = null,
                        Number = null,
                        State = null,
                        Street = null,
                        ZipCode = null
                    },
                    Birthdate = DateTime.Now, //TODO
                    DeliveryAddress = new CustomerDeliveryAddressModel {
                        City =null,
                        Complement = null,
                        Country = null,
                        State = null,
                        Street = null,
                        ZipCode = null
                    },
                    Email = null,
                    Identity = null,
                    IdentityType = DEFAULT_IDENTITYTYPE,
                    Name = null,
                    Status = DEFAULT_STATUS
                },
                MerchantId = Guid.NewGuid(),
                MerchantKey = MERCHANT_KEY,
                MerchantOrderId = transactionId.ToString("N"),
                Payment = new PaymentModel {
                    Amount = transactionRequest.Amount,
                    Authenticate = false,
                    Capture = false,
                    Country = null,
                    Currency = null,
                    Installments = 1,
                    Interest = DEFAULT_INTEREST,
                    Provider = null,
                    ServiceTaxAmount = 0,
                    SoftDescriptor = null,
                    Type = null
                },
                RequestId = transactionId
            };
        }

        bool IProvider.MakeTransaction(Guid transactionId, TransactionRequest transactionRequest)
        {
            var model = PrepareModel(transactionId, transactionRequest);
            var response = Sales(model);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ProviderException("Failed to finish transaction");

            return true;
        }

        private IRestResponse<SalesResponseModel> Sales(SalesRequestModel srm)
        {
            var request = new RestRequest($"/1/sales", Method.POST, DataFormat.Json);
            request.AddBody(srm);

            return client.Execute<SalesResponseModel>(request);
        }
    }
}
