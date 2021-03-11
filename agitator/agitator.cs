using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Drawing;

//using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;

namespace agitator
{
    class agitator
    {
        /*public bool ImpersonateThis(string user, string domain, string passwd)
        {
            bool fail;
            
            bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
            LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                ref pExistingTokenHandle);

            return fail;
        }*/

        public static string GetNiceLabel()
        {
            /// Static method to create a nice text-label showing various machine-identifications
            /// 

            string niceLabel = "Running on: "
                    + System.Environment.UserDomainName + " \\ "
                    + System.Net.Dns.GetHostName().ToUpperInvariant() + ", "
                    + " " + System.Environment.OSVersion.ToString()
                    + " as user: " + System.Environment.UserName;
            return niceLabel;
        }
        
        public static string[] FillCombo(string textfile)
        {
            //Fills combo from textfile

            StreamReader sRead;// new StreamReader("combolines.txt");
            sRead = File.OpenText(textfile);

            string[] brokenCombo = sRead.ReadToEnd().Trim().Split('\n');
            //foreach (string r in brokenCombo) { brokenCombo; }
            for (int p = 0; p < brokenCombo.Length; p++)
            {
                brokenCombo[p] = brokenCombo[p].Trim();
            }
            sRead.Close();
            Array.Reverse(brokenCombo);
            ///usage:this.comboBox1.DataSource = brokenCombo;
            return brokenCombo;
        }
        public static string FillTextBoxFromTxtFile(string textfile)
        {
            string result = File.ReadAllText(textfile);
            return result;
        }
        public static void FillTxtFileFromTextBox(string textfile, string value)
        {
            File.WriteAllText(textfile, value);
        }

        public static string[] FillComboFromDir(string path)
        {
            string[] DirList = System.IO.Directory.GetFiles(path, @"*.*");
            return DirList;
        }

        public static string[] FillComboFromDirBat(string path)
        {
            string[] DirList = System.IO.Directory.GetFiles(path, @"*.bat");
            return DirList;
        }

        public static void FillFile(string textfile, string item)
        {
            string StringToCut = item;
            StreamWriter Saver; // = new StreamWriter("combolines.txt");
            Saver = File.AppendText(textfile);
            //Saver.NewLine = 
            Saver.WriteLine(StringToCut);
            Saver.Close();
        }
        public static string[] ItemsFromSeparators(string list)
        {
            string[] separatedList = list.Split(
                new[] { "\r\n", "\r", "\n", "," },
                StringSplitOptions.None
                );
            return separatedList;
        }

        public class Agitator
        {
            private string pathToPsexec = "c:\\pstools\\psexec.exe";

            public string PathToPsexec
            {
                get { return pathToPsexec; }
                set { pathToPsexec = value; }
            }
            private int delay = 0;
            public int Delay
            {
                get { return delay; }
                set { delay = value; }
            }

            public void ExecuteThisSelf(string[] machines, string[] args)
            {
                //Furure test...
                System.Diagnostics.Process glenn = new System.Diagnostics.Process();                
            }
            
            public void ExecuteThis(object[] objmachines, object[] objargs)
            {
                string[] machines = new string[objmachines.Length];

                for (int i = 0; i < objmachines.Length; i++)
                {
                    machines[i] = objmachines[i] as string;
                }
                string[] scripts = new string[objargs.Length];
                for (int i = 0; i < objargs.Length; i++)
                {
                    scripts[i] = objargs[i] as string;
                }
                this.ExecuteThis(machines, scripts);

                //RunThis.ExecuteThis(machines, scripts);

            }

            public void ExecuteThis(string[] machines, string[] args) ///Used for remote with PsExec.
            {
                foreach (string machine in machines)
                {
                    foreach (string arg in args)
                    {
                        System.Diagnostics.Process runObj = new System.Diagnostics.Process();
                        //string pathToPsexec = "c:\\pstools\\psexec.exe";
                        runObj.StartInfo.FileName = PathToPsexec;
                        //runObj.StartInfo.Arguments = "\\\\" + (string)machine + " -u  -p xxx " + "-c " + (string)arg;
                        runObj.StartInfo.Arguments = "\\\\" + (string)machine + (string)arg;
                        
                        runObj.Start();
                        System.Threading.Thread.Sleep(this.Delay);
                    }
                }
            }
            public void ExecuteThis(string[] args)///Several local
            {
                foreach (string arg in args)
                {
                    System.Diagnostics.Process runObj = new System.Diagnostics.Process();
                    
                    //string pathToPsexec = "c:\\pstools\\psexec.exe";
                    
                    ExecuteThis(arg);
                    
                    //runObj.StartInfo.FileName = PathToPsexec;
                    //runObj.StartInfo.Arguments = "\\\\" + (string)machine + " " + arg;
                }
            }
            public void ExecuteThis(string args)///One local
            {
                System.Diagnostics.Process RunThis = new System.Diagnostics.Process();

                string StringToCut = args;
                StreamWriter Saver; // = new StreamWriter("combolines.txt");
                Saver = File.AppendText("combolines.txt");
                //Saver.NewLine = 
                Saver.WriteLine(StringToCut);
                Saver.Close();

                string[] ArrayOfArguments = StringToCut.Split(' ');

                RunThis.StartInfo.FileName = ArrayOfArguments[0];

                StringBuilder glenn = new StringBuilder();
                for (int i = 1; i < ArrayOfArguments.Length; i++)
                {
                    glenn.Append(ArrayOfArguments[i]);
                }
                RunThis.StartInfo.Arguments = glenn.ToString();
                RunThis.Start();
            }
            
        }
        public class EditBox // : System.Web.UI.WebControls.TextBox
        {
            private string contents;
            public string Contents
            {
                get { return contents; }
                set { contents = value; }
            }
        }
    }
    public static class AppExtensions
    {
        public static void UncheckAllItems(this System.Windows.Forms.CheckedListBox clb)
        {
            while (clb.CheckedIndices.Count > 0)
                clb.SetItemChecked(clb.CheckedIndices[0], false);
        }
        public static void CheckAllItems(this System.Windows.Forms.CheckedListBox c1c)
        {
            for (int i = 0; i < c1c.Items.Count; i++)
            {
                c1c.SetItemChecked(i, true);
            }
        }
    }
}

