using BusinessLogic.UserValidation;
using ClientLib.Api;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        #region Properties
        private readonly INavigationService _navigationService;
        private readonly IHttpUser _httpUser;
        private readonly IDialogService _idialogService;
        public RelayCommand btnGoBack { get; set; }
        public RelayCommand btnRegister { get; set; }
        public User NewUser { get; set; }
        private readonly UserValidation _userValidation;
        #endregion

        #region Constructor
        public RegisterViewModel(UserValidation userValidation, INavigationService navigationService, IHttpUser httpUser, IDialogService idialogService)
        {
            _userValidation = userValidation;
            _navigationService = navigationService;
            _httpUser = httpUser;
            _idialogService = idialogService;
            NewUser = new User();
            btnRegister = new RelayCommand(initRegisterCommand);
            btnGoBack = new RelayCommand(InitGoBackCommand);
        }
        #endregion

        #region Methods
        //register command
        private async void initRegisterCommand()
        {
            bool checkUser = _userValidation.Register(NewUser);
            if (checkUser)
            {
                bool ok = await _httpUser.Register(NewUser);
                if (ok)
                {
                    await _idialogService.ShowMessage("You are registered !", "OK");
                    NewUser = new User();
                    RaisePropertyChanged("NewUser");
                    _navigationService.NavigateTo("Login");
                }
                else
                    await _idialogService.ShowMessage("Something wrong !", "Error");
            }
            else
                await _idialogService.ShowMessage("Something wrong !", "Error");

        }

        //navigated to go back
        private void InitGoBackCommand()
        {
            _navigationService.GoBack();
        }
        #endregion
    }
}
