using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using SevenDigital.Api.Wrapper;
using SevenDigital.Api.Wrapper.Schema.ReleaseEndpoint;

namespace SevenDigital.Android.ApiBrowser {
	[Activity(Label = "Browse Albums")]
	public class AlbumsActivity : BrowseActivity<Release> {
		
		public override void SetListView() {
			var releaseSearch = new FluentApi<ReleaseSearch>().WithParameter("q", _entryView.Text).Please();
			_listView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.list_item, GetNames(releaseSearch.Results.Releases).ToArray());
		}

		public override IEnumerable<string> GetNames(IEnumerable<Release> releases) {
			return releases.Select(release => release.Title);
		}
	}
}