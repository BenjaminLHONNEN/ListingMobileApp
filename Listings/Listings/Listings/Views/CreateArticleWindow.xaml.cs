using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateArticleWindow : ContentPage
    {
        public CreateArticleWindow()
        {
            InitializeComponent();

            BindingContext = new CreatePageViewModel(Navigation);
        }
    }
}