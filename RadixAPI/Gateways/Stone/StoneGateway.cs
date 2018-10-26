using RadixAPI.Contract;
using RestSharp;

namespace RadixAPI.Gateways.Stone
{
    public class StoneGateway : IGateway
    {
        const string API_URL = "https://transaction.stone.com.br";
        private readonly RestClient client;

        public StoneGateway()
        {
            this.client = new RestClient();
        }

        bool IGateway.MakeTransaction(TransactionRequest transactionRequest)
        {
            return true;
        }

        private IRestResponse<SaleResponseModel> Sale(SaleRequestModel srm)
        {
            var request = new RestRequest($"{API_URL}/Sale", Method.POST);
            request.AddBody(srm);

            return client.Execute<SaleResponseModel>(request);
        }
    }
}
