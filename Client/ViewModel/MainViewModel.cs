using BusinessLogic.InputValidation;
using Client.Extentions;
using ClientLib.Api;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        public User User { get; set; }
        public RelayCommand BtnDisconnect { get; set; }
        private readonly INavigationService _navigationService;
        private readonly IHttpItem _httpItem;
        private readonly IHttpBook _httpBook;
        private readonly IHttpCustomer _httpCustomer;
        private readonly IDialogService _dialogService;
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<AbstractItem> Items { get; set; }
        public ObservableCollection<AbstractItem> ItemsBySearch { get; set; }
        public Customer Customer { get; set; }
        public RelayCommand<AbstractItem> ShowItemSelected { get; set; }
        public ICommand FilterTextChangedCommand { get; set; }
        public ICommand FilterComboChangedCommand { get; set; }
        public string Search { get; set; } = "";
        private readonly IFilterSearch _filterSearch;
        public RelayCommand<AbstractItem> BtnBuy { get; set; }
        public string SelectedFilter { get; set; }
        public RelayCommand BtnRefresh { get; set; }
        public RelayCommand<AbstractItem> BtnUpdate { get; set; }
        public IHttpSale _saleService { get; set; }
        public RelayCommand BtnAdminPermission { get; set; }
        public bool IsEnableToFilter { get; set; } = true;
        public string SelectedFilterDiscount { get; set; }
        public string SearchDiscount { get; set; } = "";
        public RelayCommand SearchDiscountCommand { get; set; }
        public ObservableCollection<string> DiscountTypes { get; set; }
        public ObservableCollection<string> SearchTypes { get; set; }
        private readonly ValidationInputs _validationInputs;
        #endregion

        #region Constructor
        public MainViewModel(ValidationInputs validationInputs, IHttpCustomer httpCustomer, INavigationService navigationService, IHttpItem httpItem,
            IDialogService dialogService, IFilterSearch filterSearch, IHttpSale saleService, IHttpBook httpBook)
        {
            _validationInputs = validationInputs;
            _httpBook = httpBook;
            _saleService = saleService;
            _httpCustomer = httpCustomer;
            _dialogService = dialogService;
            _navigationService = navigationService;
            _httpItem = httpItem;
            _filterSearch = filterSearch;
            //get user from login
            Messenger.Default.Register<User>(this, (user) =>
             {
                 User = user;
                 RaisePropertyChanged("User");
             });
            BtnDisconnect = new RelayCommand(InitDisconnectCommand);
            ShowItemSelected = new RelayCommand<AbstractItem>(InitItemSelectedCommand);
            FilterTextChangedCommand = new RelayCommand(InitSearchCommand);
            FilterComboChangedCommand = new RelayCommand(InitSearchCommand);
            BtnBuy = new RelayCommand<AbstractItem>(InitBuyCommand);
            BtnUpdate = new RelayCommand<AbstractItem>(InitUpdateItem, CanUpdate);
            BtnAdminPermission = new RelayCommand(InitAdminPermissionCommand);
            BtnRefresh = new RelayCommand(InitItems);
            InitCustomers();
            InitItems();
            SearchDiscountCommand = new RelayCommand(InitSearchDiscountCommand);
            InitDiscountType();
            InitSearchType();
            MessengerInstance.Register<bool>(this, "AddBook", b => InitItems());
            MessengerInstance.Register<bool>(this, "AddJournal", b => InitItems());
            MessengerInstance.Register<bool>(this, "UpdateItem", b => InitItems());
        }
        #endregion

        #region Methods
        public void InitSearchType()
        {
            SearchTypes = new ObservableCollection<string>
            {
                "Name",
                "Type",
                "Items in Discount"
            };
            RaisePropertyChanged(() => SearchTypes);
        }

        public void InitDiscountType()
        {
            DiscountTypes = new ObservableCollection<string>
            {
                "Publisher",
                "Writer",
                "Genre",
                "Type"
            };
            RaisePropertyChanged(() => DiscountTypes);
        }

        private bool CanUpdate(AbstractItem arg)
        {
            return User.IsAdmin;
        }

        //init update item and navigated to update item page
        private async void InitUpdateItem(AbstractItem obj)
        {
            var item = await _httpItem.GetItemById(obj.Id);
            _navigationService.NavigateTo("UpdateItem");
            Messenger.Default.Send(item);
        }


        ////navigated to Admin page
        private void InitAdminPermissionCommand()
        {
            _navigationService.NavigateTo("Admin");
            Messenger.Default.Send(Customer);
        }

        //init buy command
        private async void InitBuyCommand(AbstractItem item)
        {
            if (Customer != null && User != null)//if user choose customer
            {
                var historySale = new Sale
                {
                    ItemId = item.Id,
                    CustomerId = Customer.Id,
                    UserId = User.Id,
                    Date = DateTime.Now,
                    FinalPrice = item.Price
                };
                bool checkSale = _validationInputs.ValidForBuying(historySale);
                if (checkSale)
                {
                    bool ok = await _saleService.BuyItemAsync(historySale);
                    if (ok)
                    {
                        await _dialogService.ShowMessage("Item purchased !", "Ok");
                        InitItems();
                        MessengerInstance.Send(true, "SellItem");
                    }
                    else
                        await _dialogService.ShowMessage("Something wrong !", "Error");
                }
                else
                    await _dialogService.ShowMessage("Something wrong !", "Error");
            }
            else await _dialogService.ShowMessage("Choose Customer !", "Error");

        }

        //init searchDiscount
        public async void InitSearchDiscountCommand()
        {
            ItemsBySearch = Items;
            if (SearchDiscount != "" && SelectedFilterDiscount == "Publisher")//user choose by publisher discount
                ItemsBySearch = new ObservableCollection<AbstractItem>(await _httpItem.GetItemsByPublisherDiscount(SearchDiscount));
            else
            {
                if (SelectedFilterDiscount == "Writer")//user choose writer discount
                    ItemsBySearch = new ObservableCollection<AbstractItem>(await _httpItem.GetItemsByWriterDiscount(SearchDiscount));
                else
                    if (SelectedFilterDiscount == "Genre")//user choose genre discount
                    ItemsBySearch = new ObservableCollection<AbstractItem>(await _httpItem.GetItemsByGenreDiscount(SearchDiscount));
                else
                    if (SelectedFilterDiscount == "Type")//user choose type discount
                    ItemsBySearch = new ObservableCollection<AbstractItem>(await _httpItem.GetItemsByTypeDiscount(SearchDiscount));
            }
            RaisePropertyChanged("ItemsBySearch");
            SearchDiscount = "";
            RaisePropertyChanged("SearchDiscount");

        }


        //init search command
        private void InitSearchCommand()
        {
            IsEnableToFilter = true;
            RaisePropertyChanged("IsEnableToFilter");
            ItemsBySearch = Items;
            if (Search != "" && (SelectedFilter == "Name" || SelectedFilter == "Type"))//for wait for text input from user
            {
                if (SelectedFilter == "Name")//user choose get items by name
                    ItemsBySearch = new ObservableCollection<AbstractItem>(_filterSearch.GetItemsByName(ItemsBySearch, Search));
                if (SelectedFilter == "Type")//user choose get items by type
                    ItemsBySearch = new ObservableCollection<AbstractItem>(_filterSearch.GetItemsByType(ItemsBySearch, Search));
            }
            else
            {
                if (SelectedFilter == "Items in Discount")////user choose get items by discount
                {
                    IsEnableToFilter = false;//user cannot write anything if choose by discount
                    Search = "";
                    RaisePropertyChanged("Search");
                    RaisePropertyChanged("IsEnableToFilter");
                    ItemsBySearch = new ObservableCollection<AbstractItem>(_filterSearch.GetItemsByDiscount(ItemsBySearch));
                }
            }

            RaisePropertyChanged("ItemsBySearch");

        }

        //init current item
        private async void InitItemSelectedCommand(AbstractItem item)
        {
            if (item != null)
                item = await _httpItem.GetItemById(item.Id);
            Messenger.Default.Send(item);//send current item selected to user control

        }

        //init items to list view
        public async void InitItems()
        {
            var result = await _httpItem.GetAllItems();
            Items = new ObservableCollection<AbstractItem>(result);
            ItemsBySearch = Items;
            RaisePropertyChanged(() => ItemsBySearch);
            InitCustomers();
            InitSearchType();
            InitDiscountType();
            InitItemSelectedCommand(null);
        }

        //init customers to combobox
        public async void InitCustomers()
        {
            Customers = new ObservableCollection<Customer>(await _httpCustomer.GetAllCustomers());
            Customers.Add(null);
            RaisePropertyChanged("Customers");
        }

        //navigate to login page
        private void InitDisconnectCommand()
        {
            _navigationService.NavigateTo("Login");
        }

        #endregion
    }
}
