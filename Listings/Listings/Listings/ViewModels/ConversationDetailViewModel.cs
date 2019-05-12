using System.Collections.Generic;
using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Models;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class ConversationDetailViewModel : BaseViewModel
    {
        private List<ConversationMessage> _conversation;

        public List<ConversationMessage> Conversations
        {
            get => _conversation;
            set
            {
                _conversation = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshConversation { get; set; }

        public ConversationDetailViewModel(long conversationId, INavigation navigation)
        {
            RefreshConversation = new Command(async () =>
            {
                Conversations = await ConversationService.GetConversation(conversationId);
            });
            RefreshConversation.Execute(null);
        }
    }
}