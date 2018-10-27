using RadixAPI.Contract;
using RestSharp;
using System;

namespace RadixAPI.Providers.Cielo
{
    public class Cielo : IProvider
    {
        const string API_URL = "https://apisandbox.cieloecommerce.cielo.com.br";
        const string DEFAULT_INTEREST = "ByIssuer";
        const string MERCHANT_ID = "00020000-0000-0000-0000-000000000000";
        const string MERCHANT_KEY = "";
        private readonly RestClient client;

        public Cielo()
        {
            this.client = new RestClient(API_URL);
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
                    IdentityType = "CPF",
                    Name = null,
                    Status = "NEW"
                },
                MerchantId = Guid.Parse(MERCHANT_ID),
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

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        private IRestResponse<SalesResponseModel> Sales(SalesRequestModel srm)
        {
            var request = new RestRequest($"/1/sales",Method.POST);
            request.AddBody(srm);

            return client.Execute<SalesResponseModel>(request);
        }
    }
}
