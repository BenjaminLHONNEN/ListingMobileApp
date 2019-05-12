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
    public partial class ArticleDetail : ContentPage
    {
        public ArticleDetail(Article article)
        {
            InitializeComponent();

            BindingContext = new ArticleDetailViewModel(article);
        }
    }
}