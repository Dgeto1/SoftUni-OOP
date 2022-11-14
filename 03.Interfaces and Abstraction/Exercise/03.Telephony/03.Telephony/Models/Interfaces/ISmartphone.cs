using System;
namespace _03.Telephony
{
    public interface ISmartphone : IStationaryPhone
	{
		string Browsing(string url);
	}
}

