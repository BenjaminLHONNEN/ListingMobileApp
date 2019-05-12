using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Models;
using Listings.Resources;
using Listings.Views;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class ArticleListViewModel : BaseViewModel
    {
        private Article _selectedArticle;
        private List<Article> _articles;
        private List<Article> _articlesConstant;
        private string _research;

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

        public string Research
        {
            get => _research;
            set
            {
                _research = value;
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
        public ICommand CreateArticlesCommand { get; set; }
        public ICommand ResearchCommand { get; set; }

        public ArticleListViewModel(INavigation navigation)
        {
            ReloadArticlesCommand = new Command(async () =>
            {
                IsBusy = true;
                _articlesConstant = await ArticlesService.GetAllArticlesAsync();
                Articles = _articlesConstant;
                IsBusy = false;
            });
            ReloadArticlesCommand.Execute(null);
            ResearchCommand = new Command(() =>
            {
                Articles = _articlesConstant.Where(w =>
                    w.Title.ToUpper().Contains(Research.ToUpper()) ||
                    w.Content.ToUpper().Contains(Research.ToUpper())).ToList();
            });
            CreateArticlesCommand = new Command(async () =>
            {
                await navigation.PushAsync(new CreateArticleWindow(), true);
                ReloadArticlesCommand.Execute(null);
            });
        }
    }
}