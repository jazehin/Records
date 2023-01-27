namespace Records
{
    class Program
    {
        static void Main()
        {
            // courtesy of https://www.youtube.com/@IAmTimCorey
            Record1 r1a = new("Tim", "Corey");
            Record1 r1b = new("Tim", "Corey");
            Record1 r1c = new("Sue", "Storm");

            Class1 c1a = new("Tim", "Corey");
            Class1 c1b = new("Tim", "Corey");
            Class1 c1c = new("Sue", "Storm");

            Console.WriteLine("Record:");
            Console.WriteLine($"To String: {r1a}");
            Console.WriteLine($"Equal: {Equals(r1a, r1b)}");
            Console.WriteLine($"Reference equal: {ReferenceEquals(r1a, r1b)}");
            Console.WriteLine($"==: {r1a == r1b}");
            Console.WriteLine($"!=: {r1a != r1c}");
            Console.WriteLine($"Hash code A: {r1a.GetHashCode()}");
            Console.WriteLine($"Hash code B: {r1b.GetHashCode()}");
            Console.WriteLine($"Hash code C: {r1c.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine();

            Console.WriteLine("Class:");
            Console.WriteLine($"To String: {c1a}");
            Console.WriteLine($"Equal: {Equals(c1a, c1b)}");
            Console.WriteLine($"Reference equal: {ReferenceEquals(c1a, c1b)}");
            Console.WriteLine($"==: {c1a == c1b}");
            Console.WriteLine($"!=: {c1a != c1c}");
            Console.WriteLine($"Hash code A: {c1a.GetHashCode()}");
            Console.WriteLine($"Hash code B: {c1b.GetHashCode()}");
            Console.WriteLine($"Hash code C: {c1c.GetHashCode()}");

            Console.WriteLine();

            var (fn, ln) = r1a; // decontruction
            Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");

            Record1 r1d = r1a with
            {
                FirstName = "Jon"
            };
            Console.WriteLine($"Jon's record: {r1d}");

            Console.WriteLine();
            Record2 r2a = new("Tim", "Corey");
            Console.WriteLine($"R2a Value: {r2a}");
            Console.WriteLine($"R2a fn: {r2a.FirstName}  ln: {r2a.LastName}");
            Console.WriteLine(r2a.SayHello());
        }
    }
    public record Record1(string FirstName, string LastName);
    public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName); // inheritance works

    public class DiscoveryModel // security with records
    {
        public User1 LookupUser { get; set; }
        public int IncidentsFound { get; set; }
        public List<string> Incidents { get; set; }
    }

    public record Record2(string FirstName, string LastName)
    {
        private string _firstName = FirstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init { }
        }


        public string FullName { get => $"{FirstName} {LastName}"; }

        public string SayHello()
        {
            return $"Hello {FirstName}";
        }
    }

    public class Class1 // nearly identical to Record1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }
}
