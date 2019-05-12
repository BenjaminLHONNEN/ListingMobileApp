using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Auth;
using Listings.Models;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class CreatePageViewModel : BaseViewModel
    {
        private Article _article;

        public Article Article
        {
            get => _article;
            set
            {
                _article = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddArticle { get; set; }

        public CreatePageViewModel(INavigation navigation)
        {
            Title = "Créer une offre";
            Article = new Article()
            {
                Category = new Category()
                {
                    Id = 1,
                    Name = "Test"
                },
                UserId = AuthService.Instance.UserId.Value
            };
            AddArticle = new Command(async () =>
            {
                var result = await ArticlesService.CreateArticle(Article);
                await navigation.PopAsync();
            });
        }
    }
}