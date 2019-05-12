using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Auth;
using Listings.Models;
using Listings.Views;
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

        public ArticleDetailViewModel(Article article, INavigation navigation)
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
                    var createdConversation = await ConversationService.CreateConversation(createConversationModel);
                    await navigation.PushAsync(new ConversationDetail(createdConversation.Id));
                }
            });
        }
    }
}
