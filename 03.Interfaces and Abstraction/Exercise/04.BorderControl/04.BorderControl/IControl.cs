using System;
namespace _04.BorderControl
{
	public interface IControl
	{
		public string Id { get; set; }

		string FakeId(string fId);
	}
}

