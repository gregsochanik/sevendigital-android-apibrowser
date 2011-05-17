using System;

namespace SevenDigital.Api.Wrapper
{
	public interface IOAuthCredentials
	{
		string ConsumerKey { get; set; }
		string ConsumerSecret { get; set; }
	}

	public class OAuthCredentials : IOAuthCredentials
	{
		public OAuthCredentials() {
			ConsumerKey = "YOUR_KEY_HERE";
			ConsumerSecret = "";
		}

		public string ConsumerKey { get; set; }
		public string ConsumerSecret { get; set; }
	}
}