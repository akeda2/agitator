using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.DirectoryServices;

namespace fromAD
{
    public class machineExtractor
    {
        public machineExtractor(){}
        public machineExtractor(string domainName)
        {
            this.DomainName = domainName;
        }
            //string myDomain = @"LDAP://" + args[0];
        private string privDomainName;
        public string DomainName
        {
            set { privDomainName = value;}
            get { return privDomainName; }
        }
        public string[] GetEntries()
        {

            //string[] Entries = new string[10000];
            //DirectoryEntry entry = new DirectoryEntry("LDAP://adm");
            
            DirectoryEntry entry = new DirectoryEntry(DomainName);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = ("(objectClass=computer)");
            
            //char[] charsToTrim = new char[2];

            string charsToTrim = "CN=";

            //charsToTrim[0] = '\u004F';
            //charsToTrim[1] = 'U';
            //charsToTrim[2] = '\u003D';

            string[] Entries = new string[0];
            //SearchResult sRes = new SearchResult();
            
            //string[] Entries = new string[mySearcher.FindAll().Count];
            int e = 0;
            foreach (SearchResult resEnt in mySearcher.FindAll())
            {
                Entries;
                Entries[e] = resEnt.GetDirectoryEntry().Name.TrimStart(charsToTrim.ToCharArray()).ToString();
                e++;
                //Console.WriteLine(resEnt.GetDirectoryEntry().Name.TrimStart(charsToTrim.ToCharArray()).ToString());
            }
            return Entries;
            //Console.ReadKey();
    }}
}
