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
            private bool _islogged;
            public ObservableCollection<MasterMenuItem> MenuItems { get; set; }
            public bool IsLogged => _islogged;
            public UserConnection UserConnection => AuthService.Instance.UserConnection;

            public MasterMasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem {Id = 0, Title = "Liste d'articles", TargetType = typeof(ArticlesList)},
                });
                _islogged = AuthService.Instance.IsLogged();
                OnPropertyChanged(nameof(IsLogged));
                if (_islogged)
                {
                    MenuItems.Add(
                        new MasterMenuItem
                            {Id = 3, Title = "Mes conversations", TargetType = typeof(ConversationList)});
                    MenuItems.Add(
                        new MasterMenuItem
                            {Id = 1, Title = "Créer un article", TargetType = typeof(CreateArticleWindow)});
                    OnPropertyChanged(nameof(MenuItems));
                }
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