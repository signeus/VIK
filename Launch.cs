using System;
using System.Windows.Forms;
using System.Collections.Generic;
using VIK.Core;
using VIK.Core.XmlModule;
using VIK.Core.FileModule;

namespace VIK
{
    public partial class Launch : Form
    {
        SpeechManager speechManager = new SpeechManager();
        
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public Launch()
        {
            InitializeComponent();

            FileManager fileManager = new FileManager();
            dictionary = fileManager.RecoverFileDictionary();

            FillProfiles();
            
            speechManager.StartSpeech();
        }

        private void FillProfiles()
        {
            foreach(var name in dictionary)
            {
                cbxPerfiles.Items.Add(name.Key);
            }
        }
        private void Rec_Click(object sender, EventArgs e)
        {
            speechManager.StartSpeech();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            speechManager.StopSpeech();
        }

        private void cbxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string fileName = comboBox.SelectedItem.ToString();
            speechManager.RefreshGrammarWithWords(fileName);
            XmlManager xmlManager = new XmlManager();
            xmlManager.LoadFileByDictionary(dictionary, fileName);
            List<string> items = xmlManager.RecoverItems();
        }
        
    }
}
