using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class StartPageViewModel : ViewModelBase
    {
        #region Properties
        public RelayCommand GoToLoginCommand { get; set; }
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor
        public StartPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToLoginCommand = new RelayCommand(InitGoToLogin);
        }
        #endregion

        #region Methods
        private void InitGoToLogin()
        {
            _navigationService.NavigateTo("Login");
        }
        #endregion
    }
}
