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
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.GetAsync($"{ApiConstant.ApiUrl}/conversations");
                    string json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<Conversation>>(json);
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

        public static async Task<List<ConversationMessage>> GetConversation(long conversationId)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.Instance.GetToken());
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.GetAsync($"{ApiConstant.ApiUrl}/conversations/{conversationId}/messages");
                    string json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<List<ConversationMessage>>(json);
                    }
                    return new List<ConversationMessage>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<ConversationCreated> CreateConversation(CreateConversation createConversation)
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
                        return JsonConvert.DeserializeObject<ConversationCreated>(responseText);
                    }
                    return null;
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
