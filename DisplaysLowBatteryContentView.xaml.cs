using CommunityToolkit.Maui.Core.Platform;

namespace MauiApp2
{
    public partial class DisplaysLowBatteryContentView : ContentView
    {
       
        public DisplaysLowBatteryContentView()
        {
            InitializeComponent();
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            var vm = (DisplaysLowBatteryContentViewModel)BindingContext;
            vm.IsStart = true;
            await vm.RefreshAsync();
        }
    }
}