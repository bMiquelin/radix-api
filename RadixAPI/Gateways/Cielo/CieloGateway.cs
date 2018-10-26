using RadixAPI.Contract;
using RestSharp;

namespace RadixAPI.Gateways.Cielo
{
    public class CieloGateway : IGateway
    {
        const string API_URL = "https://apisandbox.cieloecommerce.cielo.com.br";
        private readonly RestClient client;

        public CieloGateway()
        {
            this.client = new RestClient();
        }

        bool IGateway.MakeTransaction(TransactionRequest transactionRequest)
        {
            return true;
        }

        private IRestResponse<SalesResponseModel> Sales(SalesRequestModel srm)
        {
            var request = new RestRequest($"{API_URL}/1/sales",Method.POST);
            request.AddBody(srm);

            return client.Execute<SalesResponseModel>(request);
        }
    }
}
