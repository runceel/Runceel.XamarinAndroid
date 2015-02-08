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

namespace Runceel.XamarinAndroid.Test.Views
{
    [Activity(MainLauncher = true, Label = "MainActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.Main);

            var listButton = this.FindViewById<Button>(Resource.Id.buttonNavigateBasicList);
            listButton.Click += (s, e) =>
                {
                    var intent = new Intent(this, typeof(BasicListActivity));
                    this.StartActivity(intent);
                };

            var observableCollectionButton = this.FindViewById<Button>(Resource.Id.buttonNavigateObservableCollection);
            observableCollectionButton.Click += (s, e) =>
                {
                    var intent = new Intent(this, typeof(ObservableCollectionActivity));
                    this.StartActivity(intent);
                };

            var readOnlyObservableCollectionButton = this.FindViewById<Button>(Resource.Id.buttonNavigateReadOnlyObservableCollection);
            readOnlyObservableCollectionButton.Click += (s, e) =>
                {
                    var intent = new Intent(this, typeof(ReadOnlyObservableCollectionActivity));
                    this.StartActivity(intent);
                };
        }
    }
}