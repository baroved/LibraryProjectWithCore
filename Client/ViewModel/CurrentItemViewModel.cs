using ClientLib.Api;
using GalaSoft.MvvmLight;
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
    public class CurrentItemViewModel : ViewModelBase
    {
        #region Properties
        public AbstractItem Item { get; set; }
        #endregion

        #region Constructor
        public CurrentItemViewModel()
        {
            //register to massenger for get current item who's selected
            Messenger.Default.Register<AbstractItem>(this, (item) =>
                {
                    Item = item;
                    RaisePropertyChanged("Item");
                });
        }
        #endregion
    }
}
