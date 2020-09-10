using System.Collections.Generic;

namespace KulikWPF
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Department depart { get; set; }
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            string worksAt = depart == null ? "" : $" работает в отделе {depart}";
            return $"{LastName} {FirstName} {worksAt}";
        }

        public static void AddEdit()
        {
            
        }
    }
}
