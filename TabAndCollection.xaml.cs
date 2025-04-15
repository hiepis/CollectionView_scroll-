
using System.Collections.ObjectModel;

namespace MauiApp2
{
    public partial class TabAndCollection : ContentPage
    {
        public static List<string> HorizontalItems { get; } = Enumerable.Range(1, 10).Select(i => $"Item {i}").ToList();
        public TabAndCollection()
        {
            InitializeComponent();
            BindingContext = new TabAndCollectionViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
    }
    
}
