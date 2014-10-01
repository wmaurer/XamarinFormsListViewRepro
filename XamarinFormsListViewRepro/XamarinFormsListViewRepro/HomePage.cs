namespace XamarinFormsListViewRepro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xamarin.Forms;

    public class HomePage : ContentPage
    {
        private readonly Label _label;
        private readonly ListView _listView;

        public HomePage()
        {
            var button = new Button { Text = "Click Me" };
            _label = new Label();
            _listView = new ListView { BackgroundColor = Color.Blue, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.EndAndExpand };
            // scenario A) ItemsSource is null. ListView size is zero, therefore after click, "aa", "bb", "cc" will never show
            _listView.ItemsSource = null;
            // scenario B) ItemsSource has one initial item. ListView is only big enough to hold one item,
            // therefore after click, only "aa" will show
            //_listView.ItemsSource = new List<string> { string.Empty };
            // scenario C) ItemsSource has 3 items. ListView is big enough to hold 3 items (of course),
            // therefore after click, all three items "aa", "bb, "cc" will show
            //_listView.ItemsSource = Enumerable.Repeat(string.Empty, 3).ToList();
            
            Content = new StackLayout {
                BackgroundColor = Color.Red,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { button, _label, _listView }
            };

            button.Clicked += ButtonOnClicked;
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            _listView.ItemsSource = new List<string> { "aa", "bb", "cc" };
            // uncomment the following line and regardless of which scenario A) B) or C) above, all three items are displayed!
            //_label.Text = "3";
        }
    }
}
