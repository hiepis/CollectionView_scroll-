using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp2
{
    public partial class DisplaysLowBatteryContentViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isAddMore = false;
        
        [ObservableProperty]
        private bool isRefreshing = false;
        [ObservableProperty]
        public ObservableCollection<DashboardDisplayShowModel> itemsCollection = new();
        [ObservableProperty]
        private bool isStart = false;

        public DisplaysLowBatteryContentViewModel()
        {
            ItemsCollection.Add(new DashboardDisplayShowModel
            {
                SerialNumber = "slot2",
                TextButton1 = "Description 2",
            });
        }


        public async Task RefreshAsync()
        {
            try
            {
                //IsRefreshing = false;
                IsAddMore = true;
                Console.WriteLine($"RefreshAsync called at {DateTime.UtcNow:HH:mm:ss.fff}");
                ItemsCollection = new ObservableCollection<DashboardDisplayShowModel>();
                await Task.Delay(100);
                IsAddMore = false;
                AddUI();

                IsStart = false;
               
                IsRefreshing = false;
            }
            finally
            {
                

            }
        }

        private async void AddUI()
        {
            var list = new List<DashboardDisplayShowModel>();
            list.Add(new DashboardDisplayShowModel
            {
                SerialNumber = "slot2",
                TextButton1 = "Description 2",
                SelectCommand = new AsyncRelayCommand<DashboardDisplayShowModel>(OnSelectedCommand),
                GestureLongPressCommand = new AsyncRelayCommand<DashboardDisplayShowModel>(OnGestureLongPressCommand),
                CommandChecked = new AsyncRelayCommand<DashboardDisplayShowModel>(OnCommandChecked),
                IsMultiSelection = true,
                ColorInfo = Colors.Blue,
                CountProducts = 2,
            });
            list.ForEach(ItemsCollection.Add);
        }
        [RelayCommand]
        private async Task RemainingItemsThresholdReachedAsync()
        {
            if (ItemsCollection != null && ItemsCollection.Count >= 20)
                ItemsCollection.Add(new DashboardDisplayShowModel
                {
                    SerialNumber = "slot2",
                    TextButton1 = "Description 2",
                    SelectCommand = new AsyncRelayCommand<DashboardDisplayShowModel>(OnSelectedCommand),
                    GestureLongPressCommand = new AsyncRelayCommand<DashboardDisplayShowModel>(OnGestureLongPressCommand),
                    CommandChecked = new AsyncRelayCommand<DashboardDisplayShowModel>(OnCommandChecked),
                    IsMultiSelection = false,
                    ColorInfo = Colors.Blue,
                    CountProducts = 2,
                });
        }

        private async Task OnCommandChecked(DashboardDisplayShowModel? model)
        {
            throw new NotImplementedException();
        }

        private async Task OnGestureLongPressCommand(DashboardDisplayShowModel? model)
        {
            throw new NotImplementedException();
        }

        private async Task OnSelectedCommand(DashboardDisplayShowModel? model)
        {
            throw new NotImplementedException();
        }
    }


    #region model
    public partial class DashboardDisplayShowModel : ObservableObject
    {
        [ObservableProperty]
        private string serialNumber;
        [ObservableProperty]
        private string summarizedStatus;
        [ObservableProperty]
        private string displayDefinition;
        [ObservableProperty]
        private string lastSuccessfullyCommunication;
        [ObservableProperty]
        private string attachedProductDescriptionString;
        [ObservableProperty]
        private Color colorInfo;
        [ObservableProperty]
        private ICommand selectCommand;
        [ObservableProperty]
        private bool isVisibleProducts;
        [ObservableProperty]
        private int countProducts;
        [ObservableProperty]
        private bool isAssign = false;
        [ObservableProperty]
        private Thickness thicknessMultiSelection = new Thickness(0, 0, 0, 0);
        [ObservableProperty]
        private bool isMultiSelection = false;
        partial void OnIsMultiSelectionChanged(bool value)
        {
            if (value)
                ThicknessMultiSelection = new Thickness(56, 0, -56, 0);
            else
                ThicknessMultiSelection = new Thickness(0, 0, 0, 0);
        }
        [ObservableProperty]
        private ICommand gestureLongPressCommand;
        [ObservableProperty]
        private ICommand commandChecked;
        [ObservableProperty]
        private Color colorStrokeSelected = Colors.Gray;
        [ObservableProperty]
        private Color colorFillSelected = Colors.Transparent;
        [ObservableProperty]
        private bool isSelected = false;
        partial void OnIsSelectedChanged(bool value)
        {
            if (value)
            {
                ColorStrokeSelected = Colors.Blue;
                ColorFillSelected = Colors.Blue;
            }
            else
            {
                ColorStrokeSelected = Colors.Gray;
                ColorFillSelected = Colors.Transparent;
            }
        }
        #region Button Swipe
        [ObservableProperty]
        private Color colorButton1 = Color.FromHex("#aaaaaa");
        [ObservableProperty]
        private bool isVisibleButton1 = false;
        [ObservableProperty]
        private bool isVisibleButton2 = false;
        [ObservableProperty]
        private string imageButton1;
        [ObservableProperty]
        private string imageButton2 = "close.png";
        [ObservableProperty]
        private string textButton1;
        [ObservableProperty]
        private string textButton2 ="";
        [ObservableProperty]
        private ICommand commandButton1;
        [ObservableProperty]
        private ICommand commandButton2;
        [ObservableProperty]
        private bool isOpen = false;
        [ObservableProperty]
        private bool isEnabled = true;

        #endregion
    }
    #endregion
}
