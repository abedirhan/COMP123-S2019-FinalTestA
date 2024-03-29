﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using COMP123_S2019_FinalTestA.Objects;

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
        public static List<string> PowerList = new List<string>();

        Random random = new Random();

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
        /// Generate first and last name when you click generate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            LoadNames();

        }

        /// <summary>
        /// Method generate first name and last name
        /// </summary>
        private void LoadNames()
        {
            // Random Name Generator
            ReadName(@"../../Data/firstNames.txt");

            var nameCount = random.Next(NameList.Count);
            Program.chracter.FirstName = NameList[nameCount];
            FirstNameDataLabel.Text = Program.chracter.FirstName;
            


            //Random Last Name Generator
            ReadLastName(@"../../Data/lastNames.txt");

            var lastNameCount = random.Next(LastNameList.Count);

            Program.chracter.LastName = LastNameList[lastNameCount];
            LastNameDataLabel.Text = Program.chracter.LastName;
            

            Program.chracter.HeroName = Program.chracter.FirstName + " " + Program.chracter.LastName;

        }

        /// <summary>
        /// Read Power
        /// </summary>
        /// <param name="fileName"></param>
        static void LoadPower(string fileName)
        {
            using (StreamReader powerReader = new StreamReader(File.Open(fileName, FileMode.Open)))
            {
                var randomPower = powerReader.ReadLine();
                while (randomPower != null)
                {
                    PowerList.Add(randomPower);
                    randomPower = powerReader.ReadLine();
                }

                //cleanup
                powerReader.Close();
                powerReader.Dispose();
            }
        }

        /// <summary>
        /// Load Power
        /// </summary>
        private void GenerateRandomPowers()
        {
            // Random Power Generator

            var randomIndex = random.Next(PowerList.Count);

            PowerOneDataLabel.Text = PowerList[randomIndex];
            randomIndex = random.Next(PowerList.Count);
            PowerTwoDataLabel.Text = PowerList[randomIndex];
            randomIndex = random.Next(PowerList.Count);
            PowerThreeDataLabel.Text = PowerList[randomIndex];
            randomIndex = random.Next(PowerList.Count);
            PowerFourDataLabel.Text = PowerList[randomIndex];
            Hero.Powers.Add(PowerOneDataLabel.Text);
            Hero.Powers.Add(PowerTwoDataLabel.Text);
            Hero.Powers.Add(PowerThreeDataLabel.Text);
            Hero.Powers.Add(PowerFourDataLabel.Text);
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

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            ChracterOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            ChracterOpenFileDialog.FileName = "Character_Sheet.txt";
            ChracterOpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            var result = ChracterOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                // open file stream to read
                using (StreamReader inputStream =
                    new StreamReader(File.Open(ChracterOpenFileDialog.FileName, FileMode.Open)))
                {
                    // read stuff from the file into the Character Sheet object
                    var input = inputStream.ReadLine();
                    while (input != null)
                    {

                        CsAgilityDataLabel.Text = inputStream.ReadLine();
                        CsFightingDataLabel.Text = inputStream.ReadLine();
                        CsStrenghtDataLabel.Text = inputStream.ReadLine();
                        CsEnduranceDataLabel.Text = inputStream.ReadLine();
                        CsReasonDataLabel.Text = inputStream.ReadLine();
                        CsInitutionDataLabel.Text = inputStream.ReadLine();
                        CsPsycheDataLabel.Text = inputStream.ReadLine();
                        CsPopularityDataLabel.Text = inputStream.ReadLine();
                        CsHeroNameDataLabel.Text = inputStream.ReadLine();
                        
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
                using (StreamWriter outputstream =
                    new StreamWriter(File.Open(ChracterSaveFileDialog.FileName, FileMode.Create)))
                {
                   outputstream.WriteLine(CsAgilityDataLabel.Text = Program.chracter.Agility);
                   outputstream.WriteLine(CsFightingDataLabel.Text = Program.chracter.Fighting);
                   outputstream.WriteLine(CsStrenghtDataLabel.Text = Program.chracter.Strength);
                   outputstream.WriteLine(CsEnduranceDataLabel.Text = Program.chracter.Endurance);
                   outputstream.WriteLine(CsReasonDataLabel.Text = Program.chracter.Reason);
                   outputstream.WriteLine(CsInitutionDataLabel.Text = Program.chracter.Intuition);
                   outputstream.WriteLine(CsPsycheDataLabel.Text = Program.chracter.Psyche);
                   outputstream.WriteLine(CsPopularityDataLabel.Text = Program.chracter.Popularity);
                   outputstream.WriteLine(CsHeroNameDataLabel.Text = Program.chracter.HeroName);
                    foreach (var a in Hero.Powers)
                    {
                       outputstream.WriteLine(CsAllPowerList.Items.Add(a));
                    }



                    //Cleanup
                    outputstream.Close();
                    outputstream.Dispose();
                }

            }

            MessageBox.Show("File Saved Successfully!", "Saving...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            LoadAbility();

        }

        private void LoadAbility()
        {
            Program.chracter.Agility = random.Next(10, 50 + 1).ToString();
            Program.chracter.Strength = random.Next(10, 50 + 1).ToString();
            Program.chracter.Endurance = random.Next(10, 50 + 1).ToString();
            Program.chracter.Reason = random.Next(10, 50 + 1).ToString();
            Program.chracter.Intuition = random.Next(10, 50 + 1).ToString();
            Program.chracter.Psyche = random.Next(10, 50 + 1).ToString();
            Program.chracter.Popularity = random.Next(10, 50 + 1).ToString();
            Program.chracter.Fighting = random.Next(10, 50 + 1).ToString();


            AgilityDataLabel.Text = Program.chracter.Agility;
            StrengthDataLabel.Text = Program.chracter.Strength;
            EnduranceDataLabel.Text = Program.chracter.Endurance;
            ReasonDataLabel.Text = Program.chracter.Reason;
            IntuitionDataLabel.Text = Program.chracter.Intuition;
            PsycheDataLabel.Text = Program.chracter.Psyche;
            PopularityDataLabel.Text = Program.chracter.Popularity;
            FightingDataLabel.Text = Program.chracter.Fighting;


            //
            //            Program.chracter.Agility = AgilityDataLabel.Text;
            //            Program.chracter.Strength = StrengthDataLabel.Text;
            //            Program.chracter.Endurance = EnduranceDataLabel.Text;
            //            Program.chracter.Reason = ReasonDataLabel.Text;
            //            Program.chracter.Intuition = IntuitionDataLabel.Text;
            //            Program.chracter.Psyche = PsycheDataLabel.Text;
            //            Program.chracter.Popularity = PopularityDataLabel.Text;
            //            Program.chracter.Fighting = FightingDataLabel.Text;


        }

        private void HeroGenerator_Load(object sender, EventArgs e)
        {
            LoadNames();
            LoadAbility();
            LoadPower(@"../../Data/powers.txt");
            GenerateRandomPowers();
            LoadChracterSheet();
        }

        /// <summary>
        /// This Method Load Chracter Sheet
        /// </summary>
        private void LoadChracterSheet()
        {
            CsAgilityDataLabel.Text = Program.chracter.Agility;
            CsFightingDataLabel.Text = Program.chracter.Fighting;
            CsStrenghtDataLabel.Text = Program.chracter.Strength;
            CsEnduranceDataLabel.Text = Program.chracter.Endurance;
            CsReasonDataLabel.Text = Program.chracter.Reason;
            CsInitutionDataLabel.Text = Program.chracter.Intuition;
            CsPsycheDataLabel.Text = Program.chracter.Psyche;
            CsPopularityDataLabel.Text = Program.chracter.Popularity;
            CsHeroNameDataLabel.Text = Program.chracter.HeroName;
            foreach (var a in Hero.Powers)
            {
                CsAllPowerList.Items.Add(a);
            }
        }

        private void GeneratePower_Click(object sender, EventArgs e)
        {
            GenerateRandomPowers();

        }

        private void Clear()
        {
            CsAgilityDataLabel.Text = "";
            CsFightingDataLabel.Text = "";
            CsStrenghtDataLabel.Text = "";
            CsEnduranceDataLabel.Text = "";
            CsReasonDataLabel.Text = "";
            CsInitutionDataLabel.Text = "";
            CsPsycheDataLabel.Text = "";
            CsPopularityDataLabel.Text = "";
            CsHeroNameDataLabel.Text = "";
            CsAllPowerList.ClearSelected();
            FirstNameDataLabel.Text = "";
            LastNameDataLabel.Text = "";

        }
    }
}

