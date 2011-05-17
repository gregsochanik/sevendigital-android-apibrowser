using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using SevenDigital.Api.Wrapper;
using SevenDigital.Api.Wrapper.Schema.TrackEndpoint;

namespace SevenDigital.Android.ApiBrowser {
	[Activity(Label = "Browse Songs")]
	public class SongsActivity : BrowseActivity<TrackSearchResult> {
		
		public override void SetListView() {
			var trackSearch = new FluentApi<TrackSearch>().WithParameter("q", _entryView.Text).Please();
			_listView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, GetNames(trackSearch.Results).ToArray());
		}

		public override IEnumerable<string> GetNames(IEnumerable<TrackSearchResult> trackSearchResults) {
			return trackSearchResults.Select(trackSearchResult => trackSearchResult.Track.Title);
		}
	}
}