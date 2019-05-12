using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listings.ApiHelper;
using Listings.Models;
using Listings.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Listings.Auth
{
    public class AuthService : BaseViewModel
    {
        private static AuthService _instance;

        private UserToken _userToken;
        private UserConnection _userConnection;
        public UserConnection UserConnection => _userConnection;

        public Int64? UserId
        {
            get
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var tokenS = handler.ReadToken(_userToken.Token) as JwtSecurityToken;
                    var keyValuePairParent = tokenS?.Payload.FirstOrDefault(w => w.Key == "user_id");
                    var keyValuePair = keyValuePairParent.Value;
                    var value = keyValuePair.Value;
                    return (Int64)value;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static AuthService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthService();
                }

                return _instance;
            }
        }

        private bool _isLogged;

        private AuthService()
        {
            _isLogged = false;
            if (Application.Current.Properties.ContainsKey("userToken") &&
                Application.Current.Properties["userToken"] != null)
            {
                _userToken = JsonConvert.DeserializeObject<UserToken>(Application.Current.Properties["userToken"]
                    .ToString());
            }

            if (Application.Current.Properties.ContainsKey("userConnection") &&
                Application.Current.Properties["userToken"] != null)
            {
                _userConnection =
                    JsonConvert.DeserializeObject<UserConnection>(Application.Current.Properties["userConnection"]
                        .ToString());
            }

            if (_userConnection != null && _userToken != null)
            {
                _isLogged = true;
            }

            if (_userConnection != null)
            {
                Task.Run(async () => { await LogUser(_userConnection); });
            }
        }

        private async Task SaveUser()
        {
            Application.Current.Properties["userToken"] = JsonConvert.SerializeObject(_userToken);
            Application.Current.Properties["userConnection"] = JsonConvert.SerializeObject(_userConnection);
            await Application.Current.SavePropertiesAsync();
        }

        public bool IsLogged()
        {
            return _isLogged && DateTime.Now <= _userToken.Exp;
        }

        public async Task<bool> LogUser(UserConnection user)
        {
            try
            {
                _userToken = await UserService.AuthUserAsync(user);
                _userConnection = user;
                await SaveUser();
                _isLogged = true;
                OnPropertyChanged(nameof(IsLogged));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetToken()
        {
            return _userToken?.Token;
        }
    }
}