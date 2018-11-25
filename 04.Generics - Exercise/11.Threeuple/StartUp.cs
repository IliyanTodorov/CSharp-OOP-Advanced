namespace Threeuple
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] personInfo = Console.ReadLine().Split().ToArray();

            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = personInfo[3];

            string[] beerInfo = Console.ReadLine().Split().ToArray();

            string name = beerInfo[0];
            int liters = int.Parse(beerInfo[1]);

            bool isDrunk = beerInfo[2] == "drunk";
            

            string[] bankInfo = Console.ReadLine().Split().ToArray();

            string user = bankInfo[0];
            double accountBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];


            var personTuple = new SpecialThreeuple<string, string, string>(fullName, address, town);
            var beerTuple = new SpecialThreeuple<string, int, bool>(name, liters, isDrunk);
            var specialTuple = new SpecialThreeuple<string, double, string>(user, accountBalance, bankName);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTuple);
        }
    }
}
