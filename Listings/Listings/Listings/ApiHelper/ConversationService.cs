using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Listings.Auth;
using Listings.Models;
using Newtonsoft.Json;

namespace Listings.ApiHelper
{
    public class ConversationService
    {
        public static async Task<List<Conversation>> GetConversations()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Instance.GetToken());
                    var response = await httpClient.GetAsync($"{ApiConstant.ApiUrl}/conversations");
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<Conversation>>(await response.Content.ReadAsStringAsync());
                    }
                    return new List<Conversation>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<bool> CreateConversation(CreateConversation createConversation)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Instance.GetToken());
                    string json = JsonConvert.SerializeObject(createConversation);
                    var response = await httpClient.PostAsync($"{ApiConstant.ApiUrl}/conversations", new StringContent(json, Encoding.UTF8, "application/json"));
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
    }
}
