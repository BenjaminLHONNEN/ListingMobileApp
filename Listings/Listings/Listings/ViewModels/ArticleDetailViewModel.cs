using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Auth;
using Listings.Models;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class ArticleDetailViewModel :  BaseViewModel
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

        public ICommand CreateConversation { get; set; }

        public ArticleDetailViewModel(Article article)
        {
            Article = article;
            CreateConversation = new Command(async () =>
            {
                var userId = AuthService.Instance.UserId;
                if (userId.HasValue)
                {
                    CreateConversation createConversationModel = new CreateConversation
                    {
                        ArticleId = article.Id.Value,
                        ReceiverId = article.User.Id,
                        SenderId =  userId.Value
                    };
                    await ConversationService.CreateConversation(createConversationModel);
                }
            });
        }
    }
}
