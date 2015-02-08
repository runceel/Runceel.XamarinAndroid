# Runceel.XamarinAndroid

Runceel.XamarinAndroid is Adapter for IList<T>, ObservableCollection<T> and ReadOnlyObservableCollection<T>.

## How to use

### Create ListAdapter from IList<T>
```cs
var list = new List<string>
{
    "a", "b", "c", "d"
};
this.ListAdapter = list.ToAdapter(
    (_, __) => LayoutInflater.FromContext(this).Inflate(Android.Resource.Layout.SimpleListItem1, null),
    (_, x, v) => v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = x);
```

### Create ListAdapter from ObservableCollection<T>

NotifyDataSetChanged is called automaticaly.
```cs
this.list = new ObservableCollection<string>();
this.ListAdapter = this.list.ToAdapter(
    (_, __) => LayoutInflater.FromContext(this).Inflate(Android.Resource.Layout.SimpleListItem1, null),
    (_, x, v) => v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = x);
```

### Create ListAdapter from ReadOnlyObservableCollection<T>.

NotifyDataSetChanged is called automaticaly.
```cs
this.list = new ObservableCollection<string>();
this.readOnlyList = new ReadOnlyObservableCollection<string>(list);
this.ListAdapter = this.readOnlyList.ToAdapter(
    (_, __) => LayoutInflater.FromContext(this).Inflate(Android.Resource.Layout.SimpleListItem1, null),
    (_, x, v) => v.FindViewById<TextView>(Android.Resource.Id.Text1).Text = x);
```

