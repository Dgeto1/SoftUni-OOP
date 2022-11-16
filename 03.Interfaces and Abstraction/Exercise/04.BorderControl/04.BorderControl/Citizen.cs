using System;
namespace _04.BorderControl
{
    public class Citizen : IControl
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public string FakeId(string fId)
        {
            bool check = this.Id.EndsWith(fId);
            if (check)
            {
                return this.Id;
            }
                
        }
    }
}

