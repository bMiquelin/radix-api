using Microsoft.Extensions.Configuration;
using RadixAPI.Contract;
using RadixAPI.Exceptions;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class ClearSale : IAntiFraudProvider
    {
        private readonly RestClient client;

        private const int DEFAULT_PAYMENTTYPEID = 1;
        private const string DEFAULT_ANALYSISLOCATION = "BRA";
        private const string ACCEPTABLE_STATUS = "APA";
        private const string DEFAULT_CURRENCY = "BRL";
        private readonly string API_KEY;
        private readonly string CLIENT_ID;
        private readonly string CLIENT_SECRET;

        public ClearSale(IConfiguration configuration)
        {
            var settings = configuration.GetSection($"AntiFraudProviders:{nameof(ClearSale)}");
            this.API_KEY = settings[nameof(this.API_KEY)];
            this.CLIENT_ID = settings[nameof(this.CLIENT_ID)];
            this.CLIENT_SECRET = settings[nameof(this.CLIENT_SECRET)];
            this.client = new RestClient(settings["API_URL"]);
        }

        /// <returns>LoginToken</returns>
        private IRestResponse<ResponseAuth> Auth()
        {
            //TODO cache verifying Data.Token.ExpirationDate to minimize unnecessary login count

            var request = new RestRequest("/auth/login", Method.POST, DataFormat.Json);

            var requestAuth = new RequestAuthModel {
                Login = new CredentialsModel
                {
                    ApiKey = API_KEY,
                    ClientId = CLIENT_ID,
                    ClientSecret = CLIENT_SECRET
                }
            };

            request.AddBody(requestAuth);
            var response = client.Execute<ResponseAuth>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new AntiFraudException("Failed to authenticate with AntiFraud service");

            return response;
        }

        private IRestResponse<ResponseSend> Send(TransactionRequest transactionRequest)
        {
            var request = new RestRequest("/order/send", Method.POST, DataFormat.Json);

            if (!Enum.TryParse(typeof(CreditCardTypeEnum), transactionRequest.CreditCard.Brand, out var cardType)) cardType = CreditCardTypeEnum.Others;
            var requestSend = new RequestSendModel {
                AnalysisLocation = DEFAULT_ANALYSISLOCATION,
                ApiKey = API_KEY,
                LoginToken = Auth().Data.Token.Value,
                Orders = new Collection<OrderModel>
                {
                    new OrderModel{
                        IP = transactionRequest.IP,
                        BillingData = new PersonModel
                        {
                            Address = new AddressModel
                            {
                                City = transactionRequest.BillingData.Address.City,
                                Country = transactionRequest.BillingData.Address.Country,
                                State = transactionRequest.BillingData.Address.State,
                                ZipCode = transactionRequest.BillingData.Address.ZipCode
                            },
                            BirthDate =  transactionRequest.BillingData.BirthDate,
                            Email = transactionRequest.BillingData.Email,
                            Gender = transactionRequest.BillingData.Gender,
                            ID = transactionRequest.BillingData.ID,
                            Name = transactionRequest.BillingData.Name,
                            Phones = new Collection<PhoneModel>(transactionRequest.BillingData.Phones.Select(phone => new PhoneModel{
                                    AreaCode = phone.AreaCode,
                                    CountryCode = phone.CountryCode,
                                    Number = phone.Number,
                                    Type = TelephoneTypeEnum.Undefined
                                }).ToList())
                        },
                        ShippingData = new PersonModel
                        {
                            Address = new AddressModel
                            {
                                City = transactionRequest.ShippingData.Address.City,
                                Country = transactionRequest.ShippingData.Address.Country,
                                State = transactionRequest.ShippingData.Address.State,
                                ZipCode = transactionRequest.ShippingData.Address.ZipCode
                            },
                            BirthDate =  transactionRequest.ShippingData.BirthDate,
                            Email = transactionRequest.ShippingData.Email,
                            Gender = transactionRequest.ShippingData.Gender,
                            ID = transactionRequest.ShippingData.ID,
                            Name = transactionRequest.ShippingData.Name,
                            Phones = new Collection<PhoneModel>(transactionRequest.ShippingData.Phones.Select(phone => new PhoneModel{
                                    AreaCode = phone.AreaCode,
                                    CountryCode = phone.CountryCode,
                                    Number = phone.Number,
                                    Type = TelephoneTypeEnum.Undefined
                                }).ToList())
                        },
                        Currency = DEFAULT_CURRENCY,
                        Date = DateTime.UtcNow,
                        Email = transactionRequest.Email,
                        ID = transactionRequest.TransactionId.ToString(),
                        TotalShipping = 0,
                        TotalOrder = transactionRequest.Amount,
                        TotalItems = transactionRequest.Amount,
                        Items = new Collection<ItemModel> { },
                        Origin = transactionRequest.StoreName,
                        Payments = new Collection<PaymentModel>
                        {
                            new PaymentModel
                            {
                                Amount = transactionRequest.Amount,
                                CardBin = transactionRequest.CreditCard.CardNumber.Substring(0, 6),
                                CardNumber = transactionRequest.CreditCard.CardNumber,
                                CardExpirationDate = transactionRequest.CreditCard.ExpirationDate,
                                CardHolderName = transactionRequest.CreditCard.Holder,
                                CardType = (CreditCardTypeEnum)cardType,
                                Date = DateTime.UtcNow,
                                PaymentTypeId = DEFAULT_PAYMENTTYPEID,
                                Type = PaymentTypeEnum.CREDIT_CARD
                            }
                        }
                    }
                }
            };

            request.AddBody(requestSend);
            var response = client.Execute<ResponseSend>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new AntiFraudException("Failed to send data to AntiFraud service");

            return response;
        }

        bool IAntiFraudProvider.Validate(TransactionRequest transactionRequest)
        {
            var response = Send(transactionRequest);

            var success = !response.Data.Orders.Any(order => order.Status != ACCEPTABLE_STATUS);
            if (!success)
            {
                var errors = response.Data.Orders.Select(order => StatusDictionary.Status[order.Status]);
                throw new AntiFraudException($"AntiFraud did not aproved the transaction: {string.Join(",", errors)}");
            }

            return true;
        }
    }
}
