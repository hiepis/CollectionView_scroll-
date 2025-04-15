using CommunityToolkit.Maui.Core.Platform;

namespace MauiApp2
{
    public partial class DisplaysContentView1 : ContentView
    {
       
        public DisplaysContentView1()
        {
            InitializeComponent();
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            var vm = (DisplaysContentViewModel1)BindingContext;
            vm.IsStart = true;
            await vm.RefreshAsync();
        }
    }
}