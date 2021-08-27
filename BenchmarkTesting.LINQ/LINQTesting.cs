using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkTesting.LINQ
{
    public class LINQTesting
    {
        private readonly Faker<Person> _faker = new();

        private readonly List<Person> _persons;

        public LINQTesting()
        {
            _persons = _faker
                .RuleFor(person => person.FullName, faker => faker.Name.FullName())
                .RuleFor(person => person.IsStudent, faker => faker.Random.Bool())
                .RuleFor(person => person.Id, faker => faker.Random.Number(1, 2000))
                .Generate(300000);

            _persons[150000].Id = 0;
        }

        public Person GetPersonWithWhereExperession()
        {
            return _persons.Where(person => person.Id == 0).Single();
        }

        public Person GetPersonWithOnlySingleExpression()
        {
            return _persons.Single(person => person.Id == 0);
        }

        public int StudentsCountWithWhereExpression()
        {
            return _persons.Where(person => person.IsStudent).Count();
        }

        public int StudentsCountWithOnlyCountExpression()
        {
            return _persons.Count(person => person.IsStudent);
        }

        public int StudentsCountWithFor()
        {
            var count = 0;

            for (int i = 0; i < _persons.Count; i++)
            {
                if (_persons[i].IsStudent)
                {
                    count++;
                }
            }

            return count;
        }

        public int StudentsCountWithForEach()
        {
            var count = 0;

            foreach (var person in _persons)
            {
                if (person.IsStudent)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
