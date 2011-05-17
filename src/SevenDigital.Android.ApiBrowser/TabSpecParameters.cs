using System;

namespace SevenDigital.Android.ApiBrowser
{
	public class TabSpecParameters {
		public TabSpecParameters(Type type, string specName, string indicatorLabel, int resource) {
			Type = type;
			SpecName = specName;
			IndicatorLabel = indicatorLabel;
			Resource = resource;
		}

		public Type Type { get; private set; }
		public string SpecName { get; private set; }
		public string IndicatorLabel { get; private set; }
		public int Resource { get; private set; }
	}
}