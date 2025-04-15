using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp2
{
    public partial class TabAndCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private DisplaysContentViewModel displaysContentViewModel;
        [ObservableProperty]
        private DisplaysContentViewModel1 displaysContentViewModel1;
        [ObservableProperty]
        private DisplaysLowBatteryContentViewModel displaysLowBatteryViewModel;
        public TabAndCollectionViewModel()
        {
            DisplaysContentViewModel = new();
            DisplaysContentViewModel1 = new();
            DisplaysLowBatteryViewModel = new();
        }
    }
}
