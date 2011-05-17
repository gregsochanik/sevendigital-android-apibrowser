using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Util;
using Android.Widget;

namespace SevenDigital.Android.ApiBrowser
{
	public abstract class BrowseActivity<T> : Activity
	{
		private bool _isActive;
		protected EditText _entryView;
		protected ListView _listView;

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			
			try {

				_entryView = FindViewById<EditText>(Resource.Id.entry);
				_entryView.AfterTextChanged += entryView_AfterTextChanged;

				_listView = FindViewById<ListView>(Resource.Id.results);
				_listView.ItemClick += (s, a) =>
				                       Toast.MakeText(Application, ((TextView)a.View).Text, ToastLength.Short).Show();

			} catch (Exception ex) {
				Log.Debug("Api.Browser", ex.Message);
				Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
			}
		}

		void entryView_AfterTextChanged(object sender, AfterTextChangedEventArgs e) {

			if (!_isActive) {
				_isActive = true;
				try {
					SetListView();
				} catch (Exception ex) {
					Log.Debug("Api", ex.Message);
					Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
				}
				_isActive = false;
			}
		}

		public abstract void SetListView();

		public abstract IEnumerable<string> GetNames(IEnumerable<T> artists);
	}
}