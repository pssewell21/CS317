using System;
using System.Collections.Generic;

namespace CS317Program.Operations.TelephoneDirectorySearch
{
    class TelephoneDirectorySearch : BaseClass
    {
        private List<TelephoneDirectoryEntry> _directory;
        
        public TelephoneDirectorySearch()
        {
            _directory = new List<TelephoneDirectoryEntry>();

            Console.Write("\nEnter the number of directory entries to be created (Up to 9999): ");
            var numEntries = GetIntegerInput();

            try
            {
                var result = GenerateEntryList(numEntries);
                _directory.AddRange(result);
                _directory.Sort((x, y) => x.GetName().CompareTo(y.GetName()));
            }
            catch (Exception e)
            {
                HandleException(e);
            }
        }

        public void Run()
        {
            PrintDirectory();

            Console.Write("\nEnter the name of the person to look up: ");
            var input = Console.ReadLine();

            // Implementation of binary search
            var l = 0;
            var r = _directory.Count - 1;
            var dir = _directory.ToArray();
            string phoneNumber = "";
            bool entryFound = false;

            while (l <= r)
            {
                var m = (l + r) / 2;

                if (input.Equals(dir[m].GetName()))
                {
                    phoneNumber = dir[m].GetPhoneNumber();
                    entryFound = true;
                    break;
                }
                else if (input.CompareTo(dir[m].GetName()) < 0)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            if (entryFound)
            {
                Console.WriteLine("\nThe phone number for {0} is {1}", input, phoneNumber);
            }
            else
            {
                Console.WriteLine("\nEntry not found for {0}", input);
            }
        }

        private List<TelephoneDirectoryEntry> GenerateEntryList(int numEntries)
        {
            var list = new List<TelephoneDirectoryEntry>();
                
            var firstNameBase = "John";
            var lastName = "Doe";
            var phoneNumberBase = "931-455-";

            for (int i = 1; i <= numEntries && i <= 9999; i++)
            {
                var firstName = string.Format("{0}{1}", firstNameBase, i);
                var name = string.Format("{0} {1}", firstName, lastName);
                string phoneNumber;

                if (i < 10)
                {
                    phoneNumber = string.Format("{0}000{1}", phoneNumberBase, i);
                }
                else if (i >= 10 && i < 100)
                {
                    phoneNumber = string.Format("{0}00{1}", phoneNumberBase, i);
                }
                else if (i >= 100 && i < 1000)
                {
                    phoneNumber = string.Format("{0}0{1}", phoneNumberBase, i);
                }
                else if (i >= 1000 && i < 10000)
                {
                    phoneNumber = string.Format("{0}{1}", phoneNumberBase, i);
                }
                else
                {
                    throw new Exception("Something went wrong");
                }

                list.Add(new TelephoneDirectoryEntry(name, phoneNumber));
            }

            return list;
        }

        private void PrintDirectory()
        {
            Console.WriteLine("\nDirectory contents:");

            foreach (var item in _directory)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
