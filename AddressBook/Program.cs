using System.Collections.Generic;
using System.IO;
using System.Text;
using BinaryTreeNode;

namespace AddressBook
{
    class Program
    {
        private const string AddressBookDataFile = "addressbook.txt";

        private static BinarySearchTree<string> addressBook;


        static void Main(string[] args)
        {
            addressBook = new BinarySearchTree<string>();

            List<string> addresses = ReadAddressbookData();

            for (int i = 0; i < addresses.Count; i++)
            {
                addressBook.Add(addresses[i]);
            }

        }

        private static List<string> ReadAddressbookData()
        {
            var nameList = new List<string>();
            var fileStream = new StreamReader(AddressBookDataFile, Encoding.UTF8);

            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                nameList.Add(line);
            }
            fileStream.Close();

            return nameList;
        }
    }
}
