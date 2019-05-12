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
    public partial class ConversationList : ContentPage
    {
        public ConversationList()
        {
            InitializeComponent();

            BindingContext = new ConversationListViewModel(Navigation);
            ConversationListItems.ItemTapped += (sender, args) =>
            {
                Conversation conversation = (Conversation) args.Item;
                Navigation.PushAsync(new ConversationDetail(conversation.Id));
            };
        }
    }
}