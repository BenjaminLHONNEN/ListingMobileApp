using System.Collections.Generic;
using System.Windows.Input;
using Listings.ApiHelper;
using Listings.Models;
using Listings.Views;
using Xamarin.Forms;

namespace Listings.ViewModels
{
    public class ConversationListViewModel : BaseViewModel
    {
        private List<Conversation> _conversations;
        private Conversation _selectedConversation;

        public List<Conversation> Conversations
        {
            get=> _conversations;
            set
            {
                _conversations = value;
                OnPropertyChanged();
            }
        }

        public Conversation SelectedConversation
        {
            get => _selectedConversation;
            set
            {
                _selectedConversation = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenDetailConversationCommand { get; set; }

        public ICommand RefreshConversationCommand { get; set; }

        public ConversationListViewModel(INavigation navigation)
        {
            RefreshConversationCommand = new Command(async () =>
            {
                Conversations = await ConversationService.GetConversations();
            });
            RefreshConversationCommand.Execute(null);
        }
    }
}