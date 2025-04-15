using System.Collections.ObjectModel;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        public static List<string> HorizontalItems { get; } = Enumerable.Range(1, 10).Select(i => $"Item {i}").ToList();
        public MainPage()
        {
            InitializeComponent();
        }

    }
    
}
