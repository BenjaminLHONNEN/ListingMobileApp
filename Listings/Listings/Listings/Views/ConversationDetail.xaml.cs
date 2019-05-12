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
    public partial class ConversationDetail : ContentPage
    {
        public ConversationDetail(long conversationId)
        {
            InitializeComponent();

            BindingContext = new ConversationDetailViewModel(conversationId, Navigation);
        }
    }
}