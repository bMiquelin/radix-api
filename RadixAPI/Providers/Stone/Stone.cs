using RadixAPI.Contract;
using RadixAPI.Helper;
using RestSharp;
using System;
using System.Collections.ObjectModel;

namespace RadixAPI.Providers.Stone
{
    public class Stone : IProvider
    {
        const string API_URL = "https://transaction.stone.com.br";
        private readonly RestClient client;

        public Stone()
        {
            this.client = new RestClient();
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

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        private IRestResponse<SaleResponseModel> Sale(SaleRequestModel srm)
        {
            var request = new RestRequest($"{API_URL}/Sale", Method.POST);
            request.AddBody(srm);

            return client.Execute<SaleResponseModel>(request);
        }
    }
}
