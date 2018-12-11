namespace ExtendedDatabase
{
    using Contracts;
    using System;
    using System.Linq;

    public class Database
    {
        private const int DefaultCapacity = 16;
        private int size;

        private readonly IPerson[] people;

        public Database()
        {
            this.people = new IPerson[DefaultCapacity];
            this.size = 0;
        }

         public int Size => this.size;

        public Database(params IPerson[] peopleInput) : this()
        {
            if (peopleInput.Length > DefaultCapacity)
            {
                throw new InvalidOperationException("Parameters are too long!");
            }

            foreach (var person in peopleInput)
            {
                this.Add(person);
            }
        }

        public void Add(IPerson person)
        {
            if (this.size >= DefaultCapacity)
            {
                throw new InvalidOperationException("Database is full!");
            }

            var containsUsername = this.people.Any(p => p != null && p.Username == person.Username);
            if (containsUsername)
            {
                throw new InvalidOperationException("Person with the same username already exists!");
            }

            var containsId = this.people.Any(p => p != null && p.ID == person.ID);
            if (containsId)
            {
                throw new InvalidOperationException("Person with the same ID already exists!");
            }

            this.people[this.size++] = person;
        }

        public void Remove()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.people[--this.size] = null;
        }

        public IPerson[] Fetch() => this.people.Take(this.size).ToArray();

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Invalid username!");
            }

            var targetPerson = this.people.FirstOrDefault(p => p != null && p.Username == username);

            if (targetPerson == null)
            {
                throw new InvalidOperationException("No person found with that username!");
            }

            return targetPerson;
        }

        public IPerson FindById(long ID)
        {
            if (ID < 0)
            {
                throw new ArgumentNullException("Invalid ID!");
            }

            var targetPerson = this.people.FirstOrDefault(p => p != null && p.ID == ID);

            if (targetPerson == null)
            {
                throw new InvalidOperationException("No person found with that ID!");
            }

            return targetPerson;
        }
    }
}