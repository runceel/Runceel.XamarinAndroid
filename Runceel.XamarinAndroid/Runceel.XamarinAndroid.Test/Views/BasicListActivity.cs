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

using Runceel.XamarinAndroid;

namespace Runceel.XamarinAndroid.Test.Views
{
    [Activity(Label = "BasicListActivity")]
    public class BasicListActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var list = new List<string>
            {
                "a", "b", "c", "d"
            };
            this.ListAdapter = list.ToAdapter(
                (_, __) => LayoutInflater.FromContext(this).Inflate(Android.Resource.Layout.SimpleListItem1, null),
                (_, x, v) => v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = x);
        }
    }
}