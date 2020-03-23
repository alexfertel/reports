using System;

namespace CSharp.BasicDSL
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string this[string property]
        {
            get
            {
                switch (property)
                {
                    case "FirstName":
                        return this.FirstName;
                    case "LastName":
                        return this.LastName;
                    default:
                        throw new ArgumentException(string.Format(
                            "No field named {0} in {1}",
                            property,
                            typeof(Person)
                        ));
                }
            }
            set
            {
                switch (property)
                {
                    case "FirstName":
                        this.FirstName = value;
                        break;
                    case "LastName":
                        this.LastName = value;
                        break;
                    default:
                        throw new ArgumentException(string.Format(
                            "No field named {0} in {1}",
                            property,
                            typeof(Person)
                        ));
                }
            }
        }

        public override string ToString()
        {
            return string.Format("[Person: {0} {1}]", this.FirstName, this.LastName);
        }
    }

    static class PersonExtensions
    {
        public static Person FirstName(this Person person, string firstName)
        {
            person.FirstName = firstName;
            return person;
        }

        public static Person LastName(this Person person, string lastName)
        {
            person.LastName = lastName;
            return person;
        }
    }
}