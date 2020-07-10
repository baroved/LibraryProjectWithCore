using Client.Extentions;
using ClientLib.Api;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class HistorySalesViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<Sale> HistorySales { get; set; }
        private readonly IHttpSale _saleService;
        public RelayCommand BtnGoBack { get; set; }
        private readonly INavigationService _navigationService;
        public Customer Customer { get; set; }
        #endregion

        #region Constructor
        public HistorySalesViewModel(IHttpSale saleService, INavigationService navigationService)
        {
            _saleService = saleService;
            _navigationService = navigationService;
            BtnGoBack = new RelayCommand(InitGoBackCommand);

            InitHistorySales();
            Messenger.Default.Register<Customer>(this, (customer) =>
             {
                 Customer = customer;
             });
            MessengerInstance.Register<bool>(this, "SellItem", b => InitHistorySales());
            MessengerInstance.Register<bool>(this, "SaleByCustomer", b => InitHistorySales());
        }
        #endregion

        #region Methods
        //navigated to go back
        private void InitGoBackCommand()
        {
            _navigationService.GoBack();
        }

        //init history sales
        public async void InitHistorySales()
        {
            HistorySales = new ObservableCollection<Sale>(await _saleService.GetAllHistorySales());
            if (Customer != null && Customer.Name != "All Sales")
                HistorySales = new ObservableCollection<Sale>(HistorySales.Where(item => item.CustomerId == Customer.Id).ToList());
            else
            {
                Customer = new Customer
                {
                    Name = "All Sales"
                };
                RaisePropertyChanged("Customer");
            }
            RaisePropertyChanged("HistorySales");
        }
        #endregion
    }
}
