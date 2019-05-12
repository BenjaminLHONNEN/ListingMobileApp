using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Listings.Models;
using Listings.Resources;
using Newtonsoft.Json;

namespace Listings.ApiHelper
{
    public static class UserService
    {
        public static async Task<UserToken> AuthUserAsync(UserConnection user)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsync(
                        $"{ApiConstant.ApiUrl}/auth/login",
                        new FormUrlEncodedContent(
                            new KeyValuePair<string, string>[]
                            {
                                new KeyValuePair<string, string>("email", user.Email),
                                new KeyValuePair<string, string>("password", user.Password)
                            }
                        ));
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<UserToken>(await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        throw new Exception(LocalizedResource.AuthError);
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