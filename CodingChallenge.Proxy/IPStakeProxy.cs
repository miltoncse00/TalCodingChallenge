using System;
using System.Net;
using System.Threading.Tasks;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Interfaces;
using Newtonsoft.Json;
using Polly;
using RestSharp;

namespace CodingChallenge.Proxy
{
    public class ProxyBase
    {
        protected Task<IRestResponse> GetPolyRetryResult(Func<Task<IRestResponse>> executeRequest)
        {
            var poly = Policy
                .HandleResult<IRestResponse>(r => r.ResponseStatus != ResponseStatus.Completed)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt * 5));

            return poly.ExecuteAsync(() => executeRequest());
        }
    }

    public class IPStakeProxy: ProxyBase, IIPStakeProxy
    {
        private readonly string _baseUrl;
        private readonly string _accessKey;

        public IPStakeProxy(string baseUrl, string accessKey)
        {
            _baseUrl = baseUrl;
            _accessKey = accessKey;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }


        public async Task<Address> GetAddress(string ip)
        {
            var restClient = new RestClient(_baseUrl);
            var request = new RestRequest($"{ip}", Method.GET);
            request.AddQueryParameter("access_key", _accessKey);
           
            var result = await GetPolyRetryResult(() => restClient.ExecuteAsync(request));

            if (result.ResponseStatus == ResponseStatus.Error)
            {
                string message = $"Error retrieving response from ipstake api ";
                throw new ApplicationException(message, result.ErrorException);
            }

            var address = JsonConvert.DeserializeObject<Address>(result.Content);
           
            return address;
        }
    }
}
