using System;
using System.Threading.Tasks;
using CodingChallenge.Domain;
using CodingChallenge.Domain.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace CodingChallenge.Proxy
{
    public class JayrideChallegeProxy :ProxyBase, IJayrideChallegeProxy
    {
        readonly string _baseUrl;

        public JayrideChallegeProxy(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<Quote> GetQuote()
        {
            var restClient = new RestClient(_baseUrl);
            var request = new RestRequest($"api/QuoteRequest", Method.GET);

            var result = await GetPolyRetryResult(() => restClient.ExecuteAsync(request));

            if (result.ResponseStatus == ResponseStatus.Error)
            {
                string message = $"Error retrieving response from ipstake api ";
                throw new ApplicationException(message, result.ErrorException);
            }

            var address = JsonConvert.DeserializeObject<Quote>(result.Content);

            return address;
        }
    }
}