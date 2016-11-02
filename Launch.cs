using System;
using System.Windows.Forms;
using System.Collections.Generic;
using VIK.Core;
using VIK.Core.XmlModule;
using VIK.Core.FileModule;
using VIK.Core.Entities;

namespace VIK
{
    public partial class Launch : Form
    {
        SpeechManager speechManager = new SpeechManager();

        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        List<FileEntity> fileList = new List<FileEntity>();

        public Launch()
        {
            InitializeComponent();

            
            FileManager fileManager = new FileManager();
            dictionary = fileManager.RecoverFileDictionary();
            fileList = fileManager.RecoverFileList();

            FillProfiles();
            
            speechManager.StartSpeech();
        }

        private void FillProfiles()
        {
            foreach(var file in fileList)
            {
                cbxPerfiles.Items.Add(file.Filename);
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
            string name = comboBox.SelectedItem.ToString();

            FileEntity entity = FindFileSelected(name);

            speechManager.RefreshGrammarWithWords(entity.Name);
            XmlManager xmlManager = new XmlManager();
            xmlManager.LoadFileByDictionary(dictionary, entity.Name);
            List<CommandEntity> items = xmlManager.RecoverItems();
        }

        private FileEntity FindFileSelected(string name)
        {
            foreach(var file in fileList)
            {
                if (file.Filename.Equals(name))
                    return file;
            }
            return null;
        }
        
        private void CreateFileXML()
        {
            XmlManager xml = new XmlManager();
            xml.CreateXml("test1.xml");
        }
    }
}
