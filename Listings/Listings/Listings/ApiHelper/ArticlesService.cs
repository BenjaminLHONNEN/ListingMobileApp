using Listings.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Listings.Auth;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace Listings.ApiHelper
{
    public class ArticlesService
    {
        public static async Task<bool> CreateArticle(Article article)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var t = AuthService.Instance.GetToken();
                    if (AuthService.Instance.GetToken() != null)
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Instance.GetToken());
                    }

                    string json = JsonConvert.SerializeObject(new {article = article});
                    var response = await httpClient.PostAsync($"{ApiConstant.ApiUrl}/articles",
                        new StringContent(json, Encoding.UTF8, "application/json"));
                    
                    var responseText = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<List<Article>> GetAllArticlesAsync()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.GetAsync($"{ApiConstant.ApiUrl}/articles");
                    string json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<Article>>(json);
                    }
                    else
                    {
                        return new List<Article>();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}