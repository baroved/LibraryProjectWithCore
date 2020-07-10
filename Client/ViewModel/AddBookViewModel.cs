using BusinessLogic.InputValidation;
using Client.Extentions;
using ClientLib.Api;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Shared.BookResponse;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class AddBookViewModel : ViewModelBase
    {
        #region Properties
        public Book NewBook { get; set; }
        private readonly IHttpGenres _httpGenres;
        private readonly IHttpBook _httpBook;
        private readonly IHttpBookGenre _httpBookGenre;
        public ObservableCollection<Genre> Genres { get; set; }
        public ObservableCollection<ExtentionsGenres> GenresBinding { get; set; }
        public RelayCommand BtnCancel { get; set; }
        public RelayCommand BtnAddBook { get; set; }
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        public string Copies { get; set; } = "";
        public string Price { get; set; } = "";
        private readonly IHttpPublisher _publisherService;
        private readonly IHttpWriter _writerService;
        public ObservableCollection<Publisher> Publishers { get; set; }
        public ObservableCollection<Writer> Writers { get; set; }
        public Publisher Publisher { get; set; }
        public Writer Writer { get; set; }
        private readonly ValidationInputs _validationInputs;
        #endregion

        #region Constructor
        public AddBookViewModel(ValidationInputs validationInputs, IHttpGenres httpGenres, INavigationService navigationService, IDialogService dialogService, IHttpBook httpBook
            , IHttpBookGenre httpBookGenre, IHttpPublisher publisherService, IHttpWriter writerService)
        {
            _publisherService = publisherService;
            _writerService = writerService;
            NewBook = new Book();
            _httpBookGenre = httpBookGenre;
            _httpBook = httpBook;
            _httpGenres = httpGenres;
            _navigationService = navigationService;
            _dialogService = dialogService;
            GenresBinding = new ObservableCollection<ExtentionsGenres>();
            BtnCancel = new RelayCommand(InitGoBackCommand);
            BtnAddBook = new RelayCommand(InitAddBookCommand);
            InitGenres();
            InitPublishers();
            InitWriters();
            _validationInputs = validationInputs;
        }
        #endregion

        #region Methods
        //init publishers to combobox
        public async void InitPublishers()
        {
            Publishers = new ObservableCollection<Publisher>(await _publisherService.GetAllPublishers());
            RaisePropertyChanged("Publishers");
        }

        //init writers to combobox
        public async void InitWriters()
        {
            Writers = new ObservableCollection<Writer>(await _writerService.GetAllWriters());
            RaisePropertyChanged("Writers");
        }

        private async void InitAddBookCommand()
        {
            var listGenresSelected = GenresBinding
                .Where(item => item.IsChecked == true).Select(a => a.Id).ToList();//get genres selected
            if (listGenresSelected.Any() && Publisher != null && Writer != null)
            {
                NewBook.Isbn = Guid.NewGuid().ToString();
                NewBook.PrintDate = DateTime.Now;
                NewBook.WriterId = Writer.Id;
                NewBook.PublisherId = Publisher.Id;
                int copies;
                double price;
                bool checkCopies = int.TryParse(Copies, out copies);
                bool checkPrice = double.TryParse(Price, out price);
                if (!checkCopies || !checkPrice)//check if secceeded to parse price and copies
                    await _dialogService.ShowMessage("Price and/or Copies inputs must be Numbers", "Error");
                else
                {
                    NewBook.CopiesInStock = copies;
                    NewBook.Price = price;
                    bool checkBook = _validationInputs.ValidForAddBook(NewBook);
                    if (checkBook)
                    {
                        bool ok = await _httpBook.AddBookAsync(NewBook);
                        if (ok)
                        {
                            bool AddToBookGenre = await _httpBookGenre.AddToBookGenre(listGenresSelected);//after add book ,i added genres to this book
                            MessengerInstance.Send(true, "AddBook");
                            if (AddToBookGenre)
                            {
                                RestartInputs();
                                await _dialogService.ShowMessage("Book added !", "Ok");
                                _navigationService.GoBack();
                            }
                        }
                        else
                            await _dialogService.ShowMessage("Something wrong !", "Error");
                    }
                    else
                    {
                        await _dialogService.ShowMessage("Something wrong !", "Error");
                    }
                }

            }
            else
            {
                await _dialogService.ShowMessage("You have to choose Genre/s / Publisher / and Writer!", "Error");
            }

        }
        private void RestartInputs()
        {
            NewBook = new Book();
            SetComboBox();
            Copies = "";
            Price = "";
        }

        //return to default 
        private void SetComboBox()
        {
            foreach (var item in GenresBinding)
                item.IsChecked = false;
        }

        //init go back
        private void InitGoBackCommand()
        {
            RestartInputs();
            _navigationService.GoBack();
        }

        //init genres to combobox
        public async void InitGenres()
        {
            Genres = new ObservableCollection<Genre>(await _httpGenres.GetAllGenresAsync());
            foreach (var item in Genres)
            {
                var genre = new ExtentionsGenres
                {
                    Id = item.Id,
                    Name = item.Type,
                    IsChecked = false
                };
                GenresBinding.Add(genre);
            }
            RaisePropertyChanged("GenresBinding");
        }
        #endregion
    }
}
