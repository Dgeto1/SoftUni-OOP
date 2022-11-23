using System;
namespace _03.Telephony
{
	public interface  IPhone
	{
		public string PhoneNumber { get; set; }

		public void Calling(string PhoneNumber);
	}
}

