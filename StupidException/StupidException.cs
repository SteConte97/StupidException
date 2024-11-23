using RestSharp;
using System.Net;
using System.Text.Json;

namespace CustomStupidException
{
    public class StupidException : Exception
    {
        public int StatusCode { get; private set; }

        #region HttpCat

        private const string _httpCatBaseUrl = "https://http.cat";

        public enum TypeResourcesCat
        {
            url,
            jpg
        }

        public string? HttpCatSource { get; private set; }

        private void getResourceHttpCat(TypeResourcesCat? typeResources)
        {
            try
            {
                var httpStatusCode = (HttpStatusCode)StatusCode;
                //the http 306 and 505 statuses are the only enumerator statuses that do not match on HttpCat
                if (httpStatusCode != HttpStatusCode.Unused && httpStatusCode != HttpStatusCode.HttpVersionNotSupported)
                {
                    HttpCatSource = $"{_httpCatBaseUrl}/{StatusCode}";
                }
                else
                {
                    HttpCatSource = $"{_httpCatBaseUrl}/404";
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region RandomAdvice

        public string? RandomAdvice { get; private set; }


        public struct ResponseRandomAdvice
        {
            public Slip? slip { get; set; }

        }
        public struct Slip
        {
            public int id { get; set; }
            public string advice { get; set; }

        }


        private static readonly RestClient _clientRandomAdvice = new RestClient(new RestClientOptions
        {
            BaseUrl = new Uri("https://api.adviceslip.com"),
        });

        private async Task getRandomAdvice()
        {
            try
            {
                var request = new RestRequest("/advice", Method.Get);
                var res = await _clientRandomAdvice.ExecuteAsync(request);
                if (!string.IsNullOrEmpty(res.Content))
                {
                    RandomAdvice = JsonSerializer.Deserialize<ResponseRandomAdvice>(res.Content).slip?.advice;
                }
            }
            catch (Exception)
            {
            }
        }


        #endregion

        public StupidException(int statusCode, string? message = null, Exception? inner = null, TypeResourcesCat? typeResources = TypeResourcesCat.url) : base(message, inner)
        {
            StatusCode = statusCode;
            getResourceHttpCat(typeResources);
            getRandomAdvice().Wait();
        }
    }
}
