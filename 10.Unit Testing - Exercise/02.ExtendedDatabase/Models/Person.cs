namespace ExtendedDatabase
{
    using Contracts;

    public class Person : IPerson
    {
        public Person(long id, string username)
        {
            this.ID = id;
            this.Username = username;
        }

        public long ID { get; }

        public string Username { get; }
    }
}