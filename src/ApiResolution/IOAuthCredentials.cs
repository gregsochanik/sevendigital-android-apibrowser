namespace SevenDigital.Api.Wrapper
{
	public interface IOAuthCredentials
	{
		string ConsumerKey { get; set; }
		string ConsumerSecret { get; set; }
	}

	public class Creds : IOAuthCredentials
	{
		public Creds() {
			ConsumerKey = "YOUR_KEY_HERE";
			ConsumerKey = "";
		}
		public string ConsumerKey { get; set; }
		public string ConsumerSecret { get; set; }
	}
}