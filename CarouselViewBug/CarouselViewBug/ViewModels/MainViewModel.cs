using CarouselViewPeekAreaInsetsBug.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarouselViewPeekAreaInsetsBug.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        protected List<MyCarouselItem> _items;
        public List<MyCarouselItem> Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        protected string _pageIndicator;
        public string PageIndicator
        {
            get => _pageIndicator;
            set
            {
                if (_pageIndicator != value)
                {
                    _pageIndicator = value;
                    OnPropertyChanged();
                }
            }
        }

        protected int _currentPage;
        public int CurrentPage { get => _currentPage; set => _currentPage = value; }

        public ICommand PositionChangedCommand { get; set; }

        public MainViewModel()
        {
            PositionChangedCommand = new Command(OnPositionChanged);

            Items = new List<MyCarouselItem>()
            {
                new MyCarouselItem() { Message = "This is item #1 and page info below updates accordingly." },
                new MyCarouselItem() { Message = "This is item #2 and page info below updates accordingly." },
                new MyCarouselItem() { Message = "This is item #3 and page info below updates accordingly." },
                new MyCarouselItem() { Message = "This is item #4 BUT page info below DOES NOT update accordingly if PeekAreaInsets is not zero. Change PeekAreaInsets to zero and everyting will be OK." }
            };

            PageIndicator = $"{(CurrentPage + 1).ToString()} of {Items.Count}";
        }

        protected void OnPositionChanged()
        {
            PageIndicator = $"{(CurrentPage + 1).ToString()} of {Items.Count}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
