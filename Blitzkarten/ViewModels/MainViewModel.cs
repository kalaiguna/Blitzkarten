// MainViewModel.cs
using Blitzkarten.Controls;
using Blitzkarten.Models;
using Blitzkarten.Services;
using System.ComponentModel;


namespace Blitzkarten.ViewModels
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        private readonly BlitzKarteService _flashCardService;
        private List<BlitzKarte> _flashCards = [];
        private int _currentIndex = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BlitzKarte? CurrentCard => _flashCards != null && _flashCards.Count > 0
            ? _flashCards[_currentIndex]
            : null;

        private Command _nextCardCommand = null!;
        private Command _previousCardCommand = null!;

        //public Command NextCardCommand => _nextCardCommand ??= new Command(NextCard);
        //public Command PreviousCardCommand => _previousCardCommand ??= new Command(PreviousCard);

        public Command NextCardCommand => _nextCardCommand ??= new Command(async () => await NextCardAsync());
        public Command PreviousCardCommand => _previousCardCommand ??= new Command(async () => await PreviousCardAsync());

        private string _currentProgress = "0 / 0";
        public string CurrentProgress
        {
            get => _currentProgress;
            private set
            {
                if (_currentProgress != value)
                {
                    _currentProgress = value;
                    OnPropertyChanged(nameof(CurrentProgress));
                }
            }
        }

        private BlitzKarteView? _currentCardView = null;

        public void SetCardView(BlitzKarteView cardView)
        {
            _currentCardView = cardView;
        }

        public async Task EnsureFrontViewIsVisible()
        {
            if (_currentCardView != null && !_currentCardView.IsFrontSideVisible)
            {
                await _currentCardView.FlipCard();
            }
        }

        public MainViewModel(BlitzKarteService flashCardService)
        {
            _flashCardService = flashCardService;
            _nextCardCommand = new Command(async () => await NextCardAsync());
            _previousCardCommand = new Command(async () => await PreviousCardAsync());
            LoadFlashCards();
        }

        private async void LoadFlashCards()
        {
            _flashCards = await BlitzKarteService.LoadBlitzKarten();// _flashCardService.LoadBlitzKarten();
            OnPropertyChanged(nameof(CurrentCard));
            _currentIndex = (_currentIndex + 1) % _flashCards.Count;
            CurrentProgress = $"{_currentIndex} / {_flashCards.Count}";
        }

        private async Task NextCardAsync()
        {
            if (_flashCards == null || _flashCards.Count == 0) return;

            await EnsureFrontViewIsVisible();

            _currentIndex = (_currentIndex + 1) % _flashCards.Count;
            OnPropertyChanged(nameof(CurrentCard));
            CurrentProgress = $"{_currentIndex + 1}/{_flashCards.Count}";
        }

        private async Task PreviousCardAsync()
        {
            if (_flashCards == null || _flashCards.Count == 0) return;

            await EnsureFrontViewIsVisible();

            _currentIndex = (_currentIndex - 1 + _flashCards.Count) % _flashCards.Count;
            OnPropertyChanged(nameof(CurrentCard));
            CurrentProgress = $"{_currentIndex + 1}/{_flashCards.Count}";
        }

        //public void NextCard()
        //{
        //    if (_flashCards == null || _flashCards.Count == 0) return;
        //    _currentIndex = (_currentIndex + 1) % _flashCards.Count;            
        //    OnPropertyChanged(nameof(CurrentCard));
        //    CurrentProgress = $"{_currentIndex} / {_flashCards.Count}";
            
        //}

        //public void PreviousCard()
        //{
        //    if (_flashCards == null || _flashCards.Count == 0) return;

        //    _currentIndex = (_currentIndex - 1 + _flashCards.Count) % _flashCards.Count;
        //    CurrentProgress = $"{_currentIndex} / {_flashCards.Count}";                        
        //    OnPropertyChanged(nameof(CurrentCard));
        //}

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
