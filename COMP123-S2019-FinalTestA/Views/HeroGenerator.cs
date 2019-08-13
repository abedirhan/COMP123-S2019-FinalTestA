using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * STUDENT NAME: Ayhan SAGLAM
 * STUDENT ID:301059969
 * DESCRIPTION: This is the Here Generator Form
 */

namespace COMP123_S2019_FinalTestA.Views
{
    public partial class HeroGenerator : MasterForm
    {
        public static List<string> NameList = new List<string>();
        public static List<string> LastNameList = new List<string>();
        public HeroGenerator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// First Name reading
        /// </summary>
        /// <param name="fileName"></param>
        static void ReadName(string fileName)
        {
            using (StreamReader nameReader = new StreamReader(File.Open(fileName, FileMode.Open)))
            {
                var randomGenName = nameReader.ReadLine();
                while (randomGenName != null)
                {
                    NameList.Add(randomGenName);
                    randomGenName = nameReader.ReadLine();
                }

                //cleanup
                nameReader.Close();
                nameReader.Dispose();
            }
        }
        /// <summary>
        /// last name reading
        /// </summary>
        /// <param name="fileName"></param>
        static void ReadLastName(string fileName)
        {
            using (StreamReader lastNameReader = new StreamReader(File.Open(fileName, FileMode.Open)))
            {
                var randomGenLastName = lastNameReader.ReadLine();
                while (randomGenLastName != null)
                {
                    LastNameList.Add(randomGenLastName);
                    randomGenLastName = lastNameReader.ReadLine();
                }

                //cleanup
                lastNameReader.Close();
                lastNameReader.Dispose();
            }

        }
        /// <summary>
        /// Generate first and last name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            // Random Name Generator
            ReadName(@"../../Data/firstNames.txt");
            Random random1 = new Random();
            var nameCount = random1.Next(NameList.Count);
            FirstNameDataLabel.Text = NameList[nameCount];

            //Random Last Name Generator
            ReadLastName(@"../../Data/lastNames.txt");
            Random random2 = new Random();
            var lastNameCount = random2.Next(LastNameList.Count);
            LastNameDataLabel.Text = LastNameList[lastNameCount];
        }

        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HeroGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void HeroGenerator_Activated(object sender, EventArgs e)
        {


        }



        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            ChracterOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ChracterOpenFileDialog.FileName = "Character_Sheet.txt";
            ChracterOpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            var result = ChracterOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                // open file stream to read
                using (StreamReader inputStream = new StreamReader(File.Open(ChracterOpenFileDialog.FileName, FileMode.Open)))
                {
                    // read stuff from the file into the Character Sheet object
                    var input = inputStream.ReadLine();
                    while (input != null)
                    {
                        OpenDeneme.Items.Add(input);
                        input = inputStream.ReadLine();

                    }
                    //cleanup
                    inputStream.Close();
                    inputStream.Dispose();
                }
            }
        }
        /// <summary>
        /// Open Binary File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BinaryOpenToolStripButton_Click(object sender, EventArgs e)
        {
            // configuration for openFileDialog
            ChracterOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ChracterOpenFileDialog.FileName = "Character_Sheet.dat";
            ChracterOpenFileDialog.Filter = "Binary Files (*.dat)|*.dat|All Files (*.*)|*.*";

            var result = ChracterOpenFileDialog.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                // open file stream to read
                using (BinaryReader inputStream = new BinaryReader(File.Open(ChracterOpenFileDialog.FileName, FileMode.Open)))
                {
                    // read stuff from the file into the Character Sheet object
                    var input=inputStream.ReadString();
                    while (input != null)
                    {
                        OpenDeneme.Items.Add(input);
                        input = inputStream.ReadString();

                    }
                    //cleanup
                    inputStream.Close();
                    inputStream.Dispose();
                }
            }
        }
        /// <summary>
        /// Save text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            ChracterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ChracterSaveFileDialog.FileName = "Character_Sheet.txt";
            ChracterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            var result = ChracterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                using (StreamWriter outputstream = new StreamWriter(File.Open(ChracterSaveFileDialog.FileName, FileMode.Create)))
                {
                    outputstream.WriteLine("Deneme Basarili");
                    outputstream.WriteLine("Bunu Texte Yazdik");
                    outputstream.WriteLine("Reading Details");

                    //Cleanup
                    outputstream.Close();
                    outputstream.Dispose();
                }

                

            }

            MessageBox.Show("File Saved Successfully!", "Saving...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        /// <summary>
        /// Binary save file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BinarySaveToolStripButton_Click(object sender, EventArgs e)
        {
            ChracterSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ChracterSaveFileDialog.FileName = "Character_Sheet.txt";
            ChracterSaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            var result = ChracterSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                using (BinaryWriter outputstream = new BinaryWriter(File.Open(ChracterSaveFileDialog.FileName, FileMode.Create)))
                {
                    outputstream.Write("Deneme Basarili");
                    outputstream.Write("Bunu Texte Yazdik");
                    outputstream.Write("Reading Details");
                    //Cleanup
                    outputstream.Close();
                    outputstream.Dispose();
                }

            }

            MessageBox.Show("File Saved Successfully!", "Saving...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

