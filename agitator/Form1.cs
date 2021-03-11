using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using agitator;

namespace agitator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.label5.Text = agitator.GetNiceLabel();
            this.comboBox1.DataSource = agitator.FillCombo("combolines.txt");
            
            this.checkedListBox2.Items.AddRange(agitator.FillComboFromDir(".\\scripts"));

            //this.checkedListBox2.Items.AddRange(agitator.FillCombo("scripts.txt"));

            this.checkedListBox1.Items.AddRange(agitator.FillCombo("machines.txt"));

            this.comboBox2.DataSource = agitator.FillCombo("users.txt");

            this.textBox1.Text = agitator.FillTextBoxFromTxtFile(@".\pathToPsT.txt");

            this.checkedListBox1.AllowDrop = true;
            this.checkedListBox1.DragEnter += checkedListBox1_DragEnter;
            this.checkedListBox1.DragDrop += checkedListBox1_DragDrop;
        }

        



        private void button2_Click(object sender, EventArgs e)
        {
            /*System.Diagnostics.Process RunThis = new Process();
            StringBuilder PathToCut = new StringBuilder();

            string StringToCut = comboBox1.Text;

            string[] ArrayOfArguments = StringToCut.Split(' ');

            RunThis.StartInfo.FileName = ArrayOfArguments[0];
            //string FinalArgs;

            StringBuilder glenn = new StringBuilder();
            for (int i = 1; i < ArrayOfArguments.Length; i++)
            {

                glenn.Append(ArrayOfArguments[i]);
                //ArrayOfArguments.ToString().CopyTo(FinalArgs, i);
            }
            RunThis.StartInfo.Arguments = glenn.ToString(); //ArrayOfArguments[1-ArrayOfArguments.Length];
            RunThis.Start();*/

            agitator.FillFile("users.txt", comboBox2.Text);
            agitator.FillTxtFileFromTextBox(@".\pathToPsT.txt", this.textBox1.Text);
            agitator.Agitator RunThis = new agitator.Agitator();
            //string[] machines = checkedListBox1.SelectedItems.ToString().Split('\n');
            //string[] machines = checkedListBox1.CheckedItems.ToString().Split('\n');
            
            //string[] scripts = checkedListBox2.SelectedItems.ToString().Split('\n');
            //string[] scripts = checkedListBox2.CheckedItems.ToString().Split('\n');
            //agitator.Agitator.Stone myStone = new agitator.Agitator.Stone(machines,scripts);
            //RunThis.ExecuteThis(myStone.MachineRock, myStone.ScriptRock);

            //for(int p = 0; p < checkedListBox1.SelectedItems.Count; p++)

            
            ///static obj-to-string
            string[] machines = new string[checkedListBox1.CheckedItems.Count];

            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++ )
            {
                machines[i] = checkedListBox1.CheckedItems[i] as string;
            }
            string[] scripts = new string[checkedListBox2.CheckedItems.Count];
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                if (checkBox1.Checked == true)
                {
                    scripts[i] = " -u " + comboBox2.Text + " -p " + maskedTextBox1.Text + " -i -c -f " + checkedListBox2.CheckedItems[i] as string;
                }
                else {
                    scripts[i] = " -u " + comboBox2.Text + " -p " + maskedTextBox1.Text + " -c -f " + checkedListBox2.CheckedItems[i] as string;
                }
            }

            //RunThis.PathToPsexec = ".\\psexec.exe"; //old default
            RunThis.PathToPsexec = this.textBox1.Text + @"\psexec.exe";
            RunThis.ExecuteThis(machines, scripts);

            //RunThis.ExecuteThis(checkedListBox1.CheckedItems, checkedListBox2.CheckedItems);

            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            agitator.Agitator SingleRun = new agitator.Agitator();
            SingleRun.ExecuteThis(this.comboBox1.SelectedItem.ToString());
            //SingleRun.ExecuteThis(sender.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Edit script
            agitator.Agitator editor = new agitator.Agitator();
            editor.ExecuteThis("notepad " + checkedListBox2.SelectedItem.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Refresh after update
            agitator.FillTxtFileFromTextBox(@".\pathToPsT.txt", this.textBox1.Text);
            Application.Restart();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Edit machines
            agitator.Agitator editorMachines = new agitator.Agitator();
            editorMachines.ExecuteThis("notepad machines.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ///Add script
            ///simply by editing scripts.txt
            agitator.Agitator editor = new agitator.Agitator();
            editor.ExecuteThis("explorer .\\scripts");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //agitator.Agitator infoRun = new agitator.Agitator();
            //infoRun.ExecuteThis(this.textBox1.Text + @"\psinfo.exe " + @"\\" + this.checkedListBox1.SelectedItem.ToString());

            System.Diagnostics.Process infoRun = new System.Diagnostics.Process();
            infoRun.StartInfo.FileName = "cmd";
            infoRun.StartInfo.Arguments = "/K " + @"""" + this.textBox1.Text + "\\psinfo.exe" + @""" " + "\\\\" + this.checkedListBox1.SelectedItem.ToString() + " -d" + " -u " + comboBox2.Text + " -p " + maskedTextBox1.Text;
            infoRun.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkedListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
                }
        private void checkedListBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                //checkedListBox1.Items.Add(file);
                checkedListBox1.Items.AddRange(agitator.FillCombo(file));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkedListBox1.UncheckAllItems();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            checkedListBox1.CheckAllItems();
        }
    }
}