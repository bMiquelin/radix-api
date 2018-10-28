using Microsoft.Extensions.Configuration;
using RadixAPI.Contract;
using RadixAPI.Exceptions;
using RestSharp;
using System;

namespace RadixAPI.Providers.Cielo
{
    public class Cielo : IProvider
    {
        const string DEFAULT_PAYMENTTYPE = "CreditCard";
        const string DEFAULT_INTEREST = "ByIssuer";
        const string DEFAULT_IDENTITYTYPE = "CPF";
        const string DEFAULT_STATUS = "NEW";
        const string DEFAULT_CURRENCY = "BRL";

        private readonly RestClient client;
        private readonly string PAYMENT_COUNTRY;
        private readonly string MERCHANT_ID;
        private readonly string MERCHANT_KEY;

        public Cielo(IConfiguration configuration)
        {
            var settings = configuration.GetSection($"Providers:{nameof(Cielo)}");
            this.MERCHANT_KEY = settings[nameof(this.MERCHANT_KEY)];
            this.MERCHANT_ID = settings[nameof(this.MERCHANT_ID)];
            this.PAYMENT_COUNTRY = settings[nameof(this.PAYMENT_COUNTRY)];

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
                        City = transactionRequest.BillingData.Address.City,
                        Complement = null,
                        Country = transactionRequest.BillingData.Address.Country,
                        Number = null,
                        State = transactionRequest.BillingData.Address.State,
                        Street = null,
                        ZipCode = transactionRequest.BillingData.Address.ZipCode
                    },
                    Birthdate = DateTime.Now.ToShortDateString(), //TODO
                    DeliveryAddress = new CustomerDeliveryAddressModel {
                        City = transactionRequest.ShippingData.Address.City,
                        Complement = null,
                        Country = transactionRequest.ShippingData.Address.Country,
                        State = transactionRequest.ShippingData.Address.State,
                        Street = null,
                        ZipCode = transactionRequest.ShippingData.Address.ZipCode
                    },
                    Email = transactionRequest.Email,
                    Identity = transactionRequest.CPF,
                    IdentityType = DEFAULT_IDENTITYTYPE,
                    Name = transactionRequest.CustomerName,
                    Status = DEFAULT_STATUS
                },
                MerchantId = Guid.NewGuid(),
                MerchantKey = MERCHANT_KEY,
                MerchantOrderId = transactionId.ToString(),
                Payment = new PaymentModel {
                    Amount = transactionRequest.Amount,
                    Authenticate = false,
                    Capture = false,
                    Country = PAYMENT_COUNTRY,
                    Currency = DEFAULT_CURRENCY,
                    Installments = 1,
                    Interest = DEFAULT_INTEREST,
                    Provider = null,
                    ServiceTaxAmount = 0,
                    SoftDescriptor = transactionRequest.Descriptor,
                    Type = DEFAULT_PAYMENTTYPE
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
            var request = new RestRequest($"/sales", Method.POST, DataFormat.Json);
            request.AddBody(srm);

            return client.Execute<SalesResponseModel>(request);
        }
    }
}
