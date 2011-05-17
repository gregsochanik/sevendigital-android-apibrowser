using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace SevenDigital.Android.ApiBrowser {
	[Activity(Label = "ApiBrowser", MainLauncher = true, Icon = "@drawable/icon")]
	public class ApiTabActivity : TabActivity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.main_tab);

			var tabSpecs = new List<TabSpecParameters>
			{
				new TabSpecParameters(typeof (ArtistActivity), "artists", "Artists",
				                      Resource.Drawable.ic_tab_artists),
				new TabSpecParameters(typeof (AlbumsActivity), "albums", "Albums",
				                      Resource.Drawable.ic_tab_albums),
				new TabSpecParameters(typeof (SongsActivity), "songs", "Songs",
				                      Resource.Drawable.ic_tab_artists)
			};
			foreach (var tabSpec in tabSpecs) {
				AddTabSpec(tabSpec);
			}

			TabHost.CurrentTab = 0;
		}

		private void AddTabSpec(TabSpecParameters tabSpecParameters) {
			var intent = new Intent(this, tabSpecParameters.Type);
			intent.AddFlags(ActivityFlags.NewTask);

			TabHost.TabSpec spec = TabHost.NewTabSpec(tabSpecParameters.SpecName);
			spec.SetIndicator(tabSpecParameters.IndicatorLabel, Resources.GetDrawable(tabSpecParameters.Resource));
			spec.SetContent(intent);
			TabHost.AddTab(spec);
		}
	}
}