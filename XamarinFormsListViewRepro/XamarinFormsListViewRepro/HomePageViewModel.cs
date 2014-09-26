namespace XamarinFormsListViewRepro
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using ReactiveUI;

    public class HomePageViewModel : ReactiveObject
    {
        public HomePageViewModel()
        {
            var fetchData = ReactiveCommand.CreateAsyncTask(_ => Task.FromResult(new[] { "aa", "bb", "cc" }.ToList()));
            fetchData.ToProperty(this, x => x.Things, out _things);

            this.WhenAnyValue(x => x.Things).Where(x => x != null)
                .Select(x => x.Count.ToString())
                .ToProperty(this, x => x.Number, out _number);

            ClickMe = ReactiveCommand.Create();
            ClickMe.InvokeCommand(fetchData);
        }

        public ReactiveCommand<object> ClickMe { get; set; }

        private readonly ObservableAsPropertyHelper<string> _number;
        public string Number
        {
            get { return _number.Value; }
        }

        private readonly ObservableAsPropertyHelper<List<string>> _things;
        public List<string> Things
        {
            get { return _things.Value; }
        }

    }
}
