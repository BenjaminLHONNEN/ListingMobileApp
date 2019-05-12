using System;
using Listings.Auth;
using Listings.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
            AppCenter.Start("android=ca7ed945-af97-4ac5-aad3-01d2d1a402dc;" +
                            "uwp={Your UWP App secret here};" +
                            "ios={Your iOS App secret here}",
                typeof(Analytics), typeof(Crashes));
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
