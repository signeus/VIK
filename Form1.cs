using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;


namespace VIK
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = null;
        bool activoComando = false;

        SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
        List<VoiceInfo> vocesInfo = new List<VoiceInfo>();

        public Form1()
        {
            InitializeComponent();

            foreach (InstalledVoice voice in _synthesizer.GetInstalledVoices())
            {
                vocesInfo.Add(voice.VoiceInfo);
            }
        }

        private void Rec_Click(object sender, EventArgs e)
        {
            if(_recognizer == null)
            {
                _recognizer = new SpeechRecognitionEngine();
                _recognizer.SetInputToDefaultAudioDevice();
                _recognizer.LoadGrammar(AbecedarioGrammar());  //new DictationGrammar() Por defecto
                                                                  //Diccionario personalizado MyGrammar()

                _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);

                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }

        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach(RecognizedWordUnit word in e.Result.Words)
            {
                activoComando = true;
                /*if (word.Text.Equals("VIK"))
                {
                    activoComando = true;
                }
                */
                if (activoComando)
                {
                    lbPalabrasReconocidas.Items.Add(word.Text);

                    double Volumen = 90;
                    double Rate = 0;

                    //_synthesizer.Volume = (int)Volumen;
                    //_synthesizer.Rate = (int)Rate;
                    //_synthesizer.Speak(word.Text);
                }

                if (!word.Text.Equals(""))
                {
                    foreach (char character in word.Text){
                        SendKeys.Send(character.ToString());
                    }
                }
            }
        }

        private static Grammar MyGrammar()
        {
            Grammar myGramatic = new Grammar(AppDomain.CurrentDomain.BaseDirectory + "//palabras.xml");
            myGramatic.Name = "Gramatica básica de palabras";
            return myGramatic;
        }

        private Grammar AbecedarioGrammar()
        {

            Grammar myGramatic = new Grammar(AppDomain.CurrentDomain.BaseDirectory + "//abecedario.xml");
            myGramatic.Name = "Abedecario simple en español";
            return myGramatic;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_recognizer != null)
            {
                _recognizer.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
                _recognizer = null;
            }
        }
    }
}
