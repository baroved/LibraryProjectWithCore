using BusinessLogic.InputValidation;
using BusinessLogic.UserValidation;
using Client.Views;
using ClientLib.Api;
using ClientLib.Service;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Client.ViewModel
{
    public class ViewModelLocator
    {
        #region Constructor
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<CurrentItemViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AdminPageViewModel>();
            SimpleIoc.Default.Register<AddBookViewModel>();
            SimpleIoc.Default.Register<AddJournalViewModel>();
            SimpleIoc.Default.Register<HistoryPromotionsViewModel>();
            SimpleIoc.Default.Register<HistorySalesViewModel>();
            SimpleIoc.Default.Register<UpdateItemViewModel>();
            SimpleIoc.Default.Register<IHttpUser,HttpUser>();
            SimpleIoc.Default.Register<IHttpService, HttpService>();
            SimpleIoc.Default.Register<IHttpItem, HttpItem>();
            SimpleIoc.Default.Register<IHttpCustomer, HttpCustomer>();
            SimpleIoc.Default.Register<IHttpSale, HttpSale>();
            SimpleIoc.Default.Register<IHttpPromotion, HttpPromotions>();
            SimpleIoc.Default.Register<IHttpBook, HttpBook>();
            SimpleIoc.Default.Register<IHttpJournal, HttpJournal>();
            SimpleIoc.Default.Register<StartPageViewModel>();
            var nav = new NavigationService();
            nav.Configure("Login", typeof(Login));
            nav.Configure("Register", typeof(Register));
            nav.Configure("Main", typeof(Main));
            nav.Configure("Admin", typeof(AdminPage));
            nav.Configure("AddBook", typeof(AddBook));
            nav.Configure("AddJournal", typeof(AddJournal));
            nav.Configure("StartPage", typeof(StartPage));
            nav.Configure("HistorySales", typeof(HistorySales));
            nav.Configure("HistoryPromotions", typeof(HistoryPromotions));
            nav.Configure("UpdateItem", typeof(UpdateItem));

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IFilterSearch, FilterSearch>();
            SimpleIoc.Default.Register<IHttpEdition, HttpEdition>();
            SimpleIoc.Default.Register<IHttpGenres, HttpGenres>();
            SimpleIoc.Default.Register<IHttpBookGenre, HttpBookGenre>();
            SimpleIoc.Default.Register<ValidationInputs>();
            SimpleIoc.Default.Register<UserValidation>();
            SimpleIoc.Default.Register<IHttpPublisher, HttpPublisher>();
            SimpleIoc.Default.Register<IHttpWriter, HttpWriter>();
        }
        #endregion

        #region Methods
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public CurrentItemViewModel CurrentItem
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CurrentItemViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public RegisterViewModel Register
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }
        public AdminPageViewModel AdminPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdminPageViewModel>();
            }
        }

        public AddBookViewModel AddBook
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddBookViewModel>();
            }
        }

        public AddJournalViewModel AddJournal
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddJournalViewModel>();
            }
        }
        public HistorySalesViewModel HistorySales
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistorySalesViewModel>();
            }
        }

        public HistoryPromotionsViewModel HistoryPromotions
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistoryPromotionsViewModel>();
            }
        }

        public UpdateItemViewModel UpdateItem
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UpdateItemViewModel>();
            }
        }

        public StartPageViewModel StartPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartPageViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
        #endregion
    }
}