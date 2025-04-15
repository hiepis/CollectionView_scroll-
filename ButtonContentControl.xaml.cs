using CommunityToolkit.Maui.Core.Platform;
using Microsoft.VisualBasic;
using System.Windows.Input;

namespace MauiApp2
{
    public partial class ButtonContentControl : ContentView
    {
        public ButtonContentControl()
        {
            InitializeComponent();

        }
        public static readonly BindableProperty IsAssignProperty =
  BindableProperty.Create(nameof(IsAssign), typeof(bool), typeof(ButtonContentControl), false, BindingMode.TwoWay);
        public bool IsAssign
        {
            get => (bool)GetValue(IsAssignProperty);

            set => SetValue(IsAssignProperty, value);
        }

        public static readonly BindableProperty ThicknessMultiSelectionProperty =
   BindableProperty.Create(nameof(ThicknessMultiSelection), typeof(Thickness), typeof(ButtonContentControl), new Thickness(0), BindingMode.TwoWay);
        public Thickness ThicknessMultiSelection
        {
            get => (Thickness)GetValue(ThicknessMultiSelectionProperty);

            set => SetValue(ThicknessMultiSelectionProperty, value);
        }

        public static readonly BindableProperty IsVisibleProductsProperty =
   BindableProperty.Create(nameof(IsVisibleProducts), typeof(bool), typeof(ButtonContentControl), false, BindingMode.TwoWay);
        public bool IsVisibleProducts
        {
            get => (bool)GetValue(IsVisibleProductsProperty);

            set => SetValue(IsVisibleProductsProperty, value);
        }
        public static readonly BindableProperty CountProductsProperty =
         BindableProperty.Create(nameof(CountProducts), typeof(string), typeof(ButtonContentControl), string.Empty, BindingMode.TwoWay);
        public string CountProducts
        {
            get => (string)GetValue(CountProductsProperty);

            set => SetValue(CountProductsProperty, value);
        }
        public static readonly BindableProperty AttachedProductDescriptionStringProperty =
         BindableProperty.Create(nameof(AttachedProductDescriptionString), typeof(string), typeof(ButtonContentControl), string.Empty, BindingMode.TwoWay);
        public string AttachedProductDescriptionString
        {
            get => (string)GetValue(AttachedProductDescriptionStringProperty);

            set => SetValue(AttachedProductDescriptionStringProperty, value);
        }
        public static readonly BindableProperty LastSuccessfullyCommunicationProperty =
         BindableProperty.Create(nameof(LastSuccessfullyCommunication), typeof(string), typeof(ButtonContentControl), string.Empty, BindingMode.TwoWay);
        public string LastSuccessfullyCommunication
        {
            get => (string)GetValue(LastSuccessfullyCommunicationProperty);

            set => SetValue(LastSuccessfullyCommunicationProperty, value);
        }
        public static readonly BindableProperty DisplayDefinitionProperty =
         BindableProperty.Create(nameof(DisplayDefinition), typeof(string), typeof(ButtonContentControl), string.Empty, BindingMode.TwoWay);
        public string DisplayDefinition
        {
            get => (string)GetValue(DisplayDefinitionProperty);

            set => SetValue(DisplayDefinitionProperty, value);
        }
        public static readonly BindableProperty SummarizedStatusProperty =
         BindableProperty.Create(nameof(SummarizedStatus), typeof(string), typeof(ButtonContentControl), string.Empty, BindingMode.TwoWay);
        public string SummarizedStatus
        {
            get => (string)GetValue(SummarizedStatusProperty);

            set => SetValue(SummarizedStatusProperty, value);
        }
        public static readonly BindableProperty SerialNumberProperty =
         BindableProperty.Create(nameof(SerialNumber), typeof(string), typeof(ButtonContentControl), string.Empty, BindingMode.TwoWay);
        public string SerialNumber
        {
            get => (string)GetValue(SerialNumberProperty);

            set => SetValue(SerialNumberProperty, value);
        }
        public static readonly BindableProperty CommandButtonProperty =
         BindableProperty.Create(nameof(CommandButton), typeof(ICommand), typeof(ButtonContentControl), null, BindingMode.TwoWay);
        public ICommand CommandButton
        {
            get => (ICommand)GetValue(CommandButtonProperty);

            set => SetValue(CommandButtonProperty, value);
        }

        public static readonly BindableProperty CommandParameterButtonProperty =
              BindableProperty.Create(nameof(CommandParameterButton), typeof(object), typeof(ButtonContentControl), null, BindingMode.TwoWay);
        public object CommandParameterButton
        {
            get => (object)GetValue(CommandParameterButtonProperty);

            set => SetValue(CommandParameterButtonProperty, value);
        }
        public static readonly BindableProperty CommandLongButtonProperty =
         BindableProperty.Create(nameof(CommandLongButton), typeof(ICommand), typeof(ButtonContentControl), null, BindingMode.TwoWay);
        public ICommand CommandLongButton
        {
            get => (ICommand)GetValue(CommandLongButtonProperty);

            set => SetValue(CommandLongButtonProperty, value);
        }
        public event EventHandler ButtonClicked;
        private void ContentButton_Clicked(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(sender, e);
        }

        private void ButtonState_Released(object sender, EventArgs e)
        {
            GridState.BackgroundColor = Colors.Transparent;
            // cancel the operation
            cancelTokenSource.Cancel();

            // release resources
            cancelTokenSource.Dispose();
            Console.WriteLine("ButtonState_Released");
            if (islong)
            {
                Console.WriteLine("ButtonState_Released __________ long");

            }
            else
            {


                Console.WriteLine("ButtonState_Released __________ short");
                //  CommandButton?.Execute(null);
            }

        }
        bool islong;
        CancellationTokenSource cancelTokenSource;
        private void ButtonState_Pressed(object sender, EventArgs e)
        {

            islong = false;
            GridState.BackgroundColor = Colors.Gray;
            Console.WriteLine("ButtonState_Pressed");
            // initialize cancellation objects
            cancelTokenSource = new();
            CancellationToken token = cancelTokenSource.Token;
            // execute a parallel operation
            Task task = new Task(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine("Delay 1s");
                if (token.IsCancellationRequested)
                    return;
                islong = true;
                CallLongPress();

            }, token);
            task.Start();
        }

        private void ButtonState_Clicked(object sender, EventArgs e)
        {
            if (!islong)
                CommandButton?.Execute(CommandParameterButton);

        }

        private void CallLongPress()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                GridState.BackgroundColor = Colors.Transparent;
                CommandLongButton?.Execute(CommandParameterButton);
            });

        }
    }
}