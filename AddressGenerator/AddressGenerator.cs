using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddressGenerator
{
    class AddressGenerator
    {
        private List<string> firstNames;
        private List<string> lastNames;
        private List<string> addressList;

        private Random rng = new Random();

        private const int DefaultSize = 900;

        private const string FirstNamesFile = "fornamn.txt";
        private const string LastNamesFile = "efternamn.txt";

        static void Main(string[] args)
        {
            var addressGenerator = new AddressGenerator();
            addressGenerator.GenerateAddresses(DefaultSize);
            Console.WriteLine(addressGenerator);
            addressGenerator.SaveToFile("addressbook.txt");
        }

        private void GenerateAddresses(int amount)
        {
            firstNames = ReadNamesFromFile(FirstNamesFile);
            lastNames = ReadNamesFromFile(LastNamesFile);
            addressList = new List<string>();

            for (int i = 0; i < amount; i++)
            {
                string firstName = firstNames[rng.Next(firstNames.Count)];
                string lastName = lastNames[rng.Next((lastNames.Count))];
                string phone = GeneratePhoneNumber();

                addressList.Add($"{firstName} {lastName} ({phone})");
            }

            //addressList.Sort();
        }

        private List<string> ReadNamesFromFile(string fileName)
        {
            var nameList = new List<string>();
            var fileStream = new StreamReader(fileName, Encoding.Default);

            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                string[] words = line.Split(' ');
                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        nameList.Add(word);
                    }
                }
            }
            fileStream.Close();

            return nameList;
        }

        private string GeneratePhoneNumber()
        {
            string prefix = "07";
            int number = rng.Next(100000000);

            return prefix + number.ToString("00-00 00 00");
        }

        public void SaveToFile(string fileName)
        {
            var fileStream = new StreamWriter(fileName);
            foreach (string person in addressList)
            {
                fileStream.WriteLine(person);
            }
            fileStream.Close();
        }

        public override string ToString()
        {
            string str = "";
            foreach (string person in addressList)
            {
                str += person + Environment.NewLine;
            }

            str += $"Size: {addressList.Count}";
            return str;
        }
    }
}
