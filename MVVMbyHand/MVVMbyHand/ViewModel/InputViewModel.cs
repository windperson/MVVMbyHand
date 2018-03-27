using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using LibModel;
using Xamarin.Forms;

namespace MVVMbyHand.ViewModel
{
    class InputViewModel : INotifyPropertyChanged
    {
        private WordConverter _converter;
        private readonly WordHistoryModel _model;
        public InputViewModel(WordHistoryModel model)
        {
            _model = model;

            ConverterTypes = WordConverter.Types;
        }


        #region ViewModel Data-Bounded Properties

        public string[] ConverterTypes { get; }

        private int _selectedConverterType = -1;

        //NOTE: there's a strange bug in Behaviors.Forms when applying to a picker,
        //The selected index will get previous one after invoke 1st SelectedIndexChanged event.
        public int SelectedConvterType
        {
            get => _selectedConverterType;
            set
            {
                _selectedConverterType = value;
                OnPropertyChanged(nameof(SelectedConvterType));
            }
        }

        private string _inputText;

        public string InputText
        {
            get => _inputText;
            set
            {
                if (_inputText == value) { return; }
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        private string _displayText;
        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (_displayText == value) { return; }
                _displayText = value;
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        #endregion


        #region ViewModel Commands

        private Command _converterChangeCommand;
        public Command ConverterChangeCommand =>
            _converterChangeCommand ?? (_converterChangeCommand = new Command(DoChangeConverter));

        private void DoChangeConverter()
        {
            var selectedType = SelectedConvterType;
            if (selectedType != -1 && selectedType < ConverterTypes.Length)
            {
                _converter = new WordConverter(ConverterTypes[selectedType]);
            }
        }

        private Command _convertCommand;
        public Command ConvertCommand => _convertCommand ?? (_convertCommand = new Command<string>(DoConvert));

        private void DoConvert(string input)
        {
            if (string.IsNullOrEmpty(input) || _converter == null)
            {
                //do nothing
                return;
            }

            DisplayText = _converter.Convert(input);
        }

        private Command _addToHistroyCommand;

        public Command AddToHistoryCommand =>
            _addToHistroyCommand ?? (_addToHistroyCommand = new Command(AddWordToHistory));

        private void AddWordToHistory()
        {
            if (string.IsNullOrEmpty(DisplayText)) { return; }

            var historyItem = new HistoryItem
            {
                RecordAt = DateTime.Now,
                Word = DisplayText
            };

            _model.AddOne(historyItem);
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
