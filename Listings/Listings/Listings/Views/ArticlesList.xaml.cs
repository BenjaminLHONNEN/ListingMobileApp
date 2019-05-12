using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listings.Models;
using Listings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlesList : ContentPage
    {
        public ArticlesList()
        {
            InitializeComponent();
            BindingContext = new ArticleListViewModel();

            ArticleList.ItemTapped += (sender, args) =>
            {
                Article article = (Article)args.Item;
                Navigation.PushAsync(new ArticleDetail(article));
            };
            ButtonCreateView.Clicked += (sender, args) => { Navigation.PushAsync(new CreateArticleWindow()); };
        }
    }
}