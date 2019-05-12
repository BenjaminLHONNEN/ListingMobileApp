using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listings.Models;
using Listings.ViewModels;
using Listings.Views;
using Xamarin.Forms;

namespace Listings
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ArticleListViewModel(Navigation);

            ArticleList.ItemTapped += (sender, args) =>
            {
                Article article = (Article) args.Item;
                Navigation.PushAsync(new ArticleDetail(article));
            };
            ButtonCreateView.Clicked += (sender, args) => {  };
        }
    }
}
