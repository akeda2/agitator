using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;


namespace adTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.GetLength(1) < 1 )//.ToString().Trim() == string.Empty)// == String.Empty)
            {
                Console.Write("Domain: ");
                args[0] = Console.ReadLine().Trim();
            }
            string myDomain = @"LDAP://" + args[0];
            
            //DirectoryEntry entry = new DirectoryEntry("LDAP://adm");
            DirectoryEntry entry = new DirectoryEntry(myDomain);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = ("(objectClass=computer)");
            //char[] charsToTrim = new char[2];

            string charsToTrim = "CN=";

            //charsToTrim[0] = '\u004F';
            //charsToTrim[1] = 'U';
            //charsToTrim[2] = '\u003D';

            foreach (SearchResult resEnt in mySearcher.FindAll())
            {
                Console.WriteLine(resEnt.GetDirectoryEntry().Name.TrimStart(charsToTrim.ToCharArray()).ToString());
            }
            Console.ReadKey();
        }
    }
}