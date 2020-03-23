namespace CSharp.BasicDSL
{
    class InstanceCreator
    {
        public Person Person
        {
            get
            {
                return new Person();
            }
        }
    }

    static class InstanceCreatorExtensions
    {
        public static Person Person(this InstanceCreator person, string FirstName, string LastName)
        {
            return new Person
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}