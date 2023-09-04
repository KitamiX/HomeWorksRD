using System.Linq;

namespace Homework__LINQ_
{
    class Person
    {
        public Person(string name, string surname, int age, int id)
        {
            Id_P = id;
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string Name { get; set;}
        public string Surname { get; set;}
        public int Age { get; set; }
        public int Id_P { get; set; }
    }
    class Jobs
    {
        public string Job {get; set; }
        public int Id_J { get; set; }
        public Jobs(string job, int id) 
        {
            Job = job;
            Id_J = id;
        }
    }
    internal class Program
    {
        public static void searchMax(List<Person> people)
        {
            var result = people.Where(item => item.Name == "Max").ToList();
            foreach (Person p in result)
            {
                Console.WriteLine(p.Name + " " + p.Surname + " " + p.Age);
            }

        }
        public static void JoinLists(List<Person> people, List<Jobs> jobs)
        {
            var result = people.Join(jobs,
                p => p.Id_P,
                j => j.Id_J,
                (p, j) => new {
                    p.Id_P,
                    p.Name,
                    p.Surname,
                    j.Job
                    }).OrderBy(p => p.Id_P);
            foreach (var res in result)
            {
                Console.WriteLine($"{res.Id_P}. {res.Name} {res.Surname}   Job: {res.Job}");
            }
        }
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            { 
                new Person("Carl", "Gallager", 10, 1),
                new Person("Max", "Jackson", 13, 2),
                new Person("Max", "Hammilton", 15, 3),
                new Person("Max", "Smith", 30, 4),
                new Person("Max", "Johnson", 28, 5),
                new Person("Max", "Brown", 30, 6),
                new Person("Max", "Davis", 26, 7),
                new Person("Max", "Jones", 28, 8),
                new Person("Sarah", "Wilson", 29, 22),
                new Person("Michael", "Taylor", 30, 9),
                new Person("Emily", "Miller", 26, 10),
                new Person("William", "Anderson", 29, 11),
                new Person("Jessica", "Martinez", 29, 12),
                new Person("David", "Jackson", 32, 13),
                new Person("Olivia", "Thomas", 26, 14),
                new Person("James", "White", 32, 15),
                new Person("Sophia", "Harris", 29, 16),
                new Person("Robert", "Clark", 32, 17),
                new Person("Emma", "Lewis", 26, 18),
                new Person("Daniel", "Rodriguez", 32, 19),
                new Person("Ava", "Garcia", 29, 20),
                new Person("Benjamin", "Hall", 32, 21)
            };
            List <Jobs> jobs = new List<Jobs>()
            {
                new Jobs("Student", 1),
                new Jobs("Student", 2),
                new Jobs("Student", 3),
                new Jobs("Software Engineer", 4),
                new Jobs("Data Analyst", 5),
                new Jobs("Marketing Manager", 6),
                new Jobs("Graphic Designer", 7),
                new Jobs("Teacher", 8),
                new Jobs("Nurse", 9),
                new Jobs("Doctor", 10),
                new Jobs("Photographer", 11),
                new Jobs("Financial Analyst", 12),
                new Jobs("Lawyer", 13),
                new Jobs("Architect", 14),
                new Jobs("Writer", 15),
                new Jobs("Engineer", 16),
                new Jobs("Psychologist", 17),
                new Jobs("Chef", 18),
                new Jobs("Social Media Manager", 19),
                new Jobs("Sales Manager", 20),
                new Jobs("Accountant", 21),
                new Jobs("Business Consultant", 22)
            };

            searchMax(people); // Search all people named "Max" (uncomment to enable)
            JoinLists(people, jobs); //Join List<jobs> to List<person> + Order by Id
            var result = people.Where(p => p.Age == 29).Count(); //Count how many ppl in list are 29 Y.O.
            Console.WriteLine(result);
        }
    }
}