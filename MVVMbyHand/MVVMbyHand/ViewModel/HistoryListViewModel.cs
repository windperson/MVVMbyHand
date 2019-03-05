using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using LibModel;
using Xamarin.Forms;

namespace MVVMbyHand.ViewModel
{
    class HistoryListViewModel : INotifyPropertyChanged
    {
        private readonly WordHistoryModel _model;

        public HistoryListViewModel(WordHistoryModel model)
        {
            _model = model;
            GetWordHistory();
        }

        #region ViewModel Data-Bounded Properties

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if(_isBusy == value) { return;}
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private ObservableCollection<HistoryItem> _historyItems = new ObservableCollection<HistoryItem>();
        public ObservableCollection<HistoryItem> HistoryItems
        {
            get => _historyItems;
            set
            {
                _historyItems = value;
                OnPropertyChanged(nameof(HistoryItems));
            }
        }

        private HistoryItem _selectedHistoryItem;
        public HistoryItem SelectedHistoryItem
        {
            get => _selectedHistoryItem;
            set
            {
                _selectedHistoryItem = value;
                OnPropertyChanged(nameof(SelectedHistoryItem));
                
                /*
                TODO: 
                HOW to navigate to input view to show selected HistoryItem detail 
                without touching the Xamarin Forms UI API? 
                
                //Application.Current.MainPage.Navigation.PushAsync(new MVVMbyHand.View.InputView());
                */

                _selectedHistoryItem = null;
            }
        }

        #endregion


        #region ViewModel Commands

        private Command _listHistoryCommand;
        public Command ListHistoryCommand => _listHistoryCommand ?? (_listHistoryCommand = new Command(GetWordHistory));

        private void GetWordHistory()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            HistoryItems.Clear();
            var wordHistorylist = _model.GetAll();
            foreach (var historyItem in wordHistorylist)
            {
                HistoryItems.Add(historyItem);
            }

            IsBusy = false;
        }

        private Command _clearHistoryCommand;
        public Command ClearHistoryCommand =>
            _clearHistoryCommand ?? (_clearHistoryCommand = new Command(DoClearHistory));

        private void DoClearHistory()
        {
            HistoryItems.Clear();
            _model.ClearAll();
        }

        #endregion


        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
