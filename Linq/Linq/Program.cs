namespace Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            MethodSyntaxWithObject();

        }

        public static void QuerySyntax()
        {
            // inisialisasi --- kondisi --- seleksi

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 ,10};
            var filteredGreaterThanFive = 
                from number in numbers 
                where number > 5
                select number;

            var oddNumbers =
                from number in numbers
                where number % 2 == 1
                select number;

            var evenNumbers =
                from number in numbers
                where number % 2 == 1
                select number;


            foreach (var i in evenNumbers) {
                Console.WriteLine(i);
            }

        }

        public static void QuerySyntaxWithObject()
        {
            // inisialisasi --- kondisi --- seleksi

            var people = new List<Person> {
                new(1, "tes1", 1),
                new(2, "tes2", 2),
                new(3, "tes3", 3),
                new(4, "tes4", 4),
                new(5, "tes5", 5),
            };

            var allPerson =
                from person in people
                orderby person.getId()
                select person.getName();

            var findTes4 =
                from person in people
                where person.getName() == "tes4"
                select person.getName();


            foreach (var i in findTes4)
            {
                Console.WriteLine(i);
            }

        }

        public static void MethodSyntaxWithObject()
        {
            // inisialisasi --- kondisi --- seleksi

            var people = new List<Person> {
                new(1, "tes1", 1),
                new(2, "tes2", 2),
                new(3, "tes3", 3),
                new(4, "tes4", 4),
                new(5, "tes5", 5),
            };

            var allPerson = people.OrderBy(p => p.getId()).Select(p => p.getName());

            var findtest4 = people.Where(p => p.getName() == "tes4").OrderBy(p => p.getId()).Select(p => p.getName());

            foreach (var i in findtest4)
            {
                Console.WriteLine(i);
            }

        }

        public static void MethodSyntax()
        {
            // inisialisasi --- kondisi --- seleksi

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var filteredGreaterThanFive = numbers.Where(i => i > 5);

            var oddNumbers = numbers.Where(i => i % 2 == 1).OrderByDescending( i => i);

            var evenNumbers = numbers.Where(i => i % 2 == 0).OrderByDescending(i => i);

            foreach (var i in evenNumbers)
            {
                Console.WriteLine(i);
            }


        }
    }
}