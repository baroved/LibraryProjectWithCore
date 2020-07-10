using BusinessLogic.InputValidation;
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
    public class AddJournalViewModel : ViewModelBase
    {
        #region Properties
        public ObservableCollection<Edition> Editions { get; set; }
        public Edition Edition { get; set; }
        public Journal newJournal { get; set; }
        private readonly IHttpEdition _httpEdition;
        private readonly IHttpJournal _httpJournal;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        public RelayCommand BtnAddJournal { get; set; }
        public RelayCommand BtnCancel { get; set; }
        public string Copies { get; set; } = "";
        public string Price { get; set; } = "";
        public ObservableCollection<Publisher> Publishers { get; set; }
        public Publisher Publisher { get; set; }
        private readonly IHttpPublisher _publisherService;
        private readonly ValidationInputs _validationInputs;
        #endregion

        #region Constructor
        public AddJournalViewModel(ValidationInputs validationInputs, IHttpEdition httpEdition, IHttpJournal httpJournal, IDialogService dialogService
            , INavigationService navigationService, IHttpPublisher publisherService)
        {
            _publisherService = publisherService;
            _httpEdition = httpEdition;
            _httpJournal = httpJournal;
            InitAllEditions();
            BtnAddJournal = new RelayCommand(InitAddJournalCommand);
            BtnCancel = new RelayCommand(InitCancelCommand);
            newJournal = new Journal();
            _dialogService = dialogService;
            _navigationService = navigationService;
            Edition = new Edition();
            InitPublishers();
            _validationInputs = validationInputs;
        }
        #endregion

        #region Methods
        private async void InitPublishers()
        {
            Publishers = new ObservableCollection<Publisher>(await _publisherService.GetAllPublishers());
            RaisePropertyChanged("Publishers");
        }

        private void RestartInputs()
        {
            newJournal = new Journal();
            Copies = "";
            Price = "";
        }

        private void InitCancelCommand()
        {
            RestartInputs();
            _navigationService.GoBack();
        }

        private async void InitAddJournalCommand()
        {
            if (Publisher != null)
            {
                newJournal.PublisherId = Publisher.Id;
                newJournal.PrintDate = DateTime.Now;
                newJournal.EditionId = Edition.Id;
                int copies;
                double price;
                bool checkCopies = int.TryParse(Copies, out copies);
                bool checkPrice = double.TryParse(Price, out price);
                if (!checkCopies || !checkPrice)//check if parse succeeded
                    await _dialogService.ShowMessage("Price and/or Copies inputs must be Numbers", "Error");
                else
                {
                    newJournal.CopiesInStock = copies;
                    newJournal.Price = price;
                    bool checkJournal = _validationInputs.ValidForAddJournal(newJournal);
                    if (checkJournal)
                    {
                        bool ok = await _httpJournal.AddJournalAsync(newJournal);
                        if (ok)
                        {
                            RestartInputs();
                            await _dialogService.ShowMessage("Journal added !", "Ok");
                            _navigationService.GoBack();
                            MessengerInstance.Send(true, "AddJournal");
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
            else
                await _dialogService.ShowMessage("You Have to choose Publisher !", "Error");


        }

        //init all editions to combo box
        public async void InitAllEditions()
        {
            Editions = new ObservableCollection<Edition>(await _httpEdition.GetAllEditionsAsync());
            RaisePropertyChanged("Editions");
        }
        #endregion
    }
}
