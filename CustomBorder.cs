namespace MauiApp2
{
    public partial class CustomBorder : ContentView
    {
        public static readonly BindableProperty BackgroundContentProperty =
      BindableProperty.Create(nameof(BackgroundContent), typeof(Color), typeof(View1), Colors.White, BindingMode.TwoWay);
        public Color BackgroundContent
        {
            get => (Color)GetValue(BackgroundContentProperty);

            set => SetValue(BackgroundContentProperty, value);
        }
    }
}
