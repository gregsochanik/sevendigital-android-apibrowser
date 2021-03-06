﻿using System;
using System.Net;
using System.Text;

namespace SevenDigital.Api.Wrapper.Utility.Http
{
	public class HttpPostResolver : IUrlResolver
	{
		private readonly IWebClientFactory _webClientFactory;
		private string _parametersAsString = string.Empty;

		public string ParametersAsString
		{
			get { return _parametersAsString; }
			set { _parametersAsString = value; }
		}

		public HttpPostResolver(IWebClientFactory webClientFactory) {
			_webClientFactory = webClientFactory;
		}
		public HttpPostResolver(IWebClientFactory webClientFactory, string parametersAsString) {
			_webClientFactory = webClientFactory;
			ParametersAsString = parametersAsString;
		}

		public string Resolve(Uri endpoint, string method, WebHeaderCollection headers) {
			using (var webClientWrapper = _webClientFactory.GetWebClient()) {

				webClientWrapper.Encoding = Encoding.UTF8;
				webClientWrapper.Headers.Add(headers);

				return webClientWrapper.UploadString(endpoint.OriginalString, method, ParametersAsString);
			}
		}
	}
}