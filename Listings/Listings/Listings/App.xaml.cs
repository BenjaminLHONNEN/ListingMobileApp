using System;
using Listings.Auth;
using Listings.Views;
using Xamarin.Forms;

namespace Listings
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MasterParentPage();
        }

        protected override void OnStart()
        {
            var authInstance = AuthService.Instance;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
