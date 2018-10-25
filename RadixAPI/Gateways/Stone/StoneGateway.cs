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

        private void Sale(SaleRequestModel srm)
        {
            var request = new RestRequest($"{API_URL}/Sale", Method.POST);
            request.AddBody(srm);

            var response = client.Execute<SaleResponseModel>(request);
        }
    }
}
