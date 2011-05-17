using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using SevenDigital.Api.Wrapper;
using SevenDigital.Api.Wrapper.Schema.ArtistEndpoint;

namespace SevenDigital.Android.ApiBrowser {
	[Activity(Label = "Browse Artists")]
	public class ArtistActivity : BrowseActivity<Artist> {
		
		public override void SetListView() {
			var artist = new FluentApi<ArtistBrowse>().WithParameter("letter", _entryView.Text).Please();
			_listView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, GetNames(artist.Artists).ToArray());
		}

		public override IEnumerable<string> GetNames(IEnumerable<Artist> artists) {
			return artists.Select(artist => artist.Name);
		}
	}
}