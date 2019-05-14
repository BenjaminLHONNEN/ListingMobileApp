using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Auth;
using Listings.Models;
using Listings.Views;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private UserConnection _userConnection;

        public UserConnection UserConnection
        {
            get => _userConnection;
            set
            {
                _userConnection = value;
                OnPropertyChanged();
            }
        }

        public ICommand LogUserCommand { get; set; }

        public AuthViewModel(INavigation navigation)
        {
#if DEBUG
            UserConnection = new UserConnection()
            {
                Email = "user@domaine.com",
                Password = "123Pass123"
            };
#endif
            LogUserCommand = new Command(async () =>
            {
                if (UserConnection.IsValid())
                {
                    await AuthService.Instance.LogUser(UserConnection);
                    await navigation.PopToRootAsync(true);
                }
            });
        }
    }
}