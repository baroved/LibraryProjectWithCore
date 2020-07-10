using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Client.ViewModel
{
    public class AdminPageViewModel:ViewModelBase
    {
        #region Properties
        private readonly INavigationService _navigationService;
        public RelayCommand BtnGoBack { get; set; }
        public RelayCommand BtnAddItem { get; set; }
        public RelayCommand BtnHistorySales { get; set; }
        public RelayCommand BtnHistoryPromotions { get; set; }
        public Customer Customer { get; set; }
        #endregion

        #region Constructor
        public AdminPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BtnGoBack = new RelayCommand(InitGoBackCommand);
            BtnAddItem = new RelayCommand(InitAddItemCommand);
            BtnHistorySales = new RelayCommand(InitHistorySalesCommand);
            BtnHistoryPromotions = new RelayCommand(InitHistoryPromotionsCommand);
            Messenger.Default.Register<Customer>(this, (customer) =>
            {
                Customer = customer;
            });
        }
        #endregion

        #region Methods
        //navigated to history promotions
        private void InitHistoryPromotionsCommand()
        {
            _navigationService.NavigateTo("HistoryPromotions");
        }

        //navigated to history sales
        private void InitHistorySalesCommand()
        {
            _navigationService.NavigateTo("HistorySales");
            Messenger.Default.Send(Customer);
            MessengerInstance.Send(true, "SaleByCustomer");
        }

        //navigated to go back
        private void InitGoBackCommand()
        {
            _navigationService.GoBack();

        }

        //if book so open add book page,if journal open add journal
        public async void InitAddItemCommand()
        {
            MessageDialog message = new MessageDialog("What would you like to add?", "Add Item");
            UICommand book = new UICommand("Book", OpenAddBook);
            UICommand journal = new UICommand("Journal", OpenAddJournal);
            UICommand Cancel = new UICommand("Cancel", CancelAdd);
            message.Commands.Add(book);
            message.Commands.Add(journal);
            message.Commands.Add(Cancel);
            await message.ShowAsync();
        }
        private void OpenAddBook(IUICommand command)
        {
            _navigationService.NavigateTo("AddBook");
        }

        private void OpenAddJournal(IUICommand command)
        {
            _navigationService.NavigateTo("AddJournal");
        }

        private void CancelAdd(IUICommand command) { }
      #endregion 
    }
    
}
