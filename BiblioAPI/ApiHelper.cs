using System.Net.Http.Headers;

namespace BiblioAPI
{
    public class ApiHelper
    {
        public static HttpClient? ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.BaseAddress = new Uri("https://localhost:7283");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static void InsertApikey(string apiKey)
        {
            if (ApiClient != null)
            {
                if (ApiClient.DefaultRequestHeaders.Contains("X-API-Key"))
                    ApiClient.DefaultRequestHeaders.Remove("X-API-Key");

                ApiClient.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            }
        }
    }
}
