using Microsoft.Extensions.Configuration;
using RadixAPI.Contract;
using RadixAPI.Exceptions;
using RestSharp;
using System.Collections.ObjectModel;
using System.Linq;

namespace RadixAPI.AntiFraud.ClearSale
{
    public class ClearSale : IAntiFraudProvider
    {
        private readonly RestClient client;

        private const string DEFAULT_ANALYSISLOCATION = "BRA";
        private const string ACCEPTABLE_STATUS = "APA";
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

            var requestSend = new RequestSendModel {
                AnalysisLocation = DEFAULT_ANALYSISLOCATION,
                ApiKey = API_KEY,
                LoginToken = Auth().Data.Token.Value,
                Orders = new Collection<OrderModel>
                {
                    new OrderModel{
                        
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
