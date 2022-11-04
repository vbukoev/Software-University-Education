using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Families { get; set; }
        public Family()
        {
            Families = new List<Person>();
        }
        public void AddMember(Person member)
        {
            Families.Add(member);
        }
        public Person GetOldestMember()
        {
            return Families
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }
    }
}
