using System;
namespace _03.Telephony
{
	public interface IBrowse
	{
		public string URL { get; set; }

		public void Browsing(string url);
	}
}

