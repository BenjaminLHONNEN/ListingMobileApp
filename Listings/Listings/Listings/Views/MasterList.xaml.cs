using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Listings.Auth;
using Listings.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Listings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterList : ContentPage
    {
        public ListView ListView;
        public Button SignInButtonObject;

        public MasterList()
        {
            InitializeComponent();

            BindingContext = new MasterMasterMasterViewModel();
            ListView = MenuItemsListView;
            SignInButtonObject = SignInButton;
        }

        class MasterMasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterMenuItem> MenuItems { get; set; }
            public bool IsLogged => AuthService.Instance.IsLogged();
            public UserConnection UserConnection => AuthService.Instance.UserConnection;

            public MasterMasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem {Id = 0, Title = "Liste d'articles", TargetType = typeof(ArticlesList)},
                    new MasterMenuItem {Id = 1, Title = "Créer un article", TargetType = typeof(CreateArticleWindow)},
                });
            }

            #region INotifyPropertyChanged Implementation

            public event PropertyChangedEventHandler PropertyChanged;

            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }
    }
}