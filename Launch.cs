using System;
using System.IO;
using System.Windows.Forms;
using VIK.Core;

namespace VIK
{
    public partial class Launch : Form
    {
        SpeechManager speechManager = new SpeechManager();

        public Launch()
        {
            InitializeComponent();
            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("No search pattern returns:");
            foreach (var fi in di.GetFiles("*.xml"))
            {
                cbxPerfiles.Items.Add(fi.Name);
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
        }
    }
}
