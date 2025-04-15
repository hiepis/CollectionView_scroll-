using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp2
{
    public partial class DisplaysContentViewModel1 : ObservableObject
    {
        [ObservableProperty]
        private bool isAddMore = false;
        
        [ObservableProperty]
        private bool isRefreshing = false;
        [ObservableProperty]
        public ObservableCollection<ItemModel> itemsCollection = new();
        [ObservableProperty]
        private bool isStart = false;

        public DisplaysContentViewModel1()
        {
            for (int i = 0; i < 15; i++)
            {
                ItemsCollection.Add(new ItemModel
                {
                    Title = "slot2",
                    Description = "Description 2"
                });
            }

        }


        public async Task RefreshAsync()
        {
            try
            {
                //IsRefreshing = false;
                IsAddMore = true;
                Console.WriteLine($"RefreshAsync called at {DateTime.UtcNow:HH:mm:ss.fff}");
                ItemsCollection = new ObservableCollection<ItemModel>();
                await Task.Delay(2000);
                IsAddMore = false;
                await AddUI();

                IsStart = false;
               
                IsRefreshing = false;
            }
            finally
            {
                

            }
        }

        private async Task AddUI()
        {
            for (int i = 0; i < 10; i++)
            {
                ItemsCollection.Add(new ItemModel
                {
                    Title = "slot2",
                    Description = "Description 2"
                });
            }
        }
        [RelayCommand]
        private async Task RemainingItemsThresholdReachedAsync()
        {
            //if (ItemsCollection != null && ItemsCollection.Count >= 20)
            //    ItemsCollection.Add(new ItemModel
            //    {
            //        Title = "slot2",
            //        Description = "Description 2"
            //    });
        }
    }
}
