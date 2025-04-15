using CommunityToolkit.Maui.Core.Platform;

namespace MauiApp2
{
    public partial class DisplaysContentView : ContentView
    {
       
        public DisplaysContentView()
        {
            InitializeComponent();
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            var vm = (DisplaysContentViewModel)BindingContext;
            vm.IsStart = true;
            await vm.RefreshAsync();
        }
    }
}