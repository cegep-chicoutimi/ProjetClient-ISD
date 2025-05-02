using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioAPI.Models;
using Newtonsoft.Json;

namespace BiblioAPI
{
    public class BiblioProcessor
    {
        public static Task<string> Authentification(string username, string password)
        {
            string url = $"/Login/{username}/{password}";

            using (Task<HttpResponseMessage> response = ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.Result.IsSuccessStatusCode)
                {
                    Task<string> apiKey = response.Result.Content.ReadAsAsync<string>();
                    return apiKey;
                }
                else
                {
                    return null;
                }
            }
        }


        public static Task<List<LivreAPI>> GetAllLivre()
        {
            string url = "api/Livre";
            using (Task<HttpResponseMessage> response = ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.Result.IsSuccessStatusCode)
                {
                    Task<List<LivreAPI>> livre = response.Result.Content.ReadAsAsync<List<LivreAPI>>();
                    return livre;
                }
                else
                {
                    throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public static Task<List<Auteur>> GetAllAuteur()
        {
            string url = "/api/Auteur";

            using (Task<HttpResponseMessage> response = ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.Result.IsSuccessStatusCode)
                {
                    Task<List<Auteur>> auteurs = response.Result.Content.ReadAsAsync<List<Auteur>>();
                    return auteurs;
                }
                else
                {
                    throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public static Task<HttpResponseMessage> PutLivre(LivreAPI Livre)
        {
            string url = $"api/Livre/{Livre.Id}";
            string serializedLivre = JsonConvert.SerializeObject(Livre);

            HttpContent httpContent = new StringContent(serializedLivre);
            if (httpContent.Headers.ContentType != null)
            {
                httpContent.Headers.ContentType.MediaType = "application/json";
            }

            Task<HttpResponseMessage> response = ApiHelper.ApiClient.PutAsync(url, httpContent);
            return response;
        }
    }
}
