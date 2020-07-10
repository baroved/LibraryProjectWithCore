using System;
using BusinessLogic.InputValidation;
using BusinessLogic.UserValidation;
using ClientLib.Api;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Shared.Model;
using Windows.UI.Xaml.Controls;

namespace Client.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Properties
        private readonly INavigationService _navigationService;
        private readonly IHttpUser _httpUser;
        private readonly IDialogService _idialogService;
        public RelayCommand btnToRegister { get; set; }
        public RelayCommand<object> btnToLogin { get; set; }
        public User User { get; set; }
        private readonly UserValidation _userValidation;
        #endregion

        #region Constructor
        public LoginViewModel(UserValidation userValidation, INavigationService navigationService, IHttpUser httpUser, IDialogService idialogService)
        {
            _userValidation = userValidation;
            _navigationService = navigationService;
            _httpUser = httpUser;
            _idialogService = idialogService;
            User = new User();
            btnToRegister = new RelayCommand(InitRegisterCommand);
            btnToLogin = new RelayCommand<object>(InitLoginCommand);
        }
        #endregion

        #region Methods
        //login command
        private async void InitLoginCommand(object paswword)
        {
            User.Password = ((PasswordBox)paswword).Password;
            bool checkUser = _userValidation.Login(User);
            if (checkUser)
            {
                User ok = await _httpUser.Login(User);
                if (ok == null)
                    await _idialogService.ShowMessage("Something wrong!!", "Error");
                else
                {
                    if (ok.IsAdmin)//if admin
                    {
                        await _idialogService.ShowMessage("You are connected as Admin!!", "OK");
                    }
                    else
                        await _idialogService.ShowMessage("You are connected as User!!", "OK");
                    _navigationService.NavigateTo("Main");
                    User = ok;
                    Messenger.Default.Send(User);
                    User = new User();
                    RaisePropertyChanged("User");
                }
            }
            else
                await _idialogService.ShowMessage("Something wrong!!", "Error");

            }

            //navigated to register
            private void InitRegisterCommand()
            {
                _navigationService.NavigateTo("Register");
            }
            #endregion
        }
    }