using ClientLib.Api;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class HistoryPromotionsViewModel : ViewModelBase
    {
        #region Properties
        private readonly IHttpPromotion _httpPromotion;
        public ObservableCollection<Promotion> Promotions { get; set; }
        public RelayCommand BtnGoBack { get; set; }
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor
        public HistoryPromotionsViewModel(IHttpPromotion httpPromotion, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _httpPromotion = httpPromotion;
            InitPromotions();
            BtnGoBack = new RelayCommand(InitGoBackCommand);
        }
        #endregion

        #region Methods
        ////navigated to go back
        private void InitGoBackCommand()
        {
            _navigationService.GoBack();
        }

        //init all promotions
        public async void InitPromotions()
        {
            Promotions = new ObservableCollection<Promotion>(await _httpPromotion.GetAllPromotionsAsync());
            RaisePropertyChanged("Promotions");
        }
        #endregion

    }
}
