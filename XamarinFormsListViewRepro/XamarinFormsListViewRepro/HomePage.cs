namespace XamarinFormsListViewRepro
{
    using ReactiveUI;
    using ReactiveUI.XamForms;

    using Xamarin.Forms;

    public class HomePage : ReactiveContentPage<HomePageViewModel>
    {
        private readonly Button _button;
        private readonly Label _label;
        private readonly ListView _listView;

        public HomePage()
        {
            ViewModel = new HomePageViewModel();

            _button = new Button { Text = "Click Me" };
            _label = new Label { IsVisible = false };
            _listView = new ListView { BackgroundColor = Color.Blue, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.EndAndExpand };

// change to false, and it works
#if true
            var listViewStackLayout = new StackLayout {
                BackgroundColor = Color.Red,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 20, 0, 0),
                Children = { _listView }
            };
            Content = new StackLayout {
                BackgroundColor = Color.Green,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { _button, _label, listViewStackLayout }
            };
            // uncomment the following line and it works
            this.OneWayBind(ViewModel, x => x.Number, x => x._label.Text);
#else
            Content = new StackLayout { Children = { _button, _label, _listView } };
#endif

            this.BindCommand(ViewModel, x => x.ClickMe, x => x._button);
            this.OneWayBind(ViewModel, x => x.Things, x => x._listView.ItemsSource);
        }
    }
}
