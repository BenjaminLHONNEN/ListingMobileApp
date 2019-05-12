using System.Collections.Generic;
using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Models;
using Listings.Resources;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class ArticleListViewModel : BaseViewModel
    {
        private Article _selectedArticle;
        private List<Article> _articles;

        public string Title => LocalizedResource.ListingArticles;

        public Article SelectedArticle
        {
            get => _selectedArticle;
            set
            {
                _selectedArticle = value;
                OnPropertyChanged();
            }
        }

        public List<Article> Articles
        {
            get => _articles;
            set
            {
                _articles = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReloadArticlesCommand { get; set; }

        public ArticleListViewModel()
        {
            ReloadArticlesCommand = new Command(async () =>
            {
                IsBusy = true;
                Articles = await ArticlesService.GetAllArticlesAsync();
                IsBusy = false;
            });
            ReloadArticlesCommand.Execute(null);
        }
    }
}