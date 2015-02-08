using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Runceel.XamarinAndroid.Test.Views
{
    [Activity(Label = "ReadOnlyObservableCollectionActivity")]
    public class ReadOnlyObservableCollectionActivity : ListActivity
    {
        private CancellationTokenSource source;
        private ObservableCollection<string> list;
        private ReadOnlyObservableCollection<string> readOnlyList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.list = new ObservableCollection<string>();
            this.readOnlyList = new ReadOnlyObservableCollection<string>(list);
            this.ListAdapter = this.readOnlyList.ToAdapter(
                (_, __) => LayoutInflater.FromContext(this).Inflate(Android.Resource.Layout.SimpleListItem1, null),
                (_, x, v) => v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = x);

        }

        protected override void OnStart()
        {
            base.OnStart();
            this.source = new CancellationTokenSource();

            var context = SynchronizationContext.Current;
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    context.Post(_ =>
                        {
                            this.list.Add(DateTime.Now.ToString());
                        },
                        null);
                    if (this.source.Token.IsCancellationRequested) { break; }
                }
            },
                source.Token);
        }

        protected override void OnStop()
        {
            base.OnStop();
            source.Cancel();
        }
    }
}