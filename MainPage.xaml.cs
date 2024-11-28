using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private int currentIndex = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnItemTapped(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            var entry = stackLayout?.Children[0] as Entry;
            if (entry != null)
            {
                var index = ((IList<string>)collectionView.ItemsSource).IndexOf(entry.Placeholder);
                collectionView.ScrollTo(index, position: ScrollToPosition.Start, animate: SwitchAnimation.IsToggled);
                currentIndex = index;
                entry.Focus();
            }

        }

        private void OnItem2Tapped(object sender, TappedEventArgs e)
        {
            var stackLayout = sender as StackLayout;
            var entry = stackLayout?.Children[0] as Entry;
            if (entry != null)
            {
                entry.Focus();
                var index = ((IList<string>)collectionView.ItemsSource).IndexOf(entry.Placeholder);
                collectionView2.ScrollTo(index, position: ScrollToPosition.Start, animate: SwitchAnimation.IsToggled);
                currentIndex = index;
            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            SwitchAnimation.IsToggled = e.Value;
        }
    }

}
