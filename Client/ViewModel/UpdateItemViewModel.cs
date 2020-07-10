using BusinessLogic.InputValidation;
using ClientLib.Api;
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

namespace Client.ViewModel
{
    public class UpdateItemViewModel : ViewModelBase
    {
        #region Properties
        public AbstractItem Item { get; set; }
        public string Copies { get; set; } = "";
        public string Price { get; set; } = "";
        public RelayCommand BtnUpdate { get; set; }
        public RelayCommand BtnCancel { get; set; }
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IHttpBook _httpBook;
        private readonly IHttpJournal _httpJournal;
        private readonly ValidationInputs _validationInputs;
        #endregion

        #region Constructor
        public UpdateItemViewModel(ValidationInputs validationInputs, INavigationService navigationService, IDialogService dialogService
            , IHttpBook httpBook, IHttpJournal httpJournal)
        {
            _validationInputs = validationInputs;
            _navigationService = navigationService;
            _dialogService = dialogService;
            _httpBook = httpBook;
            _httpJournal = httpJournal;
            Messenger.Default.Register<AbstractItem>(this, (obj) =>
            {
                if (obj != null)
                {
                    Item = obj;
                    Copies = obj.CopiesInStock.ToString();
                    Price = obj.Price.ToString();
                    RaisePropertyChanged("Copies");
                    RaisePropertyChanged("Price");
                }
            });

            BtnCancel = new RelayCommand(InitBtnCancelCommand);
            BtnUpdate = new RelayCommand(InitBtnUpdateCommand);
        }
        #endregion

        #region Methods
        private async void InitBtnUpdateCommand()
        {
            bool ok;
            int copies;
            double price;
            bool checkCopies = int.TryParse(Copies, out copies);
            bool checkPrice = double.TryParse(Price, out price);
            if (!checkCopies || !checkPrice)//check if parse succeeded
                await _dialogService.ShowMessage("Price and/or Copies inputs must be Numbers", "Error");
            else
            {
                Item.CopiesInStock = copies;
                Item.Price = price;
                bool checkItem = _validationInputs.ValidUpdatedItem(Item);
                if (checkItem)
                {
                    if (Item is Book)
                        ok = await _httpBook.UpdateBookAsync((Book)Item);
                    else
                        ok = await _httpJournal.UpdateJournalAsync((Journal)Item);
                    if (ok)
                    {
                        await _dialogService.ShowMessage("Item Updated !", "Ok");
                        _navigationService.GoBack();
                        MessengerInstance.Send(true, "UpdateItem");
                    }
                    else
                    {
                        await _dialogService.ShowMessage("Something wrong !", "Error");
                    }
                }
                else
                    await _dialogService.ShowMessage("Something wrong !", "Error");
            }
        }
        //navigated to go back
        private void InitBtnCancelCommand()
        {
            _navigationService.GoBack();
        }
        #endregion

    }
}
