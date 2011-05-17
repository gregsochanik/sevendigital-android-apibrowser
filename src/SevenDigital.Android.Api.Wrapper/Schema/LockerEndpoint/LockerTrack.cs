﻿using System.Collections.Generic;
using System.Xml.Serialization;
using SevenDigital.Api.Wrapper.Schema.TrackEndpoint;

namespace SevenDigital.Api.Wrapper.Schema.LockerEndpoint
{
	[XmlRoot("lockerTrack")]
	public class LockerTrack
	{
		[XmlElement("track")]
		public Track Track { get; set; }

		[XmlElement("remainingDownloads")]
		public int RemainingDownloads { get; set; }

		[XmlElement("purchaseDate")]
		public string PurchaseDate { get; set; }

		[XmlArray("downloadUrls")]
		[XmlArrayItem("downloadUrl")]
		public List<DownloadUrl> DownloadUrls { get; set; }
	}
}